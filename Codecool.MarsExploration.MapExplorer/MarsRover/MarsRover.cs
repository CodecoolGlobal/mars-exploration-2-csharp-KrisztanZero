using Codecool.MarsExploration.MapGenerator.Calculators.Model;

namespace Codecool.MarsExploration.MapExplorer.MarsRover;

public record MarsRover()
{
    public string Id { get; }
    public Coordinate? CurrentPosition { get; set; }
    public int Sight { get; }
    public List<(Coordinate, string)>? AllScannedPositions { get; set; }

    public MarsRover(string id, Coordinate? currentPosition, int sight, List<(Coordinate, string)>? allScannedPositions) : this()
    {
        Id = id;
        CurrentPosition = currentPosition;
        Sight = sight;
        AllScannedPositions = allScannedPositions;
    }
}
