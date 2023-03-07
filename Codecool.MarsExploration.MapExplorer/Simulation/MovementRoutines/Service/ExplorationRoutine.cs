using Codecool.MarsExploration.MapExplorer.Simulation.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;

namespace Codecool.MarsExploration.MapExplorer.Simulation.MovementRoutines.Service;

public class ExplorationRoutine : IMovementRoutine
{
    public Random Random = new Random();
    
    public Coordinate NextStep(SimulationContext context)
    {
        var adjacentFreeCoordinates = GetAdjacentFreeCoordinates(context);
        int randomNumber = Random.Next(0, adjacentFreeCoordinates.Count);

        return adjacentFreeCoordinates[randomNumber];
    }

    public List<Coordinate> GetAdjacentFreeCoordinates(SimulationContext context)
    {
        var mapSize = context.Map.Representation.Length;
        var mapRepresentation = context.Map.Representation;
        List<Coordinate> adjacentFreeCoordinates = new List<Coordinate>();

        if (context.Rover.currentPosition.Y - 1 >= 0 && mapRepresentation[context.Rover.currentPosition.Y - 1, context.Rover.currentPosition.X] == " ")
        {
            var coordinate = new Coordinate(context.Rover.currentPosition.X, context.Rover.currentPosition.Y - 1);
            adjacentFreeCoordinates.Add(coordinate);
        }
        
        if (context.Rover.currentPosition.Y + 1 >= 0 && mapRepresentation[context.Rover.currentPosition.Y + 1, context.Rover.currentPosition.X] == " ")
        {
            var coordinate = new Coordinate(context.Rover.currentPosition.X, context.Rover.currentPosition.Y + 1);
            adjacentFreeCoordinates.Add(coordinate);
        }
        
        if (context.Rover.currentPosition.X - 1 >= 0 && mapRepresentation[context.Rover.currentPosition.Y, context.Rover.currentPosition.X - 1] == " ")
        {
            var coordinate = new Coordinate(context.Rover.currentPosition.X - 1, context.Rover.currentPosition.Y);
            adjacentFreeCoordinates.Add(coordinate);
        }
        
        if (context.Rover.currentPosition.X + 1 >= 0 && mapRepresentation[context.Rover.currentPosition.Y, context.Rover.currentPosition.X + 1] == " ")
        {
            var coordinate = new Coordinate(context.Rover.currentPosition.X + 1, context.Rover.currentPosition.Y);
            adjacentFreeCoordinates.Add(coordinate);
        }


        return adjacentFreeCoordinates;
    }

    
}