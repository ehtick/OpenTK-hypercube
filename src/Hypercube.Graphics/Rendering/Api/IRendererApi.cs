using Hypercube.Graphics.Enums;
using Hypercube.Mathematics;

namespace Hypercube.Graphics.Rendering.Api;

public interface IRendererApi
{
    void Init();

    void Disable(Feature feature);
    void Enable(Feature feature);
    void ClearColor(Color color);
    void ClearStencil(int s);
    void SetPolygonMode(PolygonFace face, PolygonMode mode);
}