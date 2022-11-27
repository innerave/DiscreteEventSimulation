using DiscreteEventSimulation;
using DiscreteEventSimulation.Events.EventTypes;

const int numberOfExperiments = 1000;

var simulations = Enumerable
	.Range(0, numberOfExperiments)
	.Select(_ =>
	{
		var simulation = new Simulation(x => x.ModelTimeManager.ModelTime >= 1000);
		simulation.Add(new TypeAEvent(0.1));
		simulation.Add(new TypeCEvent(1));
		return simulation;
	})
	.ToList();

Parallel.ForEach(simulations,simulation => simulation.Run());

var results = simulations.Select(x => x.EventStatistics).ToList();

var averageCurrentEventsCount = results.Average(x => x.CurrentEventsCount);
var averageHandledEventsCount = results.Average(x => x.HandledEventsCount);
var averageRejectedEventsCount = results.Average(x => x.RejectedEventsCount);

var calculatedResults = new Dictionary<double, int[,]>();

foreach (var eventByTime in 
         results
	         .Select(result => result.EventsCountByTime)
	         .SelectMany(eventsCountByTime => eventsCountByTime))
{
	if (calculatedResults.ContainsKey(eventByTime.Key))
	{
		calculatedResults[eventByTime.Key][0, 0] += eventByTime.Value[0, 0];
		calculatedResults[eventByTime.Key][0, 1] += eventByTime.Value[0, 1];
		calculatedResults[eventByTime.Key][1, 0] += eventByTime.Value[1, 0];
		calculatedResults[eventByTime.Key][1, 1] += eventByTime.Value[1, 1];
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
		Values = new double[,]
		{
			{
				(double)x.Value[0, 0] / numberOfExperiments,
				(double)x.Value[0, 1] / numberOfExperiments
			},
			{
				(double)x.Value[1, 0] / numberOfExperiments,
				(double)x.Value[1, 1] / numberOfExperiments
			}
		}
	})
	.OrderBy(x => x.Time)
	.ToList();

if (File.Exists("results.csv"))
{
	File.Delete("results.csv");
}

using var writer = new StreamWriter("results.csv");
writer.WriteLine($"{nameof(averageCurrentEventsCount)},{averageCurrentEventsCount}");
writer.WriteLine($"{nameof(averageHandledEventsCount)},{averageHandledEventsCount}");
writer.WriteLine($"{nameof(averageRejectedEventsCount)},{averageRejectedEventsCount}");
writer.WriteLine();
writer.WriteLine("Time,P(0:0),P(0:1),P(1:0),P(1:1)");
foreach (var result in averageResults)
{
	writer.WriteLine($"{result.Time},{result.Values[0, 0]},{result.Values[0, 1]},{result.Values[1, 0]},{result.Values[1, 1]}");
}

