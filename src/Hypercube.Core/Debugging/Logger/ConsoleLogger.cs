using Hypercube.Core.Utilities.Constants;

namespace Hypercube.Core.Debugging.Logger;

public class ConsoleLogger : ILogger
{
    public LogLevel LogLevel { get; set; } = LogLevel.Trace;
    
    public void Log(LogLevel level, string message)
    {
        if (level < LogLevel)
            return;
        
        Console.WriteLine($"{GetColor(level)}[{level}] {message}{AnsiColors.Reset}");
    }

    public void Log(LogLevel level, string template, params object[] args)
    {
        if (level < LogLevel)
            return;
        
        var formattedMessage = string.Format(template, args);
        
        Console.WriteLine($"{GetColor(level)}[{level}] {formattedMessage}{AnsiColors.Reset}");
    }

    public void Log(LogLevel level, Exception exception, string message = "")
    {
        if (level < LogLevel)
            return;
        
        var fullMessage = message != string.Empty
            ? $"{message}\nException: {exception}"
            : $"Exception: {exception}";
        
        Console.WriteLine($"{GetColor(level)}[{level}] {fullMessage}{AnsiColors.Reset}");
    }

    public void Trace(string message)
    {
        Log(LogLevel.Trace, message);
    }

    public void Debug(string message)
    {
        Log(LogLevel.Debug, message);
    }

    public void Info(string message)
    {
        Log(LogLevel.Info, message);
    }

    public void Warning(string message)
    {
        Log(LogLevel.Warning, message);
    }

    public void Error(Exception exception, string message = "")
    {
        Log(LogLevel.Error, exception, message);
    }

    public void Critical(string message)
    {
        Log(LogLevel.Critical, message);
    }

    private static string GetColor(LogLevel level)
    {
        return level switch
        {
            LogLevel.Trace => AnsiColors.BrightBlack,
            LogLevel.Debug => AnsiColors.Cyan,
            LogLevel.Info => AnsiColors.White,
            LogLevel.Warning => AnsiColors.Yellow,
            LogLevel.Error => AnsiColors.Red,
            LogLevel.Critical => $"{AnsiColors.BackgroundRed}{AnsiColors.Black}",
            _ => AnsiColors.Reset
        };
    }
}