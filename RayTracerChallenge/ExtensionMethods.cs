namespace TDev.RayTracerChallenge;

public static class ExtensionMethods
{
    public static bool EquivalentTo(this double a, double b)
    {
        const double epsilon = 0.0001;
        return Math.Abs(a - b) < epsilon;
    }
}