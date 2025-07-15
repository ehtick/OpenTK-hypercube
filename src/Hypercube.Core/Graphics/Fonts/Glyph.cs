using Hypercube.Mathematics.Shapes;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Core.Graphics.Fonts;

public struct Glyph
{
    public char Character;
    public Rect2 SourceRect;
    public Vector2 Offset;
    public float Advance;
}