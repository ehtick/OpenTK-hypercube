using Hypercube.Core.Execution.LifeCycle;
using Hypercube.Core.Windowing;
using Hypercube.Core.Windowing.Settings;

namespace Hypercube.Core.Graphics.Rendering;

public interface IRenderer : IRuntimeUpdatable
{
    IWindow MainWindow { get; }
    
    void Init(RendererSettings settings);
    void Load();
    void Shutdown();
    void Update();
    void Draw(DrawPayload payload);
    void Render();
    IWindow CreateMainWindow(WindowCreateSettings settings);
}