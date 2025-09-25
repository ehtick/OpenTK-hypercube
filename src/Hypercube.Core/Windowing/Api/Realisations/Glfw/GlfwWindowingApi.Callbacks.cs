using Hypercube.Core.Input;
using Hypercube.Mathematics.Vectors;
using Silk.NET.GLFW;
using KeyModifiers = Hypercube.Core.Input.KeyModifiers;
using MouseButton = Hypercube.Core.Input.MouseButton;
using SilkKeyModifiers = Silk.NET.GLFW.KeyModifiers;
using SilkMouseButton = Silk.NET.GLFW.MouseButton;
using Monitor = Silk.NET.GLFW.Monitor;
using SilkWindowHandle = Silk.NET.GLFW.WindowHandle;

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

    private void OnWindowCloseCallback(SilkWindowHandle* window)
    {   
        Raise(new EventWindowClose((nint) window));
    }

    private void OnWindowSizeCallback(SilkWindowHandle* window, int width, int height)
    {
        Raise(new EventWindowSize((nint) window, new Vector2i(width, height)));
    }

    private void OnWindowPositionCallback(SilkWindowHandle* window, int x, int y)
    {
        Raise(new EventWindowPosition((nint) window, new Vector2i(x, y)));
    }

    private void OnWindowFocusCallback(SilkWindowHandle* window, bool focused)
    {
        Raise(new EventWindowFocus((nint) window, focused));
    }

    private void OnWindowKey(SilkWindowHandle* window, Keys key, int scancode, InputAction action, SilkKeyModifiers mods)
    {
        Raise(new EventWindowKey((nint) window, (Key) key, scancode, (KeyState) action, (KeyModifiers) mods));
    }

    private void OnWindowCursor(SilkWindowHandle* window, double x, double y)
    {
        Raise(new EventWindowCursorPosition((nint) window, new Vector2d(x, y)));
    }

    private void OnWindowMouseButton(SilkWindowHandle* window, SilkMouseButton button, InputAction action, SilkKeyModifiers mods)
    {
        Raise(new EventWindowMouseButton((nint) window, (MouseButton) button, (KeyState) action, (KeyModifiers) mods));
    }

    private void OnWindowScroll(SilkWindowHandle* window, double x, double y)
    {
        Raise(new EventWindowScroll((nint) window, new Vector2d(x, y)));
    }
}