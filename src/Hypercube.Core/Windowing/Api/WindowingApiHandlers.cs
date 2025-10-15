using Hypercube.Core.Input;
using Hypercube.Core.Windowing.Api.Enums;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Core.Windowing.Api;

public delegate void InitHandler(string info);
public delegate void ErrorHandler(string message);
public delegate void MonitorHandler(nint window, ConnectedState state);
public delegate void JoystickHandler(int joystick, ConnectedState state);

public delegate void WindowCloseHandler(WindowHandle window);
public delegate void WindowTitleHandler(WindowHandle window, string title);
public delegate void WindowPositionHandler(WindowHandle window, Vector2i position);
public delegate void WindowSizeHandler(WindowHandle window, Vector2i size);
public delegate void WindowFocusHandler(WindowHandle window, bool focused);

public delegate void WindowKey(WindowHandle window, KeyStateChangedArgs state);
public delegate void WindowScroll(WindowHandle window, Vector2d offset);
public delegate void WindowMouseButton(WindowHandle window, MouseButtonChangedArgs state);
public delegate void WindowChar(WindowHandle window, uint codePoint);
