namespace DiscreteEventSimulation.Random;

using static Math;

internal class InverseTransformSampling : IRandomNumberGenerator
{
	private readonly LinearCongruentialGenerator linearCongruentialGenerator;

	public InverseTransformSampling(LinearCongruentialGenerator linearCongruentialGenerator)
	{
		this.linearCongruentialGenerator = linearCongruentialGenerator;
	}

	public double Next(double lambda) => Log(1 - linearCongruentialGenerator.Next()) / -lambda;
}
