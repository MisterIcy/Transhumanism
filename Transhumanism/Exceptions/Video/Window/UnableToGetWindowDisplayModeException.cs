namespace Transhumanism.Exceptions.Video.Window;

public sealed class UnableToGetWindowDisplayModeException : WindowException
{

    public UnableToGetWindowDisplayModeException() : base("Unable to get the window's display mode")
    {
    }
}
