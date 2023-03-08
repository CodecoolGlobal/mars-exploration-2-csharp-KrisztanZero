using Codecool.MarsExploration.MapExplorer.Exploration;
using Codecool.MarsExploration.MapExplorer.Simulation.Model;

namespace Codecool.MarsExploration.MapExplorer.Simulation.OutcomeAnalyzer;

public interface IAnalyzer
{
    ExplorationOutcome Outcome { get; }
    bool AnalyzerOutcome(SimulationContext context);
}