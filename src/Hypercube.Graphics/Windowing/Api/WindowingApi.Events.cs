using Hypercube.GraphicsApi.GlfwApi.Enums;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Graphics.Windowing.Api;

public abstract unsafe partial class WindowingApi
{
    protected interface IEvent;

    protected readonly record struct EventError(string Description)
        : IEvent;
    
    protected record struct EventCursorPosition(
        nint Window,
        Vector2d Position
    ) : IEvent;

    protected record struct EventCursorEnter(
        nint Window,
        bool Entered
    ) : IEvent;

    protected record struct EventScroll(
        nint Window,
        Vector2d Offset
    ) : IEvent;

    protected record struct EventKey(
        nint Window,
        Key Key,
        int ScanCode,
        InputAction Action,
        KeyModifier Modifier
    ) : IEvent;
    
    protected record struct EventMouseButton(
        nint Window,
        MouseButton Button,
        InputAction Action,
        KeyModifier Mods
    ) : IEvent;
    
    protected record struct EventChar
    (
        nint Window,
        uint CodePoint
    ) : IEvent;

    protected record struct EventWindowClose
    (
        nint Window
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

    protected record struct EventWindowCreated
    (
        nint Window,
        TaskCompletionSource<nint>? TaskCompletionSource = null
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