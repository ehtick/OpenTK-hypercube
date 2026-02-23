using Hypercube.Mathematics.Shapes;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Core.Graphics.Fonts;

public readonly struct Glyph
{
    public readonly char Character;
    public readonly Rect2 SourceRect;
    public readonly Vector2 Offset;
    public readonly float Advance;

    public Glyph(char character, Rect2 sourceRect, Vector2 offset, float advance)
    {
        Character = character;
        SourceRect = sourceRect;
        Offset = offset;
        Advance = advance;
    }
}