namespace DiscreteEventSimulation.Random;

using static Math;

internal class InverseTransformSampling : IRandomNumberGenerator
{
	private const double Lambda = 1.0;

	private readonly LinearCongruentialGenerator linearCongruentialGenerator;

	public InverseTransformSampling(LinearCongruentialGenerator linearCongruentialGenerator)
	{
		this.linearCongruentialGenerator = linearCongruentialGenerator;
	}

	public double Next() => Log(1 - linearCongruentialGenerator.Next()) / -Lambda;
}
