using Hypercube.Graphics.Rendering.Api;
using Hypercube.Utilities.Dependencies;

namespace Hypercube.Graphics.Rendering.Context;

public class RenderContext : IRenderContext
{
    [Dependency] private readonly IRenderingApi _renderingApi = default!;
}