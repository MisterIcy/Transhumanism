namespace Transhumanism.Exceptions.Video.Window;

public sealed class UnableToSetWindowDisplayModeException : WindowException
{

    public UnableToSetWindowDisplayModeException() : base("Unable to set a display mode on the specified window")
    {
    }
}
