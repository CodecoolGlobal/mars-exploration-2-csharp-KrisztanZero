using Codecool.MarsExploration.MapGenerator.MapElements.Model;

namespace Codecool.MarsExploration.MapGenerator.Output.Service;

public interface IMapFileWriter
{
    void WriteMapFile(Map map, string file);
}
