using Codecool.MarsExploration.MapExplorer.Exploration;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;

namespace Codecool.MarsExploration.MapExplorer.Simulation.Model;

public record SimulationContext 
    (int Steps, int StepsToTimeout, MarsRover.MarsRover Rover, 
        Coordinate SpaceShipLocation, Map Map, IEnumerable<string> MonitoredResources, ExplorationOutcome? Outcome)
{
    public int Steps { get; set; } = Steps;
    public int StepsToTimeout { get; set; } = StepsToTimeout;
    public ExplorationOutcome? Outcome { get; set; } = Outcome;
}