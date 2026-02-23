using Hypercube.Core.Windowing.Settings;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Core.Windowing.Api.Base;

public abstract partial class BaseWindowingApi
{
    protected abstract string Info { get; }
    
    protected abstract bool InternalInit();
    protected abstract void InternalTerminate();
    
    protected abstract void InternalPollEvents();
    protected abstract void InternalPostEmptyEvent();
    protected abstract void InternalWaitEvents();
    
    protected abstract void InternalWaitEventsTimeout(double timeout);
    protected abstract void InternalMakeContextCurrent(WindowHandle window);
    protected abstract WindowHandle InternalGetCurrentContext();
    
    protected abstract WindowHandle InternalWindowCreate(WindowCreateSettings settings);
    protected abstract void InternalWindowDestroy(WindowHandle window);
    protected abstract void InternalWindowSetTitle(WindowHandle window, string title);
    protected abstract void InternalWindowSetPosition(WindowHandle window, Vector2i position);
    protected abstract void InternalWindowSetSize(WindowHandle window, Vector2i size);
    protected abstract void InternalWindowSetFramebufferSize(WindowHandle window, Vector2i size);
    
    protected abstract void InternalSwapBuffers(WindowHandle window);
}