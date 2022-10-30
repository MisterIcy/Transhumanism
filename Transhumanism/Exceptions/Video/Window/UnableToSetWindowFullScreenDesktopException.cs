namespace Transhumanism.Exceptions.Video.Window;

public sealed class UnableToSetWindowFullScreenDesktopException : WindowException
{

    public UnableToSetWindowFullScreenDesktopException() : base(
        "Unable to set window fullscreen for the specified window")
    {
    }
}
