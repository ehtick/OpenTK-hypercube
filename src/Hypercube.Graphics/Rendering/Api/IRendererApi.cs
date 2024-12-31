using Hypercube.Graphics.Enums;
using Hypercube.GraphicsApi.GlApi;
using Hypercube.GraphicsApi.GlApi.Enum;
using Hypercube.GraphicsApi.Objects;
using Hypercube.Mathematics;
using PolygonFace = Hypercube.Graphics.Enums.PolygonFace;
using PolygonMode = Hypercube.Graphics.Enums.PolygonMode;

namespace Hypercube.Graphics.Rendering.Api;

public interface IRendererApi
{
    string Info { get; }
    
    void Init(IBindingsContext context);

    void Disable(Feature feature);
    void Enable(Feature feature);
    void ClearColor(Color color);
    void Clear(ClearBufferMask mask);
    void ClearStencil(int s);
    void SetPolygonMode(PolygonFace face, PolygonMode mode);
    IArrayObject GenArrayObject();
    IBufferObject GenBufferObject(BufferTarget target);
}