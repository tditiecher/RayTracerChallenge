namespace TDev.RayTracerChallenge;

public readonly struct Color : IEquatable<Color>
{
    public double Red { get; }
    public double Green { get; }
    public double Blue { get; }

    public Color(double red, double green, double blue)
    {
        Red = red;
        Green = green;
        Blue = blue;
    }

    public Color Add(Color other)
    {
        return new Color(Red + other.Red, Green + other.Green, Blue + other.Blue);
    }

    public Color Subtract(Color other)
    {
        return new Color(Red - other.Red, Green - other.Green, Blue - other.Blue);
    }

    public Color Multiply(double value)
    {
        return new Color(Red * value, Green * value, Blue * value);
    }

    public Color HadamardProduct(Color other)
    {
        return new Color(Red * other.Red, Green * other.Green, Blue * other.Blue);
    }

    public override bool Equals(object? obj)
    {
        return obj is Color color && Equals(color);
    }

    public bool Equals(Color other)
    {
        return Red.EquivalentTo(other.Red) && Green.EquivalentTo(other.Green) && Blue.EquivalentTo(other.Blue);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Red, Green, Blue);
    }

    public static bool operator ==(Color left, Color right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Color left, Color right)
    {
        return !(left == right);
    }

    public static Color operator +(Color left, Color right)
    {
        return left.Add(right);
    }

    public static Color operator -(Color left, Color right)
    {
        return left.Subtract(right);
    }

    public static Color operator *(Color left, Color right)
    {
        return left.HadamardProduct(right);
    }

    public static Color operator *(Color left, double right)
    {
        return left.Multiply(right);
    }

    public static Color operator *(double left, Color right)
    {
        return right.Multiply(left);
    }


    public static class Static
    {
        public static Color Color(double red, double green, double blue)
        {
            return new Color(red, green, blue);
        }
    }
}