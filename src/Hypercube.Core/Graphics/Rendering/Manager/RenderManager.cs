using System.Diagnostics;
using Hypercube.Core.Graphics.Rendering.Api;
using Hypercube.Core.Graphics.Rendering.Api.Handlers;
using Hypercube.Core.Graphics.Rendering.Api.Settings;
using Hypercube.Core.Graphics.Rendering.Context;
using Hypercube.Core.Graphics.Rendering.Shaders;
using Hypercube.Core.Windowing;
using Hypercube.Core.Windowing.Manager;
using Hypercube.Utilities.Debugging.Logger;
using Hypercube.Utilities.Dependencies;

namespace Hypercube.Core.Graphics.Rendering.Manager;

[EngineInternal]
[UsedImplicitly]
public sealed class RenderManager : IRenderManager, IRenderManagerInternal
{
    [Dependency] private readonly DependenciesContainer _dependenciesContainer = default!;
    [Dependency] private readonly IWindowManager _windowManager = default!;
    [Dependency] private readonly ILogger _logger = default!;
    [Dependency] private readonly IRenderContext _context = default!;

    public event DrawHandler? OnDraw;

    private IRenderingApi? _api;

    public IRenderingApi Api
    {
        get => _api ?? throw new Exception();
        private set => _api = value;
    }

    public int BatchCount => Api.BatchCount;
    public int VerticesCount => Api.VerticesCount;
    public double Fps => _fps;
    
    private readonly Stopwatch _stopwatch = new();
    private double _lastTime;
    private double _fps;
    private int _frameCount;
    private double _elapsedTime;
    
    public void Init(IContextInfo context, RenderingApiSettings settings)
    {
        Api = ApiFactory.Get(settings.Api, settings, _windowManager.Api);
        
        _dependenciesContainer.Inject(Api);

        Api.OnInit += OnInit;
        Api.OnDebugInfo += OnDebugInfo;
        Api.OnDraw += OnDraw;
        
        Api.Init(context);
        
        _context.Init(Api, _windowManager.Api);

        StartupFrameTime();
    }

    private void OnInit(string info)
    {
        _logger.Info($"Render Api ({Enum.GetName(Api.Type)}) info:\n\r{info}");
    }

    private void OnDebugInfo(string info)
    {
        _logger.Debug(info);
    }

    public void Load()
    {
        Api.Load();
    }

    public void Shutdown()
    {
        Api.Terminate();
    }

    public void Render(IWindow window)
    {
        RefreshFrameTime();
        Api.Render(window);
    }

    public IShaderProgram CreateShaderProgram(string source)
    {
        return Api.CreateShaderProgram(source);
    }

    private void StartupFrameTime()
    {
        _stopwatch.Start();
    }
    
    private void RefreshFrameTime()
    {
        var currentTime = _stopwatch.Elapsed.TotalSeconds;
        var deltaTime = currentTime - _lastTime;

        _frameCount++;
        _lastTime = currentTime;
        _elapsedTime += deltaTime;

        if (_elapsedTime < 1.0)
            return;
        
        _fps = _frameCount / _elapsedTime;
        _frameCount = 0;
        _elapsedTime = 0.0;
    }
}