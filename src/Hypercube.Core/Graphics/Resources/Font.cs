using Hypercube.Core.Graphics.Fonts;
using Hypercube.Core.Resources.Loaders;

namespace Hypercube.Core.Graphics.Resources;

/// <summary>
/// Represents a GPU font with glyph atlas, metrics, and helpers.
/// </summary>
[PublicAPI]
public class Font : Resource
{
    public readonly Texture Texture;
    public readonly FontInfo Info;

    public Font(Texture texture, FontInfo info)
    {
        Texture = texture;
        Info = Info;
    }
    
    public override void Dispose()
    {
        Texture.Dispose();
    }
}
