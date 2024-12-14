using Hypercube.Core.Dependencies;
using Hypercube.Core.Graphics.Rendering.Api;
using Hypercube.Core.Graphics.Rendering.Api.GlRenderer;
using JetBrains.Annotations;

namespace Hypercube.Core.Graphics.Rendering.Manager;

[PublicAPI]
public class RendererManager : IRendererManager
{
    [Dependency] private readonly DependenciesContainer _container = default!;
    
    private IRendererApi _rendererApi = default!;
    
    public void Init()
    {
        _rendererApi = new GlRendererApi();
        _container.Inject(_rendererApi);
        
        _rendererApi.Init();
    }
}