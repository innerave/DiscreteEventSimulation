using DiscreteEventSimulation.Random;

var linearCongruentialGenerator = new LinearCongruentialGenerator();
var random = new InverseTransformSampling(linearCongruentialGenerator);

for (int i = 0; i < 100; i++)
{
	Console.WriteLine(random.Next());
	
}
