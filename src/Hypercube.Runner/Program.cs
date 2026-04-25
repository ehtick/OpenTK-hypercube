using System.Reflection;
using Hypercube.Core;
using Hypercube.Utilities.Arguments;

namespace Hypercube.Runner;

public static class Program
{
    private static readonly ArgumentParser Parser = new ArgumentParser()
        .AddOption<string>("assembly", @default: "Assembly.dll");
    
    public static void Main(string[] args)
    {
        Parser.Parse(args);
        
        var domain = Directory.GetCurrentDirectory();
        var assembly = Parser.Get<string>("assembly");
        var path = $"{domain}/{assembly}";
        
        Assembly.LoadFile(path);
        FrameworkEntering.Start(args);
    }
}
