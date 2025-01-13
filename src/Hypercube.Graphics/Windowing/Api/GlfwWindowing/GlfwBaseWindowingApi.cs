using System.Text;
using Hypercube.Graphics.Windowing.Settings;
using Hypercube.Mathematics.Vectors;
using Silk.NET.GLFW;
using ContextApi = Hypercube.Graphics.Windowing.Settings.ContextApi;
using SilkWindowHandle = Silk.NET.GLFW.WindowHandle;

namespace Hypercube.Graphics.Windowing.Api.GlfwWindowing;

public sealed unsafe partial class GlfwBaseWindowingApi : BaseWindowingApi
{
    public override WindowingApi Type => WindowingApi.Glfw;
    
    private Glfw _glfw = default!;

    protected override string InternalInfo
    {
        get
        {
            _glfw.GetVersion(out var major, out var minor, out var revision);
           
            var result = new StringBuilder();
            
            result.AppendLine($"Version: {major}.{minor}.{revision}");
            result.Append($"Thread: {Thread?.Name ?? "unnamed"} ({Thread?.ManagedThreadId ?? -1})");

            return result.ToString();
        }
    }


    public override bool InternalInit()
    {
        _glfw = Glfw.GetApi();
        _glfw.SetErrorCallback(OnErrorCallback);
        
        if (!_glfw.Init())
            return false;

        _glfw.SetMonitorCallback(OnMonitorCallback);
        _glfw.SetJoystickCallback(OnJoystickCallback);
        
        return true;
    }

    public override void InternalTerminate()
    {
        _glfw.Terminate();
    }

    public override void InternalPollEvents()
    {
        _glfw.PollEvents();
    }

    public override void InternalPostEmptyEvent()
    {
        _glfw.PostEmptyEvent();
    }

    public override void InternalMakeContextCurrent(nint window)
    {
        _glfw.MakeContextCurrent((SilkWindowHandle*) window);
    }

    public override nint InternalGetCurrentContext()
    {
        return (nint) _glfw.GetCurrentContext();
    }

    public override void InternalWaitEvents()
    {
        _glfw.WaitEvents();
    }

    public override void InternalWaitEventsTimeout(double timeout)
    {
        _glfw.WaitEventsTimeout(timeout);
    }

    public override nint InternalWindowCreate(WindowCreateSettings settings)
    {
        var size = settings.Size;
        var title = settings.Title;
        var monitor = settings.MonitorShare;
        var share = settings.ContextShare;
        
        _glfw.WindowHint(WindowHintClientApi.ClientApi, ToClientApi(settings.Api));

        if (settings.Api != ContextApi.None)
        {
            _glfw.WindowHint(WindowHintInt.ContextVersionMajor, settings.Api.Version.Major);
            _glfw.WindowHint(WindowHintInt.ContextVersionMinor, settings.Api.Version.Minor);
        }

        _glfw.WindowHint(WindowHintBool.OpenGLDebugContext, settings.Api.DebugFlag);
        _glfw.WindowHint(WindowHintBool.OpenGLForwardCompat, settings.Api.ForwardCompatibleFlag);

        if (settings.Api >= new Version(3, 2))
            _glfw.WindowHint(WindowHintOpenGlProfile.OpenGlProfile, ToGlProfile(settings.Api));

        var windowHandle = _glfw.CreateWindow(size.X, size.Y, title, null, null);

        _glfw.SetWindowCloseCallback(windowHandle, OnWindowCloseCallback);
        _glfw.SetWindowSizeCallback(windowHandle, OnWindowSizeCallback);
        _glfw.SetWindowPosCallback(windowHandle, OnWindowPositionCallback);
        _glfw.SetWindowFocusCallback(windowHandle, OnWindowFocusCallback);
        
        return (nint) windowHandle;
    }

    public override void InternalWindowSetTitle(nint window, string title)
    {
        _glfw.SetWindowTitle((SilkWindowHandle*) window, title);
    }

    public override void InternalWindowSetPosition(nint window, Vector2i position)
    {
        _glfw.SetWindowPos((SilkWindowHandle*) window, position.X, position.Y);
    }

    public override void InternalWindowSetSize(nint window, Vector2i size)
    {
        _glfw.SetWindowSize((SilkWindowHandle*) window, size.X, size.Y);
    }

    public override nint InternalGetProcAddress(string name)
    {
        return _glfw.GetProcAddress(name);
    }

    public override void InternalSwapBuffers(nint window)
    {
        _glfw.SwapBuffers((SilkWindowHandle*) window);
    }
}