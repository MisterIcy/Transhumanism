namespace Transhumanism.Exceptions.Video.Window;

public class UnableToGetGammaRampException : WindowException
{

    public UnableToGetGammaRampException() : base("Unable to get the gamma ramp for the specified window")
    {
    }
}
