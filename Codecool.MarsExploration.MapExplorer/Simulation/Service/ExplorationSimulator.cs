using System.Security.Cryptography.X509Certificates;
using Codecool.MarsExploration.MapExplorer.Configuration;
using Codecool.MarsExploration.MapExplorer.MapLoader;
using Codecool.MarsExploration.MapExplorer.Simulation.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;

namespace Codecool.MarsExploration.MapExplorer.Simulation.Service;

public class ExplorationSimulator
{
    private SimulationContext _simulationContext;

   public ExplorationSimulator(MarsRover.MarsRover rover, Map map, Configuration.Configuration configuration)
   {
       _simulationContext = new SimulationContext(0, configuration.Timeout, rover, configuration.LandingCoordinates,
           map, configuration.MonitoredResources, null);
   }

    public void Run ()
    {

    }

}