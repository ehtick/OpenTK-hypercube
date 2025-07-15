using System.Collections.ObjectModel;
using Hypercube.Mathematics.Shapes;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Core.Graphics.Texturing;

/// <inheritdoc/>
[PublicAPI]
public class Image : IImage
{
    private readonly byte[] _data;

    /// <inheritdoc/>
    public int Channels { get; }

    /// <inheritdoc/>
    public Vector2i Size { get; }

    /// <inheritdoc/>
    public int Width => Size.X;

    /// <inheritdoc/>
    public int Height => Size.Y;

    /// <inheritdoc/>
    public Rect2 UV => Rect2.UV;

    /// <inheritdoc/>
    public ReadOnlyCollection<byte> Data => Array.AsReadOnly(_data);

    public Image(byte[] data, int width, int height, int channels)
    {
        _data = data;
        
        Size = new Vector2i(width, height);
        Channels = channels;
    }

    /// <inheritdoc/>
    public ReadOnlySpan<byte> GetPixel(Vector2i position)
    {
        return GetPixel(position.X, position.Y);
    }

    /// <inheritdoc/>
    public ReadOnlySpan<byte> GetPixel(int x, int y)
    {
        if (x < 0 || x >= Width)
            throw new ArgumentOutOfRangeException(nameof(x), x, $"Value must be between 0 and {Width - 1} inclusive.");
        
        if (y < 0 || y >= Height)
            throw new ArgumentOutOfRangeException(nameof(y), y, $"Value must be between 0 and {Height - 1} inclusive.");
        
        return new ReadOnlySpan<byte>(_data, (y * Width + x) * Channels, Channels);
    }
}