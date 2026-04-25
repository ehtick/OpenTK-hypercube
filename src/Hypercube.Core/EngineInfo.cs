using System.Reflection;
using Hypercube.Utilities.Constants;

namespace Hypercube.Core;

[PublicAPI]
public static class EngineInfo
{
    public static readonly string Name = "Hypercube"; 
    public static readonly string Version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? string.Empty;
    public static readonly string Configuration = ((AssemblyConfigurationAttribute?) Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyConfigurationAttribute)))?.Configuration ?? string.Empty;
    public static readonly string WelcomeMessage =
    $"""
    {Ansi.SeroburoMalinovy256}{Ansi.Bold}[Meta]{Ansi.Reset}
    {Ansi.SeroburoMalinovy256}{Ansi.Bold} > {Ansi.Reset}Name: {Name} ({Configuration})            
    {Ansi.SeroburoMalinovy256}{Ansi.Bold} > {Ansi.Reset}Version: {Version}
    """;
}