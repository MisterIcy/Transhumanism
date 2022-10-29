namespace Transhumanism.Exceptions.Video.Display;

public sealed class UnableToGetBoundsException : DisplayException
{

    public UnableToGetBoundsException(int displayId) : base($"Unable to get the bound of display: {displayId}", displayId)
    {
    }
}
