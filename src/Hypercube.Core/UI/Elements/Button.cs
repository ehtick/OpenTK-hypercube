using Hypercube.Core.Graphics.Rendering.Context;
using Hypercube.Core.Graphics.Resources;
using Hypercube.Mathematics;
using Hypercube.Mathematics.Shapes;

namespace Hypercube.Core.UI.Elements;

public class Button : Element
{
    private string _text = string.Empty;
    private ButtonState _state = ButtonState.Normal;
    
    public Font? Font;
    public Color TextColor = Color.White;
    public Color BackgroundColor = new Color(60, 60, 60, 255);
    public Color HoverColor = new Color(80, 80, 80, 255);
    public Color PressedColor = new Color(50, 50, 50, 255);
    public Color BorderColor = new Color(100, 100, 100, 255);
    
    public float BorderThickness = 1f;
    public float CornerRadius = 4f;
    public Vector2 Padding = new(10, 6);
    
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
    
    public event Action<Button>? OnClick;
    public event Action<Button>? OnHoverChanged;
    
    public Button()
    {
        HorizontalAlignment = UI.Alignment.HorizontalAlignment.Left;
        VerticalAlignment = UI.Alignment.VerticalAlignment.Top;
    }
    
    internal void Init()
    {
        // Инициализация без привязки к окну
    }
    
    protected virtual void UpdateSize()
    {
        var textWidth = 0f;
        var textHeight = Font?.LineHeight ?? 20;
        
        if (Font is not null && !string.IsNullOrEmpty(_text))
        {
            foreach (var c in _text)
            {
                if (Font.Glyphs.TryGetValue(c, out var glyph))
                {
                    textWidth += glyph.Advance;
                }
            }
        }
        
        Size = new Vector2(
            (textWidth + Padding.X * 2) * Scale,
            (textHeight + Padding.Y * 2) * Scale
        );
    }
    
    private Color GetCurrentColor()
    {
        return _state switch
        {
            ButtonState.Normal => BackgroundColor,
            ButtonState.Hover => HoverColor,
            ButtonState.Pressed => PressedColor,
            _ => BackgroundColor
        };
    }
    
    private bool IsPointInside(Vector2 point)
    {
        return point.X >= Position.X &&
               point.X <= Position.X + Size.X &&
               point.Y >= Position.Y &&
               point.Y <= Position.Y + Size.Y;
    }
    
    private void SetState(ButtonState newState)
    {
        if (_state == newState)
            return;
        
        _state = newState;
        OnHoverChanged?.Invoke(this);
    }
    
    internal void UpdateInput(Vector2 mousePos, bool isPressed, bool justPressed, bool justReleased)
    {
        var isHovered = IsPointInside(mousePos);
        var wasHovered = _state == ButtonState.Hover || _state == ButtonState.Pressed;
        
        if (isPressed && isHovered)
        {
            SetState(ButtonState.Pressed);
        }
        else if (isHovered)
        {
            SetState(ButtonState.Hover);
        }
        else
        {
            SetState(ButtonState.Normal);
        }
        
        // Обработка клика (при отпускании кнопки над элементом после нажатия)
        if (justReleased && isHovered && wasHovered)
        {
            OnClick?.Invoke(this);
        }
    }
    
    public override void Render(IRenderContext context)
    {
        if (!Visible)
            return;
        
        // Рисуем фон
        var bgColor = GetCurrentColor();
        context.DrawRectangle(new Rect2(Position, Size), bgColor, false);
        
        // Рисуем рамку
        if (BorderThickness > 0)
        {
            context.DrawRectangle(new Rect2(Position, Size), BorderColor, true);
        }
        
        // Рисуем текст
        if (Font is not null && !string.IsNullOrEmpty(_text))
        {
            var textPos = Position + new Vector2(Padding.X, Padding.Y);
            context.DrawText(_text, Font, textPos, TextColor, Scale);
        }
        
        base.Render(context);
    }
}

public enum ButtonState
{
    Normal,
    Hover,
    Pressed
}
