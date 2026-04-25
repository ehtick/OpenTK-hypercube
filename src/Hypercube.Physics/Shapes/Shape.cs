namespace Hypercube.Physics.Shapes;

public class Shape
{
    public ShapeId Id;
    public ShapeId PrevShapeId;
    public ShapeId NextShapeId;

    public ShapeUnion Value;
    public ShapeType Type;
    
    public Material Material;

    public Aabb Aabb;
    public Aabb FatAabb;

    public Vector2 LocalCentroid;

    public int bodyId;
    
}