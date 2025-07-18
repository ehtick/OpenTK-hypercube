using Hypercube.Core.Windowing.Settings;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Core.Windowing.Api.Base;

public abstract partial class BaseWindowingApi : IWindowingApiInternal
{
    protected abstract string InternalInfo { get; }
    
    public abstract bool InternalInit();
    public abstract void InternalTerminate();
    
    public abstract void InternalPollEvents();
    public abstract void InternalPostEmptyEvent();
    public abstract void InternalWaitEvents();
    
    public abstract void InternalWaitEventsTimeout(double timeout);
    public abstract void InternalMakeContextCurrent(nint window);
    public abstract nint InternalGetCurrentContext();
    
    public abstract nint InternalWindowCreate(WindowCreateSettings settings);
    public abstract void InternalWindowDestroy(nint window);
    public abstract void InternalWindowSetTitle(nint window, string title);
    public abstract void InternalWindowSetPosition(nint window, Vector2i position);
    public abstract void InternalWindowSetSize(nint window, Vector2i size);

    public abstract nint InternalGetProcAddress(string name);
    public abstract void InternalSwapInterval(int interval);
    public abstract void InternalSwapBuffers(nint window);
}