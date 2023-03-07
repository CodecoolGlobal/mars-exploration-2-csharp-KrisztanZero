using Codecool.MarsExploration.MapExplorer.Simulation.Model;
using Codecool.MarsExploration.MapExplorer.Simulation.MovementRoutines.Service;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;

namespace Codecool.MarsExploration.MapExplorer.Simulation.ExplorationSimulationSteps.Service;

public class ExplorationSimulationSteps 
{
    private SimulationContext _simulationContext;
    // private Coordinate _currentPosition;
    // private int roverSight;

    public ExplorationSimulationSteps(SimulationContext simulationContext)
    {
        _simulationContext = simulationContext;
        
        //_currentPosition = _simulationContext.MarsRover.CurrentPosition
        //_roverSight = _simulationContext.MarsRover.roverSight
    }
    
    public void Run(SimulationContext context)
    {
        // _currentPosition = Movement(_currentPosition, map)
        
        StepIncrement();
    }
    
    public void Movement(Coordinate currentPosition, Map map)
    {
        IMovementRoutine routine = _simulationContext.Outcome == null ? new ExplorationRoutine() : new ReturnRoutine();
        
        routine.NextStep(currentPosition, map);
    
    }

    public void Scanning()
    {
        
        
        throw new NotImplementedException();
    }

    public void Analysis()
    {
        throw new NotImplementedException();
    }

    public void Log()
    {
        throw new NotImplementedException();
    }

    public void StepIncrement()
    {
        _simulationContext.Steps += 1;
    }
}