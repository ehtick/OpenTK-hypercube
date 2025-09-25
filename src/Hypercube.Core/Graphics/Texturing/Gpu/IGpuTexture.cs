namespace Hypercube.Core.Graphics.Texturing.Gpu;

/// <summary>
/// Represents a GPU texture resource with basic properties and lifecycle management.
/// </summary>
public interface IGpuTexture : IDisposable
{
    /// <summary>
    /// Gets the native GPU handle (identifier) for this texture.
    /// This handle is used to bind or manipulate the texture in GPU operations.
    /// </summary>
    TextureHandle Handle { get; }
    
    /// <summary>
    /// Gets the width of the texture in pixels.
    /// </summary>
    int Width { get; }
    
    /// <summary>
    /// Gets the height of the texture in pixels.
    /// </summary>
    int Height { get; }
    
    /// <summary>
    /// Gets the number of color channels per pixel in the texture (e.g., 3 for RGB, 4 for RGBA).
    /// </summary>
    int Channels { get; }
}
