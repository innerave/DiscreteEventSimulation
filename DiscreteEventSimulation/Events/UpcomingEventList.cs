namespace DiscreteEventSimulation.Events;

internal sealed class UpcomingEventList
{
	private readonly SortedDictionary<double, List<IEvent>> upcomingEvents = new();

	public void Add(IEvent @event)
	{
		if (upcomingEvents.TryGetValue(@event.ModelTime, out var events))
		{
			events.Add(@event);
		}
		else
		{
			upcomingEvents.Add(@event.ModelTime, new List<IEvent> { @event });
		}
	}

	public bool TryGetCriticalEvent(out IEvent @event)
	{
		if (upcomingEvents.Count == 0)
		{
			@event = default!;
			return false;
		}

		var criticalTime = upcomingEvents.Keys.First();
		var criticalEvents = upcomingEvents[criticalTime];

		@event = criticalEvents[0];
		criticalEvents.RemoveAt(0);

		if (criticalEvents.Count == 0)
		{
			upcomingEvents.Remove(criticalTime);
		}

		return true;
	}
}