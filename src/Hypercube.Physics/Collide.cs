using Hypercube.Physics.Manifolds;
using Hypercube.Physics.Shapes.Structs;

namespace Hypercube.Physics;

public static class Collide 
{
    public static float UnitsPerMeter = 1.0f;
    public static float LinearSlop => 0.005f * UnitsPerMeter;
    public static float SpeculativeDistance => 4.0f * LinearSlop;
    
    public static Manifold Circles(ShapeCircle circleA, Transform transformA, ShapeCircle circleB, Transform transformB)
    {
        var transform = transformA.ToLocalSpaceOf(transformB);

        var pointA = circleA.Center;
        var pointB = transform.TransformPoint(pointA);
        var pointDirection = pointB - pointA;

        // NOTE: Maybe LengthFast?
        var (distance, normal) = pointDirection.LengthNormalized;
        
        var radiusA = circleA.Radius;
        var radiusB = circleB.Radius;
        
        var separation = distance - radiusA - radiusB;
        if (separation > SpeculativeDistance)
            return Manifold.Empty;
        
        var centerA = pointA + normal * radiusA;
        var centerB = pointB - normal * radiusB;
        var contact = Vector2.Lerp(centerA, centerB, 0.5f);

        var manifoldAnchorA = contact.Rotate(transformA.Rotation);
        var manifoldAnchorB = manifoldAnchorA + (transformA.Position - transformB.Position);
        var manifoldPoint = manifoldAnchorA + transformA.Position;

        return new Manifold(
            normal.Rotate(transformA.Rotation),
            new ManifoldPoint(
                manifoldPoint,
                manifoldAnchorA,
                manifoldAnchorB,
                separation,
                0
            )
        );
    }
}