using Hypercube.Mathematics.Shapes;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Graphics.Fonts;

public struct Glyph
{
    public char Character;
    public Box2 SourceRect;
    public Vector2 Offset;
    public float Advance;
}