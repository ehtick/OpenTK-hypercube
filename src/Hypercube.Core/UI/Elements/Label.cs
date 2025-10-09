using Hypercube.Core.Graphics.Rendering.Context;
using Hypercube.Core.Graphics.Resources;
using Hypercube.Mathematics;

namespace Hypercube.Core.UI.Elements;

public class Label : Element
{
    public Font? Font;
    public string Text = string.Empty;
    public Color Color = Color.White;
    
    public override void Render(IRenderContext context)
    {
        base.Render(context);
        
        if (Font is null)
            return;
        
        context.DrawText(Text, Font, Position, Color);
    }
}