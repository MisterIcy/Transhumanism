using SDLTooSharp.Bindings.SDL2;
using Transhumanism.Engine.Common;
using Transhumanism.Engine.Events.Publishers;
using Transhumanism.Engine.Events.Subscribers;
using Transhumanism.Engine.Events.Window;
using Transhumanism.Exceptions.Video.Window;

namespace Transhumanism.Engine.Video;

public class Window : IDisposable, ISubscriber
{
    private IntPtr _windowPtr;
    public IntPtr WindowPtr { get; }

    public uint WindowId { get; }

    public Window(uint windowId)
    {
        WindowId = windowId;
        WindowPtr = SDL.SDL_GetWindowFromID(WindowId);
        if ( WindowPtr == IntPtr.Zero )
        {
            throw new InvalidWindowIDException();
        }
        EventPublisher.GetInstance().Subscribe(this);
    }
    protected Window(IntPtr windowPtr)
    {
        if ( windowPtr == IntPtr.Zero )
        {
            throw new InvalidWindowPointerException("Invalid window pointer passed to the constructor");
        }

        WindowId = SDL.SDL_GetWindowID(_windowPtr);
        EventPublisher.GetInstance().Subscribe(this);
    }

    public Window(
        string title,
        int? x = null,
        int? y = null,
        int? width = null,
        int? height = null,
        uint flags = (uint)SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN
    )
    {
        x ??= (int)SDL.SDL_WINDOWPOS_CENTERED;
        y ??= (int)SDL.SDL_WINDOWPOS_CENTERED;
        width ??= 1024;
        height ??= 768;

        _windowPtr = SDL.SDL_CreateWindow(title, (int)x, (int)y, (int)width, (int)height, flags);
        if ( _windowPtr == IntPtr.Zero )
        {
            throw new UnableToCreateWindowException("Unable to create window");
        }

        WindowId = SDL.SDL_GetWindowID(_windowPtr);
        EventPublisher.GetInstance().Subscribe(this);
    }

    public bool Flash(FlashOperation operation)
    {
        int result = SDL.SDL_FlashWindow(_windowPtr, (SDL.SDL_FlashOperation)operation);
        if ( result != 0 )
        {
            throw new UnableToFlashWindowException("Unable to flash the window");

        }

        return true;
    }

    public static Window GetGrabbed()
    {
        IntPtr result = SDL.SDL_GetGrabbedWindow();
        if ( result == IntPtr.Zero )
        {
            throw new NoCurrentlyGrabbedWindowException("There is no window currently grabbed");
        }

        return new Window(result);
    }

    public Rectangle Borders
    {
        get {
            int result =
                SDL.SDL_GetWindowBordersSize(_windowPtr, out var top, out var left, out var bottom, out var right);

            if ( result != 0 )
            {
                throw new UnableToGetWindowBorderException("Unable to get the window's border size");
            }

            return Rectangle.FromLTBR(left, top, bottom, right);
        }
    }

    public float Brightness
    {
        get => SDL.SDL_GetWindowBrightness(_windowPtr);
        set => SDL.SDL_SetWindowBrightness(_windowPtr, value);
    }

    public int DisplayIndex
    {
        get {
            int result = SDL.SDL_GetWindowDisplayIndex(_windowPtr);

            if ( result < 0 )
            {
                throw new UnableToGetTheDisplayOfWindowException("Unable to get the display of the window");
            }

            return result;
        }
    }

    public Display Display => new Display(DisplayIndex);

    public DisplayMode DisplayMode
    {
        get {
            var result = SDL.SDL_GetWindowDisplayMode(_windowPtr, out var mode);
            if ( result != 0 )
            {
                throw new UnableToGetWindowDisplayModeException();
            }

            return new DisplayMode(mode);
        }
        set {
            var result = SDL.SDL_SetWindowDisplayMode(_windowPtr, (SDL.SDL_DisplayMode)value);
            if ( result != 0 )
            {
                throw new UnableToSetWindowDisplayModeException();
            }

        }
    }

    public WindowFlags WindowFlags => new WindowFlags(SDL.SDL_GetWindowFlags(_windowPtr));

    public GammaRamp GammaRamp
    {
        get {
            int result = SDL.SDL_GetWindowGammaRamp(_windowPtr, out var red, out var green, out var blue);
            if ( result != 0 )
            {
                throw new UnableToGetGammaRampException();
            }

            return new GammaRamp(red, green, blue);
        }
        set {
            int result = SDL.SDL_SetWindowGammaRamp(_windowPtr, value.Red, value.Green, value.Blue);
            if ( result != 0 )
            {
                throw new UnableToSetGammaRampException();
            }
        }
    }

    public bool IsGrabbed
    {
        get => SDL.SDL_GetWindowGrab(_windowPtr);
        set => SDL.SDL_SetWindowGrab(_windowPtr, value);
    }

    public Size MaximumSize
    {
        get {
            SDL.SDL_GetWindowMaximumSize(_windowPtr, out var w, out var h);
            return new Size(w, h);
        }
        set => SDL.SDL_SetWindowMaximumSize(_windowPtr, value.Width, value.Height);
    }

