using Hypercube.Core.Execution.LifeCycle;
using Hypercube.Core.Windowing.Windows;

namespace Hypercube.Core.Graphics.Rendering;

public interface IRenderer : IRuntimeUpdatable
{
    IWindow MainMainWindow { get; }
    
    void Init(RendererSettings settings);
    void Load();
    void Shutdown();
    void Update();
    void Draw(DrawPayload payload);
    void Render();
    IWindow CreateMainWindow(WindowCreateSettings settings);
}