using Hypercube.Core.Graphics.Rendering.Api.Settings;
using Hypercube.Core.Graphics.Windowing.Api;

namespace Hypercube.Core.Graphics.Rendering;

public readonly struct RendererSettings
{
    public WindowingThreadSettings? Thread { get; init; }
    public WindowingApiSettings WindowingApi { get; init; }
    public RenderingApiSettings RenderingApi { get; init; }
    public int ReadySleepDelay { get; init; }
}

public readonly struct WindowingThreadSettings
{
    public string Name { get; init; }
    public ThreadPriority Priority { get; init; }
    public int StackSize { get; init; }
}