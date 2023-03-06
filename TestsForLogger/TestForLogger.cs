using Codecool.MarsExploration.MapExplorer.Logger;
using NUnit.Framework.Internal;
using Logger = Codecool.MarsExploration.MapExplorer.Logger.Logger;

namespace TestsForLogger;

public class Tests
{
    private Logger _logger;
    
    [SetUp]
    public void Setup()
    {
        _logger = new Logger();
    }

    [Test]
    public void TestForLoggingOnConsole()
    {
        var message = "Hello";
        
        _logger.LogToConsole(message);
        
        Assert.That(message, Is.EqualTo("Hello"));
    }

    [Test]
    public void TestForLoggingIntoFile()
    {
        var message = "Hello this is a file.";
        var fileName = "AnotherFileName";
        var filePath =
            $@"E:\OOP\TW4\MarsExploration\mars-exploration-2-csharp-KrisztanZero\Codecool.MarsExploration.MapExplorer\LoggedFiles\{fileName}.txt";
        _logger.LogToFile(message, fileName);
        
        Assert.That(filePath, Does.Exist);
    }
}
