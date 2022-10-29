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
}