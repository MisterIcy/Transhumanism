using System.Drawing;
using SDLTooSharp.Bindings.SDL2;

namespace Transhumanism.Engine.Common;

public class Point2 : IEquatable<Point2>
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point2(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Point2(int v) : this(v, v)
    {
    }

    public Point2() : this(0)
    {
    }

    public bool Equals(Point2? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return X == other.X && Y == other.Y;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Point2)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    public static bool operator ==(Point2? left, Point2? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Point2? left, Point2? right)
    {
        return !Equals(left, right);
    }

    public static explicit operator Point2(SDL.SDL_Point pt)
    {
        return new Point2(pt.X, pt.Y);
    }

    public static explicit operator Point2(Point pt)
    {
        return new Point2(pt.X, pt.Y);
    }

    public static explicit operator SDL.SDL_Point(Point2 pt)
    {
        SDL.SDL_Point point = default;
        point.X = pt.X;
        point.Y = pt.Y;
        return point;
    }

    public static explicit operator Point(Point2 pt)
    {
        Point point = default;
        point.X = pt.X;
        point.Y = pt.Y;

        return point;
    }
}