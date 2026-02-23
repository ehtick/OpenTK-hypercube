using System.Text;
using Hypercube.Core.Graphics;
using Hypercube.Core.Windowing.Api.Base;
using Hypercube.Core.Windowing.Settings;
using Hypercube.Mathematics.Vectors;
using Silk.NET.GLFW;
using SilkGlfw = Silk.NET.GLFW.Glfw;
using SilkWindowHandle = Silk.NET.GLFW.WindowHandle;
using ContextApi = Hypercube.Core.Windowing.Settings.ContextApi;
using SilkMonitor = Silk.NET.GLFW.Monitor;

namespace Hypercube.Core.Windowing.Api.Realisations.Glfw;

[EngineInternal]
public sealed unsafe partial class GlfwWindowingApi : BaseWindowingApi
{
    private SilkGlfw _glfw = null!;
    
    public override WindowingApi Type => WindowingApi.Glfw;

    protected override string Info
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

    public GlfwWindowingApi(WindowingApiSettings settings) : base(settings)
    {
    }

    protected override bool InternalInit()
    {
        _glfw = SilkGlfw.GetApi();
        _glfw.SetErrorCallback(OnErrorCallback);
        
        if (!_glfw.Init())
            return false;

        _glfw.SetMonitorCallback(OnMonitorCallback);
        _glfw.SetJoystickCallback(OnJoystickCallback);
        return true;
    }

    protected override void InternalTerminate() => _glfw.Terminate();

    protected override void InternalPollEvents() => _glfw.PollEvents();

    protected override void InternalPostEmptyEvent() => _glfw.PostEmptyEvent();

    protected override void InternalMakeContextCurrent(WindowHandle window) => _glfw.MakeContextCurrent((SilkWindowHandle*) (nint) window);

    protected override WindowHandle InternalGetCurrentContext() => new((nint) _glfw.GetCurrentContext());

    protected override void InternalWaitEvents() => _glfw.WaitEvents();

    protected override void InternalWaitEventsTimeout(double timeout) => _glfw.WaitEventsTimeout(timeout);

    protected override WindowHandle InternalWindowCreate(WindowCreateSettings settings)
    {
        var size = settings.Size;
        var title = settings.Title;
        var monitor = (SilkMonitor*) settings.MonitorShare;
        var share = (SilkWindowHandle*) settings.ContextShare;
        
        // Hint
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

        // Creation
        var windowHandle = _glfw.CreateWindow(size.X, size.Y, title, monitor, share);

        // Sync
        _glfw.GetWindowPos(windowHandle, out var positionX, out var positionY);
        
        WindowSizeCallback(windowHandle, settings.Size.X, settings.Size.Y);
        WindowPositionCallback(windowHandle, positionX, positionY);

        // Callbacks
        _glfw.SetKeyCallback(windowHandle, WindowKeyCallback);
        _glfw.SetScrollCallback(windowHandle, WindowScrollCallback);
        _glfw.SetMouseButtonCallback(windowHandle, WindowMouseButtonCallback);
        _glfw.SetCursorPosCallback(windowHandle, WindowCursorCallback);
        
        _glfw.SetWindowCloseCallback(windowHandle, WindowCloseCallback);
        _glfw.SetWindowSizeCallback(windowHandle, WindowSizeCallback);
        _glfw.SetFramebufferSizeCallback(windowHandle, WindowFramebufferSizeCallback);
        _glfw.SetWindowPosCallback(windowHandle, WindowPositionCallback);
        _glfw.SetWindowFocusCallback(windowHandle, WindowFocusCallback);
        
        return new WindowHandle((nint) windowHandle);
    }

    protected override void InternalWindowDestroy(WindowHandle window)
    {
        _glfw.DestroyWindow((SilkWindowHandle*) (nint) window);
    }

    protected override void InternalWindowSetTitle(WindowHandle window, string title)
    {
        _glfw.SetWindowTitle((SilkWindowHandle*) (nint) window, title);
    }

    protected override void InternalWindowSetPosition(WindowHandle window, Vector2i position)
    {
        _glfw.SetWindowPos((SilkWindowHandle*) (nint) window, position.X, position.Y);
    }

    protected override void InternalWindowSetSize(WindowHandle window, Vector2i size)
    {
        _glfw.SetWindowSize((SilkWindowHandle*) (nint) window, size.X, size.Y);
    }

    protected override void InternalWindowSetFramebufferSize(WindowHandle window, Vector2i size)
    {
        _glfw.SetWindowSize((SilkWindowHandle*) (nint) window, size.X, size.Y);
    }

    protected override void InternalSwapBuffers(WindowHandle window)
    {
        _glfw.SwapBuffers((SilkWindowHandle*) (nint) window);
    }

    public override void SwapInterval(int interval)
    {
        _glfw.SwapInterval(interval);
    }

    public override nint GetProcAddress(string name)
    {
        return _glfw.GetProcAddress(name);
    }
}