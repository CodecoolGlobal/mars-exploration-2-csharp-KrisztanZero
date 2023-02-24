using Codecool.MarsExploration.MapGenerator.MapElements.Model;

namespace Codecool.MarsExploration.MapGenerator.MapElements.Service.Builder;

public interface IMapElementBuilder
{
    MapElement Build(int size, string symbol, string name, int dimensionGrowth, string? preferredLocationSymbol = null);
}
