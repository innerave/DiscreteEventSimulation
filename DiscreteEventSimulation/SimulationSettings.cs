namespace DiscreteEventSimulation;

public class SimulationSettings
{
	public SimulationSettings(double requestIntensity, int resourceCount, double serviceIntensity, int queueCapacity, double simulationTime, int simulationRuns, double statisticsInterval)
	{
		RequestIntensity = requestIntensity;
		ResourceCount = resourceCount;
		ServiceIntensity = serviceIntensity;
		QueueCapacity = queueCapacity;
		SimulationTime = simulationTime;
		SimulationRuns = simulationRuns;
		StatisticsInterval = statisticsInterval;
	}

	/// <summary>
	/// Интенсивность входного потока
	/// </summary>
	public double RequestIntensity { get; }
	
	/// <summary>
	/// Число каналов обслуживания
	/// </summary>
	public int ResourceCount { get; }

	/// <summary>
	/// Интенсивность обслуживания заявок
	/// </summary>
	public double ServiceIntensity { get; }

	/// <summary>
	/// Число мест в очереди
	/// </summary>
	public int QueueCapacity { get; }

	/// <summary>
	/// Продолжительность моделирования
	/// </summary>
	public double SimulationTime { get; }

	/// <summary>
	/// Число прогонов
	/// </summary>
	public int SimulationRuns { get; }
	
	/// <summary>
	/// Интервал сбора статистики
	/// </summary>
	public double StatisticsInterval { get; }
}