namespace Transhumanism.Exceptions.Video.Window;

public sealed class UnableToSetOpacityException : WindowException
{

    public UnableToSetOpacityException() : base("Unable to set the opacity for the specified window")
    {
    }
}
