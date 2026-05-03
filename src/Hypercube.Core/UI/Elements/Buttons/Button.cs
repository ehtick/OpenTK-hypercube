using Hypercube.Core.Execution.LifeCycle;
using Hypercube.Core.Input;

namespace Hypercube.Core.UI.Elements.Buttons;

[PublicAPI]
public class Button : Element
{
    public bool Enabled = true;
    public bool Hovered { get; private set; }
    public bool Pressed { get; private set; }

    public event Action? OnClicked;
    public event Action? OnHoverEntered;
    public event Action? OnHoverExited;
    public event Action? OnPressedDown;
    public event Action? OnReleased;

    protected override void OnUpdate(FrameEventArgs args)
    {
        if (!Enabled || !Visible)
            return;

        var mousePosition = UI.MousePosition;
        var isInside = Contains(mousePosition);

        if (isInside && !Hovered)
        {
            Hovered = true;
            OnHoverEntered?.Invoke();
        }

        if (!isInside && Hovered)
        {
            Hovered = false;
            OnHoverExited?.Invoke();
        }

        if (Hovered && UI.InputHandler.IsMouseButtonPressed(MouseButton.Left))
        {
            Pressed = true;
            OnPressedDown?.Invoke();
        }

        if (Pressed && UI.InputHandler.IsMouseButtonReleased(MouseButton.Left))
        {
            Pressed = false;
            OnReleased?.Invoke();

            if (Hovered)
                OnClicked?.Invoke();
        }
    }

    protected virtual bool Contains(Vector2 point) =>
        point.X >= AbsolutePosition.X &&
        point.X <= AbsolutePosition.X + AbsoluteSize.X &&
        point.Y >= AbsolutePosition.Y &&
        point.Y <= AbsolutePosition.Y + AbsoluteSize.Y;
}
