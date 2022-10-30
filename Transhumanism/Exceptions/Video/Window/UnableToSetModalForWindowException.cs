namespace Transhumanism.Exceptions.Video.Window;

public sealed class UnableToSetModalForWindowException : WindowException
{

    public UnableToSetModalForWindowException() : base("Unable to set the window as a modal for another window")
    {
    }
}
