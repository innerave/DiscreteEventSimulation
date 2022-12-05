namespace DiscreteEventSimulation.Events.EventTypes;

internal class TypeCEvent : IEvent
{
	public TypeCEvent(double modelTime)
	{
		ModelTime = modelTime;
	}
	
	public double ModelTime { get; }
	
	public void Handle(EventPlanner eventPlanner, EventStatistics eventStatistics, Resource resource)
	{
		var list = new double[SimulationSettings.QueueCapacity + SimulationSettings.ResourceCount + 1];
		list[eventStatistics.CurrentEventsCount] = 1;
		eventStatistics.EventsCountByTime.Add(ModelTime, list);
		eventPlanner.PlanTypeCEvent();
	}
}