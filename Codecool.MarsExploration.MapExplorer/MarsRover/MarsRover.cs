using Codecool.MarsExploration.MapGenerator.Calculators.Model;

namespace Codecool.MarsExploration.MapExplorer.MarsRover;

public record MarsRover(string Rover, Coordinate InitialPosition, int Sight, object O)
{
    public string Id { get; }
    public Coordinate? CurrentPosition { get; set; }
    public int Sight { get; }
    public Dictionary<Coordinate, string>? AllScannedPositions { get; set; }
}
