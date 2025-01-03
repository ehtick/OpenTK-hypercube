using JetBrains.Annotations;

namespace Hypercube.Graphics.Texturing;

[PublicAPI]
public interface ITexture : IDisposable
{
    int Handle { get; }
    IImage Image { get; }

    // void Bind(TextureTarget target);
    // void Unbind(TextureTarget target);
}