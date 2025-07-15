using System.Collections.ObjectModel;
using Hypercube.Mathematics.Shapes;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Core.Graphics.Texturing;

/// <summary>
/// Represents a 2D image with pixel data and associated metadata.
/// </summary>
public interface IImage
{
    /// <summary>
    /// Gets the size of the image in pixels as a 2D vector (width, height).
    /// </summary>
    Vector2i Size { get; }

    /// <summary>
    /// Gets a read-only collection of raw image data bytes.
    /// The data is typically stored in row-major order.
    /// </summary>
    ReadOnlyCollection<byte> Data { get; }

    /// <summary>
    /// Gets the UV coordinate rectangle mapping the image.
    /// Typically used for texture sampling.
    /// </summary>
    Rect2 UV { get; }

    /// <summary>
    /// Gets the number of color channels per pixel (e.g., 3 for RGB, 4 for RGBA).
    /// </summary>
    int Channels { get; }

    /// <summary>
    /// Gets the width of the image in pixels.
    /// </summary>
    int Width => Size.X;

    /// <summary>
    /// Gets the height of the image in pixels.
    /// </summary>
    int Height => Size.Y;

    /// <summary>
    /// Returns a read-only span of bytes representing the pixel data at the specified position.
    /// The span length equals the number of channels.
    /// </summary>
    /// <param name="position">The 2D pixel coordinates (x, y) within the image.</param>
    /// <returns>A <see cref="ReadOnlySpan{Byte}"/> containing pixel channel data.</returns>
    ReadOnlySpan<byte> GetPixel(Vector2i position);

    /// <summary>
    /// Returns a read-only span of bytes representing the pixel data at the specified coordinates.
    /// The span length equals the number of channels.
    /// </summary>
    /// <param name="x">The x-coordinate of the pixel.</param>
    /// <param name="y">The y-coordinate of the pixel.</param>
    /// <returns>A <see cref="ReadOnlySpan{Byte}"/> containing pixel channel data.</returns>
    ReadOnlySpan<byte> GetPixel(int x, int y);
}
