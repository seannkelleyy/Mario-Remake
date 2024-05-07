using Serilog;
using System;

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
        // Allows us to serialze the log file
        string timestamp = DateTime.Now.ToString("-MM-dd-HH-mm-ss");

        // This places log file in logs folder in Logging folder
        string logFilePath = $"../../../logging/logs/log{timestamp}.txt";
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

        //_logger.Error(message);
    }

    // This is called when the game is closed
    public void Close()
    {
        Log.CloseAndFlush();
    }
}
