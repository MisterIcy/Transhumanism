using SDLTooSharp.Bindings.SDL2;

namespace Transhumanism.Engine.Events.Display;

public sealed class DisplayConnectedEventArgs : DisplayEventArgs
{
    public DisplayConnectedEventArgs(SDL.SDL_Event ev) : base(ev)
    {
    }
}