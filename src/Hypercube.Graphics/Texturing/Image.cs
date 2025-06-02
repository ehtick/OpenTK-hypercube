using System.Collections.ObjectModel;
using Hypercube.Mathematics.Shapes;
using Hypercube.Mathematics.Vectors;
using JetBrains.Annotations;

namespace Hypercube.Graphics.Texturing;

[PublicAPI]
public class Image : IImage
{
    public Vector2i Size { get; }
    public int Channels { get; }

    private readonly byte[] _data;

    public ReadOnlyCollection<byte> Data => Array.AsReadOnly(_data);
    public int Width => Size.X;
    public int Height => Size.Y;
    public Rect2 UV => Rect2.UV;

    public Image(byte[] data, int width, int height, int channels)
    {
        _data = data;
        
        Size = new Vector2i(width, height);
        Channels = channels;
    }

    public ReadOnlySpan<byte> GetPixel(Vector2i position)
    {
        return GetPixel(position.X, position.Y);
    }

    public ReadOnlySpan<byte> GetPixel(int x, int y)
    {
        if (x < 0 || y < 0 || x >= Width || y >= Height)
            throw new ArgumentOutOfRangeException();

        var index = (y * Width + x) * Channels;
        return new ReadOnlySpan<byte>(_data, index, Channels);
    }
}