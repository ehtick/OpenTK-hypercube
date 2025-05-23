using Hypercube.Graphics.Windowing.Api;
using Hypercube.Graphics.Windowing.Settings;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Graphics.Windowing.Manager;

public interface IWindowManager
{
    event Action<Vector2i>? OnMainWindowResized;
    
    bool Ready { get; }
    
    void Init(WindowingApiSettings settings);
    void WaitInit(int sleepDelay);
    void Shutdown();
    
    void EnterLoop();
    void PollEvents();
    
    IWindow Create(WindowCreateSettings settings);
}