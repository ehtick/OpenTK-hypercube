using Hypercube.Core.Graphics.Rendering.Context;
using Hypercube.Mathematics;
using Hypercube.Mathematics.Shapes;

namespace Hypercube.Core.UI.Elements;

[PublicAPI]
public class Rectangle : Element
{
    public Color Color = Color.White;
    
    protected override void OnRender(IRenderContext renderer, UIDrawPayload payload)
    {
        var rect = Rect2.FromSize(AbsolutePosition, AbsoluteSize);
        
        renderer.DrawRectangle(rect, Color);

        base.OnRender(renderer, payload);
    }
}
