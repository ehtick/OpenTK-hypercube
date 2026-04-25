using Hypercube.Core.Graphics.Rendering.Context;

namespace Hypercube.Core.UI.Elements;

public class WindowRoot : Element
{
    public override void Render(IRenderContext context)
    {
        if (!Visible)
            return;
        
        foreach (var child in Children)
        {
            if (child.Visible)
            {
                child.Render(context);
            }
        }
    }
}
