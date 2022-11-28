namespace DiscreteEventSimulation;

internal class EventStatistics
{
	public int CurrentEventsCount { get; set; }

	public int HandledEventsCount { get; set; }

	public int RejectedEventsCount { get; set; }
	
	public Dictionary<double, int[]> EventsCountByTime { get; set; } = new();
}