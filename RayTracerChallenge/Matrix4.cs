namespace TDev.RayTracerChallenge;

public readonly struct Matrix4
{
    private const int Size = 4;

    private readonly double[,] _values;

    public double this[int row, int col] => _values[row, col];

    public Matrix4(
        double c00, double c01, double c02, double c03
        , double c10, double c11, double c12, double c13
        , double c20, double c21, double c22, double c23
        , double c30, double c31, double c32, double c33)
    {
        _values = new double[Size, Size];
        _values[0, 0] = c00;
        _values[0, 1] = c01;
        _values[0, 2] = c02;
        _values[0, 3] = c03;
        _values[1, 0] = c10;
        _values[1, 1] = c11;
        _values[1, 2] = c12;
        _values[1, 3] = c13;
        _values[2, 0] = c20;
        _values[2, 1] = c21;
        _values[2, 2] = c22;
        _values[2, 3] = c23;
        _values[3, 0] = c30;
        _values[3, 1] = c31;
        _values[3, 2] = c32;
        _values[3, 3] = c33;
    }

    private Matrix4(double[,] values)
    {
        _values = values;
    }

    public static Matrix4 Identity { get; } = new(
        1, 0, 0, 0,
        0, 1, 0, 0,
        0, 0, 1, 0,
        0, 0, 0, 1);

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

    public Matrix4 Multiply(Matrix4 other)
    {
        var values = new double[Size, Size];

        for (var row = 0; row < Size; row++)
        {
            for (var col = 0; col < Size; col++)
            {
                values[row, col] =
                    this[row, 0] * other[0, col] +
                    this[row, 1] * other[1, col] +
                    this[row, 2] * other[2, col] +
                    this[row, 3] * other[3, col];
            }
        }

        return new Matrix4(values);
    }

    public Tuple Multiply(Tuple tuple)
    {
        var values = new double[Size, 1];

        for (var row = 0; row < Size; row++)
        {
            for (var col = 0; col < Size; col++)
            {
                values[row, 0] =
                    this[row, 0] * tuple.X +
                    this[row, 1] * tuple.Y +
                    this[row, 2] * tuple.Z +
                    this[row, 3] * tuple.W;
            }
        }

        return new Tuple(values[0, 0], values[1, 0], values[2, 0], values[3, 0]);
    }

    public static bool operator ==(Matrix4 left, Matrix4 right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Matrix4 left, Matrix4 right)
    {
        return !(left == right);
    }

    public static Matrix4 operator *(Matrix4 left, Matrix4 right)
    {
        return left.Multiply(right);
    }

    public static Tuple operator *(Matrix4 left, Tuple right)
    {
        return left.Multiply(right);
    }
}
