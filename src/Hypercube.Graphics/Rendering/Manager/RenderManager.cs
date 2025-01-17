using Hypercube.Graphics.Rendering.Api;
using Hypercube.Graphics.Rendering.Shaders;
using Hypercube.Graphics.Windowing;
using Hypercube.Resources.Storage;
using Hypercube.Utilities.Debugging.Logger;
using Hypercube.Utilities.Dependencies;

namespace Hypercube.Graphics.Rendering.Manager;

public class RenderManager : IRenderManager
{
    [Dependency] private readonly ILogger _logger = default!;
    [Dependency] private readonly IResourceStorage _resourceStorage = default!;
    
    private IRenderingApi? _api;

    private IRenderingApi Api
    {
        get => _api ?? throw new Exception();
        set => _api = value;
    }
    
    public void Init(IContextInfo context, RenderingApiSettings settings)
    {
        Api = ApiFactory.Get(settings.Api);
        Api.OnInit += info => _logger.Info($"Render Api ({Enum.GetName(settings.Api)}) info:\n\r{info}");
        
        Api.Init(context, settings);
    }

    public void Load()
    {
        Api.Load(_resourceStorage);
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