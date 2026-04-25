using System.Runtime.CompilerServices;

namespace Hypercube.Physics;

public readonly struct Transform
{
    public readonly Vector2 Position;
    public readonly Vector2Angle Rotation;

    public Transform(Vector2 position)
    {
        Position = position;
        Rotation = Vector2Angle.Zero;
    }
    
    public Transform(Vector2 position, Vector2Angle rotation)
    {
        Position = position;
        Rotation = rotation;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Transform ToLocalSpaceOf(Transform transformB) => GetRelativeTransform(this, transformB);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Vector2 TransformPoint(Vector2 point) => TransformPoint(this, point);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Transform GetRelativeTransform(Transform transformA, Transform transformB)
    {
        return new Transform(
            (transformB.Position - transformA.Position).InvRotate(transformB.Rotation),
            transformA.Rotation.SubtractAngle(transformA.Rotation)
        );
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 TransformPoint(Transform transform, Vector2 point)
    {
        return new Vector2(
            transform.Rotation.Cos * point.X - transform.Rotation.Sin * point.Y + transform.Position.X,
            transform.Rotation.Sin * point.X + transform.Rotation.Cos * point.Y + transform.Position.Y
        );
    }
}
