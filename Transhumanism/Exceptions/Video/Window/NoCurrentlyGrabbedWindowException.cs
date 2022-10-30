namespace Transhumanism.Exceptions.Video.Window;

public sealed class NoCurrentlyGrabbedWindowException : VideoException
{

    public NoCurrentlyGrabbedWindowException(string message) : base(message)
    {
    }
}
