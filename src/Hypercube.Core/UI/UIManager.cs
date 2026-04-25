using Hypercube.Core.Execution.LifeCycle;
using Hypercube.Core.Graphics.Patching;
using Hypercube.Core.Input;
using Hypercube.Core.Input.Handler;
using Hypercube.Core.UI.Elements;
using Hypercube.Core.Windowing.Manager;
using Hypercube.Mathematics;
using Hypercube.Mathematics.Shapes;
using Hypercube.Utilities.Dependencies;
using Hypercube.Utilities.Debugging.Logger;

namespace Hypercube.Core.UI;

public class UIManager : IUIManager, IPostInject
{
    [Dependency] private readonly IRuntimeLoop _runtimeLoop = null!;
    [Dependency] private readonly IPatchManager _patchManager = null!;
    [Dependency] private readonly IInputHandler _inputHandler = null!;
    [Dependency] private readonly IWindowingManager _windowingManager = null!;
    [Dependency] private readonly ILogger _logger = null!;

    private readonly WindowRoot _root = new();
    private readonly UIPatch _patch;
    
    private bool _wasMousePressed = false;
    
    public WindowRoot Root => _root;

    public UIManager()
    {
        _patch = new UIPatch(this);
    }

    public void OnPostInject()
    {
        _patchManager.AddPatch(_patch);
        _runtimeLoop.Actions.Add(OnUpdate, EngineUpdatePriority.UIUpdate);
        
        _logger.Debug("UI Manager initialized");
    }

    public void AddElement(Element element)
    {
        _root.AddChild(element);
        
        // Инициализация кнопок для обработки ввода
        InitializeButtons(element);
    }

    public void RemoveElement(Element element)
    {
        _root.RemoveChild(element);
    }

    public void Arrange()
    {
        var window = _windowingManager.MainWindow;
        if (window is null)
            return;
        
        var rect = new Rect2(0, 0, window.Size.X, window.Size.Y);
        _root.Arrange(rect);
    }

    private void InitializeButtons(Element element)
    {
        if (element is Button button)
        {
            button.Init();
        }
        
        foreach (var child in element.Children)
        {
            InitializeButtons(child);
        }
    }

    private void OnUpdate(FrameEventArgs args)
    {
        // Получаем позицию мыши и состояние кнопок
        var mousePos = new Vector2(_inputHandler.MousePosition.X, _inputHandler.MousePosition.Y);
        var isPressed = _inputHandler.IsMouseButtonHeld(MouseButton.Left);
        var justPressed = isPressed && !_wasMousePressed;
        var justReleased = !isPressed && _wasMousePressed;
        
        Arrange();
        UpdateButtons(mousePos, isPressed, justPressed, justReleased);
        
        _wasMousePressed = isPressed;
    }
    
    private void UpdateButtons(Vector2 mousePos, bool isPressed, bool justPressed, bool justReleased)
    {
        foreach (var child in _root.Children)
        {
            UpdateButtonsRecursive(child, mousePos, isPressed, justPressed, justReleased);
        }
    }
    
    private void UpdateButtonsRecursive(Element element, Vector2 mousePos, bool isPressed, bool justPressed, bool justReleased)
    {
        if (element is Button button)
        {
            button.UpdateInput(mousePos, isPressed, justPressed, justReleased);
        }
        
        foreach (var child in element.Children)
        {
            UpdateButtonsRecursive(child, mousePos, isPressed, justPressed, justReleased);
        }
    }
}
