using System.Collections.ObjectModel;
using Hypercube.Graphics.Rendering.Api;
using Hypercube.Graphics.Texturing;
using Hypercube.Graphics.Texturing.Gpu;
using Hypercube.Mathematics.Shapes;
using Hypercube.Mathematics.Vectors;
using Hypercube.Resources.Loaders;

namespace Hypercube.Graphics.Resources;

public sealed class Texture : Resource, IImage
{
    public Vector2i Size { get; }
    public Box2 UV { get; }
    public int Channels { get; }
    public IGpuTexture? Gpu { get; private set; }

    private readonly byte[] _data;

    public ReadOnlyCollection<byte> Data => _data.AsReadOnly();
    
    public Texture(Vector2i size, byte[] data, int channels, Box2 uv)
    {
        _data = data;
        
        Size = size;
        Channels = channels;
        UV = uv;
    }

    public void GpuBind(IRenderingApi api)
    {
        Gpu = new GpuTexture(api, Size.X, Size.Y, Channels, _data);
    }
    
    public ReadOnlySpan<byte> GetPixel(Vector2i position)
    {
        return GetPixel(position.X, position.Y);
    }

    public ReadOnlySpan<byte> GetPixel(int x, int y)
    {
        if (x < 0 || y < 0 || x >= Size.X || y >= Size.Y)
            throw new ArgumentOutOfRangeException();

        var index = (y * Size.X + x) * Channels;
        return new ReadOnlySpan<byte>(_data, index, Channels);
    }
    
    public override void Dispose()
    {
        Gpu?.Dispose();
        Gpu = null;
    }
}