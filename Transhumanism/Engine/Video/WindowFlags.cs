using SDLTooSharp.Bindings.SDL2;

namespace Transhumanism.Engine.Video;

public class WindowFlags
{
    public bool Fullscreen { get; set; }
    public bool OpenGL { get; set; }
    public bool Shown { get; set; }
    public bool Hidden { get; set; }
    public bool Borderless { get; set; }
    public bool Resizable { get; set; }
    public bool Minimized { get; set; }
    public bool Maximized { get; set; }
    public bool MouseGrabbed { get; set; }
    public bool InputFocus { get; set; }
    public bool MouseFocus { get; set; }
    public bool FullscreenDesktop { get; set; }
    public bool Foreign { get; set; }
    public bool AllowHighDPI { get; set; }
    public bool MouseCapture { get; set; }
    public bool AlwaysOnTop { get; set; }
    public bool SkipTaskbar { get; set; }
    public bool Utility { get; set; }
    public bool ToolTip { get; set; }
    public bool PopupMenu { get; set; }
    public bool KeyboardGrabbed { get; set; }
    public bool Vulkan { get; set; }
    public bool Metal { get; set; }
    public bool InputGrabbed { get; set; }

    public WindowFlags(uint flags)
    {
        Fullscreen = ( flags & (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN ) ==
                     (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN;
        OpenGL = ( flags & (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_OPENGL ) ==
                 (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_OPENGL;
        Shown = ( flags & (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN ) ==
                (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN;
        Hidden = ( flags & (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_HIDDEN ) ==
                 (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_OPENGL;
        Borderless = ( flags & (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_BORDERLESS ) ==
                     (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_BORDERLESS;
        Resizable = ( flags & (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE ) ==
                    (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE;
        Minimized = ( flags & (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_MINIMIZED ) ==
                    (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_MINIMIZED;
        Maximized = ( flags & (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_MAXIMIZED ) ==
                    (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_MAXIMIZED;
        MouseGrabbed = ( flags & (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_MOUSE_GRABBED ) ==
                       (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_MOUSE_GRABBED;
        InputFocus = ( flags & (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_INPUT_FOCUS ) ==
                     (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_INPUT_FOCUS;
        MouseFocus = ( flags & (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_MOUSE_FOCUS ) ==
                     (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_MOUSE_FOCUS;
        FullscreenDesktop = ( flags & (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN_DESKTOP ) ==
                            (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN_DESKTOP;
        Foreign = ( flags & (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_FOREIGN ) ==
                  (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_FOREIGN;
        AllowHighDPI = ( flags & (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_ALLOW_HIGHDPI ) ==
                       (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_ALLOW_HIGHDPI;
        MouseCapture = ( flags & (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_MOUSE_CAPTURE ) ==
                       (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_MOUSE_CAPTURE;
        AlwaysOnTop = ( flags & (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_ALWAYS_ON_TOP ) ==
                      (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_ALWAYS_ON_TOP;
        SkipTaskbar = ( flags & (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_SKIP_TASKBAR ) ==
                      (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_SKIP_TASKBAR;
        Utility = ( flags & (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_UTILITY ) ==
                  (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_UTILITY;
        ToolTip = ( flags & (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_TOOLTIP ) ==
                  (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_TOOLTIP;
        PopupMenu = ( flags & (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_POPUP_MENU ) ==
                    (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_POPUP_MENU;
        KeyboardGrabbed = ( flags & (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_KEYBOARD_GRABBED ) ==
                          (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_KEYBOARD_GRABBED;
        Vulkan = ( flags & (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_VULKAN ) ==
                 (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_VULKAN;
        Metal = ( flags & (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_METAL ) ==
                (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_METAL;
        InputGrabbed = ( flags & (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_INPUT_GRABBED ) ==
                       (ulong)SDL.SDL_WindowFlags.SDL_WINDOW_INPUT_GRABBED;
    }

    public uint GetFlags()
    {
        uint result = 0;

        result |= (uint)( Fullscreen ? SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN : 0 );
        result |= (uint)( OpenGL ? SDL.SDL_WindowFlags.SDL_WINDOW_OPENGL : 0 );
        result |= (uint)( Shown ? SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN : 0 );
        result |= (uint)( Hidden ? SDL.SDL_WindowFlags.SDL_WINDOW_HIDDEN : 0 );
        result |= (uint)( Borderless ? SDL.SDL_WindowFlags.SDL_WINDOW_BORDERLESS : 0 );
        result |= (uint)( Resizable ? SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE : 0 );
        result |= (uint)( Minimized ? SDL.SDL_WindowFlags.SDL_WINDOW_MINIMIZED : 0 );
        result |= (uint)( Maximized ? SDL.SDL_WindowFlags.SDL_WINDOW_MAXIMIZED : 0 );
        result |= (uint)( MouseGrabbed ? SDL.SDL_WindowFlags.SDL_WINDOW_MOUSE_GRABBED : 0 );
        result |= (uint)( InputFocus ? SDL.SDL_WindowFlags.SDL_WINDOW_INPUT_FOCUS : 0 );
        result |= (uint)( MouseFocus ? SDL.SDL_WindowFlags.SDL_WINDOW_MOUSE_FOCUS : 0 );
        result |= (uint)( FullscreenDesktop ? SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN_DESKTOP : 0 );
        result |= (uint)( Foreign ? SDL.SDL_WindowFlags.SDL_WINDOW_FOREIGN : 0 );
        result |= (uint)( AllowHighDPI ? SDL.SDL_WindowFlags.SDL_WINDOW_ALLOW_HIGHDPI : 0 );
        result |= (uint)( MouseCapture ? SDL.SDL_WindowFlags.SDL_WINDOW_MOUSE_CAPTURE : 0 );
        result |= (uint)( AlwaysOnTop ? SDL.SDL_WindowFlags.SDL_WINDOW_ALWAYS_ON_TOP : 0 );
        result |= (uint)( SkipTaskbar ? SDL.SDL_WindowFlags.SDL_WINDOW_SKIP_TASKBAR : 0 );
        result |= (uint)( Utility ? SDL.SDL_WindowFlags.SDL_WINDOW_UTILITY : 0 );
        result |= (uint)( ToolTip ? SDL.SDL_WindowFlags.SDL_WINDOW_TOOLTIP : 0 );
        result |= (uint)( PopupMenu ? SDL.SDL_WindowFlags.SDL_WINDOW_POPUP_MENU : 0 );
        result |= (uint)( KeyboardGrabbed ? SDL.SDL_WindowFlags.SDL_WINDOW_KEYBOARD_GRABBED : 0 );
        result |= (uint)( Vulkan ? SDL.SDL_WindowFlags.SDL_WINDOW_VULKAN : 0 );
        result |= (uint)( Metal ? SDL.SDL_WindowFlags.SDL_WINDOW_METAL : 0 );
        result |= (uint)( InputGrabbed ? SDL.SDL_WindowFlags.SDL_WINDOW_INPUT_GRABBED : 0 );

        return result;
    }
}
