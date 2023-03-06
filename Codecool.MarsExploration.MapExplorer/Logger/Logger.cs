using System.Reflection;
using System.Text;

namespace Codecool.MarsExploration.MapExplorer.Logger;

public class Logger : ILogger
{
    private StringBuilder sb = new StringBuilder();
    
    public void LogToConsole(string message)
    {
        Console.WriteLine(message);
    }

    public void LogToFile(string message, string fileName)
    {
        if (File.Exists(fileName))
        {
            throw new Exception("This file already exists!");
        }
        
        var filePath =
            @"E:\OOP\TW4\MarsExploration\mars-exploration-2-csharp-KrisztanZero\Codecool.MarsExploration.MapExplorer\LoggedFiles\";

        sb.Append(message);
        
        File.AppendAllText(filePath + $"{fileName}" + ".txt", sb.ToString());
    }
}