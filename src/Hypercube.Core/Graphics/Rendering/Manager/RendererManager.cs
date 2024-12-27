using Hypercube.Core.Dependencies;
using Hypercube.Core.Graphics.Rendering.Api;
using Hypercube.Core.Graphics.Rendering.Enums;
using Hypercube.Mathematics;
using JetBrains.Annotations;

namespace Hypercube.Core.Graphics.Rendering.Manager;

[PublicAPI]
public class RendererManager : IRendererManager
{
    [Dependency] private readonly DependenciesContainer _container = default!;
    
    private IRendererApi _rendererApi = default!;
    
    public void Init()
    {
        _rendererApi = ApiFactory.GetApi(Config.Rendering);
        _container.Inject(_rendererApi);
        
        _rendererApi.Init();
    }
    
    public void SetupRender()
    {
        _rendererApi.Enable(Feature.Blend);
        _rendererApi.Disable(Feature.ScissorTest);     
        
        //GL.BlendEquation(BlendEquationMode.FuncAdd);
        //GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
   
        _rendererApi.SetPolygonMode(PolygonFace.FrontBack, PolygonMode.Fill);        
        _rendererApi.ClearColor(Color.Black);
    }
}