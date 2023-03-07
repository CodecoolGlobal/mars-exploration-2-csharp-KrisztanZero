using Codecool.MarsExploration.MapExplorer.Exploration;
using Codecool.MarsExploration.MapExplorer.Simulation.Model;

namespace Codecool.MarsExploration.MapExplorer.Simulation.OutcomeAnalyzer;

public class TimeoutAnalyzer : IAnalyzer
{
    public ExplorationOutcome Outcome => ExplorationOutcome.Timeout;

    public bool Analyze(SimulationContext context)
    {
        return context.Steps >= context.StepsToTimeout;
    }
}