namespace DiscreteEventSimulation;

public static class SimulationSettings
{
	/// <summary>
	/// Интенсивность входного потока
	/// </summary>
	public static double RequestIntensity { get; set; } = 3.0;
	
	/// <summary>
	/// Число каналов обслуживания
	/// </summary>
	public static int ResourceCount { get; set; } = 2;

	/// <summary>
	/// Интенсивность обслуживания заявок
	/// </summary>
	public static double ServiceIntensity { get; set; } = 1.0;

	/// <summary>
	/// Число мест в очереди
	/// </summary>
	public static int QueueCapacity { get; set; } = 4;

	/// <summary>
	/// Продолжительность моделирования
	/// </summary>
	public static double SimulationTime { get; set; } = 4.2;

	/// <summary>
	/// Число прогонов
	/// </summary>
	public static int SimulationRuns { get; set; } = 5000;
	
	/// <summary>
	/// Интервал сбора статистики
	/// </summary>
	public static double StatisticsInterval { get; set; } = 0.005;
}