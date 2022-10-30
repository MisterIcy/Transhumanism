namespace Transhumanism.Exceptions.Video.Window;

public sealed class UnableToSetGammaRampException : WindowException
{

    public UnableToSetGammaRampException() : base("Unable to set the gamma ramp for the specified window")
    {
    }
}
