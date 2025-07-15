using Hypercube.Core.Graphics.Windowing.Settings;

namespace Hypercube.Core.Graphics.Rendering;

public interface IRenderer
{
    void Init(RendererSettings settings);
    void Load();
    void Shutdown();
    void Update();
    void Draw();
    void Render();
    void CreateMainWindow(WindowCreateSettings settings);
}