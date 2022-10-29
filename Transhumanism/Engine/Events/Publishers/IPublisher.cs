using SDLTooSharp.Bindings.SDL2;
using Transhumanism.Engine.Events.Subscribers;

namespace Transhumanism.Engine.Events.Publishers;

public interface IPublisher
{
    public IPublisher AddSubscriber(ISubscriber subscriber);
    public IPublisher RemoveSubscriber(ISubscriber subscriber);
    public void NotifySubscribers(SDL.SDL_Event ev);
}