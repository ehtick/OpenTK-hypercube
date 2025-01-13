using Hypercube.Graphics.Windowing.Api;

namespace Hypercube.Graphics.Windowing;

public class Window : IWindow
{
    public nint Handle { get; }
    public nint CurrentContext => _api.ContextCurrent;

    private readonly IWindowingApi _api;

    public Window(IWindowingApi api, nint handle)
    {
        _api = api;
        Handle = handle;
    }

    public void MakeCurrent()
    {
        _api.ContextCurrent = Handle;
    }

    public void SwapBuffers()
    {
        _api.WindowSwapBuffers(Handle);
    }

    public nint GetProcAddress(string name)
    {
        return _api.GetProcAddress(name);
    }
}