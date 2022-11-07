﻿using DiscreteEventSimulation.Random;

namespace DiscreteEventSimulation.Events.EventTypes;

internal class TypeBEvent : IEvent
{
	public TypeBEvent(double modelTime)
	{
		ModelTime = modelTime;
	}

	public double ModelTime { get; }
	
	public void Handle(UpcomingEventList upcomingEventList, IRandomNumberGenerator randomNumberGenerator,
		ModelTimeManager modelTimeManager, EventStatistics eventStatistics, Resource resource)
	{
		eventStatistics.CurrentEventsCount -= 1;
		eventStatistics.HandledEventsCount += 1;

		if (eventStatistics.CurrentEventsCount <= 1)
		{
			upcomingEventList.Add(new TypeBEvent(modelTimeManager.ModelTime + randomNumberGenerator.Next()));
		}
		else
		{
			resource.ReleaseResource();
		}
	}
}