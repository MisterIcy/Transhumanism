namespace Transhumanism.Exceptions.Video.Display;

public sealed class UnableToGetNumberOfDisplayModesException : DisplayException
{
    public UnableToGetNumberOfDisplayModesException(int displayId) : base(
        $"Unable to get the number of display modes for display {displayId}", displayId)
    {
    }
}
