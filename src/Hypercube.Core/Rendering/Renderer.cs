using Hypercube.Graphics.WindowManager;
using Hypercube.Graphics.WindowManager.Glfw;

namespace Hypercube.Core.Rendering;

public class Renderer
{
    private readonly IWindowManager _windowManager = new GlfwWindowManager();
    
    public void Init()
    {
        _windowManager.Init();
    }

    public void Terminate()
    {
        _windowManager.Terminate();
    }
}