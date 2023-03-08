using Codecool.MarsExploration.MapExplorer.Exploration;
using Codecool.MarsExploration.MapExplorer.Simulation.Model;

namespace Codecool.MarsExploration.MapExplorer.Simulation.OutcomeAnalyzer;

public class LackOfResourcesAnalyzer : IAnalyzer
{
    public ExplorationOutcome Outcome => ExplorationOutcome.LackOfResource;

    public bool AnalyzerOutcome(SimulationContext context)
    {
        var allScannedPositions = context.Rover.AllScannedPositions;
        var edgeOfChart = context.StepsToTimeout * 5 / 100;
        
        return context.StepsToTimeout <= edgeOfChart && !allScannedPositions.Values.Contains("*") && !allScannedPositions.Values.Contains("%");
    }
}
