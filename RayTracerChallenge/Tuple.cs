namespace TDev.RayTracerChallenge;

public readonly struct Tuple : IEquatable<Tuple>
{
    public double X { get; }
    public double Y { get; }
    public double Z { get; }
    public double W { get; }

    public Tuple(double x, double y, double z, double w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }

    public static Tuple Point(double x, double y, double z)
    {
        return new Tuple(x, y, z, 1);
    }

    public static Tuple Vector(double x, double y, double z)
    {
        return new Tuple(x, y, z, 0);
    }

    public bool IsPoint => W.EquivalentTo(1);

    public bool IsVector => W.EquivalentTo(0);

    public override bool Equals(object? obj)
    {
        return obj is Tuple tuple && Equals(tuple);
    }

    public bool Equals(Tuple other)
    {
        return X.EquivalentTo(other.X) && Y.EquivalentTo(other.Y) && Z.EquivalentTo(other.Z) && W.EquivalentTo(other.W);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y, Z, W);
    }

    public static bool operator ==(Tuple left, Tuple right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Tuple left, Tuple right)
    {
        return !(left == right);
    }
}