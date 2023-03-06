using Codecool.MarsExploration.MapExplorer.Configuration;
using Codecool.MarsExploration.MapExplorer.MapLoader;
using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Service;
using Codecool.MarsExploration.MapGenerator.Configuration.Model;
using Codecool.MarsExploration.MapGenerator.Configuration.Service;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;
using Codecool.MarsExploration.MapGenerator.MapElements.Service.Builder;
using Codecool.MarsExploration.MapGenerator.MapElements.Service.Generator;
using Codecool.MarsExploration.MapGenerator.MapElements.Service.Placer;

namespace ConfigurationValidatorTest;

public class Tests
{
    private IConfigurationValidator _configurationValidator;
    private IMapLoader _mapLoader;
    private ICoordinateCalculator _coordinateCalculator;

    private IMapGenerator _mapGenerator;

    private MapConfiguration _mapConfig;

    [SetUp]
    public void Setup()
    {
        _coordinateCalculator = new CoordinateCalculator();

        _mapLoader = new MapLoader();

        _configurationValidator = new ConfigurationValidator();
    }

    [Test]
    public void TestWhenTheValidatorIsGiveBackTrue()
    {
        var map =
            "/Users/kincsesbence/Desktop/OOP_Module_Folder/mars-exploration-2-csharp-KrisztanZero/Codecool.MarsExploration.MapExplorer/Resources/exploration-0.map";
        
        var landingCoordinates = new Coordinate(21, 10);
        
        var elementList = new List<string>() { "#", "*", "&", "%" };

        var configuration = new Configuration(map, landingCoordinates, elementList,60);
        
        var result = _configurationValidator.Validate(configuration, _mapLoader, _coordinateCalculator);
        
        Assert.IsTrue(result);
    }
}