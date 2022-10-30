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
    public WindowPublisher WindowPublisher { get; }

    public EventPublisher()
    {
        DisplayPublisher = new DisplayPublisher();
        WindowPublisher = new WindowPublisher();
    }

    public void Subscribe(ISubscriber subscriber)
    {

        switch ( subscriber )
        {
            case Video.Display:
                DisplayPublisher.AddSubscriber(subscriber);
                break;
            case Video.Window:
                WindowPublisher.AddSubscriber(subscriber);
                break;
        }


    }

    public void Unsubscribe(ISubscriber subscriber)
    {
        switch ( subscriber )
        {
            case Video.Display:
                DisplayPublisher.RemoveSubscriber(subscriber);
                break;
            case Video.Window:
                WindowPublisher.RemoveSubscriber(subscriber);
                break;
        }
    }

    public void AddEvent(SDL.SDL_Event ev)
    {
        switch ( ev.Type )
        {
            case (uint)SDL.SDL_EventType.SDL_DISPLAYEVENT:
                DisplayPublisher.NotifySubscribers(ev);
                break;
            case (uint)SDL.SDL_EventType.SDL_WINDOWEVENT:
                WindowPublisher.NotifySubscribers(ev);
                break;
        }
    }
}
