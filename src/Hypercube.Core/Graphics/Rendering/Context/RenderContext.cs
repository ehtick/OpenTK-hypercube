using Hypercube.Core.Graphics.Rendering.Api;
using Hypercube.Core.Windowing;
using Hypercube.Core.Windowing.Api;
using Hypercube.Mathematics.Shapes;

namespace Hypercube.Core.Graphics.Rendering.Context;

[EngineInternal, UsedImplicitly]
public partial class RenderContext : IRenderContext
{
    private IRenderingApi _renderingApi = default!;
    private IWindowingApi _windowingApi = default!;
    
    public void Init(IRenderingApi renderingApi, IWindowingApi windowingApi)
    {
        _renderingApi = renderingApi;
        _windowingApi = windowingApi;
    }

    public void Scissor(bool value)
    {
        _renderingApi.SetScissor(value);
    }

    public void Scissor(Rect2i rect)
    {
        _renderingApi.SetScissorRect(rect);
    }
}