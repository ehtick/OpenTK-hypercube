using Hypercube.Core.Input.Args;
using Hypercube.Core.Windowing.Api.Enums;
using Hypercube.Core.Windowing.Windows;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Core.Windowing.Api;


/// <summary>
/// Represents a handler invoked when the windowing system is initialized.
/// </summary>
/// <param name="info">Additional information about the initialization process.</param>
public delegate void InitHandler(InitInfo info);

/// <summary>
/// Represents a handler invoked when an error occurs in the windowing system.
/// </summary>
/// <param name="message">A human-readable error message.</param>
public delegate void ErrorHandler(string message);

/// <summary>
/// Represents a handler invoked when a monitor is connected or disconnected.
/// </summary>
/// <param name="window">
/// Platform-specific monitor handle.
/// Note: despite the name, this refers to a monitor, not a window.
/// </param>
/// <param name="state">The connection state of the monitor.</param>
public delegate void MonitorHandler(nint window, ConnectedState state);

/// <summary>
/// Represents a handler invoked when a joystick or gamepad is connected or disconnected.
/// </summary>
/// <param name="joystick">The joystick identifier.</param>
/// <param name="state">The connection state.</param>
public delegate void JoystickHandler(int joystick, ConnectedState state);

/// <summary>
/// Represents a handler invoked when a window requests to close.
/// </summary>
/// <param name="window">The window that is being closed.</param>
public delegate void WindowCloseHandler(WindowHandle window);

/// <summary>
/// Represents a handler invoked when a window title changes.
/// </summary>
/// <param name="window">The target window.</param>
/// <param name="title">The new window title.</param>
public delegate void WindowTitleHandler(WindowHandle window, string title);

/// <summary>
/// Represents a handler invoked when a window is moved.
/// </summary>
/// <param name="window">The target window.</param>
/// <param name="position">The new position in screen coordinates.</param>
public delegate void WindowPositionHandler(WindowHandle window, Vector2i position);

/// <summary>
/// Represents a handler invoked when a window is resized.
/// </summary>
/// <param name="window">The target window.</param>
/// <param name="size">The new size in pixels (width, height).</param>
public delegate void WindowSizeHandler(WindowHandle window, Vector2i size);

/// <summary>
/// Represents a handler invoked when a window framebuffer size changes.
/// This may differ from window size on high-DPI displays.
/// </summary>
/// <param name="window">The target window.</param>
/// <param name="size">The new framebuffer size in pixels.</param>
public delegate void WindowFramebufferSizeHandler(WindowHandle window, Vector2i size);

/// <summary>
/// Represents a handler invoked when a window gains or loses focus.
/// </summary>
/// <param name="window">The target window.</param>
/// <param name="focused">True if the window is focused; otherwise, false.</param>
public delegate void WindowFocusHandler(WindowHandle window, bool focused);

/// <summary>
/// Represents a handler invoked when a keyboard key state changes.
/// </summary>
/// <param name="window">The target window.</param>
/// <param name="state">Detailed information about the key event.</param>
public delegate void WindowKey(WindowHandle window, KeyChangedArgs state);

/// <summary>
/// Represents a handler invoked when scroll input is received.
/// </summary>
/// <param name="window">The target window.</param>
/// <param name="offset">Scroll offset (horizontal, vertical).</param>
public delegate void WindowScroll(WindowHandle window, Vector2d offset);

/// <summary>
/// Represents a handler invoked when the mouse cursor moves within a window.
/// </summary>
/// <param name="window">The target window.</param>
/// <param name="position">Cursor position in window coordinates.</param>
public delegate void WindowMousePosition(WindowHandle window, Vector2d position);

/// <summary>
/// Represents a handler invoked when a mouse button state changes.
/// </summary>
/// <param name="window">The target window.</param>
/// <param name="state">Detailed information about the mouse button event.</param>
public delegate void WindowMouseButton(WindowHandle window, MouseButtonChangedArgs state);

/// <summary>
/// Represents a handler invoked when a character is input.
/// Typically used for text input and supports Unicode code points.
/// </summary>
/// <param name="window">The target window.</param>
/// <param name="codePoint">UTF-32 Unicode code point.</param>
public delegate void WindowChar(WindowHandle window, uint codePoint);
