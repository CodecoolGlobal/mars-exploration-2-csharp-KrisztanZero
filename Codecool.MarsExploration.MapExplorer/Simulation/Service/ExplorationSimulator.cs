using Codecool.MarsExploration.MapExplorer.Configuration;
using Codecool.MarsExploration.MapExplorer.MapLoader;
using Codecool.MarsExploration.MapExplorer.Simulation.Model;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;

namespace Codecool.MarsExploration.MapExplorer.Simulation.Service;

public class ExplorationSimulator : IExplorationSimulator
{

    private IRoverDeployer _roverDeployer;
    private IMapLoader _mapLoader;
    private IConfigurationValidator _configurationValidator;

    public ExplorationSimulator(IRoverDeployer roverDeployer, IMapLoader mapLoader,
        IConfigurationValidator configurationValidator)
    {
        _roverDeployer = roverDeployer;
        _mapLoader = mapLoader;
        _configurationValidator = configurationValidator;
    }
    public SimulationContext ExploringSimulator(Map map, Configuration.Configuration configuration)
    {
        
    }
}