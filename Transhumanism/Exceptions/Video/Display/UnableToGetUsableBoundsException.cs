namespace Transhumanism.Exceptions.Video.Display;

public sealed class UnableToGetUsableBoundsException : DisplayException
{

    public UnableToGetUsableBoundsException(int displayId) : base(
        $"Unable to get usable bounds for display {displayId}", displayId)
    {
    }
}
