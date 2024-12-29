using Hypercube.Graphics.Enums;
using Hypercube.GraphicsApi;
using Hypercube.GraphicsApi.GlApi;
using Hypercube.GraphicsApi.Objects;
using Hypercube.Mathematics;

namespace Hypercube.Graphics.Rendering.Api;

public interface IRendererApi
{
    string Info { get; }
    
    void Init(IBindingsContext context);

    void Disable(Feature feature);
    void Enable(Feature feature);
    void ClearColor(Color color);
    void ClearStencil(int s);
    void SetPolygonMode(PolygonFace face, PolygonMode mode);
    IArrayObject GenArrayObject();
}