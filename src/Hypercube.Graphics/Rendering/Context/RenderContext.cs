using Hypercube.Core.Analyzers;
using Hypercube.Graphics.Rendering.Api;
using Hypercube.Graphics.Rendering.Batching;
using Hypercube.Graphics.Resources;
using Hypercube.Mathematics;
using Hypercube.Mathematics.Matrices;
using Hypercube.Mathematics.Quaternions;
using Hypercube.Mathematics.Shapes;
using Hypercube.Mathematics.Vectors;
using JetBrains.Annotations;

namespace Hypercube.Graphics.Rendering.Context;

[EngineInternal, UsedImplicitly]
public sealed class RenderContext : IRenderContext
{
    private IRenderingApi _renderingApi = default!;
    
    public void Init(IRenderingApi api)
    {
        _renderingApi = api;
    }

    public void DrawModel(Model model, Vector3 position, Quaternion rotation, Vector3 scale, Color color, Texture? texture)
    {
        var shader = texture is null ? _renderingApi.PrimitiveShaderProgram : _renderingApi.TexturingShaderProgram;
        if (shader is null)
            throw new Exception("Model shader program is not initialized.");

        if (texture is not null && texture.Gpu is null)
            texture.GpuBind(_renderingApi);
        
        _renderingApi.EnsureBatch(PrimitiveTopology.TriangleList, shader.Handle, texture?.Gpu?.Handle);

        var start = _renderingApi.BatchVerticesIndex;
        var matrix = Matrix4x4.CreateTransform(position, rotation, scale);
        
        foreach (var (v, vt, vn) in model.Indices)
        {
            var pos = matrix.Transform(model.Vertices[v]);
            
            var uv = vt >= 0 && vt < model.UVs.Length ? model.UVs[vt] : Vector2.Zero;;
            var normal = vn >= 0 && vn < model.Normals.Length
                ? TransformNormal(model.Normals[vn], matrix).Normalized
                : Vector3.UnitZ;
    
            _renderingApi.PushVertex(new Vertex(pos, uv, color, normal));
        }
        
        for (var i = 0; i < model.Indices.Length; i += 3)
        {
            _renderingApi.PushIndex(start, i + 0);
            _renderingApi.PushIndex(start, i + 1);
            _renderingApi.PushIndex(start, i + 2);
        }
    }
    
    public void DrawText(string text, Font font, Vector2 position, Color color, float scale = 1f)
    {
        if (_renderingApi.TexturingShaderProgram is null)
            throw new Exception("Texturing shader program is not initialized.");
        
        if (string.IsNullOrEmpty(text))
            return;

        if (font.Texture.Gpu is null)
            font.Texture.GpuBind(_renderingApi);
        
        // Starting position for rendering
        var penPosition = position;

        // Using a texture shader and font as a texture
        _renderingApi.EnsureBatch(PrimitiveTopology.TriangleList, _renderingApi.TexturingShaderProgram.Handle, font.Texture.Gpu?.Handle);

        foreach (var c in text)
        {
            if (!font.Glyphs.TryGetValue(c, out var glyph))
            {
                // Can be replaced by a space or skip
                continue;
            }

            // Calculate glyph size and position
            var glyphSize = glyph.SourceRect.Size * scale;
            var glyphPosition = new Vector2(
                penPosition.X + glyph.Offset.X * scale,
                penPosition.Y
            );

            // Glyph square in local coordinates
            var quad = new Box2(
                new Vector2(glyphPosition.X, glyphPosition.Y + glyphSize.Y),
                new Vector2(glyphPosition.X + glyphSize.X, glyphPosition.Y)
            );
            
            var textureSize = font.Texture.Size; 
            var uv = new Box2(
                new Vector2(glyph.SourceRect.TopLeft.X / textureSize.X, glyph.SourceRect.TopLeft.Y / textureSize.Y),
                new Vector2(glyph.SourceRect.BottomRight.X / textureSize.X, glyph.SourceRect.BottomRight.Y / textureSize.Y)
            );

            // Adding a glyph to a patch
            AddQuadTriangleBatch(_renderingApi.BatchVerticesIndex, quad, uv, color);

            // Shift the stylus to Advance (horizontal shift)
            penPosition = new Vector2(penPosition.X + glyph.Advance * scale, penPosition.Y);
        }
    }
    
    public void DrawTexture(Texture texture, Vector2 position, Angle rotation, Vector2 scale, Color color)
    {
        if (_renderingApi.TexturingShaderProgram is null)
            throw new Exception();

        var box = new Box2(-texture.Size / 2, texture.Size / 2);
        var quad =
            Matrix4x4.CreateScale(new Vector3(scale.X, scale.Y, 1.0f)) *
            Matrix4x4.CreateRotationZ((float)rotation) *
            Matrix4x4.CreateTranslation(new Vector3(position, 0));
        
        _renderingApi.EnsureBatch(PrimitiveTopology.TriangleList, _renderingApi.TexturingShaderProgram.Handle, texture.Gpu?.Handle);
        AddQuadTriangleBatch(_renderingApi.BatchVerticesIndex, quad.Transform(box), Box2.UV, color);
    }
    
    public void DrawRectangle(Box2 box, Color color, bool outline = false)
    {
        if (_renderingApi.PrimitiveShaderProgram is null)
            throw new Exception();
        
        _renderingApi.EnsureBatch(outline ? PrimitiveTopology.LineList : PrimitiveTopology.TriangleList, _renderingApi.PrimitiveShaderProgram.Handle, null);
        AddQuadTriangleBatch(_renderingApi.BatchVerticesIndex, Matrix4x4.Identity.Transform(box), Box2.UV, color);
    }
    
    private void AddQuadTriangleBatch(int start, Box2 quad, Box2 uv, Color color)
    {
        _renderingApi.PushVertex(new Vertex(quad.TopRight, uv.TopRight, color));
        _renderingApi.PushVertex(new Vertex(quad.BottomRight, uv.BottomRight, color));
        _renderingApi.PushVertex(new Vertex(quad.BottomLeft, uv.BottomLeft, color));
        _renderingApi.PushVertex(new Vertex(quad.TopLeft, uv.TopLeft, color));
        
        _renderingApi.PushIndex(start, 0);
        _renderingApi.PushIndex(start, 1);
        _renderingApi.PushIndex(start, 3);
        _renderingApi.PushIndex(start, 1);
        _renderingApi.PushIndex(start, 2);
        _renderingApi.PushIndex(start, 3);
    }

    public void AddLineBatch(int start, Box2 box2, Color color)
    {
        _renderingApi.PushVertex(new Vertex(box2.TopRight, Vector2.Zero, color));
        _renderingApi.PushVertex(new Vertex(box2.BottomLeft, Vector2.Zero, color));
        _renderingApi.PushIndex(start, 0);
        _renderingApi.PushIndex(start, 1);
    }
    
    public void AddPointBatch(int start, Vector2 point, Color color)
    {
        _renderingApi.PushVertex(new Vertex(point, Vector2.Zero, color));
        _renderingApi.PushIndex(start, 0);
    }
    
    private static Vector3 TransformNormal(Vector3 n, Matrix4x4 m)
    {
        return new Vector3(
            n.X * m.M11 + n.Y * m.M21 + n.Z * m.M31,
            n.X * m.M12 + n.Y * m.M22 + n.Z * m.M32,
            n.X * m.M13 + n.Y * m.M23 + n.Z * m.M33
        );
    }
}