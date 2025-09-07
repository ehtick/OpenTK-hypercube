using System.Collections.Frozen;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Core.Graphics.Fonts;

[PublicAPI]
public readonly struct FontInfo
{
    /// <summary>
    /// Glyph dictionary.
    /// </summary>
    public readonly FrozenDictionary<char, Glyph> Glyphs;

    #region head (font header table)

    public readonly int UnitsPerEm;

    #endregion
    
    #region hhea (horizontal header table)

    /// <summary>
    /// Height above the baseline.
    /// </summary>
    public readonly int Ascent;
    
    /// <summary>
    /// Depth below the baseline.
    /// </summary>
    public readonly int Descent;
    
    /// <summary>
    /// Additional space between lines.
    /// </summary>
    public readonly int LineGap;

    #endregion
    
    /// <summary>
    /// Total line height in pixels (ascent - descent + line gap).
    /// </summary>
    public float LineHeight => Ascent - Descent + LineGap;
    
    /// <summary>
    /// Distance from the top of the line to the baseline in pixels.
    /// </summary>
    public float Baseline => Ascent;
    
    public FontInfo(FrozenDictionary<char, Glyph> glyphs, int unitsPerEm, int ascent, int descent, int lineGap)
    {
        Glyphs = glyphs;
        UnitsPerEm = unitsPerEm;
        Ascent = ascent;
        Descent = descent;
        LineGap = lineGap;
    }
    
    /// <summary>
    /// Tries to get a glyph for a given character.
    /// </summary>
    public bool TryGetGlyph(char c, out Glyph glyph)
    {
        return Glyphs.TryGetValue(c, out glyph);
    }

    /// <summary>
    /// Returns the glyph for a character or null if not available.
    /// </summary>
    public Glyph? GetGlyphOrDefault(char c)
    {
        Glyphs.TryGetValue(c, out var glyph);
        return glyph;
    }

    /// <summary>
    /// Measures the width of a single-line string in pixels.
    /// </summary>
    public float MeasureTextWidth(string text, float scale = 1f)
    {
        if (string.IsNullOrEmpty(text))
            return 0;

        var width = 0f;
        foreach (var c in text)
        {
            if (Glyphs.TryGetValue(c, out var glyph))
                width += glyph.Advance * scale;
        }
        
        return width;
    }

    /// <summary>
    /// Measures the width and height of a multi-line string in pixels.
    /// </summary>
    public Vector2 MeasureText(string text, float scale = 1f)
    {
        if (string.IsNullOrEmpty(text))
            return Vector2.Zero;

        var width = 0f;
        var maxWidth = 0f;
        var height = LineHeight * scale;

        foreach (var c in text)
        {
            if (c == '\n')
            {
                maxWidth = MathF.Max(maxWidth, width);
                width = 0;
                height += LineHeight * scale;
                continue;
            }

            if (Glyphs.TryGetValue(c, out var glyph))
                width += glyph.Advance * scale;
        }

        maxWidth = MathF.Max(maxWidth, width);
        return new Vector2(maxWidth, height);
    }
}
