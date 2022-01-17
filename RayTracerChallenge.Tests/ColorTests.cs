using FluentAssertions;
using Xunit;

namespace TDev.RayTracerChallenge.Tests;

using static Color.Static;

public class ColorTests
{
    [Fact]
    public void RedGreenBlue()
    {
        var c = Color(-0.5, 0.4, 1.7);

        c.Red.Should().Be(-0.5);
        c.Green.Should().Be(0.4);
        c.Blue.Should().Be(1.7);
    }

    [Fact]
    public void AddingColors()
    {
        var c1 = Color(0.9, 0.6, 0.75);
        var c2 = Color(0.7, 0.1, 0.25);

        (c1 + c2).Should().Be(Color(1.6, 0.7, 1.0));
    }

    [Fact]
    public void SubtractingColors()
    {
        var c1 = Color(0.9, 0.6, 0.75);
        var c2 = Color(0.7, 0.1, 0.25);

        (c1 - c2).Should().Be(Color(0.2, 0.5, 0.5));
    }

    [Fact]
    public void MultiplyingColorByScalar()
    {
        var c = Color(0.2, 0.3, 0.4);

        (c * 2).Should().Be(Color(0.4, 0.6, 0.8));
        (2 * c).Should().Be(Color(0.4, 0.6, 0.8));
    }

    [Fact]
    public void MultiplyingColors()
    {
        var c1 = Color(1, 0.2, 0.4);
        var c2 = Color(0.9, 1, 0.1);

        (c1 * c2).Should().Be(Color(0.9, 0.2, 0.04));
    }
}
