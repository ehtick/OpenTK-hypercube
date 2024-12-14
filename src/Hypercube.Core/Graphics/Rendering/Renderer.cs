using Hypercube.Core.Dependencies;
using Hypercube.Core.Graphics.Rendering.Manager;
using Hypercube.Core.Graphics.Windowing.Manager;

namespace Hypercube.Core.Graphics.Rendering;

public class Renderer : IRenderer
{
    [Dependency] private readonly IWindowManager _windowManager = default!;
    [Dependency] private readonly IRendererManager _rendererManager = default!;
    
    public void Init()
    {
        _windowManager.Init(true);
        
        var window = _windowManager.WindowCreate();
        _windowManager.WindowSetTitle(window, "...");
        
        _rendererManager.Init();
    }

    public void Terminate()
    {

    }
}