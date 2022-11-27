namespace DiscreteEventSimulation;

internal class EventStatistics
{
	// Заявки и в очереди и в обслуживании
	public int CurrentEventsCount { get; set; }

	public int HandledEventsCount { get; set; }

	public int RejectedEventsCount { get; set; }
	
	public Dictionary<double, int[,]> EventsCountByTime { get; set; } = new();
}