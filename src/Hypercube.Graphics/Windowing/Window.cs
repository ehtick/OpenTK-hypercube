using Hypercube.Core.Analyzers;
using Hypercube.Graphics.Windowing.Api;
using Hypercube.Graphics.Windowing.Settings;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Graphics.Windowing;

[EngineInternal]
public class Window : IWindow
{
    public nint Handle { get; }
    public nint CurrentContext => _api.ContextCurrent;
    
    public Vector2i Size
    {
        get => _cachedSize;
        set => _api.WindowSetSize(Handle, value);
    }

    private readonly IWindowingApi _api;

    private Vector2i _cachedSize;
    
    public Window(IWindowingApi api, nint handle, WindowCreateSettings settings)
    {
        _api = api;
        Handle = handle;

        _cachedSize = settings.Size;
        
        _api.OnWindowSize += OnWindowSize;
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

    public void Dispose()
    {
        _api.OnWindowSize -= OnWindowSize;
        _api.WindowDestroy(Handle);
    }

    private void OnWindowSize(nint window, Vector2i size)
    {
       if (window != Handle)
           return;

       _cachedSize = size;
    }
}