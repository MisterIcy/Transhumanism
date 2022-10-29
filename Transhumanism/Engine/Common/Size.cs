namespace Transhumanism.Engine.Common;

public class Size : IEquatable<Size>
{
    private int _width;

    public int Width
    {
        get => _width;
        set {
            if ( value < 0 )
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Width must be greater than or equal to zero");
            }

            _width = value;
        }
    }

    private int _height;

    public int Height
    {
        get => _height;
        set {
            if ( value < 0 )
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Height must be greater than or equal to zero");
            }

            _width = value;
        }
    }

    public Size(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public Size(int value) : this(value, value)
    {

    }
    public Size() : this(0)
    {

    }

    public bool Empty => Width == 0 || Height == 0;


    public bool Equals(Size? other)
    {
        if ( ReferenceEquals(null, other) )
        {
            return false;
        }

        if ( ReferenceEquals(this, other) )
        {
            return true;
        }

        return _width == other._width && _height == other._height;
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

        return Equals((Size)obj);
    }
    public override int GetHashCode() => HashCode.Combine(_width, _height);
    public static bool operator ==(Size? left, Size? right) => Equals(left, right);
    public static bool operator !=(Size? left, Size? right) => !Equals(left, right);
}
