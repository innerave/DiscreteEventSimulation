namespace DiscreteEventSimulation.Random;

internal sealed class LinearCongruentialGenerator : IRandomNumberGenerator
{
	private const long M = 4294967296;
	private const long A = 1664525;
	private const long C = 1013904223;
	private long x;

	public LinearCongruentialGenerator()
	{
		x = DateTime.Now.Ticks % M;
	}

	public double Next()
	{
		x = (A * x + C) % M;
		return (double)x / M;
	}
}
