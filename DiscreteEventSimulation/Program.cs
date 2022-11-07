using DiscreteEventSimulation;
using DiscreteEventSimulation.Events.EventTypes;

var simulation = new Simulation(x => x.ModelTimeManager.ModelTime > 1000);

simulation.Add(new TypeAEvent(0.1));
simulation.Run();