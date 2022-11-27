using System.Runtime.CompilerServices;
using DiscreteEventSimulation.Random;

namespace DiscreteEventSimulation.Events.EventTypes;

internal class TypeCEvent : IEvent
{
	public TypeCEvent(double modelTime)
	{
		ModelTime = modelTime;
	}
	
	public double ModelTime { get; }
	
	public void Handle(UpcomingEventList upcomingEventList, IRandomNumberGenerator randomNumberGenerator,
		ModelTimeManager modelTimeManager, EventStatistics eventStatistics, Resource resource)
	{
		var list = new int[resource.MaxCapacity + 1,2];
		
		list[resource.CurrentCapacity, eventStatistics.CurrentEventsCount] = 1;

		eventStatistics.EventsCountByTime.Add(ModelTime, list);
		
		upcomingEventList.Add(new TypeCEvent(ModelTime + 1));
	}
}