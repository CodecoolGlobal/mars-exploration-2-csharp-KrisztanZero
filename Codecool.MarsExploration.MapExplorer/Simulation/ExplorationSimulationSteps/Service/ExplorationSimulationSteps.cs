﻿using Codecool.MarsExploration.MapExplorer.Exploration;
using Codecool.MarsExploration.MapExplorer.Simulation.Model;
using Codecool.MarsExploration.MapExplorer.Simulation.MovementRoutines.Service;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;

namespace Codecool.MarsExploration.MapExplorer.Simulation.ExplorationSimulationSteps.Service;

public class ExplorationSimulationSteps
{
    private readonly SimulationContext _simulationContext;
    private readonly OutcomeAnalyzer.OutcomeAnalyzer _outcomeAnalyzer = new OutcomeAnalyzer.OutcomeAnalyzer();
    

    public ExplorationSimulationSteps(SimulationContext simulationContext)
    {
        _simulationContext = simulationContext;
    }

    public void Run(SimulationContext context)
    {
        _simulationContext.Map.Representation[
            _simulationContext.Rover.CurrentPosition.Y,
            _simulationContext.Rover.CurrentPosition.X] = ".";
        _simulationContext.Rover.CurrentPosition = RoverMovement(_simulationContext);

        ScanCoordinatesInSight();

        AnalysisOfOutcomes();

        LogEvent();

        IncrementStep();
    }

    public Coordinate RoverMovement(SimulationContext context)
    {
        IMovementRoutine routine = _simulationContext.Outcome == ExplorationOutcome.Step
            ? new ExplorationRoutine()
            : new ReturnRoutine();

        return routine.NextStep(context);
    }

    private void ScanCoordinatesInSight()
    {
        List<Coordinate> scannedCoordinates = GetScannedCoordinates(
            _simulationContext.Rover.Sight,
            _simulationContext.Rover.CurrentPosition,
            _simulationContext.Map.Representation);

        foreach (var coordinate in scannedCoordinates)
        {
            _simulationContext.Rover.AllScannedPositions
                .Add(coordinate, _simulationContext.Map.Representation[coordinate.Y, coordinate.X]);
        }
    }

    private void AnalysisOfOutcomes()
    {
        _simulationContext.Outcome = _outcomeAnalyzer.Analyze(_simulationContext);
    }

    private void LogEvent()
    {
        List<Coordinate> scannedCoordinates = GetScannedCoordinates(
            _simulationContext.Rover.Sight,
            _simulationContext.Rover.CurrentPosition,
            _simulationContext.Map.Representation);

        foreach (var coordinate in scannedCoordinates)
        {
            foreach (var resource in _simulationContext.MonitoredResources)
            {
                if (_simulationContext.Map.Representation[coordinate.Y, coordinate.X] == resource)
                {
                    string log;
                    if (_simulationContext.Outcome == ExplorationOutcome.Step)
                    {
                        log = $"" +
                                  $"STEP: {_simulationContext.Steps}; " +
                                  $"EVENT: {_simulationContext.Outcome.ToString()}; " +
                                  $"UNIT: {_simulationContext.Rover.Id};" +
                                  $"RESOURCE: {resource}; " +
                                  $"POSITION: X:{coordinate.X}, Y:{coordinate.Y}";
                    }
                    else
                    {
                        log = $"" +
                                  $"STEP: {_simulationContext.Steps}; " +
                                  $"EVENT: {_simulationContext.Outcome.ToString()}";

                    }

                    Logger.Logger logger = new Logger.Logger();
                    logger.LogToConsole(log);
                }
            }
        }
    }

    private void IncrementStep()
    {
        _simulationContext.Steps += 1;
    }

    private List<Coordinate> GetScannedCoordinates(int sight, Coordinate currentPosition, string?[,] mapRepresentation)
    {
        var scannedCoordinates = new List<Coordinate>();

        for (int i = 1; i < sight; i++)
        {
            Coordinate above =
                new Coordinate(
                    currentPosition.X,
                    currentPosition.Y - i);

            if (above.Y > 0) scannedCoordinates.Add(above);

            Coordinate below =
                new Coordinate(
                    currentPosition.X,
                    currentPosition.Y + i);

            if (below.Y < mapRepresentation.GetLength(0)) scannedCoordinates.Add(below);

            Coordinate left =
                new Coordinate(
                    currentPosition.X - i,
                    currentPosition.Y);

            if (left.X > 0) scannedCoordinates.Add(left);

            Coordinate right =
                new Coordinate(
                    currentPosition.X + i,
                    currentPosition.Y);

            if (right.Y < mapRepresentation.GetLength(0)) scannedCoordinates.Add(right);
        }

        return scannedCoordinates;
    }
}