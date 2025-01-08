namespace Hypercube.Graphics.Windowing.Api;

public readonly struct WindowingApiSettings
{
    public bool MultiThread { get; init; } = false;
    public int EventBridgeBufferSize { get; init; } = 32;
    public float WaitEventsTimeout { get; init; } = 0f;

    public WindowingApiSettings()
    {
    }
}