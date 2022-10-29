namespace Transhumanism.Exceptions.Video.Display;

public sealed class UnableToGetDesktopDisplayModeException : DisplayException
{
    public UnableToGetDesktopDisplayModeException(int displayId) : 
        base($"Unable to get the desktop display mode for display {displayId}", displayId)
    {
    }
}