namespace Hypercube.Graphics.Texturing.Gpu;

public interface IGpuTexture : IDisposable
{
    uint Handle { get; }
    int Width { get; }
    int Height { get; }
    int Channels { get; }
}
