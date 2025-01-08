namespace Hypercube.Core.Graphics.Rendering;

public interface IRenderer
{
    void Init(bool multiThread = false);
    void CreateMainWindow();

    void Update();
    void Render();
    
    void Terminate();
}