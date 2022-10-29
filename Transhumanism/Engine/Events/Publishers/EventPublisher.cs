using SDLTooSharp.Bindings.SDL2;
using Transhumanism.Engine.Events.Subscribers;

namespace Transhumanism.Engine.Events.Publishers;

public class EventPublisher
{
    private static EventPublisher? _instance;

    public static EventPublisher GetInstance()
    {
        return _instance ??= new EventPublisher();
    }
    
    public DisplayPublisher DisplayPublisher { get; }
    
    public EventPublisher()
    {
        DisplayPublisher = new DisplayPublisher();
    }

    public void Subscribe(ISubscriber subscriber)
    {
        if (subscriber is Video.Display)
        {
            DisplayPublisher.AddSubscriber(subscriber);
        }
    }

    public void Unsubscribe(ISubscriber subscriber)
    {
        if (subscriber is Video.Display)
        {
            DisplayPublisher.RemoveSubscriber(subscriber);
        }
    }

    public void AddEvent(SDL.SDL_Event ev)
    {
        switch (ev.Type)
        {
            case (uint)SDL.SDL_EventType.SDL_DISPLAYEVENT:
                DisplayPublisher.NotifySubscribers(ev);
                break;
        }
    }
}