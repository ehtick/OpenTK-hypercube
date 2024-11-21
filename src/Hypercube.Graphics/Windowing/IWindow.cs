using Hypercube.Mathematics.Vectors;

namespace Hypercube.Graphics.Windowing;

public interface IWindow
{
    IWindowing Windowing { get; }
    IWindow? Owner { get; }
    
    
    nint Pointer { get; }
    
    Vector2i Size { get; }
    Vector2i FramebufferSize { get; }
}