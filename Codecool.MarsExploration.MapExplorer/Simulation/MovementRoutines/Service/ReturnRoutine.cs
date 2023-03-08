using Codecool.MarsExploration.MapExplorer.Simulation.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;

namespace Codecool.MarsExploration.MapExplorer.Simulation.MovementRoutines.Service;

public class ReturnRoutine : IMovementRoutine
{
    public Coordinate NextStep(SimulationContext context)
    {
        var spaceShipLocation = context.SpaceShipLocation;

        if (spaceShipLocation.Y - 1 > 0 &&
            context.Map.Representation[spaceShipLocation.Y - 1, spaceShipLocation.X] == " ")
        {
            return new Coordinate(spaceShipLocation.X, spaceShipLocation.Y - 1);
        }
        else if (spaceShipLocation.Y + 1 > 0 &&
                 context.Map.Representation[spaceShipLocation.Y + 1, spaceShipLocation.X] == " ")
        {
            return new Coordinate(spaceShipLocation.X, spaceShipLocation.Y + 1);
        }
        else if (spaceShipLocation.X - 1 > 0 &&
                 context.Map.Representation[spaceShipLocation.Y, spaceShipLocation.X - 1] == " ")
        {
            return new Coordinate(spaceShipLocation.X - 1, spaceShipLocation.Y);
        }
        else
        {
            return new Coordinate(spaceShipLocation.X + 1, spaceShipLocation.Y);
        }
    }
}