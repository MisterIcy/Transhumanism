using Transhumanism.Engine.Common;

namespace Transhumanism.Exceptions.Video.Display;

public sealed class NoDisplayForPointException : DisplayException
{
    public NoDisplayForPointException(Point2 point) : base($"The supplied point ({point.X},{point.Y}) does not exist on any display", 0)
    {
    }
}