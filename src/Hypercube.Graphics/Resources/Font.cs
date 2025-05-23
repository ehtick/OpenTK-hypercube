using Hypercube.Mathematics.Shapes;
using Hypercube.Mathematics.Vectors;
using Hypercube.Resources.Loaders;

namespace Hypercube.Graphics.Resources;

public sealed class Font : Resource
{
    public Texture Texture { get; }
    public Dictionary<char, GlyphInfo> Glyphs { get; }

    public Font(Texture texture, Dictionary<char, GlyphInfo> glyphs)
    {
        Texture = texture;
        Glyphs = glyphs;
    }

    public override void Dispose()
    {
        Texture.Dispose();
        Glyphs.Clear();
    }
}

public struct GlyphInfo
{
    public Box2 SourceRect;
    public Vector2 Offset;
    public float Advance;
}