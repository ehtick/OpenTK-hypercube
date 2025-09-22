using Hypercube.Utilities.Arguments;

namespace Hypercube.Runner;

public static class Program
{
    private static readonly ArgumentParser Parser = new ArgumentParser()
        .AddOption<string>("assembly", @default: "Assembly.dll");
    
    public static void Main(string[] args)
    {
        Parser.Parse(args);
        var assembly = Parser.Get<string>("assembly");
        // TODO: load assembly
    }
}