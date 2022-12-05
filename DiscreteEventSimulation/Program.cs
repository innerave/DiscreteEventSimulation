using System.Text;
using DiscreteEventSimulation;
using DiscreteEventSimulation.Events.EventTypes;
using SharpConfig;

var config = Configuration.LoadFromFile("settings.cfg");
var section = config["General"];
var requestIntensity = section["RequestIntensity"].DoubleValue;
var resourceCount = section["ResourceCount"].IntValue;
var serviceIntensity = section["ServiceIntensity"].DoubleValue;
var queueCapacity = section["QueueCapacity"].IntValue;
var simulationTime = section["SimulationTime"].DoubleValue;
var simulationRuns = section["SimulationRuns"].IntValue;
var statisticsInterval = section["StatisticsInterval"].DoubleValue;

Console.WriteLine("Request intensity: {0}", requestIntensity);
Console.WriteLine("Resource count: {0}", resourceCount);
Console.WriteLine("Service intensity: {0}", serviceIntensity);
Console.WriteLine("Queue capacity: {0}", queueCapacity);
Console.WriteLine("Simulation time: {0}", simulationTime);
Console.WriteLine("Simulation runs: {0}", simulationRuns);
Console.WriteLine("Statistics interval: {0}", statisticsInterval);

var simulationSettings = new SimulationSettings(requestIntensity, resourceCount, serviceIntensity, queueCapacity, simulationTime, simulationRuns, statisticsInterval);

var simulations = Enumerable
	.Range(0, simulationSettings.SimulationRuns)
	.Select(_ =>
	{
		var simulation = new Simulation(simulationSettings,x => x.ModelTimeManager.ModelTime >= simulationSettings.SimulationTime);
		simulation.Add(new TypeCEvent(0));
		simulation.Add(new TypeAEvent(simulation.RandomNumberGenerator.Next(simulationSettings.RequestIntensity)));
		return simulation;
	})
	.ToList();

Console.WriteLine("Starting simulation...");

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
		for (var i = 0; i < simulationSettings.QueueCapacity + simulationSettings.ResourceCount + 1; i++)
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
		Values = x.Value.Select(y => y / simulationSettings.SimulationRuns).ToArray()
	}).OrderBy(x => x.Time).ToList();

Console.WriteLine("Simulation finished");
Console.WriteLine("Writing results to file...");

if (File.Exists("results.csv"))
{
	File.Delete("results.csv");
}
using var writer = new StreamWriter("results.csv");
var headerBuilder = new StringBuilder();
headerBuilder.Append("Time");
for (var i = 0; i < simulationSettings.QueueCapacity + simulationSettings.ResourceCount + 1; i++)
{
	headerBuilder.Append($",P{i}");
}
writer.WriteLine(headerBuilder.ToString());
foreach (var result in averageResults)
{
	var builder = new StringBuilder();
	builder.Append(result.Time);
	for (var i = 0; i < simulationSettings.QueueCapacity + simulationSettings.ResourceCount + 1; i++)
	{
		builder.Append($",{result.Values[i]}");
	}
	writer.WriteLine(builder.ToString());
}

Console.WriteLine("Results written to file");