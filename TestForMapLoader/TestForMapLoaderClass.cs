using Codecool.MarsExploration.MapExplorer.MapLoader;
using Codecool.MarsExploration.MapGenerator.Calculators.Service;
using Codecool.MarsExploration.MapGenerator.Configuration.Model;
using Codecool.MarsExploration.MapGenerator.Configuration.Service;
using Codecool.MarsExploration.MapGenerator.MapElements.Service.Builder;
using Codecool.MarsExploration.MapGenerator.MapElements.Service.Generator;
using Codecool.MarsExploration.MapGenerator.MapElements.Service.Placer;

namespace Test_for_map_loader;

public class Tests
{
    private IMapLoader _mapLoader;

    [SetUp]
    public void Setup()
    {
        _mapLoader = new MapLoader();
    }

    [Test]
    public void TestForLoad()
    {
        var map = "E:\\OOP\\TW4\\MarsExploration\\mars-exploration-2-csharp-KrisztanZero\\Codecool.MarsExploration.MapExplorer\\Resources\\exploration-0.map";

        var mapInArray = _mapLoader.Load(map);

        var mapAsStr = File.ReadAllLines(map);
        
        Assert.That(mapInArray.Dimension, Is.EqualTo(mapAsStr.Length));
    }
}