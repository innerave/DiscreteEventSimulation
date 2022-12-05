namespace DiscreteEventSimulation;

internal class EventStatistics
{
	public int CurrentEventsCount { get; set; }

	public int HandledEventsCount { get; set; }

	public int RejectedEventsCount { get; set; }
	
	public Dictionary<double, double[]> EventsCountByTime { get; set; } = new();
}