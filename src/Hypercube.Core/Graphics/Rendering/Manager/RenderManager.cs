﻿using Hypercube.Core.Graphics.Rendering.Api;
using Hypercube.Core.Graphics.Rendering.Api.Handlers;
using Hypercube.Core.Graphics.Rendering.Api.Settings;
using Hypercube.Core.Graphics.Rendering.Context;
using Hypercube.Core.Graphics.Rendering.Shaders;
using Hypercube.Core.Graphics.Windowing;
using Hypercube.Utilities.Debugging.Logger;
using Hypercube.Utilities.Dependencies;

namespace Hypercube.Core.Graphics.Rendering.Manager;

[EngineInternal]
[UsedImplicitly]
public sealed class RenderManager : IRenderManager, IRenderManagerInternal
{
    [Dependency] private readonly DependenciesContainer _dependenciesContainer = default!;
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

    public void Init(IContextInfo context, RenderingApiSettings settings)
    {
        Api = ApiFactory.Get(settings.Api);
        
        _dependenciesContainer.Inject(Api);

        Api.OnInit += OnInit;
        Api.OnDebugInfo += OnDebugInfo;
        Api.OnDraw += OnDraw;
        
        Api.Init(context, settings);
        
        _context.Init(Api);
    }

    private void OnInit(string info, RenderingApiSettings settings)
    {
        _logger.Info($"Render Api ({Enum.GetName(settings.Api)}) info:\n\r{info}");
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
        Api.Render(window);
    }

    public IShaderProgram CreateShaderProgram(string source)
    {
        return Api.CreateShaderProgram(source);
    }
}