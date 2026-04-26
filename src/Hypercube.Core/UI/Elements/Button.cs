using Hypercube.Core.Execution.LifeCycle;
using Hypercube.Core.Graphics.Rendering;
using Hypercube.Core.Graphics.Rendering.Context;
using Hypercube.Core.Input;
using Hypercube.Core.Input.Handler;
using Hypercube.Mathematics;
using Hypercube.Mathematics.Shapes;
using Hypercube.Utilities.Dependencies;

namespace Hypercube.Core.UI.Elements;

[PublicAPI]
public class Button : Element
{
    [Dependency] private readonly IInputHandler _inputHandler = null!;
    
    public event Action<Button>? OnClick;
    public event Action<Button>? OnHoverChanged;
    
    public Label Label { get; }

    public Color BackgroundColor { get; set; } = new(60, 60, 60);
    public Color HoverColor { get; set; } = new(80, 80, 80);
    public Color PressedColor { get; set; } = new(50, 50, 50);
    public Color BorderColor { get; set; } = new(100, 100, 100);

    public float BorderThickness { get; set; } = 1f;
    public float CornerRadius { get; set; } = 4f;
    public Vector2 Padding { get; set; } = new(10, 6);

    public string Text
    {
        get => Label.Text;
        set
        {
            Label.Text = value;
            UpdateSize();
        }
    }

    private ButtonState _state = ButtonState.Normal;

    public Button()
    {
        HorizontalAlignment = UI.Alignment.HorizontalAlignment.Left;
        VerticalAlignment = UI.Alignment.VerticalAlignment.Top;

        Label = new Label();
        AddChild(Label);
    }

    protected override void OnRender(IRenderContext context, DrawPayload payload)
    {
        var color = GetCurrentColor();
        var rect = Rect2.FromCenter(Position, Size);
        
        // Background
        context.DrawRectangle(rect, color);

        // Border
        if (BorderThickness > 0)
            context.DrawRectangle(rect, BorderColor, true);

        // Center label inside button
        ArrangeLabel();
    }

    protected override void OnUpdate(FrameEventArgs args)
    {
        var mousePosition = (Vector2)_inputHandler.MousePosition;

        var isPressed = _inputHandler.IsMouseButtonHeld(MouseButton.Left);
        var justPressed = _inputHandler.IsMouseButtonPressed(MouseButton.Left);
        var justReleased = _inputHandler.IsMouseButtonReleased(MouseButton.Left);

        UpdateInput(
            mousePosition,
            isPressed,
            justPressed,
            justReleased);
    }
    
    internal void UpdateInput(
        Vector2 mousePosition,
        bool isPressed,
        bool justPressed,
        bool justReleased)
    {
        var hovered = Contains(mousePosition);
        var wasHovered = _state is ButtonState.Hover or ButtonState.Pressed;

        SetState(
            isPressed && hovered
                ? ButtonState.Pressed
                : hovered
                    ? ButtonState.Hover
                    : ButtonState.Normal);

        if (justReleased && hovered && wasHovered)
            OnClick?.Invoke(this);
    }

    protected virtual void UpdateSize()
    {
        var labelSize = Label.Size;

        Size = new Vector2(
            labelSize.X + Padding.X * 2,
            labelSize.Y + Padding.Y * 2);
    }

    private void ArrangeLabel()
    {
        var rect = new Rect2(Position + Padding, Size - Padding * 2);
        Label.Arrange(rect);
    }
    
    private bool Contains(Vector2 point)
    {
        return point.X >= Position.X &&
               point.X <= Position.X + Size.X &&
               point.Y >= Position.Y &&
               point.Y <= Position.Y + Size.Y;
    }

    private void SetState(ButtonState state)
    {
        if (_state == state)
            return;

        _state = state;
        OnHoverChanged?.Invoke(this);
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
}

public enum ButtonState
{
    Normal,
    Hover,
    Pressed
}
