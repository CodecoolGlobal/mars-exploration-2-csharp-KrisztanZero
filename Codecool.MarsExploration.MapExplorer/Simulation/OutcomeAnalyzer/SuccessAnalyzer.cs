using Codecool.MarsExploration.MapExplorer.Exploration;
using Codecool.MarsExploration.MapExplorer.Simulation.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;

namespace Codecool.MarsExploration.MapExplorer.Simulation.OutcomeAnalyzer;

public class SuccessAnalyzer : IAnalyzer
{
    public ExplorationOutcome Outcome => ExplorationOutcome.Colonizable;

    public bool AnalyzerOutcome(SimulationContext context)
    {
        var scannedPositions = context.Rover.AllScannedPositions ?? new Dictionary<Coordinate, string>();
        var coordinates = scannedPositions.Keys;
        var minerals = coordinates.Count(c => scannedPositions[c] == "*");
        var waters = coordinates.Count(c => scannedPositions[c] == "%");

        var waterNearby = coordinates.Any(c =>
            scannedPositions[c] == "%" &&
            coordinates.Any(nc => DistanceBetween(nc, c) <= 5 && scannedPositions[nc] == null));
        
        var landingLocation = context.SpaceShipLocation;
        var landingNearbyWater = coordinates.Any(c =>
            scannedPositions[c] == "%" && DistanceBetween(landingLocation, c) <= 10);

        return minerals >= 4 && waters >= 3 && waterNearby && landingNearbyWater;
    }

    private static int DistanceBetween(Coordinate from, Coordinate to)
    {
        var xDiff = Math.Abs(from.X - to.X);
        var yDiff = Math.Abs(from.Y - to.Y);

        return Math.Max(xDiff, yDiff);
    }
}