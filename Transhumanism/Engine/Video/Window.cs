using SDLTooSharp.Bindings.SDL2;

namespace Transhumanism.Engine.Video;

public class Window
{
    public IntPtr WindowPtr { get; }

    public Window(
        string title,
        int? x = null,
        int? y = null,
        int? width = null,
        int? height = null,
        uint flags = (uint)SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN
    )
    {
        if (x is null)
        {
            
        }
    }
}