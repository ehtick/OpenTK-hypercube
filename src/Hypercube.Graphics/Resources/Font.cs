using Hypercube.Graphics.Fonts;
using Hypercube.Resources.Loaders;

namespace Hypercube.Graphics.Resources;

public sealed class Font : Resource
{
    public Texture Texture { get; }
    public int Size { get; }

    private readonly Dictionary<char, Glyph> _glyphs;
    
    public IReadOnlyDictionary<char, Glyph> Glyphs => _glyphs;

    public Font(Texture texture, Dictionary<char, Glyph> glyphs, int size)
    {
        Texture = texture;
        _glyphs = glyphs;
        Size = size;
    }

    public override void Dispose()
    {
        Texture.Dispose();
        _glyphs.Clear();
    }
}

