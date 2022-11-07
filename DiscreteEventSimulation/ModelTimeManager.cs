namespace DiscreteEventSimulation;

internal class ModelTimeManager
{
	private double modelTime;

	public double ModelTime
	{
		get => modelTime;
		set
		{
			if (value < 0 || value <= modelTime)
				throw new ArgumentOutOfRangeException(
					nameof(value), 
					"Model time must be greater than 0 and greater " +
					$"than the current model time ({modelTime}).");
			modelTime = value;
		}
	}

	public void ResetModelTime()
	{
		modelTime = 0;
	}
}