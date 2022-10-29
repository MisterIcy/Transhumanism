namespace Transhumanism.Exceptions.Video.Display;

public sealed class UnableToGetDisplayModeException : DisplayException
{
    public int DisplayModeId { get; }
    public UnableToGetDisplayModeException(int displayId, int modeId) : base($"Unable to get display mode {modeId} of display {displayId}", displayId)
    {
        DisplayModeId = modeId;
    }
}
