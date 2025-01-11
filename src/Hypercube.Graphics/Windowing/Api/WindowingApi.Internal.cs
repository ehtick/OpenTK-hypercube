using Hypercube.Graphics.Windowing.Settings;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Graphics.Windowing.Api;

public abstract unsafe partial class WindowingApi : IWindowingApiInternal
{
    public abstract bool InternalInit();
    public abstract void InternalTerminate();
    public abstract void InternalPollEvents();
    public abstract void InternalPostEmptyEvent();
    public abstract void InternalWaitEvents();
    public abstract void InternalWaitEventsTimeout(double timeout);
    public abstract void InternalMakeContextCurrent(nint window);
    public abstract nint InternalWindowCreate(WindowCreateSettings settings);
    public abstract void InternalWindowSetTitle(nint window, string title);
    public abstract void InternalWindowSetPosition(nint window, Vector2i position);
    public abstract void InternalWindowSetSize(nint window, Vector2i size);
    public abstract nint InternalGetProcAddress(string name);
    public abstract void InternalSwapBuffers(nint window);
}