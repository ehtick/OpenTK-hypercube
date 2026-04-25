namespace Hypercube.Physics.Shapes.Structs;

public struct ShapeCircle
{
    public Vector2 Center;
    public float Radius;

    public ShapeCircle(Vector2 center, float radius)
    {
        Center = center;
        Radius = radius;
    }
}