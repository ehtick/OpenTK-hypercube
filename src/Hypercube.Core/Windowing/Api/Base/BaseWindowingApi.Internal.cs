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
    public abstract void InternalMakeContextCurrent(WindowHandle window);
    public abstract WindowHandle InternalGetCurrentContext();
    
    public abstract WindowHandle InternalWindowCreate(WindowCreateSettings settings);
    public abstract void InternalWindowDestroy(WindowHandle window);
    public abstract void InternalWindowSetTitle(WindowHandle window, string title);
    public abstract void InternalWindowSetPosition(WindowHandle window, Vector2i position);
    public abstract void InternalWindowSetSize(WindowHandle window, Vector2i size);

    public abstract nint InternalGetProcAddress(string name);
    public abstract void InternalSwapInterval(int interval);
    public abstract void InternalSwapBuffers(WindowHandle window);
}