using System.Diagnostics;
using SDLTooSharp.Bindings.SDL2;
using Transhumanism.Engine.Events.Subscribers;

namespace Transhumanism.Engine.Events.Publishers;

public abstract class AbstractPublisher : IPublisher
{
    protected List<ISubscriber> Subscribers { get; }

    protected AbstractPublisher()
    {
        Subscribers = new List<ISubscriber>();
    }

    public IPublisher AddSubscriber(ISubscriber subscriber)
    {
        if ( !Subscribers.Contains(subscriber) )
        {
            Subscribers.Add(subscriber);
        }

        return this;
    }

    public IPublisher RemoveSubscriber(ISubscriber subscriber)
    {
        if ( Subscribers.Contains(subscriber) )
        {
            Subscribers.Remove(subscriber);
        }

        return this;
    }

    public void NotifySubscribers(SDL.SDL_Event ev)
    {
        foreach ( var subscriber in Subscribers )
        {
            subscriber.Update(ev);
        }
    }
}
