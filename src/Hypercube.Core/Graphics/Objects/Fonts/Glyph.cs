using Hypercube.Mathematics.Shapes;

namespace Hypercube.Core.Graphics.Objects.Fonts;

/// <summary>
/// Represents a single glyph in a font, including its texture region and layout metrics.
/// </summary>
public readonly struct Glyph
{
    /// <summary>
    /// Gets the character represented by this glyph.
    /// </summary>
    public readonly char Character;

    /// <summary>
    /// Gets the source rectangle within the font texture atlas where the glyph is located.
    /// </summary>
    public readonly Rect2 SourceRect;

    /// <summary>
    /// Gets the offset applied when rendering the glyph relative to the baseline.
    /// </summary>
    public readonly Vector2 Offset;

    /// <summary>
    /// Gets the horizontal advance after rendering this glyph.
    /// </summary>
    public readonly float Advance;

    /// <summary>
    /// Initializes a new instance of the <see cref="Glyph"/> struct.
    /// </summary>
    /// <param name="character">The character represented by the glyph.</param>
    /// <param name="sourceRect">The rectangle within the texture atlas containing the glyph.</param>
    /// <param name="offset">The rendering offset relative to the baseline.</param>
    /// <param name="advance">The horizontal advance after rendering the glyph.</param>
    public Glyph(char character, Rect2 sourceRect, Vector2 offset, float advance)
    {
        Character = character;
        SourceRect = sourceRect;
        Offset = offset;
        Advance = advance;
    }
}
