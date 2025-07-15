using Hypercube.Core.Graphics.Windowing.Settings;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Core.Graphics.Windowing.Api;

[EngineInternal]
public interface IWindowingApiInternal : IContextInfo
{
    bool InternalInit();
    void InternalTerminate();
    void InternalPollEvents();
    void InternalPostEmptyEvent();
    void InternalWaitEvents();
    void InternalWaitEventsTimeout(double timeout);
    void InternalMakeContextCurrent(nint window);
    nint InternalGetCurrentContext();
    nint InternalWindowCreate(WindowCreateSettings settings);
    void InternalWindowDestroy(nint window);
    void InternalWindowSetTitle(nint window, string title);
    void InternalWindowSetPosition(nint window, Vector2i position);
    void InternalWindowSetSize(nint window, Vector2i size);
    nint InternalGetProcAddress(string name);
    void InternalSwapBuffers(nint window);
}