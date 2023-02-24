using Codecool.MarsExploration.MapGenerator.Configuration.Model;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;

namespace Codecool.MarsExploration.MapGenerator.MapElements.Service.Generator;

public interface IMapGenerator
{
    Map Generate(MapConfiguration mapConfig);
}
