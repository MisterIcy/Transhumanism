using SDLTooSharp.Bindings.SDL2;

namespace Transhumanism.Exceptions.Events;

public abstract class EventException : EngineException
{
    public SDL.SDL_Event Event { get; }
    protected EventException(string message, SDL.SDL_Event @event) : base(message)
    {
        Event = @event;
    }
}
