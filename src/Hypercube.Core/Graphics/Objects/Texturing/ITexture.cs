using Hypercube.Core.Graphics.Objects.Texturing.Gpu;
using Hypercube.Core.Graphics.Rendering.Api;

namespace Hypercube.Core.Graphics.Objects.Texturing;

/// <summary>
/// Represents a texture resource that combines image data with an optional GPU representation.
/// </summary>
public interface ITexture : IImage
{
    /// <summary>
    /// Gets the source image associated with this texture.
    /// </summary>
    IImage Image { get; }

    /// <summary>
    /// Gets the GPU texture resource if it has been created; otherwise <see langword="null"/>.
    /// </summary>
    IGpuTexture? Gpu { get; }

    /// <summary>
    /// Binds the texture to the specified rendering API context.
    /// This ensures the texture is available for subsequent rendering operations.
    /// </summary>
    /// <param name="api">
    /// The rendering API used to bind the texture.
    /// </param>
    void GpuBind(IRenderingApi api);
}
