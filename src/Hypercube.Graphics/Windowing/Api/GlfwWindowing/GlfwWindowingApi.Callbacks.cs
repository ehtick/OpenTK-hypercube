using Silk.NET.GLFW;
using Monitor = Silk.NET.GLFW.Monitor;

namespace Hypercube.Graphics.Windowing.Api.GlfwWindowing;

public unsafe partial class GlfwWindowingApi
{
    private void OnErrorCallback(ErrorCode errorCode, string description)
    {
        Raise(new EventError($"Glfw internal error {errorCode}: {description}"));
    }
    
    private void OnMonitorCallback(Monitor* monitor, ConnectedState state)
    {

    }
    
    private void OnJoystickCallback(int joystick, ConnectedState state)
    {

    }

    private void OnWindowCloseCallback(WindowHandle* window)
    {

    }
}