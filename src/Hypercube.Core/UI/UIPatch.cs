using Hypercube.Core.Graphics.Patching;
using Hypercube.Core.Graphics.Rendering;
using Hypercube.Core.Graphics.Rendering.Context;

namespace Hypercube.Core.UI;

public class UIPatch : Patch
{
    private readonly UIManager _uiManager;
    
    public override int Priority => 1000; // Рендерим UI последним
    
    public UIPatch(UIManager uiManager)
    {
        _uiManager = uiManager;
    }
    
    public override void Draw(IRenderContext renderer, DrawPayload payload)
    {
        var root = _uiManager.Root;
        
        if (!root.Visible)
            return;
        
        root.Render(renderer);
    }
}
