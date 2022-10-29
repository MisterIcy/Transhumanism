namespace Transhumanism.Exceptions.Video;

public abstract class VideoException : EngineException
{
    protected VideoException(string message) : base(message)
    {
    }
}