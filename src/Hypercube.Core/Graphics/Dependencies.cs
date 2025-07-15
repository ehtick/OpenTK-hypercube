using Hypercube.Core.Graphics.Patching;
using Hypercube.Core.Graphics.Rendering;
using Hypercube.Core.Graphics.Rendering.Context;
using Hypercube.Core.Graphics.Rendering.Manager;
using Hypercube.Core.Graphics.Viewports;
using Hypercube.Core.Graphics.Windowing.Manager;
using Hypercube.Utilities.Dependencies;

namespace Hypercube.Core.Graphics;

public static class Dependencies
{
    public static void Register(DependenciesContainer container)
    {
        container.Register<IWindowManager, WindowManager>();
        container.Register<ICameraManager, CameraManager>();
        container.Register<IRenderContext, RenderContext>();
        container.Register<IRenderManager, RenderManager>();
        container.Register<IPatchManager, PatchManager>();
        container.Register<IRenderer, Renderer>();
    }
}