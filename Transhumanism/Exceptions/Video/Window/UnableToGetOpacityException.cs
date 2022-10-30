namespace Transhumanism.Exceptions.Video.Window;

public sealed class UnableToGetOpacityException : WindowException
{

    public UnableToGetOpacityException() : base("Unable to get the opacity of the specified window")
    {
    }
}
