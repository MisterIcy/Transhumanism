using SDLTooSharp.Bindings.SDL2;
using Transhumanism.Engine.Common;
using Transhumanism.Engine.Events.Display;
using Transhumanism.Engine.Events.Publishers;
using Transhumanism.Engine.Events.Subscribers;
using Transhumanism.Exceptions.Video.Display;

namespace Transhumanism.Engine.Video;

public class Display : ISubscriber
{
    public int DisplayId { get; }

    /// <summary>
    /// Gets the name of the display
    /// </summary>
    public string Name => SDL.SDL_GetDisplayName(DisplayId);

    /// <summary>
    /// Gets the display's DPI information
    /// </summary>
    /// <exception cref="UnableToGetDPIException">Thrown if we cannot get DPI information for the display</exception>
    public DPI Dpi => new DPI(DisplayId);

    /// <summary>
    /// Gets the display's current mode
    /// </summary>
    /// <exception cref="UnableToGetCurrentDisplayModeException">Thrown if we cannot get the current display mode</exception>
    public DisplayMode CurrentMode
    {
        get {
            int result = SDL.SDL_GetCurrentDisplayMode(DisplayId, out var mode);
            if ( result != 0 )
            {
                throw new UnableToGetCurrentDisplayModeException(DisplayId);
            }

            return new DisplayMode(mode);
        }
    }

    /// <summary>
    /// Gets the display's desktop mode
    /// </summary>
    /// <exception cref="UnableToGetDesktopDisplayModeException">Thrown if we cannot get the desktop display mode</exception>
    public DisplayMode DesktopMode
    {
        get {
            int result = SDL.SDL_GetDesktopDisplayMode(DisplayId, out var mode);
            if ( result != 0 )
            {
                throw new UnableToGetDesktopDisplayModeException(DisplayId);
            }

            return new DisplayMode(mode);
        }
    }

    /// <summary>
    /// Gets the number of supported display modes by the display
    /// </summary>
    /// <exception cref="UnableToGetNumberOfDisplayModesException">Thrown if we cannot get the number of display modes</exception>
    public int NumDisplayModes
    {
        get {
            int result = SDL.SDL_GetNumDisplayModes(DisplayId);
            if ( result < 1 )
            {
                throw new UnableToGetNumberOfDisplayModesException(DisplayId);
            }

            return result;
        }
    }

    /// <summary>
    /// Gets a list of supported display modes
    /// </summary>
    /// <exception cref="UnableToGetDisplayModeException">Thrown if we cannot get a particular display mode</exception>
    /// <exception cref="UnableToGetNumberOfDisplayModesException">Throw if we cannot get the number of display modes</exception>
    public List<DisplayMode> DisplayModes
    {
        get {
            int numDispModes = NumDisplayModes;
            List<DisplayMode> modes = new List<DisplayMode>(numDispModes);

            for ( int i = 0; i < numDispModes; i++ )
            {
                int result = SDL.SDL_GetDisplayMode(DisplayId, i, out var mode);
                if ( result != 0 )
                {
                    throw new UnableToGetDisplayModeException(DisplayId, i);
                }

                modes.Add(new DisplayMode(mode));
            }

            return modes;
        }
    }

    /// <summary>
    /// Gets the display's orientation
    /// </summary>
    public DisplayOrientation Orientation => (DisplayOrientation)SDL.SDL_GetDisplayOrientation(DisplayId);

    /// <summary>
    /// Gets the number of displays which are attached to the system
    /// </summary>
    /// <exception cref="NoDisplaysFoundException">Thrown in no displays were found</exception>
    public static int Count
    {
        get {
            int result = SDL.SDL_GetNumVideoDisplays();
            if ( result < 0 )
            {
                throw new NoDisplaysFoundException();
            }

            return result;
        }
    }

    public Display(int displayId)
    {
        DisplayId = displayId;
        EventPublisher.GetInstance().Subscribe(this);
    }

    ~Display()
    {
        EventPublisher.GetInstance().Unsubscribe(this);
    }

    public event EventHandler<DisplayConnectedEventArgs>? Connected;
    public event EventHandler<DisplayDisconnetedEventArgs>? Disconnected;
    public event EventHandler<DisplayOrientationChangedEventArgs>? OrientationChanged;

    protected virtual void OnConnected(DisplayConnectedEventArgs args)
    {
        Connected?.Invoke(this, args);
    }

    protected virtual void OnDisconnected(DisplayDisconnetedEventArgs args)
    {
        Disconnected?.Invoke(this, args);
    }

    protected virtual void OnOrientationChnged(DisplayOrientationChangedEventArgs args)
    {
        OrientationChanged?.Invoke(this, args);
    }

    public static Display GetDisplayOnPoint(Point2 point)
    {
        int result = SDL.SDL_GetPointDisplayIndex((SDL.SDL_Point)point);
        if ( result < 0 )
        {
            throw new NoDisplayForPointException(point);
        }

        return new Display(result);
    }

    public void Update(SDL.SDL_Event ev)
    {
        if ( ev.Type != (uint)SDL.SDL_EventType.SDL_DISPLAYEVENT || ev.Display.Display != (uint)DisplayId )
        {
            return;
        }

        switch ( ev.Display.Event )
        {
            case (byte)SDL.SDL_DisplayEventID.SDL_DISPLAYEVENT_CONNECTED:
                OnConnected(new DisplayConnectedEventArgs(ev));
                break;
            case (byte)SDL.SDL_DisplayEventID.SDL_DISPLAYEVENT_DISCONNECTED:
                OnDisconnected(new DisplayDisconnetedEventArgs(ev));
                break;
            case (byte)SDL.SDL_DisplayEventID.SDL_DISPLAYEVENT_ORIENTATION:
                OnOrientationChnged(new DisplayOrientationChangedEventArgs(ev));
                break;
        }
    }

    public Rectangle Bounds
    {
        get {
            int result = SDL.SDL_GetDisplayBounds(DisplayId, out var rect);
            if ( result != 0 )
            {
                throw new UnableToGetBoundsException(DisplayId);
            }

            return (Rectangle)rect;
        }
    }

    public Rectangle UsableBounds
    {
        get {
            int result = SDL.SDL_GetDisplayUsableBounds(DisplayId, out var rect);
            if ( result != 0 )
            {
                throw new UnableToGetUsableBoundsException(DisplayId);
            }

            return (Rectangle)rect;
        }
    }
}
