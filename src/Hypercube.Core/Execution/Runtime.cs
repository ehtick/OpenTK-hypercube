using Hypercube.Core.Debugging.Logger;
using Hypercube.Core.Dependencies;
using Hypercube.Core.Graphics.Rendering;
using Hypercube.Core.Graphics.Rendering.Manager;
using Hypercube.Core.Graphics.Windowing.Manager;

namespace Hypercube.Core.Execution;

public sealed class Runtime
{
    private readonly DependenciesContainer _dependencies = new();

    [Dependency] private readonly ILogger _logger = default!;
    [Dependency] private readonly IRuntimeLoop _runtimeLoop = default!;
    [Dependency] private readonly IRenderer _renderer = default!;
    
    public void Start()
    {
        InitDependencies();
        
        _logger.Info("Runtime started");
        
        _renderer.Init();
        _runtimeLoop.Run();
    }
    
    private void InitDependencies()
    {
        _dependencies.Register<ILogger, ConsoleLogger>();
        _dependencies.Register<IRuntimeLoop, RuntimeLoop>();
        _dependencies.Register<IWindowManager, WindowManager>();
        _dependencies.Register<IRendererManager, RendererManager>();
        _dependencies.Register<IRenderer, Renderer>();
        
        _dependencies.InstantiateAll();
        _dependencies.Inject(this);
    }
}