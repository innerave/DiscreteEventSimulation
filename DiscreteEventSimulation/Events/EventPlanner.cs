using DiscreteEventSimulation.Events.EventTypes;
using DiscreteEventSimulation.Random;

namespace DiscreteEventSimulation.Events;

internal class EventPlanner
{
	private readonly ModelTimeManager modelTimeManager;
	private EventStatistics eventStatistics;
	private readonly UpcomingEventList upcomingEventList;
	private readonly IRandomNumberGenerator randomNumberGenerator;

	public EventPlanner(ModelTimeManager modelTimeManager, EventStatistics eventStatistics, UpcomingEventList upcomingEventList, IRandomNumberGenerator randomNumberGenerator)
	{
		this.modelTimeManager = modelTimeManager;
		this.eventStatistics = eventStatistics;
		this.upcomingEventList = upcomingEventList;
		this.randomNumberGenerator = randomNumberGenerator;
	}

	public void PlanTypeAEvent()
	{
		upcomingEventList.Add(new TypeAEvent(modelTimeManager.ModelTime + randomNumberGenerator.Next(SimulationSettings.RequestIntensity)));
	}
	
	public void PlanTypeBEvent()
	{
		upcomingEventList.Add(new TypeBEvent(modelTimeManager.ModelTime + randomNumberGenerator.Next(SimulationSettings.ServiceIntensity)));
	}
	
	public void PlanTypeCEvent()
	{
		upcomingEventList.Add(new TypeCEvent(modelTimeManager.ModelTime + SimulationSettings.StatisticsInterval));
	}
}