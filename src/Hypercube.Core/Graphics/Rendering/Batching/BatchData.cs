using Hypercube.Core.Graphics.Rendering.Enums;

namespace Hypercube.Core.Graphics.Rendering.Batching;

public readonly struct BatchData : IEquatable<BatchData>
{
    public readonly int Start;
    public readonly int? Texture;
    public readonly int Shader;
    public readonly PrimitiveTopology PrimitiveTopology;

    public BatchData(int start, int? texture, int shader, PrimitiveTopology primitiveTopology)
    {
        Start = start;
        Texture = texture;
        Shader = shader;
        PrimitiveTopology = primitiveTopology;
    }
    
    public bool Equals(BatchData other)
    {
        return Start == other.Start &&
               Texture == other.Texture &&
               Shader == other.Shader &&
               PrimitiveTopology == other.PrimitiveTopology;
    }

    public override bool Equals(object? obj)
    {
        return obj is BatchData other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Start, Texture, Shader, (int)PrimitiveTopology);
    }
    
    public static bool operator ==(BatchData a, BatchData b)
    {
        return a.Equals(b);
    }

    public static bool operator !=(BatchData a, BatchData b)
    {
        return !a.Equals(b);
    }
}