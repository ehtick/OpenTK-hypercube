using Hypercube.Core.Execution.LifeCycle;
using Hypercube.Core.Windowing;
using Hypercube.Core.Windowing.Api;
using Hypercube.Core.Windowing.Manager;
using Hypercube.Utilities.Dependencies;

namespace Hypercube.Core.Input.Handler;

/// <summary>
/// A class that directly listens to window events and processes them to work correctly,
/// pre first level work with push handling, lower level would be <see cref="IWindowingApi"/>
/// which takes data directly from the current window handling API.
///
/// In most cases it is better to work with <see cref="IInputManager"/>,
/// which is an add-on on top of the current implementation.
/// </summary>
[UsedImplicitly]
public sealed partial class InputHandler : IInputHandler, IPostInject
{
    [Dependency] private readonly IWindowManager _window = null!;
    [Dependency] private readonly IRuntimeLoop _runtimeLoop = null!;
    
    private readonly Dictionary<nint, KeyStateBuffer> _keys = new();

    private IWindowingApi Api => _window.Api;
    
    public void OnPostInject()
    {
        _runtimeLoop.Actions.Add(OnUpdate, EngineUpdatePriority.InputHandler); 
        
        Api.OnWindowKey += OnKeyUpdate;
        Api.OnWindowMouseButton += OnMouseButtonUpdate;
    }

    public void Clear()
    {
        ClearKeyState();
        ClearMouseButtonState();
    }

    private void OnUpdate(FrameEventArgs args)
    {
        Clear();
    }

    private void OnKeyUpdate(WindowHandle window, KeyStateChangedArgs state)
    {
        GetKeySateBuffer(window).Apply(state);
    }
    
    private void OnMouseButtonUpdate(WindowHandle window, MouseButtonChangedArgs state)
    {
        GetMouseStateBuffer(window).Apply(state);
    }
}
