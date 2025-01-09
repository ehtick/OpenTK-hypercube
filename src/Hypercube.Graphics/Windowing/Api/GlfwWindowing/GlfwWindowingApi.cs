using Hypercube.Graphics.Windowing.Settings;
using Hypercube.Mathematics.Vectors;
using Silk.NET.GLFW;
using ContextApi = Hypercube.Graphics.Windowing.Settings.ContextApi;
using SilkWindowHandle = Silk.NET.GLFW.WindowHandle;

namespace Hypercube.Graphics.Windowing.Api.GlfwWindowing;

public sealed unsafe partial class GlfwWindowingApi : WindowingApi
{
    private static readonly Glfw Glfw = Glfw.GetApi();
    
    public override bool InternalInit()
    {
        Glfw.SetErrorCallback(OnErrorCallback);
        
        if (!Glfw.Init())
            return false;

        Glfw.SetMonitorCallback(OnMonitorCallback);
        Glfw.SetJoystickCallback(OnJoystickCallback);
        
        return true;
    }

    public override void InternalTerminate()
    {
        Glfw.Terminate();
    }

    public override void InternalPollEvents()
    {
        Glfw.PollEvents();
    }

    public override void InternalPostEmptyEvent()
    {
        Glfw.PostEmptyEvent();
    }

    public override void InternalWaitEvents()
    {
        Glfw.WaitEvents();
    }

    public override void InternalWaitEventsTimeout(double timeout)
    {
        Glfw.WaitEventsTimeout(timeout);
    }

    public override nint InternalWindowCreate(WindowCreateSettings settings)
    {
        var size = settings.Size;
        var title = settings.Title;
        var monitor = settings.MonitorShare;
        var share = settings.ContextShare;
        
        Glfw.WindowHint(WindowHintClientApi.ClientApi, ToClientApi(settings.Api));

        if (settings.Api != ContextApi.None)
        {
            Glfw.WindowHint(WindowHintInt.ContextVersionMajor, settings.Api.Version.Major);
            Glfw.WindowHint(WindowHintInt.ContextVersionMinor, settings.Api.Version.Minor);
        }

        Glfw.WindowHint(WindowHintBool.OpenGLDebugContext, settings.Api.DebugFlag);
        Glfw.WindowHint(WindowHintBool.OpenGLForwardCompat, settings.Api.ForwardCompatibleFlag);

        if (settings.Api >= new Version(3, 2))
            Glfw.WindowHint(WindowHintOpenGlProfile.OpenGlProfile, ToGlProfile(settings.Api));

        var windowHandle = Glfw.CreateWindow(size.X, size.Y, title, null, null);

        Glfw.SetWindowCloseCallback(windowHandle, OnWindowCloseCallback);
        Glfw.SetWindowSizeCallback(windowHandle, OnWindowSizeCallback);
        Glfw.SetWindowPosCallback(windowHandle, OnWindowPositionCallback);
        Glfw.SetWindowFocusCallback(windowHandle, OnWindowFocusCallback);
        
        return (nint) windowHandle;
    }

    public override void InternalWindowSetTitle(nint window, string title)
    {
        Glfw.SetWindowTitle((SilkWindowHandle*) window, title);
    }

    public override void InternalWindowSetPosition(nint window, Vector2i position)
    {
        Glfw.SetWindowPos((SilkWindowHandle*) window, position.X, position.Y);
    }

    public override void InternalWindowSetSize(nint window, Vector2i size)
    {
        Glfw.SetWindowSize((SilkWindowHandle*) window, size.X, size.Y);
    }

    public override nint InternalGetProcAddress(string name)
    {
        return Glfw.GetProcAddress(name);
    }
}