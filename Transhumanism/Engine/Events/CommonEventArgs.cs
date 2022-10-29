using SDLTooSharp.Bindings.SDL2;

namespace Transhumanism.Engine.Events;

public abstract class CommonEventArgs : EventArgs
{
    public uint Type { get; }
    public uint Timestamp { get; }

    protected CommonEventArgs(SDL.SDL_Event ev)
    {
        Type = ev.Common.Type;
        Timestamp = ev.Common.Timestamp;
    }
}
