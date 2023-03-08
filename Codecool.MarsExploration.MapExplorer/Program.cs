using Codecool.MarsExploration.MapExplorer.Configuration;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Service;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;

namespace Codecool.MarsExploration.MapExplorer;

class Program
{
    private static readonly string WorkDir = AppDomain.CurrentDomain.BaseDirectory;

    public static void Main(string[] args)
    {
        string mapFile = $@"{WorkDir}\Resources\exploration-0.map";
        Coordinate landingSpot = new Coordinate(6, 6);
        List<string> monitoredResources = new List<string>() { "*", "%" };
        ICoordinateCalculator coordinateCalculator = new CoordinateCalculator();
        MapLoader.MapLoader mapLoader = new MapLoader.MapLoader();

        Configuration.Configuration configuration =
            new Configuration.Configuration(mapFile, landingSpot, monitoredResources, 100);

        ConfigurationValidator configurationValidator = new ConfigurationValidator();

        Map map;
        
        if (configurationValidator.Validate(configuration, mapLoader, coordinateCalculator))
        {
            map = mapLoader.Load(mapFile);
            
            
            
            
        }
        else
        {
            Console.WriteLine("Configuration validation unsuccessful");
        }
        
        




    }
}
