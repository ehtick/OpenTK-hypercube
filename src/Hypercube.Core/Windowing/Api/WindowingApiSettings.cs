namespace Hypercube.Core.Windowing.Api;

public readonly struct WindowingApiSettings
{
    public bool Multithread { get; init; }
    public WindowingApi Api { get; init; }
    public int EventBridgeBufferSize { get; init; }
    public float WaitEventsTimeout { get; init; }
}