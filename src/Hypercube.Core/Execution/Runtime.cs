using System.Reflection;
using Hypercube.Core.Configuration;
using Hypercube.Core.Debugging.Logger;
using Hypercube.Core.Dependencies;
using Hypercube.Core.Execution.Attributes;
using Hypercube.Core.Execution.Enums;
using Hypercube.Core.Graphics.Patching;
using Hypercube.Core.Graphics.Rendering;
using Hypercube.Core.Graphics.Rendering.Manager;
using Hypercube.Core.Graphics.Windowing.Manager;
using Hypercube.Core.Utilities.Extensions;
using Hypercube.Core.Utilities.Helpers;

namespace Hypercube.Core.Execution;

public sealed class Runtime
{
    private readonly DependenciesContainer _dependencies = new();

    [Dependency] private readonly ILogger _logger = default!;
    [Dependency] private readonly IConfigManager _configManager = default!;
    [Dependency] private readonly IRuntimeLoop _runtimeLoop = default!;
    [Dependency] private readonly IRenderer _renderer = default!;

    private readonly Dictionary<EntryPointLevel, List<MethodInfo>> _entryPoints = [];
    
    public void Start()
    {
        InitPrimaryDependencies();
        
        _logger.Echo(EngineInfo.WelcomeMessage);
        _logger.Info("Dependency initialization...");
        
        InitDependencies();

        _configManager.Init();
        
        _logger.Info("Dependency initialization is complete!");
        _logger.Info("Preparing for the execution of entry points...");

        EntryPointsLoad();
        EntryPointsExecute(EntryPointLevel.BeforeInit);
        
        _logger.Info("The entry points are called!");
        _logger.Info("Initialization of internal modules...");
        
        _renderer.Init(Config.RenderThreading);
        
        _logger.Info("Preparation is complete, start the main application cycle");
        EntryPointsExecute(EntryPointLevel.AfterInit);
        _runtimeLoop.Run();
    }

    private void InitPrimaryDependencies()
    {
        // I don't care about the fucking rules,
        // I want to put a value in the readonly field,
        // I'll fucking do it
        ReflectionHelper.SetField(this, nameof(_logger), new ConsoleLogger());
        
        _dependencies.Register<ILogger>(_logger);
    }
    
    private void InitDependencies()
    {
        _dependencies.Register<IConfigManager, ConfigManager>();
        
        _dependencies.Register<IRuntimeLoop, RuntimeLoop>();
        
        _dependencies.Register<IWindowManager, WindowManager>();
        _dependencies.Register<IRendererManager, RendererManager>();
        _dependencies.Register<IPatchManager, PatchManager>();
        _dependencies.Register<IRenderer, Renderer>();
        
        _dependencies.InstantiateAll();
        _dependencies.Inject(this);
    }

    private void EntryPointsLoad()
    {
        var methods = ReflectionHelper.GetExecutableMethodsWithAttributeFromAllAssemblies<EntryPointAttribute>(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
        foreach (var method in methods)
        {
            if (!method.IsStatic)
                throw new InvalidOperationException();
            
            var attribute = method.GetCustomAttribute<EntryPointAttribute>()!;
            _entryPoints.GetOrInstantiate(attribute.Level).Add(method);
            
            _logger.Debug($"Loaded {method.Name} entry point");
        }
    }
    
    private void EntryPointsExecute(EntryPointLevel level)
    {
        if (!_entryPoints.TryGetValue(level, out var entryPoints))
            return;
        
        foreach (var method in entryPoints)
        {
            var parameters = method.GetParameters();
            if (parameters.Length == 1)
            {
                if (parameters[0].ParameterType == typeof(DependenciesContainer))
                {
                    method.Invoke(null, [_dependencies]);
                    continue;
                }
                
                throw new InvalidOperationException();
            }
            
            method.Invoke(null, null);
        }
    }
}