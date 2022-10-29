using SDLTooSharp.Bindings.SDL2;
using Transhumanism.Exceptions.Events.Display;

namespace Transhumanism.Engine.Events.Display;

public abstract class DisplayEventArgs : CommonEventArgs
{
    public uint DisplayId { get; }
    public byte EventType { get; }
    public int Data { get; }

    protected DisplayEventArgs(SDL.SDL_Event ev) : base(ev)
    {
        DisplayId = ev.Display.Display;
        EventType = ev.Display.Event;
        Data = ev.Display.Data1;
    }

    public DisplayEventArgs Factory(SDL.SDL_Event ev)
    {
        return ev.Display.Type switch
        {
            (uint)SDL.SDL_DisplayEventID.SDL_DISPLAYEVENT_CONNECTED => new DisplayConnectedEventArgs(ev),
            (uint)SDL.SDL_DisplayEventID.SDL_DISPLAYEVENT_DISCONNECTED => new DisplayDisconnetedEventArgs(ev),
            (uint)SDL.SDL_DisplayEventID.SDL_DISPLAYEVENT_ORIENTATION => new DisplayOrientationChangedEventArgs(ev),
            _ => throw new UnknownDisplayEventException(ev)
        };
    }
}