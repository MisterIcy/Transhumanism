namespace Transhumanism.Exceptions.Video.Display;

public sealed class NoDisplaysFoundException : VideoException
{
    public NoDisplaysFoundException() : base("No displays were found")
    {
    }
}