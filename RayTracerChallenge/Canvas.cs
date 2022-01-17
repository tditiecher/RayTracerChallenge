namespace TDev.RayTracerChallenge;

public class Canvas
{
    private readonly Color[,] _pixels;

    public Canvas(int width, int height)
    {
        Width = width;
        Height = height;
        _pixels = new Color[Width, Height];

        ClearPixels();
    }

    public int Width { get; }
    public int Height { get; }

    public Color this[int x, int y]
    {
        get => _pixels[x, y];
        set => _pixels[x, y] = value;
    }

    public async Task SaveAsPortablePixelMap(string path)
    {
        const int maxColorValue = 255;

        await using var writer = File.CreateText(path);

        await writer.WriteLineAsync("P3");
        await writer.WriteLineAsync($"{Width} {Height}");
        await writer.WriteLineAsync($"{maxColorValue}");

        for (var x = 0; x < Width; x++)
        for (var y = 0; y < Height; y++)
        {
            var color = _pixels[x, y];
            var r = Convert.ToInt32(Math.Max(0, Math.Min(maxColorValue, color.Red)));
            var g = Convert.ToInt32(Math.Max(0, Math.Min(maxColorValue, color.Green)));
            var b = Convert.ToInt32(Math.Max(0, Math.Min(maxColorValue, color.Blue)));
            await writer.WriteLineAsync($"{r} {g} {b}");
        }
    }

    private void ClearPixels()
    {
        for (var x = 0; x < Width; x++)
        for (var y = 0; y < Height; y++)
            _pixels[x, y] = new Color(0, 0, 0);
    }
}
