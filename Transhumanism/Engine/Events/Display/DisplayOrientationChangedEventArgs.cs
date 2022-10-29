using SDLTooSharp.Bindings.SDL2;

namespace Transhumanism.Engine.Events.Display;

public class DisplayOrientationChangedEventArgs : DisplayEventArgs
{
    public DisplayOrientationChangedEventArgs(SDL.SDL_Event ev) : base(ev)
    {
    }
}
