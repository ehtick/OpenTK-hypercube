using Hypercube.Core.Graphics.Objects.Texturing;
using Hypercube.Core.Graphics.Objects.Texturing.Gpu;
using Hypercube.Core.Graphics.Rendering.Api;
using Hypercube.Core.Resources.Loaders;
using Hypercube.Mathematics.Shapes;

namespace Hypercube.Core.Graphics.Resources;

public sealed class Texture : Resource, ITexture
{
    /// <inheritdoc/>
    public IImage Image { get; }

    /// <inheritdoc/>
    public IGpuTexture? Gpu { get; private set; }

    /// <inheritdoc/>
    public Vector2i Size => Image.Size;

    /// <inheritdoc/>
    public Rect2 Uv => Image.Uv;

    /// <inheritdoc/>
    public int Channels => Image.Channels;

    /// <inheritdoc/>
    public ReadOnlyMemory<byte> Data => Image.Data;

    public Texture(byte[] data, Vector2i size, int channels, Rect2 uv)
    {
        Image = new Image(data, size, channels, uv);
    }
    
    public Texture(Image image)
    {
        Image = image;
    }

    /// <inheritdoc/>
    public void GpuBind(IRenderingApi api)
    {
        Gpu?.Dispose();
        Gpu = new GpuTexture(api, Size.X, Size.Y, Channels, Image.Data.Span.ToArray());
    }

    /// <inheritdoc/>
    public ReadOnlySpan<byte> GetPixel(Vector2i position) => Image.GetPixel(position);
    
    /// <inheritdoc/>
    public ReadOnlySpan<byte> GetPixel(int x, int y) => Image.GetPixel(x, y);

    public override void Dispose()
    {
        Gpu?.Dispose();
        Gpu = null;
    }
}