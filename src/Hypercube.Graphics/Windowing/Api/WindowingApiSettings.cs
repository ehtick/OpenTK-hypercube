namespace Hypercube.Graphics.Windowing.Api;

public readonly struct WindowingApiSettings
{
    public static readonly WindowingApiSettings DefaultGlfw = new()
    {
        Api = WindowingApi.Glfw,
        EventBridgeBufferSize = 32,
        WaitEventsTimeout = 0f,
        VSync = true
    };

    public WindowingApi Api { get; init; }
    public int EventBridgeBufferSize { get; init; }
    public float WaitEventsTimeout { get; init; }
    public bool VSync { get; init; }
}