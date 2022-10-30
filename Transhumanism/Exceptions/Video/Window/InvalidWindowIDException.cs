namespace Transhumanism.Exceptions.Video.Window;

public sealed class InvalidWindowIDException : WindowException
{

    public InvalidWindowIDException() : base("Unable to get a window for the specified ID")
    {
    }
}
