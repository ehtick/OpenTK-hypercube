using Hypercube.Mathematics.Vectors;

namespace Hypercube.Graphics.Windowing;

public interface IWindow : IContextInfo, IDisposable
{
    public nint Handle { get; }
    public nint CurrentContext { get; }
    public Vector2i Size { get; set; }
    
    void MakeCurrent();
    void SwapBuffers();
}