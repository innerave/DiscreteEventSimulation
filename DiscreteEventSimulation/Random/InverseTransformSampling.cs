namespace DiscreteEventSimulation.Random;

using static Math;

internal class InverseTransformSampling
{
    private const double lambda = 1.0;

    private readonly LinearCongruentialGenerator linearCongruentialGenerator;

    public InverseTransformSampling(LinearCongruentialGenerator linearCongruentialGenerator)
    {
        this.linearCongruentialGenerator = linearCongruentialGenerator;
    }

    public double Next() => Log(1 - linearCongruentialGenerator.Next()) / -lambda;
}
