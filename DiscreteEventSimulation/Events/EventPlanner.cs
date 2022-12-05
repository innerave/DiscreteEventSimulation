using DiscreteEventSimulation.Events.EventTypes;
using DiscreteEventSimulation.Random;

namespace DiscreteEventSimulation.Events;

internal class EventPlanner
{
	private readonly ModelTimeManager modelTimeManager;
	private EventStatistics eventStatistics;
	private readonly UpcomingEventList upcomingEventList;
	private readonly IRandomNumberGenerator randomNumberGenerator;
	private readonly SimulationSettings simulationSettings;

	public EventPlanner(ModelTimeManager modelTimeManager, EventStatistics eventStatistics, UpcomingEventList upcomingEventList, IRandomNumberGenerator randomNumberGenerator, SimulationSettings simulationSettings)
	{
		this.modelTimeManager = modelTimeManager;
		this.eventStatistics = eventStatistics;
		this.upcomingEventList = upcomingEventList;
		this.randomNumberGenerator = randomNumberGenerator;
		this.simulationSettings = simulationSettings;
	}

	public void PlanTypeAEvent()
	{
		upcomingEventList.Add(new TypeAEvent(modelTimeManager.ModelTime + randomNumberGenerator.Next(simulationSettings.RequestIntensity)));
	}
	
	public void PlanTypeBEvent()
	{
		upcomingEventList.Add(new TypeBEvent(modelTimeManager.ModelTime + randomNumberGenerator.Next(simulationSettings.ServiceIntensity)));
	}
	
	public void PlanTypeCEvent()
	{
		upcomingEventList.Add(new TypeCEvent(modelTimeManager.ModelTime + simulationSettings.StatisticsInterval));
	}
}