    public Size MinimumSize
    {
        get {
            SDL.SDL_GetWindowMinimumSize(_windowPtr, out var w, out var h);
            return new Size(w, h);
        }
        set => SDL.SDL_SetWindowMinimumSize(_windowPtr, value.Width, value.Height);
    }

    public float Opacity
    {
        get {
            int result = SDL.SDL_GetWindowOpacity(_windowPtr, out var opacity);
            if ( result != 0 )
            {
                throw new UnableToGetOpacityException();
            }

            return opacity;
        }
        set {
            int result = SDL.SDL_SetWindowOpacity(_windowPtr, value);
            if ( result != 0 )
            {
                throw new UnableToSetOpacityException();
            }
        }
    }

    public PixelFormat PixelFormat => new PixelFormat(SDL.SDL_GetWindowPixelFormat(_windowPtr));

    public Point2 Position
    {
        get {
            SDL.SDL_GetWindowPosition(_windowPtr, out var x, out var y);
            return new Point2(x, y);
        }
        set => SDL.SDL_SetWindowPosition(_windowPtr, value.X, value.Y);
    }

    public Size Size
    {
        get {
            SDL.SDL_GetWindowSize(_windowPtr, out var w, out var h);
            return new Size(w, h);
        }
        set => SDL.SDL_SetWindowSize(_windowPtr, value.Width, value.Height);
    }

    //TODO: Properly refactor with a Surface Object
    public IntPtr Surface => SDL.SDL_GetWindowSurface(_windowPtr);

    public string Title
    {
        get => SDL.SDL_GetWindowTitle(_windowPtr);
        set => SDL.SDL_SetWindowTitle(_windowPtr, value);
    }

    public void Hide()
    {
        if ( WindowFlags.Hidden )
        {
            return;
        }

        SDL.SDL_HideWindow(_windowPtr);
    }

    public void Show()
    {
        if ( WindowFlags.Shown )
        {
            return;
        }

        SDL.SDL_ShowWindow(_windowPtr);
    }

    public void Minimize()
    {
        if ( WindowFlags.Minimized )
        {
            return;
        }

        SDL.SDL_MinimizeWindow(_windowPtr);
    }

    public void Maximize()
    {
        if ( WindowFlags.Maximized )
        {
            return;
        }

        SDL.SDL_MaximizeWindow(_windowPtr);
    }

    public void Restore()
    {
        if ( WindowFlags.Minimized || WindowFlags.Maximized )
        {
            SDL.SDL_RestoreWindow(_windowPtr);
        }
    }

    public void Raise() => SDL.SDL_RaiseWindow(_windowPtr);

    public bool HasBorder
    {
        get => !WindowFlags.Borderless;
        set => SDL.SDL_SetWindowBordered(_windowPtr, value);
    }

    public bool IsFullscreen
    {
        get => WindowFlags.Fullscreen;
        set {
            int result = SDL.SDL_SetWindowFullscreen(
                _windowPtr,
                value ? (uint)SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN : 0);
            if ( result != 0 )
            {
                throw new UnableToSetWindowFullScreenException();
            }
        }
    }

