using SDLTooSharp.Bindings.SDL2;

namespace Transhumanism.Engine.Common;

public class Rectangle : IEquatable<Rectangle>
{
    public Point2 Origin { get; set; }
    public Size Dimensions { get; set; }

    public Rectangle(Point2 origin, Size dimensions)
    {
        Origin = origin;
        Dimensions = dimensions;
    }

    public Rectangle(int x, int y, int width, int height) : this(new Point2(x, y), new Size(width, height))
    {

    }

    public Rectangle() : this(0, 0, 0, 0)
    {

    }

    public static Rectangle FromLTBR(int left, int top, int bottom, int right)
    {
        return new Rectangle(left, top, right - left, bottom - top);
    }

    public int Left
    {
        get => Origin.X;
        set => Origin.X = value;
    }

    public int Top
    {
        get => Origin.Y;
        set => Origin.Y = value;
    }

    public int Right
    {
        get => Origin.X + Dimensions.Width;
    }

    public int Bottom
    {
        get => Origin.Y + Dimensions.Height;
    }

    public int Width
    {
        get => Dimensions.Width;
        set => Dimensions.Width = value;
    }

    public int Height
    {
        get => Dimensions.Height;
        set => Dimensions.Height = value;
    }

    public static explicit operator SDL.SDL_Rect(Rectangle rectangle)
    {
        SDL.SDL_Rect rect = default;
        rect.X = rectangle.Left;
        rect.Y = rectangle.Top;
        rect.W = rectangle.Width;
        rect.H = rectangle.Height;

        return rect;
    }

    public static explicit operator System.Drawing.Rectangle(Rectangle rectangle)
    {
        System.Drawing.Rectangle rect = default;
        rect.X = rectangle.Left;
        rect.Y = rectangle.Top;
        rect.Width = rectangle.Width;
        rect.Height = rectangle.Height;

        return rect;
    }

    public static explicit operator Rectangle(SDL.SDL_Rect rect)
    {
        return new Rectangle(rect.X, rect.Y, rect.W, rect.H);
    }

    public static explicit operator Rectangle(System.Drawing.Rectangle rect)
    {
        return new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
    }

    public bool Equals(Rectangle? other)
    {
        if ( ReferenceEquals(null, other) )
        {
            return false;
        }

        if ( ReferenceEquals(this, other) )
        {
            return true;
        }

        return Origin.Equals(other.Origin) && Dimensions.Equals(other.Dimensions);
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

        return Equals((Rectangle)obj);
    }
    public override int GetHashCode() => HashCode.Combine(Origin, Dimensions);
    public static bool operator ==(Rectangle? left, Rectangle? right) => Equals(left, right);
    public static bool operator !=(Rectangle? left, Rectangle? right) => !Equals(left, right);
}
