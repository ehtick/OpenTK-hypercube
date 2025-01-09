using Hypercube.Graphics.Windowing.Api;
using Hypercube.Graphics.Windowing.Settings;

namespace Hypercube.Core.Graphics.Windowing.Manager;

public interface IWindowManager
{
    bool Ready { get; }
    void Init(WindowingApiSettings settings);
    void WaitInit(int sleepDelay);
    void EnterLoop();
    void PollEvents();
    void Create(WindowCreateSettings settings);
}