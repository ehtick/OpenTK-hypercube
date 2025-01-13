using Hypercube.Graphics.Windowing.Api.Enums;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Graphics.Windowing.Api;

public delegate void InitHandler(string info);
public delegate void ErrorHandler(string message);
public delegate void MonitorHandler(nint window, ConnectedState state);
public delegate void JoystickHandler(int joystick, ConnectedState state);
public delegate void WindowCloseHandler(nint window);
public delegate void WindowPositionHandler(nint window, Vector2i position);
public delegate void WindowSizeHandler(nint window, Vector2i size);
public delegate void WindowFocusHandler(nint window, bool focused);