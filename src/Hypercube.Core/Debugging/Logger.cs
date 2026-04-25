using System.Text;
using Hypercube.Utilities.Constants;
using Hypercube.Utilities.Debugging.Logger;

namespace Hypercube.Core.Debugging;

public sealed class Logger : ConsoleLogger
{
    /// <inheritdoc/>
    public override void Log(LogLevel level, string message)
    {
        if (level < LogLevel)
            return;

        var color = GetColor(level);
        
        var lines = message.Split(["\r\n", "\r", "\n"], StringSplitOptions.None);
        if (lines.Length == 0)
            return;

        var sb = new StringBuilder();
        
        sb.Append($"{color}[{level}]{Ansi.Reset} {lines[0]}{Ansi.Reset}");
        
        var secondaryPrefix = $" {color}>{Ansi.Reset} ";

        for (var i = 1; i < lines.Length; i++)
        {
            sb.Append('\n');
            sb.Append($"{secondaryPrefix}{lines[i]}{Ansi.Reset}");
        }

        Echo(sb.ToString());
    }

    /// <inheritdoc/>
    public override void Log(LogLevel level, Exception exception, string message = "")
    {
        var fullMessage = string.IsNullOrWhiteSpace(message) 
            ? exception.ToString() 
            : $"{message}\n{exception}";

        Log(level, fullMessage);
    }

    /// <inheritdoc/>
    public override string GetColor(LogLevel level)
    {
        return level switch
        {
            LogLevel.Trace => Ansi.BrightBlack,
            LogLevel.Debug => Ansi.Magenta,
            LogLevel.Info => Ansi.Green,
            LogLevel.Warning => Ansi.Yellow,
            LogLevel.Error => Ansi.Red,
            LogLevel.Critical => Ansi.BrightRed,
            _ => Ansi.Reset
        };
    }
}