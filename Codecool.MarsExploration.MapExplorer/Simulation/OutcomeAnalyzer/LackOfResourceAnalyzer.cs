using Codecool.MarsExploration.MapExplorer.Exploration;
using Codecool.MarsExploration.MapExplorer.Simulation.Model;

namespace Codecool.MarsExploration.MapExplorer.Simulation.OutcomeAnalyzer;

public class LackOfResourcesAnalyzer : IAnalyzer
{
    public ExplorationOutcome Outcome => ExplorationOutcome.LackOfResource;

    public bool AnalyzerOutcome(SimulationContext context)
    {
        var allScannedPositions = context.Rover.AllScannedPositions;
        var edgeOfChart = 50;

        
        return context.StepsToTimeout <= edgeOfChart &&  
               (from position in allScannedPositions from resource 
                   in context.MonitoredResources where position.Item2 == resource select position).Any();
    }
}
