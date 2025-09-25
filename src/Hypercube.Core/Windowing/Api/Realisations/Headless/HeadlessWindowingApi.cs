using Hypercube.Core.Graphics;
using Hypercube.Core.Windowing.Api.Base;
using Hypercube.Core.Windowing.Settings;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Core.Windowing.Api.Realisations.Headless;

public sealed class HeadlessWindowingApi : BaseWindowingApi
{
    public override WindowingApi Type => WindowingApi.Headless;
    protected override string InternalInfo => string.Empty;
    
    public override bool InternalInit()
    {
        return true;
    }

    public override void InternalTerminate()
    {
    }

    public override void InternalPollEvents()
    {
    }

    public override void InternalPostEmptyEvent()
    {
    }

    public override void InternalWaitEvents()
    {
    }

    public override void InternalWaitEventsTimeout(double timeout)
    {
    }

    public override void InternalMakeContextCurrent(WindowHandle window)
    {
    }

    public override WindowHandle InternalGetCurrentContext()
    {
        return WindowHandle.Zero;
    }

    public override WindowHandle InternalWindowCreate(WindowCreateSettings settings)
    {
        return WindowHandle.Zero;
    }

    public override void InternalWindowDestroy(WindowHandle window)
    {
    }

    public override void InternalWindowSetTitle(WindowHandle window, string title)
    {
    }

    public override void InternalWindowSetPosition(WindowHandle window, Vector2i position)
    {
    }

    public override void InternalWindowSetSize(WindowHandle window, Vector2i size)
    {
    }

    public override nint InternalGetProcAddress(string name)
    {
        return nint.Zero;
    }

    public override void InternalSwapBuffers(WindowHandle window)
    {
    }

    public override void InternalSwapInterval(int interval)
    {
    }
}