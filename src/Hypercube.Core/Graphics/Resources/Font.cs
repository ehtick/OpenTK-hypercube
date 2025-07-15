using Hypercube.Core.Graphics.Fonts;
using Hypercube.Core.Resources.Loaders;

namespace Hypercube.Core.Graphics.Resources;

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

