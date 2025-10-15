using Hypercube.Core.Graphics;

namespace Hypercube.Core.Windowing.Api;

public readonly struct WindowingApiSettings
{
    public WindowingApi Api { get; init; }
    public int EventBridgeBufferSize { get; init; }
    public float WaitEventsTimeout { get; init; }
}