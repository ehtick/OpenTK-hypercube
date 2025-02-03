using JetBrains.Annotations;

namespace Hypercube.Graphics.Texturing;

[PublicAPI]
public interface IImage
{
    int Width { get; }
    int Height { get; }
    byte[] Data { get; }
}