using Hypercube.Graphics.Rendering.Api;
using Hypercube.Graphics.Rendering.Context;
using Hypercube.Graphics.Rendering.Shaders;
using Hypercube.Graphics.Windowing;
using Hypercube.Utilities.Debugging.Logger;
using Hypercube.Utilities.Dependencies;

namespace Hypercube.Graphics.Rendering.Manager;

public class RenderManager : IRenderManager
{
    public event DrawHandler? OnDraw;
    
    [Dependency] private readonly DependenciesContainer _dependenciesContainer = default!;
    [Dependency] private readonly ILogger _logger = default!;
    [Dependency] private readonly IRenderContext _context = default!;
    
    private IRenderingApi? _api;

    private IRenderingApi Api
    {
        get => _api ?? throw new Exception();
        set => _api = value;
    }
    
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

    public IShaderProgram CreateShaderProgram(Dictionary<ShaderType, string> shaderSources)
    {
        return Api.CreateShaderProgram(shaderSources);
    }
}