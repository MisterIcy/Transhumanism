using SDLTooSharp.Bindings.SDL2;

namespace Transhumanism.Exceptions.Video.Display;

public sealed class NoDisplayForPointException : DisplayException
{
    public NoDisplayForPointException(SDL.SDL_Point point) : base($"The supplied point ({point.X},{point.Y}) does not exist on any display", 0)
    {
    }
}