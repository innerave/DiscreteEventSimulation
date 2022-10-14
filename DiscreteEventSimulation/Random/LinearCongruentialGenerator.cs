namespace DiscreteEventSimulation.Random;

internal sealed class LinearCongruentialGenerator : IRandomNumberGenerator
{
    private const long m = 4294967296;
    private const long a = 1664525;
    private const long c = 1013904223;
    private long x;

    public LinearCongruentialGenerator()
    {
        x = DateTime.Now.Ticks % m;
    }

    public double Next()
    {
        x = ((a * x) + c) % m;
        return (double)x / m;
    }
}