    public bool IsDesktopFullscreen
    {
        get => WindowFlags.FullscreenDesktop;
        set {
            int result = SDL.SDL_SetWindowFullscreen(
                _windowPtr,
                value ? (uint)SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN_DESKTOP : 0);
            if ( result != 0 )
            {
                throw new UnableToSetWindowFullScreenDesktopException();
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="icon"></param>
    /// TODO: Replace the ugly pointer with a surface object
    public void SetIcon(IntPtr icon)
    {
        SDL.SDL_SetWindowIcon(_windowPtr, icon);
    }

    public void SetInputFocus()
    {
        int result = SDL.SDL_SetWindowInputFocus(_windowPtr);
        if ( result != 0 )
        {
            throw new UnableToSetWindowInputFocus();
        }
    }

    public void SetModalFor(Window parent)
    {
        int result = SDL.SDL_SetWindowModalFor(_windowPtr, parent._windowPtr);
        if ( result != 0 )
        {
            throw new UnableToSetModalForWindowException();
        }
    }

    public bool IsResizable
    {
        get => WindowFlags.Resizable;
        set => SDL.SDL_SetWindowResizable(_windowPtr, value);
    }

    ~Window()
    {
        ReleaseUnmanagedResources();
    }
    public void Update(SDL.SDL_Event ev)
    {
        if ( ev.Window.WindowID != WindowId )
        {
            return;
        }

        switch ( ev.Window.Type )
        {
            case (uint)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_SHOWN:
                OnShown(new WindowEventArgs(ev));
                break;
            case (uint)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_HIDDEN:
                OnHidden(new WindowEventArgs(ev));
                break;
            case (uint)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_EXPOSED:
                OnExposed(new WindowEventArgs(ev));
                break;
            case (uint)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_MOVED:
                OnMoved(new WindowEventArgs(ev));
                break;
            case (uint)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_RESIZED:
                OnResized(new WindowEventArgs(ev));
                break;
            case (uint)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_SIZE_CHANGED:
                OnSizeChanged(new WindowEventArgs(ev));
                break;
            case (uint)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_MINIMIZED:
                OnMinimized(new WindowEventArgs(ev));
                break;
            case (uint)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_MAXIMIZED:
                OnMaximized(new WindowEventArgs(ev));
                break;
            case (uint)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_RESTORED:
                OnRestored(new WindowEventArgs(ev));
                break;
            case (uint)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_ENTER:
                OnEnter(new WindowEventArgs(ev));
                break;
            case (uint)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_LEAVE:
                OnLeave(new WindowEventArgs(ev));
                break;
            case (uint)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_FOCUS_GAINED:
                OnFocusGained(new WindowEventArgs(ev));
                break;
            case (uint)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_FOCUS_LOST:
                OnFocusLost(new WindowEventArgs(ev));
                break;
            case (uint)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_CLOSE:
                OnClose(new WindowEventArgs(ev));
                break;
            case (uint)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_TAKE_FOCUS:
                OnTakeFocus(new WindowEventArgs(ev));
                break;
            case (uint)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_HIT_TEST:
                OnHitTest(new WindowEventArgs(ev));
                break;
            case (uint)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_ICCPROF_CHANGED:
                OnIccProfileChanged(new WindowEventArgs(ev));
                break;
            case (uint)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_DISPLAY_CHANGED:
                OnDisplayChanged(new WindowEventArgs(ev));
                break;

        }
    }
    private void ReleaseUnmanagedResources()
    {
        if ( _windowPtr != IntPtr.Zero )
        {
            SDL.SDL_DestroyWindow(_windowPtr);
        }
    }
    public void Dispose()
    {
        ReleaseUnmanagedResources();
        EventPublisher.GetInstance().Unsubscribe(this);
        GC.SuppressFinalize(this);
    }

    public event EventHandler<WindowEventArgs>? Shown;
    public event EventHandler<WindowEventArgs>? Hidden;
    public event EventHandler<WindowEventArgs>? Exposed;
    public event EventHandler<WindowEventArgs>? Moved;
    public event EventHandler<WindowEventArgs>? Resized;
    public event EventHandler<WindowEventArgs>? SizeChanged;
    public event EventHandler<WindowEventArgs>? Minimized;
    public event EventHandler<WindowEventArgs>? Maximized;
    public event EventHandler<WindowEventArgs>? Restored;
    public event EventHandler<WindowEventArgs>? Enter;
    public event EventHandler<WindowEventArgs>? Leave;
    public event EventHandler<WindowEventArgs>? FocusGained;
    public event EventHandler<WindowEventArgs>? FocusLost;
    public event EventHandler<WindowEventArgs>? Close;
    public event EventHandler<WindowEventArgs>? TakeFocus;
    public event EventHandler<WindowEventArgs>? HitTest;
    public event EventHandler<WindowEventArgs>? ICCProfileChanged;
    public event EventHandler<WindowEventArgs>? DisplayChanged;

    protected virtual void OnShown(WindowEventArgs args) => Shown?.Invoke(this, args);
    protected virtual void OnHidden(WindowEventArgs args) => Hidden?.Invoke(this, args);
    protected virtual void OnExposed(WindowEventArgs args) => Exposed?.Invoke(this, args);
    protected virtual void OnMoved(WindowEventArgs args) => Moved?.Invoke(this, args);
    protected virtual void OnResized(WindowEventArgs args) => Resized?.Invoke(this, args);
    protected virtual void OnSizeChanged(WindowEventArgs args) => SizeChanged?.Invoke(this, args);
    protected virtual void OnMinimized(WindowEventArgs args) => Minimized?.Invoke(this, args);
    protected virtual void OnMaximized(WindowEventArgs args) => Maximized?.Invoke(this, args);
    protected virtual void OnRestored(WindowEventArgs args) => Restored?.Invoke(this, args);
    protected virtual void OnEnter(WindowEventArgs args) => Enter?.Invoke(this, args);
    protected virtual void OnLeave(WindowEventArgs args) => Leave?.Invoke(this, args);
    protected virtual void OnFocusGained(WindowEventArgs args) => FocusGained?.Invoke(this, args);
    protected virtual void OnFocusLost(WindowEventArgs args) => FocusLost?.Invoke(this, args);
    protected virtual void OnClose(WindowEventArgs args) => Close?.Invoke(this, args);
    protected virtual void OnTakeFocus(WindowEventArgs args) => TakeFocus?.Invoke(this, args);
    protected virtual void OnHitTest(WindowEventArgs args) => HitTest?.Invoke(this, args);
    protected virtual void OnIccProfileChanged(WindowEventArgs args) => ICCProfileChanged?.Invoke(this, args);
    protected virtual void OnDisplayChanged(WindowEventArgs args) => DisplayChanged?.Invoke(this, args);

}
