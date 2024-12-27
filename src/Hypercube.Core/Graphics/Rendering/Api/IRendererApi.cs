using Hypercube.Core.Graphics.Rendering.Enums;
using Hypercube.Mathematics;

namespace Hypercube.Core.Graphics.Rendering.Api;

public interface IRendererApi
{
    void Init();

    void Disable(Feature feature);
    void Enable(Feature feature);
    void ClearColor(Color color);
    void ClearStencil(int s);
    void SetPolygonMode(PolygonFace face, PolygonMode mode);
}