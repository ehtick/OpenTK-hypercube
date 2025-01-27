using Hypercube.Graphics.Patching;
using Hypercube.Graphics.Rendering;
using Hypercube.Graphics.Rendering.Context;
using Hypercube.Graphics.Rendering.Manager;
using Hypercube.Graphics.Viewports;
using Hypercube.Graphics.Windowing.Manager;
using Hypercube.Utilities.Dependencies;

namespace Hypercube.Graphics;

public static class Dependencies
{
    public static void Register(DependenciesContainer container)
    {
        container.Register<ICameraManager, CameraManager>();
        container.Register<IWindowManager, WindowManager>();
        container.Register<IRenderContext, RenderContext>();
        container.Register<IRenderManager, RenderManager>();
        container.Register<IPatchManager, PatchManager>();
        container.Register<IRenderer, Renderer>();
    }
}