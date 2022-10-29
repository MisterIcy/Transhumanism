using SDLTooSharp.Bindings.SDL2;

namespace Transhumanism.Engine.Video;

public enum DisplayOrientation
{
    Unknown = SDL.SDL_DisplayOrientation.SDL_ORIENTATION_UNKNOWN,
    Landscape = SDL.SDL_DisplayOrientation.SDL_ORIENTATION_LANDSCAPE,
    LandscapeFlipped = SDL.SDL_DisplayOrientation.SDL_ORIENTATION_LANDSCAPE_FLIPPED,
    Portrait = SDL.SDL_DisplayOrientation.SDL_ORIENTATION_PORTRAIT,
    PortraitFlipped = SDL.SDL_DisplayOrientation.SDL_ORIENTATION_PORTRAIT_FLIPPED
}