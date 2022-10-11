namespace DiscreteEventSimulation.Events;

internal interface IEvent
{
    double ModelTime { get; }

    void Handle();
}
