using Hypercube.Core.Windowing.Settings;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Core.Windowing.Api;

[EngineInternal]
public interface IWindowingApiInternal : IContextInfo
{
    bool InternalInit();
    void InternalTerminate();
    void InternalPollEvents();
    void InternalPostEmptyEvent();
    void InternalWaitEvents();
    void InternalWaitEventsTimeout(double timeout);
    void InternalMakeContextCurrent(WindowHandle window);
    WindowHandle InternalGetCurrentContext();
    WindowHandle InternalWindowCreate(WindowCreateSettings settings);
    void InternalWindowDestroy(WindowHandle window);
    void InternalWindowSetTitle(WindowHandle window, string title);
    void InternalWindowSetPosition(WindowHandle window, Vector2i position);
    void InternalWindowSetSize(WindowHandle window, Vector2i size);
    nint InternalGetProcAddress(string name);
    void InternalSwapBuffers(WindowHandle window);
}