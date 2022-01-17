using FluentAssertions;
using Xunit;

namespace TDev.RayTracerChallenge.Tests;

using static Tuple.Static;

public class TupleTests
{
    [Fact]
    public void TupleWithW1IsAPoint()
    {
        var a = Tuple(4.3, -4.2, 3.1, 1);

        a.X.Should().Be(4.3);
        a.Y.Should().Be(-4.2);
        a.Z.Should().Be(3.1);
        a.W.Should().Be(1);
        a.IsPoint.Should().BeTrue();
        a.IsVector.Should().BeFalse();
    }

    [Fact]
    public void TupleWithW0IsAVector()
    {
        var a = Tuple(4.3, -4.2, 3.1, 0);

        a.X.Should().Be(4.3);
        a.Y.Should().Be(-4.2);
        a.Z.Should().Be(3.1);
        a.W.Should().Be(0);
        a.IsPoint.Should().BeFalse();
        a.IsVector.Should().BeTrue();
    }

    [Fact]
    public void PointCreatesTupleWithW1()
    {
        var p = Point(4, -4, 3);

        p.Should().Be(Tuple(4, -4, 3, 1));
    }

    [Fact]
    public void VectorCreatesTupleWithW0()
    {
        var v = Vector(4, -4, 3);

        v.Should().Be(Tuple(4, -4, 3, 0));
    }

    [Fact]
    public void AddingTwoTuples()
    {
        var a1 = Tuple(3, -2, 5, 1);
        var a2 = Tuple(-2, 3, 1, 0);

        a1.Add(a2).Should().Be(Tuple(1, 1, 6, 1));
        (a1 + a2).Should().Be(Tuple(1, 1, 6, 1));
    }

    [Fact]
    public void SubtractingTwoPoints()
    {
        var p1 = Point(3, 2, 1);
        var p2 = Point(5, 6, 7);

        p1.Subtract(p2).Should().Be(Vector(-2, -4, -6));
        (p1 - p2).Should().Be(Vector(-2, -4, -6));
    }

    [Fact]
    public void SubtractingVectorFromPoint()
    {
        var p = Point(3, 2, 1);
        var v = Vector(5, 6, 7);

        p.Subtract(v).Should().Be(Point(-2, -4, -6));
        (p - v).Should().Be(Point(-2, -4, -6));
    }

    [Fact]
    public void SubtractingTwoVectors()
    {
        var v1 = Vector(3, 2, 1);
        var v2 = Vector(5, 6, 7);

        v1.Subtract(v2).Should().Be(Vector(-2, -4, -6));
        (v1 - v2).Should().Be(Vector(-2, -4, -6));
    }

    [Fact]
    public void SubtractingVectorFromZeroVector()
    {
        var zero = Vector(0, 0, 0);
        var v = Vector(1, -2, 3);

        zero.Subtract(v).Should().Be(Vector(-1, 2, -3));
        (zero - v).Should().Be(Vector(-1, 2, -3));
    }

    [Fact]
    public void NegatingTuple()
    {
        var t = Tuple(1, -2, 4, -4);

        (-t).Should().Be(Tuple(-1, 2, -4, 4));
    }

    [Fact]
    public void MultiplyingTupleByScalar()
    {
        var a = Tuple(1, -2, 3, -4);

        a.Multiply(3.5).Should().Be(Tuple(3.5, -7, 10.5, -14));
        (a * 3.5).Should().Be(Tuple(3.5, -7, 10.5, -14));
        (3.5 * a).Should().Be(Tuple(3.5, -7, 10.5, -14));
    }

    [Fact]
    public void MultiplyingTupleByFraction()
    {
        var a = Tuple(1, -2, 3, -4);

        a.Multiply(0.5).Should().Be(Tuple(0.5, -1, 1.5, -2));
        (a * 0.5).Should().Be(Tuple(0.5, -1, 1.5, -2));
        (0.5 * a).Should().Be(Tuple(0.5, -1, 1.5, -2));
    }

    [Fact]
    public void DividingTupleByScalar()
    {
        var a = Tuple(1, -2, 3, -4);

        a.Divide(2).Should().Be(Tuple(0.5, -1, 1.5, -2));
        (a / 2).Should().Be(Tuple(0.5, -1, 1.5, -2));
    }

    [Fact]
    public void ComputingMagnitudeOfVector()
    {
        Magnitude(Vector(1, 0, 0)).Should().Be(1);
        Magnitude(Vector(0, 1, 0)).Should().Be(1);
        Magnitude(Vector(0, 0, 1)).Should().Be(1);
        Magnitude(Vector(1, 2, 3)).Should().Be(Math.Sqrt(14));
        Magnitude(Vector(-1, -2, -3)).Should().Be(Math.Sqrt(14));
    }

    [Fact]
    public void NormalizingVector()
    {
        Normalize(Vector(4, 0, 0)).Should().Be(Vector(1, 0, 0));
        Normalize(Vector(1, 2, 3)).Should().Be(Vector(0.26726, 0.53452, 0.80178));
    }

    [Fact]
    public void MagnitudeOfNormalizedVector()
    {
        Magnitude(Normalize(Vector(1, 2, 3))).Should().Be(1);
    }

    [Fact]
    public void DotProductOfTwoTuples()
    {
        var a = Vector(1, 2, 3);
        var b = Vector(2, 3, 4);

        Dot(a, b).Should().Be(20);
        Dot(a, b).Should().Be(20);
    }

    [Fact]
    public void CrossProductOfTwoVectors()
    {
        var a = Vector(1, 2, 3);
        var b = Vector(2, 3, 4);

        Cross(a, b).Should().Be(Vector(-1, 2, -1));
        Cross(b, a).Should().Be(Vector(1, -2, 1));
    }
}
