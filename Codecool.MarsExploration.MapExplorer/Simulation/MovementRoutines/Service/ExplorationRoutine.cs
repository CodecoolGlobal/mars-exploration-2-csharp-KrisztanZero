using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;

namespace Codecool.MarsExploration.MapExplorer.Simulation.MovementRoutines.Service;

public class ExplorationRoutine : IMovementRoutine
{
    public Random Random = new Random();
    
    public Coordinate NextStep(Coordinate currentPosition, Map map)
    {
        var adjacentFreeCoordinates = GetAdjacentFreeCoordinates(currentPosition, map);
        int randomNumber = Random.Next(0, adjacentFreeCoordinates.Count);

        return adjacentFreeCoordinates[randomNumber];
    }

    public List<Coordinate> GetAdjacentFreeCoordinates(Coordinate currentPosition, Map map)
    {
        var mapSize = map.Representation.Length;
        var mapRepresentation = map.Representation;
        List<Coordinate> adjacentFreeCoordinates = new List<Coordinate>();

        if (currentPosition.Y - 1 >= 0 && mapRepresentation[currentPosition.Y - 1, currentPosition.X] == " ")
        {
            var coordinate = new Coordinate(currentPosition.X, currentPosition.Y - 1);
            adjacentFreeCoordinates.Add(coordinate);
        }
        
        if (currentPosition.Y + 1 >= 0 && mapRepresentation[currentPosition.Y + 1, currentPosition.X] == " ")
        {
            var coordinate = new Coordinate(currentPosition.X, currentPosition.Y + 1);
            adjacentFreeCoordinates.Add(coordinate);
        }
        
        if (currentPosition.X - 1 >= 0 && mapRepresentation[currentPosition.Y, currentPosition.X - 1] == " ")
        {
            var coordinate = new Coordinate(currentPosition.X - 1, currentPosition.Y);
            adjacentFreeCoordinates.Add(coordinate);
        }
        
        if (currentPosition.X + 1 >= 0 && mapRepresentation[currentPosition.Y, currentPosition.X + 1] == " ")
        {
            var coordinate = new Coordinate(currentPosition.X + 1, currentPosition.Y);
            adjacentFreeCoordinates.Add(coordinate);
        }


        return adjacentFreeCoordinates;
    }

    
}