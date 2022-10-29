using SDLTooSharp.Bindings.SDL2;

namespace Transhumanism.Engine.Common;

public class RectangleF
{
    public Point2F Origin { get; set; }
    public SizeF Dimensions { get; set; }

    public RectangleF(Point2F origin, SizeF dimensions)
    {
        Origin = origin;
        Dimensions = dimensions;
    }

    public RectangleF(float x, float y, float width, float height) : this(new Point2F(x, y), new SizeF(width, height))
    {

    }

    public RectangleF() : this(0, 0, 0, 0)
    {

    }

    public static RectangleF FromLTBR(float left, float top, float bottom, float right)
    {
        return new RectangleF(left, top, right - left, bottom - top);
    }

    public float Left
    {
        get => Origin.X;
        set => Origin.X = value;
    }

    public float Top
    {
        get => Origin.Y;
        set => Origin.Y = value;
    }

    public float Right
    {
        get => Origin.X + Dimensions.Width;
    }

    public float Bottom
    {
        get => Origin.Y + Dimensions.Height;
    }

    public float Width
    {
        get => Dimensions.Width;
        set => Dimensions.Width = value;
    }

    public float Height
    {
        get => Dimensions.Height;
        set => Dimensions.Height = value;
    }

    public static explicit operator SDL.SDL_FRect(RectangleF rectangle)
    {
        SDL.SDL_FRect rect = default;
        rect.X = rectangle.Left;
        rect.Y = rectangle.Top;
        rect.W = rectangle.Width;
        rect.H = rectangle.Height;

        return rect;
    }

    public static explicit operator System.Drawing.RectangleF(RectangleF rectangle)
    {
        System.Drawing.RectangleF rect = default;
        rect.X = rectangle.Left;
        rect.Y = rectangle.Top;
        rect.Width = rectangle.Width;
        rect.Height = rectangle.Height;

        return rect;
    }

    public static explicit operator RectangleF(SDL.SDL_FRect rect)
    {
        return new RectangleF(rect.X, rect.Y, rect.W, rect.H);
    }

    public static explicit operator RectangleF(System.Drawing.RectangleF rect)
    {
        return new RectangleF(rect.X, rect.Y, rect.Width, rect.Height);
    }
}
