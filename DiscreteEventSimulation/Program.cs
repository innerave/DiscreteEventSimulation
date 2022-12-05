using System.Text;
using DiscreteEventSimulation;
using DiscreteEventSimulation.Events.EventTypes;

var simulations = Enumerable
	.Range(0, SimulationSettings.SimulationRuns)
	.Select(_ =>
	{
		var simulation = new Simulation(x => x.ModelTimeManager.ModelTime >= SimulationSettings.SimulationTime);
		simulation.Add(new TypeCEvent(0));
		simulation.Add(new TypeAEvent(simulation.RandomNumberGenerator.Next(SimulationSettings.RequestIntensity)));
		return simulation;
	})
	.ToList();

Parallel.ForEach(simulations,simulation => simulation.Run());

var results = simulations.Select(x => x.EventStatistics).ToList();

var calculatedResults = new Dictionary<double, double[]>();

foreach (var eventByTime in 
         results
	         .Select(result => result.EventsCountByTime)
	         .SelectMany(eventsCountByTime => eventsCountByTime))
{
	if (calculatedResults.ContainsKey(eventByTime.Key))
	{
		for (var i = 0; i < SimulationSettings.QueueCapacity + SimulationSettings.ResourceCount + 1; i++)
		{
			calculatedResults[eventByTime.Key][i] += eventByTime.Value[i];
		}
	}
	else
	{
		calculatedResults.Add(eventByTime.Key, eventByTime.Value);
	}
}

var averageResults = calculatedResults
	.Select(x => new
	{
		Time = x.Key,
		Values = x.Value.Select(y => y / SimulationSettings.SimulationRuns).ToArray()
	}).OrderBy(x => x.Time).ToList();


if (File.Exists("results.csv"))
{
	File.Delete("results.csv");
}
using var writer = new StreamWriter("results.csv");
var headerBuilder = new StringBuilder();
headerBuilder.Append("Time");
for (var i = 0; i < SimulationSettings.QueueCapacity + SimulationSettings.ResourceCount + 1; i++)
{
	headerBuilder.Append($",P{i}");
}
writer.WriteLine(headerBuilder.ToString());
foreach (var result in averageResults)
{
	var builder = new StringBuilder();
	builder.Append(result.Time);
	for (var i = 0; i < SimulationSettings.QueueCapacity + SimulationSettings.ResourceCount + 1; i++)
	{
		builder.Append($",{result.Values[i]}");
	}
	writer.WriteLine(builder.ToString());
}