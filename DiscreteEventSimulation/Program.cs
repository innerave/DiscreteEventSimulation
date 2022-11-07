using DiscreteEventSimulation;
using DiscreteEventSimulation.Events.EventTypes;

var simulations = Enumerable
	.Range(0, 1000)
	.Select(_ =>
	{
		var simulation = new Simulation(x => x.ModelTimeManager.ModelTime >= 1000);
		simulation.Add(new TypeAEvent(0.1));
		return simulation;
	})
	.ToList();

Parallel.ForEach(simulations,simulation => simulation.Run());

var results = simulations.Select(x => x.EventStatistics).ToList();

Console.WriteLine("Average number of events: {0}", results.Average(x => x.HandledEventsCount));