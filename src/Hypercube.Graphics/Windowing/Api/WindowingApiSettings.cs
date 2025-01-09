namespace Hypercube.Graphics.Windowing.Api;

public readonly struct WindowingApiSettings
{
    public static readonly WindowingApiSettings Default = new()
    {
        EventBridgeBufferSize = 32,
        WaitEventsTimeout = 0f
    };
    
    public int EventBridgeBufferSize { get; init; } = 32;
    public float WaitEventsTimeout { get; init; } = 0f;

    public WindowingApiSettings()
    {
    }
}