using Hypercube.Core.Analyzers;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Graphics.Windowing;

public interface IWindow : IContextInfo, IDisposable
{
    [EngineCore]
    public nint Handle { get; }
    
    [EngineCore]
    public nint CurrentContext { get; }
    
    public Vector2i Size { get; set; }
    
    void MakeCurrent();
    void SwapBuffers();
}