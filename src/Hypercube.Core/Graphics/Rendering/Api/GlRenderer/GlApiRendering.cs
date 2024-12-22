using Hypercube.Core.Debugging.Logger;
using Hypercube.Core.Dependencies;
using Hypercube.Core.Graphics.Rendering.Api.GlRenderer.Enums;
using Hypercube.Core.Graphics.Windowing.Api.GlApi;
using Hypercube.Core.Graphics.Windowing.Api.GlApi.Enum;
using Hypercube.Mathematics;

namespace Hypercube.Core.Graphics.Rendering.Api.GlRenderer;

public class GlApiRendering : IRendererApi
{
    private const int SwapInterval = 1;
    
    [Dependency] private readonly ILogger _logger = default!;
    
    public void Init()
    {
        _logger.Info(Gl.GetString(StringName.Extensions));
        _logger.Info(Gl.GetString(StringName.Vendor));
        _logger.Info(Gl.GetString(StringName.Version));
        _logger.Info(Gl.GetString(StringName.ShadingLanguageVersion));
    }
    
    public void ClearColor(Color color)
    {
        Gl.ClearColor(color);
    }

    public void ClearStencil(int s)
    {
        Gl.ClearStencil(s);
    }

    public void Clear(ClearBufferMask mask)
    {
        Gl.Clear(mask);
    }
}