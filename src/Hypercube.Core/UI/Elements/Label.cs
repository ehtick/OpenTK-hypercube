using Hypercube.Core.Graphics.Rendering.Context;
using Hypercube.Core.Graphics.Resources;
using Hypercube.Mathematics;

namespace Hypercube.Core.UI.Elements;

public class Label : Element
{
    private string _text = string.Empty;
    
    public Font? Font;
    public Color Color = Color.White;
    
    public string Text
    {
        get => _text;
        set
        {
            if (_text == value)
                return;
            
            _text = value ?? string.Empty;
            UpdateSize();
        }
    }
    
    public float Scale = 1f;
    
    public Label()
    {
        HorizontalAlignment = UI.Alignment.HorizontalAlignment.Left;
        VerticalAlignment = UI.Alignment.VerticalAlignment.Top;
    }
    
    protected virtual void UpdateSize()
    {
        if (Font is null || string.IsNullOrEmpty(_text))
        {
            Size = Vector2.Zero;
            return;
        }
        
        var width = 0f;
        var height = Font.LineHeight;
        
        foreach (var c in _text)
        {
            if (Font.Glyphs.TryGetValue(c, out var glyph))
            {
                width += glyph.Advance;
            }
        }
        
        Size = new Vector2(width * Scale, height * Scale);
    }
    
    public override void Render(IRenderContext context)
    {
        base.Render(context);
        
        if (!Visible || Font is null || string.IsNullOrEmpty(_text))
            return;
        
        context.DrawText(_text, Font, Position, Color, Scale);
    }
}