using DiscreteEventSimulation;
using DiscreteEventSimulation.Random;

var sim = new Simulation(x => x.ModelTime > 1000);

sim.Run();