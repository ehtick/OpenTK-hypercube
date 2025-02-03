using Hypercube.Utilities.Constants;
using Hypercube.Utilities.Helpers;
using JetBrains.Annotations;

namespace Hypercube.Core;

[PublicAPI]
public static class EngineInfo
{
    public static readonly string Name = "Hypercube"; 
    public static readonly string Version = AssemblyHelper.Version;
    public static readonly string Configuration = AssemblyHelper.Configuration;
    public static readonly string WelcomeMessage =
    $"""
    {Ansi.SeroburoMalinovy256}{Ansi.Bold}Name: {Name} ({Configuration}){Ansi.Reset}            
    {Ansi.SeroburoMalinovy256}{Ansi.Bold}Version: {Version}{Ansi.Reset}
    """;
}