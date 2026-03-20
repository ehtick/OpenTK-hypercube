using Hypercube.Mathematics.Matrices;

namespace Hypercube.Core.Graphics.Rendering.Batching;

public readonly struct RenderState
{
    public readonly Matrix4x4 View;
    public readonly Matrix4x4 Projection;

    public RenderState(Matrix4x4 view, Matrix4x4 projection)
    {
        View = view;
        Projection = projection;
    }
}