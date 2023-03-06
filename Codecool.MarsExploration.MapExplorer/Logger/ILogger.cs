namespace Codecool.MarsExploration.MapExplorer.Logger;

public interface ILogger
{
    void LogToConsole(string message);

    void LogToFile(string message, string fileName);
}
