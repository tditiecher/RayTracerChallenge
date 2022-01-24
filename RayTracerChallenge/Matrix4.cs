namespace TDev.RayTracerChallenge;

public readonly struct Matrix4
{
    private const int Size = 4;

    private readonly double[,] _values;

    public double this[int row, int col]
    {
        get => _values[row, col];
        private init => _values[row, col] = value;
    }

    public Matrix4(
        double c00, double c01, double c02, double c03
        , double c10, double c11, double c12, double c13
        , double c20, double c21, double c22, double c23
        , double c30, double c31, double c32, double c33)
    {
        _values = new double[Size, Size];
        this[0, 0] = c00;
        this[0, 1] = c01;
        this[0, 2] = c02;
        this[0, 3] = c03;
        this[1, 0] = c10;
        this[1, 1] = c11;
        this[1, 2] = c12;
        this[1, 3] = c13;
        this[2, 0] = c20;
        this[2, 1] = c21;
        this[2, 2] = c22;
        this[2, 3] = c23;
        this[3, 0] = c30;
        this[3, 1] = c31;
        this[3, 2] = c32;
        this[3, 3] = c33;
    }

    public bool Equals(Matrix4 other)
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
        return obj is Matrix4 other && Equals(other);
    }

    public override int GetHashCode()
    {
        var r0 = HashCode.Combine(this[0, 0], this[0, 1], this[0, 2], this[0, 3]);
        var r1 = HashCode.Combine(this[1, 0], this[1, 1], this[1, 2], this[1, 3]);
        var r2 = HashCode.Combine(this[2, 0], this[2, 1], this[2, 2], this[2, 3]);
        var r3 = HashCode.Combine(this[2, 0], this[2, 1], this[2, 2], this[3, 3]);

        var c0 = HashCode.Combine(this[0, 0], this[1, 0], this[2, 0], this[3, 0]);
        var c1 = HashCode.Combine(this[0, 1], this[1, 1], this[2, 1], this[3, 1]);
        var c2 = HashCode.Combine(this[0, 2], this[1, 2], this[2, 2], this[3, 2]);
        var c3 = HashCode.Combine(this[0, 2], this[1, 2], this[2, 2], this[3, 3]);

        return HashCode.Combine(r0, r1, r2, r3, c0, c1, c2, c3);
    }

    public static bool operator ==(Matrix4 left, Matrix4 right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Matrix4 left, Matrix4 right)
    {
        return !(left == right);
    }
}
