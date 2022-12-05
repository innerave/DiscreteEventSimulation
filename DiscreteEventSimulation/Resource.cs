namespace DiscreteEventSimulation;

public class Resource
{
	public Resource(int maxCapacity)
	{
		MaxCapacity = maxCapacity;
	}

	public int MaxCapacity { get; }

	public int CurrentCapacity { get; set; } = 0;

	public bool TryGetResource()
	{
		if (CurrentCapacity >= MaxCapacity) return false;
		CurrentCapacity++;
		return true;
	}
	
	public void ReleaseResource()
	{
		CurrentCapacity--;
	}
}