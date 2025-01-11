namespace Hypercube.Graphics.Windowing;

public interface IWindow : IContextInfo
{
    public nint Handle { get; }

    void MakeCurrent();
    void SwapBuffers();
}