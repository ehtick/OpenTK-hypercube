using Hypercube.Graphics.Windowing.Api;
using Hypercube.Graphics.Windowing.Settings;

namespace Hypercube.Graphics.Windowing.Manager;

public interface IWindowManager
{
    bool Ready { get; }
    
    void Init(WindowingApiSettings settings);
    void WaitInit(int sleepDelay);
    void Shutdown();
    
    void EnterLoop();
    void PollEvents();
    
    IWindow Create(WindowCreateSettings settings);
}