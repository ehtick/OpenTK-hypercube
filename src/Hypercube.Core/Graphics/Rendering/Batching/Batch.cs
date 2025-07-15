using Hypercube.Mathematics.Matrices;

namespace Hypercube.Core.Graphics.Rendering.Batching;

public readonly struct Batch
{
    public readonly int Start;
    public readonly int Size;
    public readonly uint? TextureHandle;
    public readonly PrimitiveTopology PrimitiveTopology;
    public readonly Matrix4x4 Model;

    public Batch(int start, int size, uint? textureHandle, PrimitiveTopology primitiveTopology, Matrix4x4 model)
    {
        Start = start;
        Size = size;
        TextureHandle = textureHandle;
        PrimitiveTopology = primitiveTopology;
        Model = model;
    }
}