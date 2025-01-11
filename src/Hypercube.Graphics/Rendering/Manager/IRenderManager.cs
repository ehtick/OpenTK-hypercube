using Hypercube.Graphics.Rendering.Api;
using Hypercube.Graphics.Windowing;

namespace Hypercube.Graphics.Rendering.Manager;

public interface IRenderManager
{
    void Init(IContextInfo context, RenderingApiSettings settings);
    void Shutdown();
    void Render(IWindow window);
}