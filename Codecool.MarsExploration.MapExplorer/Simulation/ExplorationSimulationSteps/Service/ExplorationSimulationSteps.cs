using Codecool.MarsExploration.MapExplorer.Simulation.Model;
using Codecool.MarsExploration.MapExplorer.Simulation.MovementRoutines.Service;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;

namespace Codecool.MarsExploration.MapExplorer.Simulation.ExplorationSimulationSteps.Service;

public class ExplorationSimulationSteps 
{
    private SimulationContext _simulationContext;
    private Coordinate _currentPosition;
    private OutcomeAnalyzer.OutcomeAnalyzer _outcomeAnalyzer;
    // private int roverSight;

    public ExplorationSimulationSteps(SimulationContext simulationContext)
    {
        _simulationContext = simulationContext;

        _currentPosition = _simulationContext.Rover.CurrentPosition;
        //_roverSight = _simulationContext.MarsRover.roverSight
    }
    
    public void Run(SimulationContext context)
    {
        _currentPosition = Movement(_simulationContext);
        
        // scanning
        
        Analysis();
        
        // Log
        
        
        StepIncrement();
    }
    
    public Coordinate Movement(SimulationContext context)
    {
        IMovementRoutine routine = _simulationContext.Outcome == null ? new ExplorationRoutine() : new ReturnRoutine();
        
        return routine.NextStep(context);
    }

    public void Scanning()
    {
        
        // save all scanned areas with mapElement string
        
        throw new NotImplementedException();
    }

    public void Analysis()
    {
        _simulationContext.Outcome = _outcomeAnalyzer.Analyze(_simulationContext);
        
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