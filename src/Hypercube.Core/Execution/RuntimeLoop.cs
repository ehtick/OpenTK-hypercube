using Hypercube.Core.Debugging.Logger;
using Hypercube.Core.Dependencies;
using Hypercube.Core.Graphics.Windowing.Manager;

namespace Hypercube.Core.Execution;

public sealed class RuntimeLoop : IRuntimeLoop
{
    [Dependency] private readonly ILogger _logger = default!;
    [Dependency] private readonly IWindowManager _windowManager = default!;

    public bool Running { get; private set; }

    public void Run()
    {
        if (Running)
            throw new InvalidOperationException();

        _logger.Debug("Started run loop, suspend main thread");
        
        Running = true;
        while (Running)
        {
            OnRun();
        }
        
        _logger.Debug("Shutdown run loop, unsuspend main thread");
    }

    public void Shutdown()
    {
        Running = false;
    }

    private void OnRun()
    {
        _windowManager.PollEvents();
    }
}