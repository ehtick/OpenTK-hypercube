using Hypercube.Core.Execution;

namespace Hypercube.Core;

public static class ApiEntering
{
    public static void Start(string[] args)
    {
        var runtime = new Runtime();
        runtime.Start();
    }
}