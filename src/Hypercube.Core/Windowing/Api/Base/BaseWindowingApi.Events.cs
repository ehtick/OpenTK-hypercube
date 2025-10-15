using Hypercube.Core.Input;
using Hypercube.Core.Windowing.Api.Enums;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Core.Windowing.Api.Base;

public abstract partial class BaseWindowingApi
{
    protected interface IEvent;

    /// <summary>
    /// Represents a synchronization event used for command completion.
    /// </summary>
    protected readonly record struct EventSync(
        TaskCompletionSource Command
    ) : IEvent;
    
    /// <summary>
    /// Represents a synchronization event with a result value.
    /// </summary>
    protected readonly record struct EventSync<TResult>(
        TaskCompletionSource<TResult> Command,
        TResult Result
    ) : IEvent;
    
    /// <summary>
    /// Represents an error event triggered by GLFW.
    /// </summary>
    protected readonly record struct EventError(
        string Description
    ) : IEvent;
    
    /// <summary>
    /// Represents a monitor connection or disconnection event.<br/>
    /// GLFW reference: <a href="https://www.glfw.org/docs/latest/group__monitor.html#ga893e8d6cfed9267eb2b793cb1d481183">glfwSetMonitorCallback</a>.
    /// </summary>
    protected readonly record struct EventMonitor(
        nint Monitor,
        ConnectedState State
    ) : IEvent;
    
    /// <summary>
    /// Represents a joystick connection or disconnection event.<br/>
    /// GLFW reference: <a href="https://www.glfw.org/docs/latest/group__input.html#gaf306ce2287a11c8c9829ef7cea3bba61">glfwSetJoystickCallback</a>.
    /// </summary>
    protected readonly record struct EventJoystick(
        int Joystick,
        ConnectedState State
    ) : IEvent;
    
    /// <summary>
    /// Represents a window cursor position event.<br/>
    /// GLFW reference: <a href="https://www.glfw.org/docs/latest/group__input.html#gaa20014985561efeb2c53f1956f727830">glfwSetCursorPosCallback</a>.
    /// </summary>
    protected record struct EventWindowCursorPosition(
        WindowHandle Window,
        Vector2d Position
    ) : IEvent;

    /// <summary>
    /// Represents a cursor enter/leave event.<br/>
    /// GLFW reference: <a href="https://www.glfw.org/docs/latest/group__input.html#gaa20014985561efeb2c53f1956f727830">glfwSetCursorEnterCallback</a>.
    /// </summary>
    protected record struct EventCursorEnter(
        WindowHandle Window,
        bool Entered
    ) : IEvent;

    /// <summary>
    /// Represents a mouse scroll event.<br/>
    /// GLFW reference: <a href="https://www.glfw.org/docs/latest/group__input.html#ga0dc8d880a0d87be16d3ea8114561f6f0">glfwSetScrollCallback</a>.
    /// </summary>
    protected record struct EventWindowScroll(
        WindowHandle Window,
        Vector2d Offset
    ) : IEvent;
    
    /// <summary>
    /// Represents a keyboard input event.<br/>
    /// GLFW reference: <a href="https://www.glfw.org/docs/latest/group__input.html#ga7dad39486f2c7591af7fb25134a2501d">glfwSetKeyCallback</a>.
    /// </summary>
    protected record struct EventWindowKey(
        WindowHandle Window,
        Key Key,
        int ScanCode,
        KeyState State,
        KeyModifiers Modifier
    ) : IEvent;
    
    /// <summary>
    /// Represents a mouse button event.<br/>
    /// GLFW reference: <a href="https://www.glfw.org/docs/latest/group__input.html#gaef49b72d84d615bca0a6ed65485e035d">glfwSetMouseButtonCallback</a>.
    /// </summary>
    protected record struct EventWindowMouseButton(
        WindowHandle Window,
        MouseButton Button,
        KeyState State,
        KeyModifiers Modifier
    ) : IEvent;
    
    /// <summary>
    /// Represents a character input event.<br/>
    /// GLFW reference: <a href="https://www.glfw.org/docs/latest/group__input.html#ga7e496507126f35ea72f01b2e6ef6d155">glfwSetCharCallback</a>.
    /// </summary>
    protected record struct EventWindowChar
    (
        WindowHandle Window,
        uint CodePoint
    ) : IEvent;

    /// <summary>
    /// Represents a window close event.<br/>
    /// GLFW reference: <a href="https://www.glfw.org/docs/latest/group__window.html#ga396c07889c66f74e73039cc25b5e5524">glfwSetWindowCloseCallback</a>.
    /// </summary>
    protected record struct EventWindowClose
    (
        WindowHandle Window
    ) : IEvent;
    
    /// <summary>
    /// Represents a window title change event.<br/>
    /// GLFW doesn’t provide a direct callback for this; typically triggered by <a href="https://www.glfw.org/docs/latest/group__window.html#ga861ed3414ab8120e2f74151a666ed1dc">glfwSetWindowTitle</a>.
    /// </summary>
    protected record struct EventWindowTitle
    (
        WindowHandle Window,
        string Title
    ) : IEvent;
    
    /// <summary>
    /// Represents a window resize event.<br/>
    /// GLFW reference: <a href="https://www.glfw.org/docs/latest/group__window.html#ga0dc8d880a0d87be16d3ea8114561f6f0">glfwSetWindowSizeCallback</a>.
    /// </summary>
    protected record struct EventWindowSize
    (
        WindowHandle Window,
        Vector2i Size
    ) : IEvent;

    /// <summary>
    /// Represents a window position change event.<br/>
    /// GLFW reference: <a href="https://www.glfw.org/docs/latest/group__window.html#ga63d282e0cf4d1e62198dfd36573b0da0">glfwSetWindowPosCallback</a>.
    /// </summary>
    protected record struct EventWindowPosition
    (
        WindowHandle Window,
        Vector2i Position
    ) : IEvent;
    
    /// <summary>
    /// Represents a window content scale event.<br/>
    /// GLFW reference: <a href="https://www.glfw.org/docs/latest/group__window.html#ga1c36e52549efd47790eb3f41f95d0d67">glfwSetWindowContentScaleCallback</a>.
    /// </summary>
    protected record struct EventWindowContentScale
    (
        WindowHandle Window,
        Vector2 Scale
    ) : IEvent;

    /// <summary>
    /// Represents a window iconify (minimize/restore) event.<br/>
    /// GLFW reference: <a href="https://www.glfw.org/docs/latest/group__window.html#gaf1525cb3bccd5789c702cc9676ef3403">glfwSetWindowIconifyCallback</a>.
    /// </summary>
    protected record struct EventWindowIconify
    (
        WindowHandle Window,
        bool Iconified
    ) : IEvent;

    /// <summary>
    /// Represents a window focus change event.<br/>
    /// GLFW reference: <a href="https://www.glfw.org/docs/latest/group__window.html#ga6b3ccf48c5f4223a3b0b6f5dd8819698">glfwSetWindowFocusCallback</a>.
    /// </summary>
    protected record struct EventWindowFocus
    (
        WindowHandle Window,
        bool Focused
    ) : IEvent;

    /// <summary>
    /// Represents an internal monitor destroy event.<br/>
    /// Not part of GLFW; used internally for resource cleanup.
    /// </summary>
    protected record struct EventMonitorDestroy
    (
        int Id
    ) : IEvent;
} 