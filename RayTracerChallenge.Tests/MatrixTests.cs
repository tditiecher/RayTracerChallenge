using FluentAssertions;
using Xunit;

namespace TDev.RayTracerChallenge.Tests;

public class MatrixTests
{
    [Fact]
    public void ConstructingAndInspectingMatrix4()
    {
        var m = new Matrix4(
            1, 2, 3, 4,
            5.5, 6.5, 7.5, 8.5,
            9, 10, 11, 12,
            13.5, 14.5, 15.5, 16.5);

        m[0, 0].Should().Be(1);
        m[0, 3].Should().Be(4);
        m[1, 0].Should().Be(5.5);
        m[1, 2].Should().Be(7.5);
        m[2, 2].Should().Be(11);
        m[3, 0].Should().Be(13.5);
        m[3, 2].Should().Be(15.5);
    }

    [Fact]
    public void ConstructingAndInspectingMatrix2()
    {
        var m = new Matrix2(
            -3, 5,
            1, -2);

        m[0, 0].Should().Be(-3);
        m[0, 1].Should().Be(5);
        m[1, 0].Should().Be(1);
        m[1, 1].Should().Be(-2);
    }

    [Fact]
    public void ConstructingAndInspectingMatrix3()
    {
        var m = new Matrix3(
            -3, 5, 0,
            1, -2, -7,
            0, 1, 1);

        m[0, 0].Should().Be(-3);
        m[1, 1].Should().Be(-2);
        m[2, 2].Should().Be(1);
    }

    [Fact]
    public void EqualityOfMatrix4()
    {
        var m1 = new Matrix4(
            1, 2, 3, 4,
            5.5, 6.5, 7.5, 8.5,
            9, 10, 11, 12,
            13.5, 14.5, 15.5, 16.5);

        var m2 = new Matrix4(
            1, 2, 3, 4,
            5.5, 6.5, 7.5, 8.5,
            9, 10, 11, 12,
            13.5, 14.5, 15.5, 16.5);

        (m1 == m2).Should().BeTrue();
        m1.GetHashCode().Should().Be(m2.GetHashCode());
    }

    [Fact]
    public void InqualityOfMatrix4()
    {
        var m1 = new Matrix4(
            1, 2, 3, 4,
            5.5, 6.5, 7.5, 8.5,
            9, 10, 11, 12,
            13.5, 14.5, 15.5, 16.5);

        var m2 = new Matrix4(
            1, 2, 3, 4,
            9, 10, 11, 12,
            5.5, 6.5, 7.5, 8.5,
            13.5, 14.5, 15.5, 16.5);

        (m1 == m2).Should().BeFalse();
        m1.GetHashCode().Should().NotBe(m2.GetHashCode());
    }

    [Fact]
    public void EqualityOfMatrix3()
    {
        var m1 = new Matrix3(
            1, 2, 3,
            5.5, 6.5, 7.5,
            9, 10, 11);

        var m2 = new Matrix3(
            1, 2, 3,
            5.5, 6.5, 7.5,
            9, 10, 11);

        (m1 == m2).Should().BeTrue();
        m1.GetHashCode().Should().Be(m2.GetHashCode());
    }

    [Fact]
    public void InqualityOfMatrix3()
    {
        var m1 = new Matrix3(
            5.5, 6.5, 7.5,
            1, 2, 3,
            9, 10, 11);

        var m2 = new Matrix3(
            1, 2, 3,
            5.5, 6.5, 7.5,
            9, 10, 11);

        (m1 == m2).Should().BeFalse();
        m1.GetHashCode().Should().NotBe(m2.GetHashCode());
    }

    [Fact]
    public void EqualityOfMatrix2()
    {
        var m1 = new Matrix2(
            1, 2,
            9, 10);

        var m2 = new Matrix2(
            1, 2,
            9, 10);

        (m1 == m2).Should().BeTrue();
        m1.GetHashCode().Should().Be(m2.GetHashCode());
    }

    [Fact]
    public void InqualityOfMatrix2()
    {
        var m1 = new Matrix2(
            1, 2,
            9, 10);

        var m2 = new Matrix2(
            3, 2,
            9, 10);

        (m1 == m2).Should().BeFalse();
        m1.GetHashCode().Should().NotBe(m2.GetHashCode());
    }
}
