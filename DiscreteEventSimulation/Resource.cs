namespace DiscreteEventSimulation;

public class Resource
{
	private int maxCapacity = 1;

	public bool TryGetResource()
	{
		if (maxCapacity <= 0) return false;
		maxCapacity--;
		return true;
	}
	
	public void ReleaseResource()
	{
		maxCapacity++;
	}
}