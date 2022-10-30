using SDLTooSharp.Bindings.SDL2;

namespace Transhumanism.Engine.Video;

public class DisplayMode
{
    public int Width { get; }
    public int Height { get; }
    public int RefreshRate { get; }
    public IntPtr DriverData { get; }

    public PixelFormat Format { get; }

    public DisplayMode(SDL.SDL_DisplayMode mode)
    {
        Width = mode.W;
        Height = mode.H;
        RefreshRate = mode.RefreshRate;
        DriverData = mode.DriverData;
        Format = new PixelFormat(mode.Format);
    }

    public static explicit operator DisplayMode(SDL.SDL_DisplayMode mode)
    {
        return new DisplayMode(mode);
    }

    public static explicit operator SDL.SDL_DisplayMode(DisplayMode mode)
    {
        SDL.SDL_DisplayMode m = default;
        m.W = mode.Width;
        m.H = mode.Height;
        m.Format = mode.Format.Raw;
        m.RefreshRate = mode.RefreshRate;
        m.DriverData = mode.DriverData;

        return m;
    }
}
