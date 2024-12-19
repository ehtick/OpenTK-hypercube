namespace Hypercube.Core.Graphics.Rendering;

public interface IRenderer
{
    void Init(bool multiThread = false);
    Task InitAsync(bool multiThread = false);
    
    void Terminate();
}