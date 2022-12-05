namespace DiscreteEventSimulation;

using Events;
using Random;

internal sealed class Simulation
{
	public ModelTimeManager ModelTimeManager { get; } = new();
	public EventStatistics EventStatistics { get; } = new();
	public UpcomingEventList UpcomingEventList { get; } = new();
	
	private readonly Resource resource;

	public IRandomNumberGenerator RandomNumberGenerator { get; } = new InverseTransformSampling(new LinearCongruentialGenerator());

	private readonly SimulationSettings simulationSettings;
	
	private readonly Func<Simulation, bool> stopCondition;
	
	private readonly EventPlanner eventPlanner;

	public Simulation(SimulationSettings simulationSettings, Func<Simulation, bool> stopCondition)
	{
		this.simulationSettings = simulationSettings;
		this.stopCondition = stopCondition;
		resource = new Resource(simulationSettings.ResourceCount);
		eventPlanner = new EventPlanner(ModelTimeManager, EventStatistics, UpcomingEventList, RandomNumberGenerator, simulationSettings);
	}

	public void Run()
	{
		while (!stopCondition(this))
		{
			if (!UpcomingEventList.TryGetCriticalEvent(out var @event))
			{
				break;
			}

			ModelTimeManager.ModelTime = @event.ModelTime;
			@event.Handle(eventPlanner, EventStatistics, resource, simulationSettings);
		}
	}

	public void Add(IEvent @event)
	{
		UpcomingEventList.Add(@event);
	}
}