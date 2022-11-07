namespace DiscreteEventSimulation;

using DiscreteEventSimulation.Events;
using DiscreteEventSimulation.Random;

internal sealed class Simulation
{
	public ModelTimeManager ModelTimeManager { get; } = new();
	public EventStatistics EventStatistics { get; } = new();
	public UpcomingEventList UpcomingEventList { get; } = new();
	
	private Resource resource = new();

	private readonly IRandomNumberGenerator randomNumberGenerator = new InverseTransformSampling(new LinearCongruentialGenerator());

	private readonly Func<Simulation, bool> stopCondition;

	public Simulation(Func<Simulation, bool> stopCondition)
	{
		this.stopCondition = stopCondition;
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
			@event.Handle(UpcomingEventList, randomNumberGenerator, ModelTimeManager, EventStatistics, resource);
		}
	}

	public void Add(IEvent @event)
	{
		UpcomingEventList.Add(@event);
	}
}