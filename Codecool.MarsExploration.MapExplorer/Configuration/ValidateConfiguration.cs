using System.ComponentModel.DataAnnotations;
using Codecool.MarsExploration.MapExplorer.MapLoader;
using Codecool.MarsExploration.MapGenerator.Calculators.Service;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;

namespace Codecool.MarsExploration.MapExplorer.Configuration;

public class ConfigurationValidator : IConfigurationValidator
{
    public bool Validate(Configuration configuration, IMapLoader mapLoader, ICoordinateCalculator coordinateCalculator)
    {
        Map map = mapLoader.Load(configuration.ReadPath);
        
        if (!map.IsEmpty(configuration.LandingCoordinates))
        {
            return false;
        }

        var adjacentCoordinates = coordinateCalculator.GetAdjacentCoordinates(configuration.LandingCoordinates, map.Dimension);

        if (!adjacentCoordinates.Any(c => map.IsEmpty(c)))
        {
            return false;
        }

        if (string.IsNullOrEmpty(configuration.ReadPath))
        {
            return false;
        }

        if (!(configuration.MonitoredResources?.Any() ?? false))
        {
            return false;
        }

        if (configuration.Timeout <= 0)
        {
            return false;
        }
        
        return true;

    }
}