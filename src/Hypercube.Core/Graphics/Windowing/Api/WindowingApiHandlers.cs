using Hypercube.Core.Graphics.Windowing.Api.Enums;
using Hypercube.Core.Input;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Core.Graphics.Windowing.Api;

public delegate void InitHandler(string info);
public delegate void ErrorHandler(string message);
public delegate void MonitorHandler(nint window, ConnectedState state);
public delegate void JoystickHandler(int joystick, ConnectedState state);

public delegate void WindowCloseHandler(nint window);
public delegate void WindowTitleHandler(nint window, string title);
public delegate void WindowPositionHandler(nint window, Vector2i position);
public delegate void WindowSizeHandler(nint window, Vector2i size);
public delegate void WindowFocusHandler(nint window, bool focused);

public delegate void WindowKey(nint window, KeyStateChangedArgs state);
public delegate void WindowScroll(nint window, Vector2d offset);
public delegate void WindowMouseButton(nint window, MouseButtonChangedArgs state);
public delegate void WindowChar(nint window, uint codePoint);
