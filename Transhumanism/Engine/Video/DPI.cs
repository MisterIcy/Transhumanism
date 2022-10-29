using SDLTooSharp.Bindings.SDL2;
using Transhumanism.Exceptions.Video.Display;

namespace Transhumanism.Engine.Video;

/// <summary>
/// Structure that describes a display's DPI information
/// </summary>
public struct DPI
{
    /// <summary>
    /// The display's horizontal DPI
    /// </summary>
    public readonly float Horizontal;
    /// <summary>
    /// The display's vertical DPI
    /// </summary>
    public readonly float Vertical;
    /// <summary>
    /// The display's diagonal DPI
    /// </summary>
    public readonly float Diagonal;

    /// <summary>
    /// Creates a DPI structure
    /// </summary>
    /// <param name="displayId">The Display ID for which we want to get DPI information</param>
    /// <exception cref="UnableToGetDPIException">Thrown if we cannot get DPI information for the display</exception>
    public DPI(int displayId)
    {
        var result = SDL.SDL_GetDisplayDPI(displayId, out Diagonal, out Horizontal, out Vertical);
        if ( result != 0 )
        {
            throw new UnableToGetDPIException(displayId);
        }
    }
}
