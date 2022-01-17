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

    public bool IsPoint => W.EquivalentTo(1);

    public bool IsVector => W.EquivalentTo(0);

    public double Magnitude => Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2) + Math.Pow(W, 2));

    public Tuple Add(Tuple other)
    {
        return new Tuple(X + other.X, Y + other.Y, Z + other.Z, W + other.W);
    }

    public Tuple Subtract(Tuple other)
    {
        return new Tuple(X - other.X, Y - other.Y, Z - other.Z, W - other.W);
    }

    public Tuple Multiply(double value)
    {
        return new Tuple(X * value, Y * value, Z * value, W * value);
    }

    public Tuple Divide(double value)
    {
        return new Tuple(X / value, Y / value, Z / value, W / value);
    }

    public Tuple Normalize()
    {
        return new Tuple(X / Magnitude, Y / Magnitude, Z / Magnitude, W / Magnitude);
    }

    public double Dot(Tuple other)
    {
        return X * other.X + Y * other.Y + Z * other.Z + W * other.W;
    }

    public Tuple Cross(Tuple other)
    {
        return new Tuple(Y * other.Z - Z * other.Y, Z * other.X - X * other.Z, X * other.Y - Y * other.X, 0);
    }

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

    public static Tuple operator +(Tuple left, Tuple right)
    {
        return left.Add(right);
    }

    public static Tuple operator -(Tuple left, Tuple right)
    {
        return left.Subtract(right);
    }

    public static Tuple operator -(Tuple tuple)
    {
        return new Tuple(-tuple.X, -tuple.Y, -tuple.Z, -tuple.W);
    }

    public static Tuple operator *(Tuple tuple, double value)
    {
        return tuple.Multiply(value);
    }

    public static Tuple operator *(double value, Tuple tuple)
    {
        return tuple.Multiply(value);
    }

    public static Tuple operator /(Tuple tuple, double value)
    {
        return tuple.Divide(value);
    }
    
    
    public static class Static
    {
        public static Tuple Tuple(double x, double y, double z, double w)
        {
            return new Tuple(x, y, z, w);
        }
    
        public static Tuple Point(double x, double y, double z)
        {
            return new Tuple(x, y, z, 1);
        }

        public static Tuple Vector(double x, double y, double z)
        {
            return new Tuple(x, y, z, 0);
        }

        public static double Magnitude(Tuple t)
        {
            return t.Magnitude;
        }

        public static Tuple Normalize(Tuple t)
        {
            return t.Normalize();
        }
        
        public static double Dot(Tuple left, Tuple right)
        {
            return left.Dot(right);
        }

        public static Tuple Cross(Tuple left, Tuple right)
        {
            return left.Cross(right);
        }
    }
}