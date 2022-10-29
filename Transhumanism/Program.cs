// See https://aka.ms/new-console-template for more information

using SDLTooSharp.Bindings.SDL2;
using Transhumanism.Engine.Events.Publishers;
using Transhumanism.Engine.Logger;
using Transhumanism.Engine.Video;
using Version = Transhumanism.Version;
Console.WriteLine($"Transhumanism ({Version.GetVersion()})\t Copyright 2022 Alexandros Koutroulis {Environment.NewLine}");
Console.WriteLine("This program comes with ABSOLUTELY NO WARRANTY! This is free software, and you are welcome");
Console.WriteLine("to redistribute it under certain conditions; see the included LICENSE file");

SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING);
bool running = true;

var di1 = new Display(0);
var logger = new Logger();

logger.Trace(di1.Name, Category.Video);
di1.OrientationChanged += (sender, eventArgs) => {
    string msg = $"Orientation changed for {di1.Name}: {(DisplayOrientation)eventArgs.Data}";
    logger.Trace(msg, Category.Video);
    Console.WriteLine(msg);
};
var windowPtr = SDL.SDL_CreateWindow("Transhumanism", (
    0 ), 0, 800, 600, (uint)SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);
var renderPtr = SDL.SDL_CreateRenderer(windowPtr, -1, (uint)SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED);
while ( running )
{
    SDL.SDL_Event ev = default;
    while ( SDL.SDL_PollEvent(out ev) != 0 )
    {
        EventPublisher.GetInstance().AddEvent(ev);
        if ( ev.Type == (uint)SDL.SDL_EventType.SDL_QUIT )
        {
            running = false;
        }
    }

    SDL.SDL_SetRenderDrawColor(renderPtr, 0, 0, 0, 255);
    SDL.SDL_RenderClear(renderPtr);

    SDL.SDL_RenderPresent(renderPtr);
}
logger.Close();

SDL.SDL_DestroyRenderer(renderPtr);
SDL.SDL_DestroyWindow(windowPtr);
SDL.SDL_Quit();
