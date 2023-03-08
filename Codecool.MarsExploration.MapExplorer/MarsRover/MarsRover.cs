using Codecool.MarsExploration.MapGenerator.Calculators.Model;

namespace Codecool.MarsExploration.MapExplorer.MarsRover;

public record MarsRover(string Id, Coordinate? CurrentPosition, int Sight, IEnumerable<IEnumerable<Coordinate>> MonitoredResourcesPositions);