namespace TDev.RayTracerChallenge;

public readonly struct Matrix2 : IEquatable<Matrix2>
{
    private const int Size = 2;

    private readonly double[,] _values;

    public double this[int row, int col]
    {
        get => _values[row, col];
        private init => _values[row, col] = value;
    }

    public Matrix2(
        double c00, double c01
        , double c10, double c11)
    {
        _values = new double[Size, Size];
        this[0, 0] = c00;
        this[0, 1] = c01;
        this[1, 0] = c10;
        this[1, 1] = c11;
    }

    public bool Equals(Matrix2 other)
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
        return obj is Matrix2 other && Equals(other);
    }

    public override int GetHashCode()
    {
        var r0 = HashCode.Combine(this[0, 0], this[0, 1]);
        var r1 = HashCode.Combine(this[1, 0], this[1, 1]);

        var c0 = HashCode.Combine(this[0, 0], this[1, 0]);
        var c1 = HashCode.Combine(this[0, 1], this[1, 1]);

        return HashCode.Combine(r0, r1, c0, c1);
    }

    public static bool operator ==(Matrix2 left, Matrix2 right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Matrix2 left, Matrix2 right)
    {
        return !(left == right);
    }
}
