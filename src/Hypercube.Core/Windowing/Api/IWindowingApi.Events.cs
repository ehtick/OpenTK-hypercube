namespace Hypercube.Core.Windowing.Api;

public partial interface IWindowingApi
{
    /// <summary>
    /// Fired when the windowing system has been initialized.
    /// </summary>
    event InitHandler? OnInit;

    /// <summary>
    /// Fired when an internal error occurs within the windowing system.
    /// </summary>
    event ErrorHandler? OnError;

    /// <summary>
    /// Fired when a monitor is connected or disconnected.
    /// </summary>
    event MonitorHandler? OnMonitor;

    /// <summary>
    /// Fired when a joystick/gamepad is connected or disconnected.
    /// </summary>
    event JoystickHandler? OnJoystick;

    /// <summary>
    /// Fired when a window is requested to close.
    /// </summary>
    event WindowCloseHandler? OnWindowClose;

    /// <summary>
    /// Fired when a window title changes.
    /// </summary>
    event WindowTitleHandler? OnWindowTitle; 

    /// <summary>
    /// Fired when a window is moved.
    /// </summary>
    event WindowPositionHandler? OnWindowPosition; 

    /// <summary>
    /// Fired when a window is resized.
    /// </summary>
    event WindowSizeHandler? OnWindowSize; 

    /// <summary>
    /// Fired when a window framebuffer size changes.
    /// Typically differs from window size on high-DPI displays.
    /// </summary>
    event WindowFramebufferSizeHandler? OnWindowFramebufferSize; 

    /// <summary>
    /// Fired when a window gains or loses focus.
    /// </summary>
    event WindowFocusHandler? OnWindowFocus; 

    /// <summary>
    /// Fired when a keyboard key is pressed, released, or repeated.
    /// </summary>
    event WindowKey? OnWindowKey;

    /// <summary>
    /// Fired when a scroll input is received (mouse wheel, touchpad).
    /// </summary>
    event WindowScroll? OnWindowScroll;

    /// <summary>
    /// Fired when the mouse cursor moves within a window.
    /// </summary>
    event WindowMousePosition? OnWindowMousePosition;

    /// <summary>
    /// Fired when a mouse button is pressed or released.
    /// </summary>
    event WindowMouseButton? OnWindowMouseButton;

    /// <summary>
    /// Fired when a character is input (text input, UTF-32).
    /// </summary>
    event WindowChar? OnWindowChar;
}
