using System.Drawing;
using SDLTooSharp.Bindings.SDL2;

namespace Transhumanism.Engine.Common;

public class Point2F : IEquatable<Point2F>
{
    public float X { get; set; }
    public float Y { get; set; }

    public Point2F(float x, float y)
    {
        x = X;
        y = Y;
    }

    public Point2F(float v) : this(v, v)
    {

    }
    public Point2F() : this(0)
    {

    }
    public bool Equals(Point2F? other)
    {
        if ( ReferenceEquals(null, other) )
        {
            return false;
        }

        if ( ReferenceEquals(this, other) )
        {
            return true;
        }

        return X.Equals(other.X) && Y.Equals(other.Y);
    }
    public override bool Equals(object? obj)
    {
        if ( ReferenceEquals(null, obj) )
        {
            return false;
        }

        if ( ReferenceEquals(this, obj) )
        {
            return true;
        }

        if ( obj.GetType() != this.GetType() )
        {
            return false;
        }

        return Equals((Point2F)obj);
    }
    public override int GetHashCode() => HashCode.Combine(X, Y);
    public static bool operator ==(Point2F? left, Point2F? right) => Equals(left, right);
    public static bool operator !=(Point2F? left, Point2F? right) => !Equals(left, right);
    public static explicit operator SDL.SDL_FPoint(Point2F pt)
    {
        SDL.SDL_FPoint point = default;
        point.X = pt.X;
        point.Y = pt.Y;

        return point;
    }

    public static explicit operator PointF(Point2F pt)
    {
        PointF point = default;
        point.X = pt.X;
        point.Y = pt.Y;

        return point;
    }

    public static explicit operator Point2F(SDL.SDL_FPoint pt)
    {
        return new Point2F(pt.X, pt.Y);
    }

    public static explicit operator Point2F(PointF pt)
    {
        return new Point2F(pt.X, pt.Y);
    }
}
