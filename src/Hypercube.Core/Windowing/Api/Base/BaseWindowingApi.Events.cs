using Hypercube.Core.Input;
using Hypercube.Mathematics.Vectors;
using ConnectedState = Hypercube.Core.Windowing.Api.Enums.ConnectedState;
using KeyModifiers = Hypercube.Core.Input.KeyModifiers;
using MouseButton = Hypercube.Core.Input.MouseButton;

namespace Hypercube.Core.Windowing.Api.Base;

public abstract partial class BaseWindowingApi
{
    protected interface IEvent;

    protected readonly record struct EventSync(TaskCompletionSource Command)
        : IEvent;
    
    protected readonly record struct EventSync<TResult>(TaskCompletionSource<TResult> Command, TResult Result)
        : IEvent;
    
    protected readonly record struct EventError(
        string Description
    ) : IEvent;
    
    protected readonly record struct EventMonitor(
        nint Monitor,
        ConnectedState State
    ) : IEvent;
    
    protected readonly record struct EventJoystick(
        int Joystick,
        ConnectedState State
    ) : IEvent;
    
    protected record struct EventWindowCursorPosition(
        nint Window,
        Vector2d Position
    ) : IEvent;

    protected record struct EventCursorEnter(
        nint Window,
        bool Entered
    ) : IEvent;

    protected record struct EventWindowScroll(
        nint Window,
        Vector2d Offset
    ) : IEvent;
    
    protected record struct EventWindowKey(
        nint Window,
        Key Key,
        int ScanCode,
        KeyState State,
        KeyModifiers Modifier
    ) : IEvent;
    
    protected record struct EventWindowMouseButton(
        nint Window,
        MouseButton Button,
        KeyState State,
        KeyModifiers Modifier
    ) : IEvent;
    
    protected record struct EventWindowChar
    (
        nint Window,
        uint CodePoint
    ) : IEvent;

    protected record struct EventWindowClose
    (
        nint Window
    ) : IEvent;

    protected record struct EventWindowTitle
    (
        nint Window,
        string Title
    ) : IEvent;
    
    protected record struct EventWindowSize
    (
        nint Window,
        Vector2i Size
    ) : IEvent;

    protected record struct EventWindowPosition
    (
        nint Window,
        Vector2i Position
    ) : IEvent;
    
    protected record struct EventWindowContentScale
    (
        nint Window,
        Vector2 Scale
    ) : IEvent;

    protected record struct EventWindowIconify
    (
        nint Window,
        bool Iconified
    ) : IEvent;

    protected record struct EventWindowFocus
    (
        nint Window,
        bool Focused
    ) : IEvent;

    protected record struct EventMonitorDestroy
    (
        int Id
    ) : IEvent;
} 