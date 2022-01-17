using FluentAssertions;
using Xunit;

namespace TDev.RayTracerChallenge.Tests;

using static Color.Static;

public class CanvasTests
{
    [Fact]
    public void CreatingCanvas()
    {
        var canvas = new Canvas(10, 20);

        var black = Color(0, 0, 0);

        for (var x = 0; x < canvas.Width; x++)
        for (var y = 0; y < canvas.Height; y++)
            canvas[x, y].Should().Be(black);
    }

    [Fact]
    public void ReadingAndWritingPixels()
    {
        var canvas = new Canvas(2, 4);
        canvas[1, 3].Should().Be(Color(0, 0, 0));
        canvas[1, 3] = Color(0.5, 0.5, 0.5);
        canvas[1, 3].Should().Be(Color(0.5, 0.5, 0.5));
        canvas[1, 3] += Color(0.2, 0.2, 0.2);
        canvas[1, 3].Should().Be(Color(0.7, 0.7, 0.7));
    }

    [Fact]
    public async Task SaveAsPortablePixelMap()
    {
        var canvas = new Canvas(2, 3)
        {
            [0, 0] = Color(-1, -1, -1),
            [0, 1] = Color(255, 0, 0),
            [1, 0] = Color(0, 255, 0),
            [1, 2] = Color(300, 300, 300)
        };

        var outputFile = Path.GetTempFileName();

        await canvas.SaveAsPortablePixelMap(outputFile);

        var actualLines = await File.ReadAllLinesAsync(outputFile);

        var expectedLines = new[]
        {
            "P3",
            "2 3",
            "255",
            "0 0 0",
            "255 0 0",
            "0 0 0",
            "0 255 0",
            "0 0 0",
            "255 255 255"
        };

        actualLines.Should().Equal(expectedLines);

        File.Delete(outputFile);
    }
}