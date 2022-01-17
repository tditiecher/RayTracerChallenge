using FluentAssertions;
using Xunit;

namespace TDev.RayTracerChallenge.Tests;

public class TupleTests
{
    [Fact]
    public void TupleWithW1IsAPoint()
    {
        var a = new Tuple(4.3, -4.2, 3.1, 1);

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
        var a = new Tuple(4.3, -4.2, 3.1, 0);

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
        var p = Tuple.Point(4, -4, 3);

        p.Should().Be(new Tuple(4, -4, 3, 1));
    }

    [Fact]
    public void VectorCreatesTupleWithW0()
    {
        var v = Tuple.Vector(4, -4, 3);

        v.Should().Be(new Tuple(4, -4, 3, 0));
    }
}