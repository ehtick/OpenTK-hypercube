using Hypercube.Graphics.Windowing.Api;

namespace Hypercube.Core.Graphics.Windowing;

public class Window : IWindow
{
    private readonly IWindowingApi _api;
    
    public Window(IWindowingApi api)
    {
        _api = api;
    }
}