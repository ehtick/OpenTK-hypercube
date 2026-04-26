using Hypercube.Core.Graphics.Rendering;
using Hypercube.Core.Graphics.Rendering.Context;
using Hypercube.Core.Graphics.Resources;
using Hypercube.Core.Resources;
using Hypercube.Mathematics;
using Hypercube.Utilities.Dependencies;

namespace Hypercube.Core.UI.Elements;

[PublicAPI]
public sealed class Label : Element, IPostInject
{
    [Dependency] private readonly IResourceManager _resourceManager = null!;
    
    public ResourcePath Font = "/fonts/OpenSans.ttf";
    public int FontSize = FontResourceLoader.DefaultSize;
    
    public Color Color = Color.White;
    public string Text = string.Empty;
    public float Scale = 1f;

    private Font? _font;
    
    public void OnPostInject()
    {
        _font = _resourceManager.Load<Font>(Font, ("size", FontSize));
    }

    public Label()
    {
        HorizontalAlignment = Alignment.HorizontalAlignment.Left;
        VerticalAlignment = Alignment.VerticalAlignment.Top;
    }

    protected override void OnRender(IRenderContext context, DrawPayload payload)
    {
        if (_font is null || string.IsNullOrEmpty(Text))
            return;
        
        context.DrawText(Text, _font, Position, Color, Scale);
    }
}