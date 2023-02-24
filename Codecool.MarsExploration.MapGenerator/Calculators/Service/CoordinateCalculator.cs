using Codecool.MarsExploration.MapGenerator.MapElements.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;

namespace Codecool.MarsExploration.MapGenerator.Calculators.Service;

public class CoordinateCalculator : ICoordinateCalculator
{
    private static readonly Random Random = new();

    public Coordinate GetRandomCoordinate(int dimension)
    {
        return new Coordinate(
            Random.Next(dimension),
            Random.Next(dimension)
        );
    }

    public IEnumerable<Coordinate> GetAdjacentCoordinates(Coordinate coordinate, int dimension, int reach = 1)
    {
        var adjacent = new[]
        {
            coordinate with { Y = coordinate.Y + reach },
            coordinate with { Y = coordinate.Y - reach },
            coordinate with { X = coordinate.X + reach },
            coordinate with { X = coordinate.X - reach },

        };

        return adjacent.Where(c => c.X >= 0 && c.Y >= 0 && c.X < dimension && c.Y < dimension);
    }

    public IEnumerable<Coordinate> GetAdjacentCoordinates(IEnumerable<Coordinate> coordinates, int dimension)
    {
        return coordinates.SelectMany(c => GetAdjacentCoordinates(c, dimension));
    }
}
