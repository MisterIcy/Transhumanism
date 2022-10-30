namespace Transhumanism.Exceptions.Video.Window;

public sealed class UnableToSetWindowFullScreenException : WindowException
{

    public UnableToSetWindowFullScreenException() : base("Unable to set Fullscreen for the specified window")
    {
    }
}
