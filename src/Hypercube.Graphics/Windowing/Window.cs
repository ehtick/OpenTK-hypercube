using Hypercube.Mathematics.Vectors;

namespace Hypercube.Graphics.Windowing;

public class Window : IWindow
{
    public IWindowing Windowing { get; }
    
    public IWindow? Owner { get; }
    public nint Pointer { get; }
    public Vector2i Size { get; }
    public Vector2i FramebufferSize { get; }

    public Window(IWindowing windowing)
    {
        Windowing = windowing;
    }
}