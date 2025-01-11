namespace Hypercube.Graphics.Windowing.Api;

public readonly struct WindowingApiSettings
{
    public static readonly WindowingApiSettings Default = new()
    {
        Api = WindowingApi.Glfw,
        EventBridgeBufferSize = 32,
        WaitEventsTimeout = 0f
    };

    public WindowingApi Api { get; init; }
    public int EventBridgeBufferSize { get; init; }
    public float WaitEventsTimeout { get; init; }
}