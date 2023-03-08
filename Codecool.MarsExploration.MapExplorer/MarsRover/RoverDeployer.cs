using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Service;

namespace Codecool.MarsExploration.MapExplorer.MarsRover;

public class RoverDeployer
{
    public static void Deploy(Configuration.Configuration configuration)
    {
        var mapLoader = new MapLoader.MapLoader();
        var map = mapLoader.Load(configuration.ReadPath);

        var initialPosition = GetInitialPosition(configuration.LandingCoordinates, map.Representation);

        // Hardwired sight can be changed later to use constructor instead
        const int sight = 3;

        var monitoredResourcesPositions = GetMonitoredResourcesPositions(map.Representation, initialPosition, sight);
        
        var marsRover = new MarsRover("rover-1", initialPosition, sight, monitoredResourcesPositions);
    }

    private static Coordinate? GetInitialPosition(Coordinate spaceshipPosition, string?[,] map)
    {
        var coordinateCalculator = new CoordinateCalculator();
        var adjacentCoordinates = coordinateCalculator.GetAdjacentCoordinates(spaceshipPosition, 1);
        
        var initialPosition = GetFirstAvailableCoordinate(map, adjacentCoordinates);
        return initialPosition;
    }
    
    private static Coordinate? GetFirstAvailableCoordinate(string?[,] map, IEnumerable<Coordinate> adjacentCoordinates)
    {
        return adjacentCoordinates.FirstOrDefault(coordinate => CanPlaceOneDimensionalElement(map, coordinate));
    }

    private static bool CanPlaceOneDimensionalElement(string?[,] map, Coordinate coordinate)
    {
        return coordinate.X >= 0
               && coordinate.X < map.GetLength(0)
               && coordinate.Y >= 0
               && coordinate.Y < map.GetLength(1)
               && map[coordinate.X, coordinate.Y] == null;
    }

    private static  IEnumerable<IEnumerable<Coordinate>> GetMonitoredResourcesPositions(string?[,] map, Coordinate initialPosition, int sight)
    {
        
        var coordinatesInSight = GetCoordinatesInSight(map, initialPosition, sight);
        var coordinatesInSightThatAreNotNull = coordinatesInSight.Where(c => true);
        
        var monitoredResourcesPositions = Enumerable.Repeat(Enumerable.Empty<Coordinate>(), 0);
        monitoredResourcesPositions = monitoredResourcesPositions.Concat(new[] { coordinatesInSightThatAreNotNull });

        return monitoredResourcesPositions;
    }

    private static IEnumerable<Coordinate> GetCoordinatesInSight(string?[,] map, object initialPosition, int sight)
    {
        throw new NotImplementedException();
    }
}