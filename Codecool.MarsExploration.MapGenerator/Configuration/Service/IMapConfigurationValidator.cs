using Codecool.MarsExploration.MapGenerator.Configuration.Model;

namespace Codecool.MarsExploration.MapGenerator.Configuration.Service;

public interface IMapConfigurationValidator
{
    bool Validate(MapConfiguration mapConfig);
}
