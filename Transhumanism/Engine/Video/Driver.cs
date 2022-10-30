using SDLTooSharp.Bindings.SDL2;

namespace Transhumanism.Engine.Video;

public static class Driver
{
    public static int Count => SDL.SDL_GetNumVideoDrivers();
    public static string Current => SDL.SDL_GetCurrentVideoDriver();
    public static string GetName(int index) => SDL.SDL_GetVideoDriver(index);
}
