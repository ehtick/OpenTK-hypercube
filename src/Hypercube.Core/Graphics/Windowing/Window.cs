using Hypercube.Core.Graphics.Windowing.Api;
using Hypercube.Mathematics.Vectors;
using JetBrains.Annotations;

namespace Hypercube.Core.Graphics.Windowing;

[PublicAPI]
public unsafe class Window : IWindow
{
    private readonly IWindowingApi _windowingApi;
    private readonly WindowHandle _windowHandle;

    public Window(IWindowingApi windowingApi, WindowHandle windowHandle)
    {
        _windowingApi = windowingApi;
        _windowHandle = windowHandle;
    }

    public string Title { get; set; }
    public Vector2i Position { get; set; }
    public Vector2i Size { get; set; }
    public float Opacity { get; set; }
    public bool Visibility { get; set; }
    
    public void Show()
    {
        throw new NotImplementedException();
    }

    public void Hide()
    {
        throw new NotImplementedException();
    }

    public void Focus()
    {
        throw new NotImplementedException();
    }

    public void RequestAttention()
    {
        throw new NotImplementedException();
    }

    public void SwapBuffers()
    {
        throw new NotImplementedException();
    }

    public void Close()
    {
        throw new NotImplementedException();
    }
}
