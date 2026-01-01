using Hypercube.Core.Execution;

namespace Hypercube.Core;

public static class FrameworkEntering
{
    public static void Start(string[] args)
    {
        var runtime = new Runtime();
        runtime.Start(args);
    }
}
