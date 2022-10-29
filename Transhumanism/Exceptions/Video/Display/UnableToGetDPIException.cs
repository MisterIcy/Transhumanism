namespace Transhumanism.Exceptions.Video.Display;

public sealed class UnableToGetDPIException : DisplayException
{
    public UnableToGetDPIException(int displayId) : base($"Unable to get DPI information for display ${displayId}",
        displayId)
    {
    }
}