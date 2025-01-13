using Hypercube.Graphics.Windowing.Settings;

namespace Hypercube.Graphics.Rendering;

public interface IRenderer
{
    void Init(RendererSettings settings);
    void Shutdown();
    void Update();
    void Draw();
    void Render();
    void CreateMainWindow(WindowCreateSettings settings);
}