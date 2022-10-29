using SDLTooSharp.Bindings.SDL2;

namespace Transhumanism.Engine.Video;

public class PixelFormat
{
    public uint Raw { get; }
    public string Name => SDL.SDL_GetPixelFormatName(Raw);

    public PixelFormat(uint format)
    {
        Raw = format;
    }
}
