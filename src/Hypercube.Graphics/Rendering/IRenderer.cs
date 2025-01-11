using Hypercube.Graphics.Windowing.Settings;

namespace Hypercube.Graphics.Rendering;

public interface IRenderer
{
    void Init(RendererSettings settings);
    void Setup();
    void Shutdown();
    void Update();
    void Render();
    void CreateMainWindow(WindowCreateSettings settings);
}