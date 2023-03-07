using Codecool.MarsExploration.MapExplorer.Simulation.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;

namespace Codecool.MarsExploration.MapExplorer.Simulation.MovementRoutines.Service;

public interface IMovementRoutine
{
    public Coordinate NextStep(SimulationContext context);
}    