namespace TDev.RayTracerChallenge;

public readonly struct Matrix3 : IEquatable<Matrix3>
{
    private const int Size = 3;

    private readonly double[,] _values;

    public double this[int row, int col]
    {
        get => _values[row, col];
        private init => _values[row, col] = value;
    }

    public Matrix3(
        double c00, double c01, double c02
        , double c10, double c11, double c12
        , double c20, double c21, double c22)
    {
        _values = new double[Size, Size];
        this[0, 0] = c00;
        this[0, 1] = c01;
        this[0, 2] = c02;
        this[1, 0] = c10;
        this[1, 1] = c11;
        this[1, 2] = c12;
        this[2, 0] = c20;
        this[2, 1] = c21;
        this[2, 2] = c22;
    }

    public bool Equals(Matrix3 other)
    {
        for (var row = 0; row < Size; row++)
        {
            for (var col = 0; col < Size; col++)
            {
                if (!this[row, col].EquivalentTo(other[row, col]))
                {
                    return false;
                }
            }
        }

        return true;
    }

    public override bool Equals(object? obj)
    {
        return obj is Matrix3 other && Equals(other);
    }

    public override int GetHashCode()
    {
        var r0 = HashCode.Combine(this[0, 0], this[0, 1], this[0, 2]);
        var r1 = HashCode.Combine(this[1, 0], this[1, 1], this[1, 2]);
        var r2 = HashCode.Combine(this[2, 0], this[2, 1], this[2, 2]);

        var c0 = HashCode.Combine(this[0, 0], this[1, 0], this[2, 0]);
        var c1 = HashCode.Combine(this[0, 1], this[1, 1], this[2, 1]);
        var c2 = HashCode.Combine(this[0, 2], this[1, 2], this[2, 2]);

        return HashCode.Combine(r0, r1, r2, c0, c1, c2);
    }

    public static bool operator ==(Matrix3 left, Matrix3 right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Matrix3 left, Matrix3 right)
    {
        return !(left == right);
    }
}
