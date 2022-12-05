namespace DiscreteEventSimulation;

internal class ModelTimeManager
{
	private double modelTime = -1;

	public double ModelTime
	{
		get => modelTime;
		set
		{
			if (value < modelTime)
				throw new ArgumentOutOfRangeException(
					nameof(value), 
					$"Model time must be greater than the current model time ({modelTime}).");
			modelTime = value;
		}
	}

	public void ResetModelTime()
	{
		modelTime = -1;
	}
}