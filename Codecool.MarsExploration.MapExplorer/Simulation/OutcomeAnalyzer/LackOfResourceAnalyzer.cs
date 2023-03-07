using Codecool.MarsExploration.MapExplorer.Exploration;
using Codecool.MarsExploration.MapExplorer.Simulation.Model;

namespace Codecool.MarsExploration.MapExplorer.Simulation.OutcomeAnalyzer;

public class LackOfResourcesAnalyzer : IAnalyzer
{
    public ExplorationOutcome Outcome => ExplorationOutcome.Error;

    public bool Analyze(SimulationContext context)
    {
        var exploredRatio = (double)context.Map.Count(ElementType.Empty) / context.Map.Size;
        return exploredRatio <= 0.05; // 95% of the map has been explored
    }
}
