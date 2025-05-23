using Hypercube.Graphics.Rendering.Api;

namespace Hypercube.Graphics.Texturing.Gpu;

public sealed class GpuTexture : IGpuTexture
{
    public uint Handle { get; }
    public int Width { get; }
    public int Height { get; }
    public int Channels { get; }

    private readonly IRenderingApi _api;

    public GpuTexture(IRenderingApi api, int width, int height, int channels, byte[] data)
    {
        _api = api;
        
        Width = width;
        Height = height;
        Channels = channels;

        Handle = _api.CreateTexture(width, height, channels, data);
        
        if (Handle <= 0)
            throw new InvalidOperationException("Failed to create GPU texture.");
    }

    public void Dispose()
    {
        _api.DeleteTexture(Handle);
    }
}
