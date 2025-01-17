using Hypercube.Graphics.Rendering.Api;
using Hypercube.Graphics.Rendering.Batching;
using Hypercube.Mathematics;
using Hypercube.Mathematics.Matrices;
using Hypercube.Mathematics.Shapes;
using Hypercube.Mathematics.Vectors;
using Hypercube.Utilities.Dependencies;

namespace Hypercube.Graphics.Rendering.Context;

public class RenderContext : IRenderContext
{
    [Dependency] private readonly IRenderingApi _renderingApi = default!;

    /*
    public void DrawTexture(ITextureHandle texture, Box2 quad, Box2 uv, Color color, Matrix4x4 model)
    {
        _renderingApi.EnsureBatch(PrimitiveTopology.TriangleList, texture.Handle, _texturingShaderProgram.Handle);
        
        AddQuadTriangleBatch(model.Transform(quad), uv, color);
    }
    */

    private void AddQuadTriangleBatch(Box2 quad, Box2 uv, Color color)
    {
        _renderingApi.PushVertex(new Vertex(quad.TopRight, uv.TopRight, color));
        _renderingApi.PushVertex(new Vertex(quad.BottomRight, uv.BottomRight, color));
        _renderingApi.PushVertex(new Vertex(quad.BottomLeft, uv.BottomLeft, color));
        _renderingApi.PushVertex(new Vertex(quad.TopLeft, uv.TopLeft, color));
        
        _renderingApi.PushIndex(0);
        _renderingApi.PushIndex(3);
        _renderingApi.PushIndex(1);
        _renderingApi.PushIndex(1);
        _renderingApi.PushIndex(2);
        _renderingApi.PushIndex(3);
    }

    private void AddLineBatch(Box2 box2, Color color)
    {
        _renderingApi.PushVertex(new Vertex(box2.TopRight, Vector2.Zero, color));
        _renderingApi.PushVertex(new Vertex(box2.BottomLeft, Vector2.Zero, color));
        
        _renderingApi.PushIndex(0);
        _renderingApi.PushIndex(1);
    }
    
    private void AddPointBatch(Vector2 point, Color color)
    {
        _renderingApi.PushVertex(new Vertex(point, Vector2.Zero, color));
        
        _renderingApi.PushIndex(0);
    }
}