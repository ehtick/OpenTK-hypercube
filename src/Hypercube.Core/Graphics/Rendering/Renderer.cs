using Hypercube.Core.Execution.LifeCycle;
using Hypercube.Core.Graphics.Patching;
using Hypercube.Core.Graphics.Rendering.Context;
using Hypercube.Core.Graphics.Rendering.Manager;
using Hypercube.Core.Windowing.Manager;
using Hypercube.Core.Windowing.Windows;
using Hypercube.Utilities.Dependencies;
using Hypercube.Utilities.Extensions;

namespace Hypercube.Core.Graphics.Rendering;

[UsedImplicitly]
[EngineInternal]
public class Renderer : IRenderer, IPostInject
{
    [Dependency] private readonly IRuntimeLoop _runtimeLoop = null!;
    [Dependency] private readonly IWindowingManager _windowingManager = null!;
    [Dependency] private readonly IRenderManager _renderManager = null!;
    [Dependency] private readonly IRenderContext _renderContext = null!;
    [Dependency] private readonly IPatchManager _patchManager = null!;
    
    private readonly ManualResetEvent _readyEvent = new(false);
    
    private Thread? _thread;
    private RendererSettings _settings;
    private IWindow? _mainWindow;

    public IWindow MainMainWindow => _mainWindow!;

    public void OnPostInject()
    {
        _runtimeLoop.Actions.Add(_ => Update(), EngineUpdatePriority.RendererUpdate);
        _runtimeLoop.Actions.Add(_ => Render(), EngineUpdatePriority.RendererRender);
    }

    public void Init(RendererSettings settings)
    {
        InitAsync(settings).Wait();
    }

    public void Load()
    {
        _renderManager.Load();
    }

    public void Shutdown()
    {
        _windowingManager.Shutdown();
        _renderManager.Shutdown();
    }

    public void Update()
    {
        _windowingManager.PollEvents();
    }

    public void Draw(DrawPayload payload)
    {
        foreach (var patch in _patchManager.Patches)
        {
            patch.Draw(_renderContext, payload);
        }   
    }

    public void Render()
    {
        if (_mainWindow is null)
            throw new Exception();
        
        _renderManager.Render(_mainWindow);
    }

    public IWindow CreateMainWindow(WindowCreateSettings settings)
    {
        if (_mainWindow is not null)
            throw new Exception();
        
        _mainWindow = _windowingManager.Create(settings);
        _mainWindow.MakeCurrent();
        
        _renderManager.Init(_mainWindow, _settings.RenderingApi);

        return _mainWindow;
    }

    private Task InitAsync(RendererSettings settings)
    {
        _settings = settings;
        _renderManager.OnDraw += Draw;

        if (_settings.Thread is not { } thread)
        {
            _windowingManager.Init(_settings.WindowingApi);
            _windowingManager.WaitInit(_settings.ReadySleepDelay);
            
            return Task.CompletedTask;
        }
        
        _thread = new Thread(OnThreadStart, thread.StackSize)
        {
            Name = thread.Name,
            Priority = thread.Priority,
            IsBackground = false
        };
        
        _thread.Start();
        
        return _readyEvent.AsTask();
    }

    private void OnThreadStart()
    {
        if (_settings.Thread is null)
            throw new InvalidOperationException();
        
        _windowingManager.Init(_settings.WindowingApi);
        _windowingManager.WaitInit(_settings.ReadySleepDelay);
        
        _readyEvent.Set();
        
        _windowingManager.EnterLoop();
    }
}