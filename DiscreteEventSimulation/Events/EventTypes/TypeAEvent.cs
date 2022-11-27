using DiscreteEventSimulation.Random;

namespace DiscreteEventSimulation.Events.EventTypes;

internal class TypeAEvent : IEvent
{
	public TypeAEvent(double modelTime)
	{
		ModelTime = modelTime;
	}

	public double ModelTime { get; }

	public void Handle(UpcomingEventList upcomingEventList, IRandomNumberGenerator randomNumberGenerator,
		ModelTimeManager modelTimeManager, EventStatistics eventStatistics, Resource resource)
	{
		eventStatistics.CurrentEventsCount += 1;

		if (resource.TryGetResource())
		{
			upcomingEventList.Add(new TypeBEvent(ModelTime + randomNumberGenerator.Next()));
		}
		else
		{
			if (eventStatistics.CurrentEventsCount <= 1)
			{
				
			}
			else
			{
				eventStatistics.CurrentEventsCount -= 1;
				eventStatistics.RejectedEventsCount += 1;
			}
		}
		
		upcomingEventList.Add(new TypeAEvent(ModelTime + randomNumberGenerator.Next()));
	}
}