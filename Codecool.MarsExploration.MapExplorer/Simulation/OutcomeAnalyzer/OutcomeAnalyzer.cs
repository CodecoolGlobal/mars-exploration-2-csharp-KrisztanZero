using Codecool.MarsExploration.MapExplorer.Exploration;
using Codecool.MarsExploration.MapExplorer.Simulation.Model;

namespace Codecool.MarsExploration.MapExplorer.Simulation.OutcomeAnalyzer;

public class OutcomeAnalyzer : IOutcomeAnalyzer
{
    private readonly List<IAnalyzer> _analyzers;

    public OutcomeAnalyzer()
    {
        _analyzers = new List<IAnalyzer>
        {
            new TimeoutAnalyzer(),
            new SuccessAnalyzer(),
            new LackOfResourcesAnalyzer()
        };
    }

    public ExplorationOutcome Analyze(SimulationContext context)
    {
        foreach (var analyzer in _analyzers)
        {
            if (analyzer.Analyze(context))
            {
                return analyzer.Outcome;
            }
        }

        return ExplorationOutcome.Error;
    }
}