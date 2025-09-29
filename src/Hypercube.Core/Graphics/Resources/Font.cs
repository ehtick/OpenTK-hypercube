using System.Collections.Frozen;
using System.Runtime.CompilerServices;
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

    public FrozenDictionary<char, Glyph> Glyphs
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Info.Glyphs;
    }
    
    public int Ascent
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Info.Ascent;
    }
    
    public int Descent
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Info.Descent;
    }
    
    public int LineGap
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Info.LineGap;
    }
    
    public float LineHeight
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Info.LineHeight;
    }
    
    public float Baseline
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Info.Baseline;
    }

    public Font(Texture texture, FontInfo info)
    {
        Texture = texture;
        Info = info;
    }
    
    public override void Dispose()
    {
        Texture.Dispose();
    }
}
