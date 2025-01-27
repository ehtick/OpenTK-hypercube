using Hypercube.Graphics.Rendering.Api;
using Hypercube.Mathematics;
using Hypercube.Mathematics.Shapes;

namespace Hypercube.Graphics.Rendering.Context;

public interface IRenderContext
{
    void Init(IRenderingApi api);
    void DrawRectangle(Box2 box, Color color, bool outline = false);
}