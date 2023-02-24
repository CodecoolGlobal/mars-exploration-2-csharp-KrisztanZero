namespace Codecool.MarsExploration.MapGenerator.Configuration.Model;

public record MapElementConfiguration(
    string Symbol,
    string Name, IEnumerable<ElementToSize> ElementsToSizes,
    int DimensionGrowth = 0,
    string? PreferredLocationSymbol = null);
