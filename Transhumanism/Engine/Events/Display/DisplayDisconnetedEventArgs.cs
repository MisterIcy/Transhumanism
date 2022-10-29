using SDLTooSharp.Bindings.SDL2;

namespace Transhumanism.Engine.Events.Display;

public sealed class DisplayDisconnetedEventArgs : DisplayEventArgs
{
    public DisplayDisconnetedEventArgs(SDL.SDL_Event ev) : base(ev)
    {
    }
}
