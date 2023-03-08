using Codecool.MarsExploration.MapGenerator.Calculators.Model;

namespace Codecool.MarsExploration.MapExplorer.MarsRover;

public record MarsRover
{
    private string Id { get; }
    public Coordinate? CurrentPosition { get; set; }
    public int Sight { get; }
    public Dictionary<Coordinate, string>? AllScannedPositions { get; set; }
}
