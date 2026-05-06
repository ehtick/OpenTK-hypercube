using Hypercube.Physics.Manifolds;
using Hypercube.Physics.Shapes;
using JetBrains.Annotations;

namespace Hypercube.Physics;

public delegate Manifold ManifoldResolver(in ShapeUnion shapeA, in Transform transformA, in ShapeUnion shapeB, in Transform transformB);

[PublicAPI]
public static class Contacts
{
    private static readonly ResolveRegister[,] Resolvers = new ResolveRegister[(int) ShapeType.Segment, (int) ShapeType.Segment];

    public static void Initialize()
    {
        Add(CollideCircles, ShapeType.Circle, ShapeType.Circle);
        Add(CollidePolygons, ShapeType.Polygon, ShapeType.Polygon);
        Add(CollidePolygonCircle, ShapeType.Polygon, ShapeType.Circle);
    }
    
    public static Manifold Resolve(
        in ShapeUnion shapeA, ShapeType typeA, in Transform transformA,
        in ShapeUnion shapeB, ShapeType typeB, in Transform transformB)
    {
        var register = Resolvers[(int) typeA, (int) typeB];
        
        return register.Primary
            ? register.Function(shapeA, transformA, shapeB, transformB)
            : register.Function(shapeB, transformB, shapeA, transformB);
    }

    public static Manifold Resolve(
        in ShapeUnionTyped shapeA, in Transform transformA,
        in ShapeUnionTyped shapeB, in Transform transformB)
    {
        return Resolve(
            shapeA.Shape, shapeA.Type, transformA,
            shapeB.Shape, shapeB.Type, transformB
        );
    }
    
    public static void Add(ManifoldResolver function, ShapeType shapeA, ShapeType shapeB)
    {
        DebugPhysicsGuard.ValidateShapeType(shapeA);
        DebugPhysicsGuard.ValidateShapeType(shapeB);
        
        Resolvers[(int) shapeA, (int) shapeB].Function = function;
        Resolvers[(int) shapeA, (int) shapeB].Primary = true;
        
        if (shapeA == shapeB)
            return;
        
        Resolvers[(int) shapeB, (int) shapeA].Function = function;
        Resolvers[(int) shapeB, (int) shapeA].Primary = false;
    }
    
    private static Manifold CollideCircles(in ShapeUnion shapeA, in Transform transformA, in ShapeUnion shapeB, in Transform transformB)
    {
        var localA = shapeA.Circle;
        var localB = shapeB.Circle;
        return Collide.Circles(ref localA, transformA, ref localB, transformB);
    }

    private static Manifold CollidePolygons(in ShapeUnion shapeA, in Transform transformA, in ShapeUnion shapeB, in Transform transformB)
    {
        var localA = shapeA.Polygon;
        var localB = shapeB.Polygon;
        return Collide.Polygons(ref localA, transformA, ref localB, transformB);
    }

    private static Manifold CollidePolygonCircle(in ShapeUnion shapeA, in Transform transformA, in ShapeUnion shapeB, in Transform transformB)
    {
        var localA = shapeA.Polygon;
        var localB = shapeB.Circle;
        return Collide.PolygonCircle(ref localA, transformA, ref localB, transformB);  
    }

    private struct ResolveRegister(ManifoldResolver function, bool primary)
    {
        public ManifoldResolver Function = function;
        public bool Primary = primary;
    }
}
