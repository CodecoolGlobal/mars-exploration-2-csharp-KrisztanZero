using Codecool.MarsExploration.MapExplorer.Simulation.Model;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;
using Codecool.MarsExploration.MapExplorer.Configuration;

namespace Codecool.MarsExploration.MapExplorer.Simulation.Service;

public interface IExplorationSimulator
{
    SimulationContext ExploringSimulator(Map map, Configuration.Configuration configuration);
}