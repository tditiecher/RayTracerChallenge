using FluentAssertions;
using Xunit;

namespace TDev.RayTracerChallenge.Tests;

public class MatrixTests
{
    [Fact]
    public void ConstructingAndInspectingMatrix4()
    {
        Matrix4 m = new(
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
        Matrix2 m = new(
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
        Matrix3 m = new(
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
        Matrix4 m1 = new(
            1, 2, 3, 4,
            5.5, 6.5, 7.5, 8.5,
            9, 10, 11, 12,
            13.5, 14.5, 15.5, 16.5);

        Matrix4 m2 = new(
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
        Matrix4 m1 = new(
            1, 2, 3, 4,
            5.5, 6.5, 7.5, 8.5,
            9, 10, 11, 12,
            13.5, 14.5, 15.5, 16.5);

        Matrix4 m2 = new(
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
        Matrix3 m1 = new(
            1, 2, 3,
            5.5, 6.5, 7.5,
            9, 10, 11);

        Matrix3 m2 = new(
            1, 2, 3,
            5.5, 6.5, 7.5,
            9, 10, 11);

        (m1 == m2).Should().BeTrue();
        m1.GetHashCode().Should().Be(m2.GetHashCode());
    }

    [Fact]
    public void InqualityOfMatrix3()
    {
        Matrix3 m1 = new(
            5.5, 6.5, 7.5,
            1, 2, 3,
            9, 10, 11);

        Matrix3 m2 = new(
            1, 2, 3,
            5.5, 6.5, 7.5,
            9, 10, 11);

        (m1 == m2).Should().BeFalse();
        m1.GetHashCode().Should().NotBe(m2.GetHashCode());
    }

    [Fact]
    public void EqualityOfMatrix2()
    {
        Matrix2 m1 = new(
            1, 2,
            9, 10);

        Matrix2 m2 = new(
            1, 2,
            9, 10);

        (m1 == m2).Should().BeTrue();
        m1.GetHashCode().Should().Be(m2.GetHashCode());
    }

    [Fact]
    public void InqualityOfMatrix2()
    {
        Matrix2 m1 = new(
            1, 2,
            9, 10);

        Matrix2 m2 = new(
            3, 2,
            9, 10);

        (m1 == m2).Should().BeFalse();
        m1.GetHashCode().Should().NotBe(m2.GetHashCode());
    }

    [Fact]
    public void MultiplyingTwoMatrices()
    {
        Matrix4 m1 = new(
            1, 2, 3, 4,
            5, 6, 7, 8,
            9, 8, 7, 6,
            5, 4, 3, 2);

        Matrix4 m2 = new(
            -2, 1, 2, 3,
            3, 2, 1, -1,
            4, 3, 6, 5,
            1, 2, 7, 8);

        Matrix4 expected = new(
            20, 22, 50, 48,
            44, 54, 114, 108,
            40, 58, 110, 102,
            16, 26, 46, 42);

        (m1 * m2).Should().Be(expected);
    }

    [Fact]
    public void MultiplyMatrixByTuple()
    {
        Matrix4 m = new(
            1, 2, 3, 4,
            2, 4, 4, 2,
            8, 6, 4, 1,
            0, 0, 0, 1);

        Tuple t = new(1, 2, 3, 1);

        Tuple expected = new(18, 24, 33, 1);

        (m * t).Should().Be(expected);
    }

    [Fact]
    public void MultiplyingMatrixByIdentityMatrix()
    {
        Matrix4 m = new(
            0, 1, 2, 4,
            1, 2, 4, 8,
            2, 4, 8, 16,
            4, 8, 16, 32);

        (m * Matrix4.Identity).Should().Be(m);
    }


    [Fact]
    public void MultiplyingIdentityMatrixByTuple()
    {
        Tuple t = new(1, 2, 3, 4);

        (Matrix4.Identity * t).Should().Be(t);
    }

    [Fact]
    public void TransposingMatrix()
    {
        Matrix4 m = new(
            0, 9, 3, 0,
            9, 8, 0, 8,
            1, 8, 5, 3,
            0, 0, 5, 8);

        Matrix4 expected = new(
            0, 9, 1, 0,
            9, 8, 8, 0,
            3, 0, 5, 5,
            0, 8, 3, 8);

        m.Transpose().Should().Be(expected);
    }

    [Fact]
    public void TransposingIdentityMatrix()
    {
        Matrix4.Identity.Transpose().Should().Be(Matrix4.Identity);
    }
}
