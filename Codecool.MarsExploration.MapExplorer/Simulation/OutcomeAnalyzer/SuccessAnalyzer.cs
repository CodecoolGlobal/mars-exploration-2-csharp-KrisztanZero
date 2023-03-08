using Codecool.MarsExploration.MapExplorer.Exploration;
using Codecool.MarsExploration.MapExplorer.Simulation.Model;

namespace Codecool.MarsExploration.MapExplorer.Simulation.OutcomeAnalyzer;

public class SuccessAnalyzer : IAnalyzer
{
    public ExplorationOutcome Outcome => ExplorationOutcome.Colonizable;

    public bool AnalyzerOutcome(SimulationContext context)
    {
        // Condition 1: there is mineral within 5 empty coordinates of water
        var waterCoordinates = context.Map.GetCoordinatesOf(ElementType.Water);
        foreach (var waterCoordinate in waterCoordinates)
        {
            var nearbyMineralCoordinates = context.Map.GetNearbyCoordinates(waterCoordinate, ElementType.Mineral, 5);
            if (nearbyMineralCoordinates.Any())
            {
                return true;
            }
        }

        // Condition 2: there are 4 minerals and 3 waters found in total
        var mineralsCount = context.Map.Count(ElementType.Mineral);
        var waterCount = context.Map.Count(ElementType.Water);
        if (mineralsCount >= 4 && waterCount >= 3)
        {
            return true;
        }

        // Condition 3: there are 2 waters within 10 empty coordinates of the spaceship landing
        var landingSite = context.SpaceShipLocation;
        var nearbyWaterCoordinates = context.Map.GetNearbyCoordinates(landingSite, ElementType.Water, 10);
        if (nearbyWaterCoordinates.Count() >= 2)
        {
            return true;
        }

        // None of the conditions are met
        return false;
    }
}