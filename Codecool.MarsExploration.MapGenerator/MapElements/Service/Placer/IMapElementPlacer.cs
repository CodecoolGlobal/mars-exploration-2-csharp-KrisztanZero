using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;

namespace Codecool.MarsExploration.MapGenerator.MapElements.Service.Placer;

public interface IMapElementPlacer
{
    bool CanPlaceElement(MapElement element, string?[,] map, Coordinate coordinate);
    void PlaceElement(MapElement element, string?[,] map, Coordinate coordinate);
}
