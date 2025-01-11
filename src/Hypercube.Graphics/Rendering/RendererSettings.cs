using Hypercube.Graphics.Rendering.Api;
using Hypercube.Graphics.Windowing.Api;

namespace Hypercube.Graphics.Rendering;

public readonly struct RendererSettings
{
    public RendererThreadSettings? Thread { get; init; }
    public WindowingApiSettings WindowingApi { get; init; }
    public RenderingApiSettings RenderingApi { get; init; }
    
    public bool Threading => Thread is not null;
}

public readonly struct RendererThreadSettings
{
    public string Name { get; init; }
    public ThreadPriority Priority { get; init; }
    public int StackSize { get; init; }
    public int ReadySleepDelay { get; init; }
}