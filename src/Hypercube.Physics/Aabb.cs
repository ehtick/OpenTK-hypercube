namespace Hypercube.Physics;

public struct Aabb
{
    public Vector2 Point1;
    public Vector2 Point2;

    public Aabb(Vector2 point1, Vector2 point2)
    {
        Point1 = point1;
        Point2 = point2;
    }
}