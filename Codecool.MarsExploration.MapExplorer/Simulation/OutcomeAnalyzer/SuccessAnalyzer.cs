using Codecool.MarsExploration.MapExplorer.Exploration;
using Codecool.MarsExploration.MapExplorer.Simulation.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;

namespace Codecool.MarsExploration.MapExplorer.Simulation.OutcomeAnalyzer;

public class SuccessAnalyzer : IAnalyzer
{
    public ExplorationOutcome Outcome => ExplorationOutcome.Colonizable;

    public bool AnalyzerOutcome(SimulationContext context)
    {
        var scannedPositions = context.Rover.AllScannedPositions;
        
        var minerals = scannedPositions.Count(c => c.Item2 == "*");
        var waters = scannedPositions.Count(c => c.Item2 == "%");

        var waterNearby = scannedPositions.Any(c =>
            c.Item2 == "%" &&
            scannedPositions.Any(nc => DistanceBetween(nc.Item1, c.Item1) <= 5));
        
        var landingLocation = context.SpaceShipLocation;
        var landingNearbyWater = scannedPositions.Any(c =>
            c.Item2 == "%" && DistanceBetween(landingLocation, c.Item1) <= 10);

        return minerals >= 4 && waters >= 3 && waterNearby && landingNearbyWater;
    }

    private static int DistanceBetween(Coordinate from, Coordinate to)
    {
        var xDiff = Math.Abs(from.X - to.X);
        var yDiff = Math.Abs(from.Y - to.Y);

        return Math.Max(xDiff, yDiff);
    }
}