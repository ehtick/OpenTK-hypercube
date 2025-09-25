using Hypercube.Core.Graphics.Rendering.Api;

namespace Hypercube.Core.Graphics.Texturing.Gpu;

/// <inheritdoc/>
public sealed class GpuTexture : IGpuTexture
{
    private readonly IRenderingApi _api;

    /// <inheritdoc/>
    public TextureHandle Handle { get; }

    /// <inheritdoc/>
    public int Width { get; }

    /// <inheritdoc/>
    public int Height { get; }

    /// <inheritdoc/>
    public int Channels { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="GpuTexture"/> class by creating
    /// a GPU texture with the specified dimensions, channels, and initial pixel data.
    /// </summary>
    /// <param name="api">The rendering API used to create and manage the texture.</param>
    /// <param name="width">The width of the texture in pixels.</param>
    /// <param name="height">The height of the texture in pixels.</param>
    /// <param name="channels">The number of color channels per pixel.</param>
    /// <param name="data">The initial pixel data for the texture.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if the texture creation fails and a valid handle is not obtained.
    /// </exception>
    public GpuTexture(IRenderingApi api, int width, int height, int channels, byte[] data)
    {
        _api = api;

        Handle = _api.CreateTexture(width, height, channels, data);
        Width = width;
        Height = height;
        Channels = channels;
    }

    /// <summary>
    /// Releases the GPU texture resource by deleting it through the rendering API.
    /// </summary>
    public void Dispose()
    {
        _api.DeleteTexture(Handle);
    }
}
