namespace Hypercube.Physics;

public readonly struct ManifoldPoint
{
    public readonly Vector2 Point;
    public readonly Vector2 AnchorA;
    public readonly Vector2 AnchorB;
    
    public readonly float Separation;
    public readonly float NormalImpulse;
    public readonly float TangentImpulse;
    public readonly float TotalNormalImpulse;
    public readonly float NormalVelocity;
    
    public readonly ushort Id;
    
    public readonly bool Persisted;

    public ManifoldPoint(Vector2 point, Vector2 anchorA, Vector2 anchorB, float separation, ushort id)
    {
        Point = point;
        AnchorA = anchorA;
        AnchorB = anchorB;
        
        Separation = separation;
        NormalImpulse = 0;
        TangentImpulse = 0;
        TotalNormalImpulse = 0;
        NormalVelocity = 0;
        
        Id = id;
        
        Persisted = false;
    }
    
    
    public ManifoldPoint(Vector2 point, Vector2 anchorA, Vector2 anchorB, float separation, float normalImpulse, float tangentImpulse, float totalNormalImpulse, float normalVelocity, ushort id, bool persisted)
    {
        Point = point;
        AnchorA = anchorA;
        AnchorB = anchorB;
        
        Separation = separation;
        NormalImpulse = normalImpulse;
        TangentImpulse = tangentImpulse;
        TotalNormalImpulse = totalNormalImpulse;
        NormalVelocity = normalVelocity;
        
        Id = id;
        
        Persisted = persisted;
    }
}