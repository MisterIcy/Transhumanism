using SDLTooSharp.Bindings.SDL2;

namespace Transhumanism.Engine.Events.Window;

public class WindowEventArgs : CommonEventArgs
{

    public WindowEventArgs(SDL.SDL_Event ev) : base(ev)
    {
    }
}
