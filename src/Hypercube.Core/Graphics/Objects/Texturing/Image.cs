using Hypercube.Mathematics.Shapes;

namespace Hypercube.Core.Graphics.Objects.Texturing;

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
    public Rect2 Uv { get; }

    /// <inheritdoc/>
    public ReadOnlyMemory<byte> Data => new Memory<byte>(_data);

    public Image(byte[] data, Vector2i size, int channels, Rect2 uv)
    {
        _data = data;
        
        Size = size;
        Channels = channels;
        Uv = uv;
    }

    /// <inheritdoc/>
    public ReadOnlySpan<byte> GetPixel(Vector2i position) => GetPixel(position.X, position.Y);

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