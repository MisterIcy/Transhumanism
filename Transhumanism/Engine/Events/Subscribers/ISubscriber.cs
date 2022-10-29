using SDLTooSharp.Bindings.SDL2;

namespace Transhumanism.Engine.Events.Subscribers;

public interface ISubscriber
{
    public void Update(SDL.SDL_Event ev);
}