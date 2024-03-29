using System.Security.Cryptography.X509Certificates;
using Codecool.MarsExploration.MapExplorer.Configuration;
using Codecool.MarsExploration.MapExplorer.Exploration;
using Codecool.MarsExploration.MapExplorer.MapLoader;
using Codecool.MarsExploration.MapExplorer.Simulation.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;

namespace Codecool.MarsExploration.MapExplorer.Simulation.Service;

public class ExplorationSimulator
{
    private SimulationContext _simulationContext;
    private ExplorationSimulationSteps.Service.ExplorationSimulationSteps _explorationSimulationSteps;
    
   public ExplorationSimulator(MarsRover.MarsRover rover, Map map, Configuration.Configuration configuration)
   {
       _simulationContext = new SimulationContext(0, configuration.Timeout, rover, configuration.LandingCoordinates,
           map, configuration.MonitoredResources, ExplorationOutcome.Step);
       _explorationSimulationSteps =
           new ExplorationSimulationSteps.Service.ExplorationSimulationSteps(_simulationContext);
   }

    public void Run ()
    {
        while (_simulationContext.Outcome == ExplorationOutcome.Step)
        {
            _explorationSimulationSteps.Run(_simulationContext);
        }

        
        _simulationContext.Rover.CurrentPosition = _explorationSimulationSteps.RoverMovement(_simulationContext);
        
        var minerals = _simulationContext.Rover.AllScannedPositions.Count(c => c.Item2 == "*");
        var waterSources = _simulationContext.Rover.AllScannedPositions.Count(c => c.Item2 == "%");

        Console.WriteLine($"\nNumber of minerals found: {minerals}");
        Console.WriteLine($"Number of water sources: {waterSources}");
        
    }

}