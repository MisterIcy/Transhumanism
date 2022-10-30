using SDLTooSharp.Bindings.SDL2;

namespace Transhumanism.Engine.Video;

public enum FlashOperation
{
    Cancel = SDL.SDL_FlashOperation.SDL_FLASH_CANCEL,
    Briefly = SDL.SDL_FlashOperation.SDL_FLASH_BRIEFLY,
    UntilFocused = SDL.SDL_FlashOperation.SDL_FLASH_UNTIL_FOCUSED
}
