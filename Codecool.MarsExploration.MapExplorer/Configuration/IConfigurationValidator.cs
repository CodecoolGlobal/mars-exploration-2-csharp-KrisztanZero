using Codecool.MarsExploration.MapExplorer.MapLoader;
using Codecool.MarsExploration.MapGenerator.Calculators.Service;

namespace Codecool.MarsExploration.MapExplorer.Configuration;

public interface IConfigurationValidator
{
    public bool Validate(Configuration configuration, IMapLoader mapLoader, ICoordinateCalculator coordinateCalculator);
}