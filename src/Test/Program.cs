using Hypercube.Core;
using Hypercube.Core.Debugging.Logger;
using Hypercube.Core.Dependencies;
using Hypercube.Core.Execution.Attributes;
using Hypercube.Core.Execution.Enums;

namespace Test;

public static class Program
{
    public static void Main(string[] args)
    {
        FrameworkEntering.Start(args);
    }

    [EntryPoint(EntryPointLevel.AfterInit)]
    public static void EntryPoint(DependenciesContainer container)
    {
        var logger = container.Resolve<ILogger>();
        logger.Info("Hi!");
    }
}