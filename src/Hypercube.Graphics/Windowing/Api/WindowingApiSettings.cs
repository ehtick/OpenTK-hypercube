using WindowingApiType = Hypercube.Graphics.WindowingApi;

namespace Hypercube.Graphics.Windowing.Api;

public readonly struct WindowingApiSettings
{
    public static readonly WindowingApiSettings Default = new()
    {
        Api = WindowingApiType.Glfw,
        EventBridgeBufferSize = 32,
        WaitEventsTimeout = 0f
    };

    public WindowingApiType Api { get; init; } = WindowingApiType.Glfw;
    public int EventBridgeBufferSize { get; init; } = 32;
    public float WaitEventsTimeout { get; init; } = 0f;

    public WindowingApiSettings()
    {
    }
}