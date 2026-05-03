using System.Collections.Frozen;
using System.Runtime.CompilerServices;
using Hypercube.Core.Graphics.Objects.Fonts;
using Hypercube.Core.Resources.Loaders;

namespace Hypercube.Core.Graphics.Resources;

/// <summary>
/// Represents a GPU-backed font resource, including its texture atlas and glyph metrics.
/// </summary>
[PublicAPI]
public class Font : Resource
{
    /// <summary>
    /// Gets the texture atlas containing all glyph bitmaps for this font.
    /// </summary>
    public readonly Texture Texture;

    /// <summary>
    /// Gets the font metadata and glyph information.
    /// </summary>
    public readonly FontInfo Info;

    /// <summary>
    /// Gets a read-only dictionary of glyphs indexed by character.
    /// </summary>
    public FrozenDictionary<char, Glyph> Glyphs
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Info.Glyphs;
    }
    
    /// <summary>
    /// Gets the ascent metric, representing the distance from the baseline to the top of the font.
    /// </summary>
    public int Ascent
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Info.Ascent;
    }
    
    /// <summary>
    /// Gets the descent metric, representing the distance from the baseline to the bottom of the font.
    /// Typically a negative value.
    /// </summary>
    public int Descent
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Info.Descent;
    }
    
    /// <summary>
    /// Gets the recommended additional spacing between lines.
    /// </summary>
    public int LineGap
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Info.LineGap;
    }
    
    /// <summary>
    /// Gets the total line height, including ascent, descent, and line gap.
    /// </summary>
    public float LineHeight
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Info.LineHeight;
    }
    
    /// <summary>
    /// Gets the baseline offset used for aligning text vertically.
    /// </summary>
    public float Baseline
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Info.Baseline;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Font"/> class with the specified texture and font information.
    /// </summary>
    /// <param name="texture">The texture atlas containing glyph images.</param>
    /// <param name="info">The font metadata and glyph definitions.</param>
    public Font(Texture texture, FontInfo info)
    {
        Texture = texture;
        Info = info;
    }
    
    public Vector2 Measure(string text)
    {
        if (string.IsNullOrEmpty(text))
            return Vector2.Zero;

        var width = 0f;
        var maxWidth = 0f;
        var height = LineHeight;

        foreach (var ch in text)
        {
            if (ch == '\n')
            {
                maxWidth = float.Max(maxWidth, width);
                width = 0;
                height += LineHeight;
                continue;
            }

            if (!Glyphs.TryGetValue(ch, out var glyph))
                continue;

            width += glyph.Advance;
        }

        maxWidth = float.Max(maxWidth, width);
        return new Vector2(maxWidth, height);
    }
    
    /// <summary>
    /// Releases the GPU resources associated with this font.
    /// </summary>
    public override void Dispose()
    {
        Texture.Dispose();
    }
}
