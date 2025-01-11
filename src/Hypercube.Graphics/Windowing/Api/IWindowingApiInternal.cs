using Hypercube.Graphics.Windowing.Settings;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Graphics.Windowing.Api;

public interface IWindowingApiInternal : IContextInfo
{
    bool InternalInit();
    void InternalTerminate();
    void InternalPostEmptyEvent();
    void InternalMakeContextCurrent(nint window);
    nint InternalWindowCreate(WindowCreateSettings settings);
    void InternalWindowSetTitle(nint window, string title);
    void InternalWindowSetPosition(nint window, Vector2i position);
    void InternalWindowSetSize(nint window, Vector2i size);
    nint InternalGetProcAddress(string name);
    void InternalSwapBuffers(nint window);
}