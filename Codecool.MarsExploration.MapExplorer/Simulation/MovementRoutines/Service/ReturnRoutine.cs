using Codecool.MarsExploration.MapExplorer.Simulation.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;

namespace Codecool.MarsExploration.MapExplorer.Simulation.MovementRoutines.Service;

public class ReturnRoutine : IMovementRoutine
{
    public Coordinate NextStep(SimulationContext context)
    {
        var spaceShipLocation = context.SpaceShipLocation;

        var y = Math.Abs(spaceShipLocation.Y - context.Rover.currentPosition.Y) == 1
            ? context.Rover.currentPosition.Y
            : spaceShipLocation.Y > context.Rover.currentPosition.Y
                ? context.Rover.currentPosition.Y + 1
                : context.Rover.currentPosition.Y - 1;

        var x = Math.Abs(spaceShipLocation.X - context.Rover.currentPosition.X) == 1
            ? context.Rover.currentPosition.X
            : spaceShipLocation.X > context.Rover.currentPosition.X
            ? context.Rover.currentPosition.X + 1
            : context.Rover.currentPosition.X - 1;

        // needs to check if cell is available
        
        // should stop movement if reaches spaceship

        return new Coordinate(x, y);
    }
}