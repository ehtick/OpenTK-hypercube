namespace Hypercube.Physics.Shapes.Structs;

public struct ShapeCapsule
{
    public Vector2 Center1;
    public Vector2 Center2;
    public float Radius;

    public ShapeCapsule(Vector2 center1, Vector2 center2, float radius)
    {
        Center1 = center1;
        Center2 = center2;
        Radius = radius;
    }
}