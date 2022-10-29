namespace Transhumanism.Engine.Common;

public class SizeF : IEquatable<SizeF>
{
    private float _width;

    public float Width
    {
        get => _width;
        set {
            if ( value < 0 )
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Width must be greater or equal to 0");
            }

            _width = value;
        }
    }

    private float _height;

    public float Height
    {
        get => _height;
        set {
            if ( value < 0 )
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Height must be greater or equal to 0");
            }

            _height = value;
        }
    }

    public SizeF(float width, float height)
    {
        Width = width;
        Height = height;
    }

    public SizeF(float value) : this(value, value)
    {

    }
    public SizeF() : this(0)
    {

    }
    public bool Equals(SizeF? other)
    {
        if ( ReferenceEquals(null, other) )
        {
            return false;
        }

        if ( ReferenceEquals(this, other) )
        {
            return true;
        }

        return _width.Equals(other._width) && _height.Equals(other._height);
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

        return Equals((SizeF)obj);
    }
    public override int GetHashCode() => HashCode.Combine(_width, _height);
    public static bool operator ==(SizeF? left, SizeF? right) => Equals(left, right);
    public static bool operator !=(SizeF? left, SizeF? right) => !Equals(left, right);
}
