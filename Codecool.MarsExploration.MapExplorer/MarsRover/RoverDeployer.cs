using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Service;

namespace Codecool.MarsExploration.MapExplorer.MarsRover;

public static class RoverDeployer
{
    public static MarsRover Deploy(Configuration.Configuration configuration)
    {
        var mapLoader = new MapLoader.MapLoader();
        var map = mapLoader.Load(configuration.ReadPath);

        var initialPosition = GetInitialPosition(map.Representation, configuration.LandingCoordinates);

        // Hardwired sight can be changed later to use constructor instead
        const int sight = 3;
        
        var marsRover = new MarsRover("rover-1", initialPosition, sight, new List<(Coordinate, string)>());
        return marsRover;
    }

    private static Coordinate? GetInitialPosition(string?[,] map, Coordinate spaceshipPosition)
    {
        var coordinateCalculator = new CoordinateCalculator();
        var dimension = map.GetLength(0);
        var adjacentCoordinates = coordinateCalculator.GetAdjacentCoordinates(spaceshipPosition, dimension);
        
        var roversInitialPosition = GetFirstAvailableCoordinate(map, adjacentCoordinates);
        return roversInitialPosition;
    }
    
    private static Coordinate? GetFirstAvailableCoordinate(string?[,] map, IEnumerable<Coordinate> adjacentCoordinates)
    {
        return adjacentCoordinates.FirstOrDefault(coordinate => CanPlaceRover(map, coordinate));
    }

    // CanPlaceRover is a reused version of CanPlaceOneDimensionalElement method in MapElementPlacer.cs
    private static bool CanPlaceRover(string?[,] map, Coordinate coordinate)
    {
        return coordinate.X >= 0
               && coordinate.X < map.GetLength(0)
               && coordinate.Y >= 0
               && coordinate.Y < map.GetLength(1)
               && map[coordinate.X, coordinate.Y] == " ";
    }
}