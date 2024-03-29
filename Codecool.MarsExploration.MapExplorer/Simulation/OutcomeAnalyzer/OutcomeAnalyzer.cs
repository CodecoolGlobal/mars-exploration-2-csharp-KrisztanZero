﻿using Codecool.MarsExploration.MapExplorer.Exploration;
using Codecool.MarsExploration.MapExplorer.Simulation.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;

namespace Codecool.MarsExploration.MapExplorer.Simulation.OutcomeAnalyzer;

public class OutcomeAnalyzer : IOutcomeAnalyzer
{
    private readonly List<IAnalyzer> _analyzers;

    public OutcomeAnalyzer()
    {
        _analyzers = new List<IAnalyzer>
        {
            
            new SuccessAnalyzer(),
            new LackOfResourcesAnalyzer(),
            new TimeoutAnalyzer(),
        };
    }

    public ExplorationOutcome Analyze(SimulationContext context)
    {
        foreach (var analyzer in _analyzers)
        {
            if (analyzer.AnalyzerOutcome(context))
            {
                return analyzer.Outcome;
            }
        }

        return ExplorationOutcome.Step;
    }
}