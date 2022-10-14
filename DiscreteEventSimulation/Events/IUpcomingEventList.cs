namespace DiscreteEventSimulation.Events;

internal interface IUpcomingEventList
{
    void Add(IEvent @event);
    bool TryGetCriticalEvent(out IEvent @event);
}