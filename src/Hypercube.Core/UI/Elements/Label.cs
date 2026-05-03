using Hypercube.Core.Graphics.Rendering.Context;
using Hypercube.Core.Graphics.Resources;
using Hypercube.Core.Resources;
using Hypercube.Mathematics;
using Hypercube.Mathematics.Shapes;

namespace Hypercube.Core.UI.Elements;

[PublicAPI]
public class Label : Element
{
    public string Text
    {
        get;
        set
        {
            field = value;
            UpdateLayout();
        }
    } = string.Empty;

    public ResourcePath Font
    {
        get;
        set
        {
            field = value;
            UpdateFont();
        }
    } = "/fonts/OpenSans.ttf";

    public int FontSize
    {
        get;
        set
        {
            field = value;
            UpdateFont();
        }
    } = 18;
    
    public Color FontColor = Color.White;
    public Vector2 FontAlign = Vector2.Half;
    public bool DrawDebugRect;
    
    private Font? _font;

    protected override void OnStartup()
    {
        base.OnStartup();
        
        UpdateFont(true);
    }

    protected override void OnRender(IRenderContext renderer, UIDrawPayload payload)
    {
        if (!string.IsNullOrEmpty(Text) && _font is not null)
            renderer.DrawText(Text, _font, AbsolutePosition + AbsoluteSize * AnchorPoint, FontColor, align: FontAlign);
        
        if (DrawDebugRect)
            renderer.DrawRectangle(Rect2.FromSize(AbsolutePosition, AbsoluteSize), Color.Red, true);
        
        base.OnRender(renderer, payload);
    }

    private void UpdateFont(bool force = false)
    {
        if (_font is null && !force)
            return;
        
        _font = UI.ResourceManager.Load<Font>(Font, ("size", FontSize));
    }
}
