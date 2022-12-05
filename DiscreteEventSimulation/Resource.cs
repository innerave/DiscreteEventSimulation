namespace DiscreteEventSimulation;

public class Resource
{
	public int MaxCapacity { get; set; } = SimulationSettings.ResourceCount;

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