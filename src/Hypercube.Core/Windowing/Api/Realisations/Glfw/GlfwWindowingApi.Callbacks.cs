using Hypercube.Core.Input;
using Hypercube.Mathematics.Vectors;
using Silk.NET.GLFW;
using KeyModifiers = Hypercube.Core.Input.KeyModifiers;
using MouseButton = Hypercube.Core.Input.MouseButton;
using SilkKeyModifiers = Silk.NET.GLFW.KeyModifiers;
using SilkMouseButton = Silk.NET.GLFW.MouseButton;
using Monitor = Silk.NET.GLFW.Monitor;

namespace Hypercube.Core.Windowing.Api.Realisations.Glfw;

public unsafe partial class GlfwWindowingApi
{
    private void OnErrorCallback(ErrorCode errorCode, string description)
    {
        Raise(new EventError($"Glfw internal error {errorCode}: {description}"));
    }
    
    private void OnMonitorCallback(Monitor* monitor, ConnectedState state)
    {
        Raise(new EventMonitor((nint) monitor, FromConnectedState(state)));
    }
    
    private void OnJoystickCallback(int joystick, ConnectedState state)
    {
        Raise(new EventJoystick(joystick, FromConnectedState(state)));
    }

    private void OnWindowCloseCallback(WindowHandle* window)
    {   
        Raise(new EventWindowClose((nint) window));
    }

    private void OnWindowSizeCallback(WindowHandle* window, int width, int height)
    {
        Raise(new EventWindowSize((nint) window, new Vector2i(width, height)));
    }

    private void OnWindowPositionCallback(WindowHandle* window, int x, int y)
    {
        Raise(new EventWindowPosition((nint) window, new Vector2i(x, y)));
    }

    private void OnWindowFocusCallback(WindowHandle* window, bool focused)
    {
        Raise(new EventWindowFocus((nint) window, focused));
    }

    private void OnWindowKey(WindowHandle* window, Keys key, int scancode, InputAction action, SilkKeyModifiers mods)
    {
        Raise(new EventWindowKey((nint) window, (Key) key, scancode, (KeyState) action, (KeyModifiers) mods));
    }

    private void OnWindowCursor(WindowHandle* window, double x, double y)
    {
        Raise(new EventWindowCursorPosition((nint) window, new Vector2d(x, y)));
    }

    private void OnWindowMouseButton(WindowHandle* window, SilkMouseButton button, InputAction action, SilkKeyModifiers mods)
    {
        Raise(new EventWindowMouseButton((nint) window, (MouseButton) button, (KeyState) action, (KeyModifiers) mods));
    }

    private void OnWindowScroll(WindowHandle* window, double x, double y)
    {
        Raise(new EventWindowScroll((nint) window, new Vector2d(x, y)));
    }
}