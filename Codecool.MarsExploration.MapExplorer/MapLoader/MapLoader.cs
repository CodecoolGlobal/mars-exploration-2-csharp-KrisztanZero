using Codecool.MarsExploration.MapGenerator.MapElements.Model;

namespace Codecool.MarsExploration.MapExplorer.MapLoader;

public class MapLoader : IMapLoader
{
    public Map Load(string mapFile)
    {
        if (!File.Exists(mapFile))
        {
            throw new FileNotFoundException("The specified map file does not exist.", mapFile);
        }

        var lines = File.ReadAllLines(mapFile);

        int dimension = lines.Length;

        var representation = new string?[dimension, dimension];

        for (int y = 0; y < dimension; y++)
        {
            char[] chars = lines[y].ToCharArray();

            for (int x = 0; x < dimension; x++)
            {
                representation[x, y] = chars[x].ToString();
            }
        }

        return new Map(representation);
    }
}