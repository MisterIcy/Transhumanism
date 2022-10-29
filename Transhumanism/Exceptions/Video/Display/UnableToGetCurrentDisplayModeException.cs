namespace Transhumanism.Exceptions.Video.Display;

public sealed class UnableToGetCurrentDisplayModeException : DisplayException
{
    public UnableToGetCurrentDisplayModeException(int displayId) : base($"Unable to get the current mode for display {displayId}", displayId)
    {
    }
}
