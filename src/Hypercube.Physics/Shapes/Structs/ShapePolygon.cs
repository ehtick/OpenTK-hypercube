namespace Hypercube.Physics.Shapes.Structs;

public struct ShapePolygon
{
    public Vector2[] Vertices;
    public Vector2[] Normals;
    public Vector2 Centroid;
    public float Radius;
    public int Count;

    public ShapePolygon(Vector2[] vertices, Vector2[] normals, Vector2 centroid, float radius, int count)
    {
        Vertices = vertices;
        Normals = normals;
        Centroid = centroid;
        Radius = radius;
        Count = count;
    }
}