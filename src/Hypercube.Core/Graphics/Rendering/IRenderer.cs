using Hypercube.Core.Windowing;
using Hypercube.Core.Windowing.Settings;

namespace Hypercube.Core.Graphics.Rendering;

public interface IRenderer
{
    void Init(RendererSettings settings);
    void Load();
    void Shutdown();
    void Update();
    void Draw();
    void Render();
    IWindow CreateMainWindow(WindowCreateSettings settings);
}