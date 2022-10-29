namespace Transhumanism.Exceptions.Video.Display;

public abstract class DisplayException: VideoException
{
    public int DisplayId { get; }
    
    protected DisplayException(string message, int displayId) : base(message)
    {
        DisplayId = displayId;
    }
}