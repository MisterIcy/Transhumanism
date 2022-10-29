using SDLTooSharp.Bindings.SDL2;

namespace Transhumanism.Exceptions.Events.Display;

public sealed class UnknownDisplayEventException : EventException
{
    public UnknownDisplayEventException(SDL.SDL_Event @event) : base("Unknown display event", @event)
    {
    }
}
