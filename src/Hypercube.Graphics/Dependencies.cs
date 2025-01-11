using Hypercube.Graphics.Patching;
using Hypercube.Graphics.Rendering;
using Hypercube.Graphics.Rendering.Manager;
using Hypercube.Graphics.Windowing.Manager;
using Hypercube.Utilities.Dependencies;

namespace Hypercube.Graphics;

public static class Dependencies
{
    public static void Register(DependenciesContainer container)
    {
        container.Register<IWindowManager, WindowManager>();
        container.Register<IRenderManager, RenderManager>();
        
        container.Register<IPatchManager, PatchManager>();
        
        container.Register<IRenderer, Renderer>();
    }
}