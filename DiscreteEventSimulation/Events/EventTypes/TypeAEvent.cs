using DiscreteEventSimulation.Random;

namespace DiscreteEventSimulation.Events.EventTypes;

internal class TypeAEvent : IEvent
{
	public TypeAEvent(double modelTime)
	{
		ModelTime = modelTime;
	}

	public double ModelTime { get; }

	public void Handle(EventPlanner eventPlanner, EventStatistics eventStatistics, Resource resource,
		SimulationSettings simulationSettings)
	{
		eventStatistics.CurrentEventsCount += 1;

		if (resource.TryGetResource())
		{
			eventPlanner.PlanTypeBEvent();
		}
		else
		{
			if (eventStatistics.CurrentEventsCount <= simulationSettings.QueueCapacity + simulationSettings.ResourceCount)
			{
				
			}
			else
			{
				eventStatistics.CurrentEventsCount -= 1;
				eventStatistics.RejectedEventsCount += 1;
			}
		}
		
		eventPlanner.PlanTypeAEvent();
	}
}