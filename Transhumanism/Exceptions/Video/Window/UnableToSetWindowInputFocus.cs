namespace Transhumanism.Exceptions.Video.Window;

public sealed class UnableToSetWindowInputFocus : WindowException
{

    public UnableToSetWindowInputFocus() : base("Unable to set input focus for the specified window")
    {
    }
}
