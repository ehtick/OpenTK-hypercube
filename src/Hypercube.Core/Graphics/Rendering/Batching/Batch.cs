using System.Runtime.InteropServices;
using Hypercube.Core.Windowing;
using Hypercube.Mathematics.Matrices;

namespace Hypercube.Core.Graphics.Rendering.Batching;

[StructLayout(LayoutKind.Sequential)]
public readonly struct Batch : IEquatable<Batch>
{
    public readonly int Start;
    public readonly int Size;
    public readonly uint? TextureHandle;
    public readonly PrimitiveTopology PrimitiveTopology;
    public readonly Matrix4x4 Model;
    public readonly WindowHandle Window;

    public Batch(int start, int size, uint? textureHandle, PrimitiveTopology primitiveTopology, Matrix4x4 model, WindowHandle window)
    {
        Start = start;
        Size = size;
        TextureHandle = textureHandle;
        PrimitiveTopology = primitiveTopology;
        Model = model;
        Window = window;
    }

    public override bool Equals(object? obj)
    {
        return obj is Batch other && Equals(other);
    }

    public bool Equals(Batch other)
    {
        return Start == other.Start &&
               Size == other.Size &&
               TextureHandle == other.TextureHandle &&
               PrimitiveTopology == other.PrimitiveTopology &&
               Model == other.Model &&
               Window == other.Window;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Start, Size, TextureHandle, (int) PrimitiveTopology, Model, Window);
    }
}