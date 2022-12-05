using DiscreteEventSimulation.Random;

namespace DiscreteEventSimulation.Events;

internal interface IEvent
{
	double ModelTime { get; }
	void Handle(EventPlanner eventPlanner, EventStatistics eventStatistics, Resource resource,
		SimulationSettings simulationSettings);
}