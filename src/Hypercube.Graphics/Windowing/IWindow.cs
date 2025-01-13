namespace Hypercube.Graphics.Windowing;

public interface IWindow : IContextInfo
{
    public nint Handle { get; }
    public nint CurrentContext { get; }

    void MakeCurrent();
    void SwapBuffers();
}