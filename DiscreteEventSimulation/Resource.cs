namespace DiscreteEventSimulation;

public class Resource
{
	public int MaxCapacity { get; set; } = 1;

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