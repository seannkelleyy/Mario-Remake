using Serilog;
using System;
using System.IO;

public class Logger
{
    private readonly ILogger _logger;

    private static Logger instance = new Logger();

    // Singleton pattern, when you need a logger, you call Logger.Instance
    public static Logger Instance
    {
        get
        {
            return instance;
        }
    }

    private Logger()
    {
        string currentDir = Directory.GetCurrentDirectory();
        string parentDir = Directory.GetParent(currentDir).FullName; // Go up 1 directory
        parentDir = Directory.GetParent(parentDir).FullName; // Go up 2 directories
        parentDir = Directory.GetParent(parentDir).FullName; // Go up 3 directories

        // Allows us to serialze the log file
        string timestamp = DateTime.Now.ToString("-MM-dd-HH-mm-ss");

        // This places log file in logs folder in Logging folder
        string logFilePath = Path.Combine(parentDir, "Logging", $"logs\\log{timestamp}.txt");
        _logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(logFilePath)
            .CreateLogger();
        _logger.Information("----Logger initialized----");
    }

    public void LogInformation(string message)
    {
        _logger.Information(message);
    }

    public void LogWarning(string message)
    {
        _logger.Warning(message);
    }

    public void LogError(string message)
    {
        _logger.Error(message);
    }

    // This is called when the game is closed
    public void Close()
    {
        Log.CloseAndFlush();
    }
}
