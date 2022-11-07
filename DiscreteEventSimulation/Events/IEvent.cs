using DiscreteEventSimulation.Random;

namespace DiscreteEventSimulation.Events;

internal interface IEvent
{
	double ModelTime { get; }
	void Handle(UpcomingEventList upcomingEventList, IRandomNumberGenerator randomNumberGenerator,
		ModelTimeManager modelTimeManager, EventStatistics eventStatistics, Resource resource);
}