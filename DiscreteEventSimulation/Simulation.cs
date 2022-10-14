namespace DiscreteEventSimulation;

using System.Linq.Expressions;
using DiscreteEventSimulation.Events;
internal sealed class Simulation
{
    public double ModelTime { get; private set; }

    public int HandledEventsCount { get; private set; }

    public int RejectedEventsCount { get; private set; }

    private readonly IUpcomingEventList upcomingEventList = new UpcomingEventList();
    private readonly Func<Simulation, bool> stopCondition;

    public Simulation(Func<Simulation, bool> stopCondition)
    {
        this.stopCondition = stopCondition;
    }

    public void Run()
    {
        while (!stopCondition(this))
        {
            if (!upcomingEventList.TryGetCriticalEvent(out var @event))
            {
                break;
            }

            ModelTime = @event.ModelTime;
            @event.Handle();
        }
    }

    public void Add(IEvent @event)
    {
        upcomingEventList.Add(@event);
    }
}