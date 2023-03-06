using Codecool.MarsExploration.MapGenerator.Calculators.Model;

namespace Codecool.MarsExploration.MapExplorer.Configuration
{
    public record Configuration(string ReadPath, Coordinate LandingCoordinates, IEnumerable<string> MonitoredResources, int Timeout);
}
