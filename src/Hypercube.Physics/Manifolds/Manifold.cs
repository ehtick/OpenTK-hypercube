using Hypercube.Utilities.Collections;

namespace Hypercube.Physics.Manifolds;

public readonly struct Manifold
{
    public static readonly Manifold Empty = new(Vector2.Zero, 0f, FixedArray2<ManifoldPoint>.Empty, 0);
    
    public readonly Vector2 Normal;
    public readonly float RollingImpulse;
    public readonly FixedArray2<ManifoldPoint> Points;
    public readonly int PointCount;

    public bool IsEmpty => PointCount == 0;
    
    public Manifold(Vector2 normal, ManifoldPoint point)
    {
        Normal = normal;
        RollingImpulse = 0f;
        Points = new FixedArray2<ManifoldPoint>(point);
        PointCount = 1;
    }
    
    public Manifold(Vector2 normal, float rollingImpulse, FixedArray2<ManifoldPoint> points, int pointCount)
    {
        Normal = normal;
        RollingImpulse = rollingImpulse;
        Points = points;
        PointCount = pointCount;
    }
}