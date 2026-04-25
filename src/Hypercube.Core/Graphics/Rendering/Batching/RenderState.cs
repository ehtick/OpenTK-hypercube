using Hypercube.Mathematics.Matrices;

namespace Hypercube.Core.Graphics.Rendering.Batching;

public readonly struct RenderState : IEquatable<RenderState>
{
    public static readonly RenderState Default = new(Matrix4x4.Identity, Matrix4x4.Identity);
    
    public readonly Matrix4x4 View;
    public readonly Matrix4x4 Projection;

    public RenderState(in Matrix4x4 view, in Matrix4x4 projection)
    {
        View = view;
        Projection = projection;
    }

    public bool Equals(RenderState other)
        => View.Equals(other.View) && 
           Projection.Equals(other.Projection);

    public override bool Equals(object? obj)
        => obj is RenderState other &&
           Equals(other);

    public override int GetHashCode() => HashCode.Combine(View, Projection);

    public static bool operator ==(RenderState left, RenderState right) => left.Equals(right);

    public static bool operator !=(RenderState left, RenderState right) => !(left == right);
}
