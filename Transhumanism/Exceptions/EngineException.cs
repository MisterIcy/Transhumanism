using SDLTooSharp.Bindings.SDL2;

namespace Transhumanism.Exceptions;

public abstract class EngineException : Exception
{
    public string SDLError { get; }
    
    protected EngineException(string message) : base(message)
    {
        SDLError = SDL.SDL_GetError();
    }
}