using Hypercube.Core.Debugging.Logger;
using Hypercube.Core.Dependencies;
using Hypercube.Core.Graphics.Api.GlApi;
using Hypercube.Core.Graphics.Api.GlApi.Enum;

namespace Hypercube.Core.Graphics.Rendering.Api.GlRenderer;

public class GlRendererApi : IRendererApi
{
    private const int SwapInterval = 1;
    
    [Dependency] private readonly ILogger _logger = default!;
    
    public void Init()
    {

    }
}