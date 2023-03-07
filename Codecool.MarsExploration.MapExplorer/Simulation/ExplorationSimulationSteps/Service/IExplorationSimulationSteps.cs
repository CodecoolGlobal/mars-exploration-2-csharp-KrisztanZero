using Codecool.MarsExploration.MapGenerator.Calculators.Model;

namespace Codecool.MarsExploration.MapExplorer.Simulation.ExplorationSimulationSteps.Service;

public interface IExplorationSimulationSteps
{
    IEnumerable<Coordinate> Movement(Coordinate currentPosition); 
    // The rover needs to determine an adjacent empty spot of the chart to move
    // receives 

    void Scanning(Coordinate currentPosition, int roverSight); // The rover needs to scan the area for resources based on how far it can see (its sight).
    // return value list of ScanData(elementCoordinate, MapElement.Name)

    void Analysis(); 
    // received argument List<ScanData>
    // returns outcome

    void Log();
    // parameters stepcount event(position or outcome, Position coordinates)
    // return message string for Ilogger
    

    int StepIncrement(int stepCount); 
    // Increment the context step variable by one.

}