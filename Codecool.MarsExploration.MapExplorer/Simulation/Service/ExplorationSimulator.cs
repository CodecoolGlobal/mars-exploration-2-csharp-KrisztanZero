using System.Security.Cryptography.X509Certificates;
using Codecool.MarsExploration.MapExplorer.Configuration;
using Codecool.MarsExploration.MapExplorer.MapLoader;
using Codecool.MarsExploration.MapExplorer.Simulation.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;

namespace Codecool.MarsExploration.MapExplorer.Simulation.Service;

public class ExplorationSimulator
{
    private Configuration.Configuration _configuration;
    private MapLoader.MapLoader _mapLoader;
    private MarsRover.MarsRover _rover;
    private string _mapFile;

   public ExplorationSimulator(MarsRover.MarsRover rover, string mapFile, Configuration.Configuration)
    {
        _rover = rover;
        _mapFile = mapFile;
    }

    public SimulationContext CreateSimulationContext(Map map, Configuration.Configuration configuration)
    {
        
        return new SimulationContext(0, configuration.Timeout, _rover, configuration.LandingCoordinates, map, configuration.MonitoredResources, null);
    }
    public SimulationContext ExploringSimulator(Map map, Configuration.Configuration configuration, SimulationContext simulationContext)
    {
        simulationContext = new SimulationContext(0, configuration.Timeout, _rover, configuration.LandingCoordinates, map, configuration.MonitoredResources, null)
        return simulationContext;
    }
}