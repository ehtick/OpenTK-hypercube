using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Hypercube.Core.Execution.LifeCycle;
using Hypercube.Core.Systems.Transform;
using Hypercube.Core.Viewports;
using Hypercube.Ecs;
using Hypercube.Ecs.Queries;

namespace Hypercube.Core.Systems.Camera;

[UsedImplicitly]
public sealed class CameraSystem : EntitySystem
{
    private Query _query = null!;

    public override void Initialize()
    {
        _query = CreateQuery(new QueryMeta()
            .WithAll<CameraComponent>()
            .WithAll<TransformComponent>()
        );
    }

    public override void AfterUpdate(FrameEventArgs args)
    {
        _query.With<CameraComponent, TransformComponent>((entity, ref camera, ref transform) =>
        {
            Sync(entity, ref camera, ref transform);
        });
    }

    [PublicAPI]
    public void Link(Entity entity, ref CameraComponent camera, ICamera instance)
    {
        camera.LinkedCamera = instance;
    }
    
    [PublicAPI]
    public void Sync(Entity entity, ref CameraComponent camera)
    {
        if (!InternalTryGetLinked(ref camera, out var instance))
            return;
        
        InternalSyncProperties(ref camera, instance);
        
        if (!TryGetComponent<TransformComponent>(entity, out var transform))
            InternalSyncTransform(ref transform, instance);
    }

    [PublicAPI]
    public void Sync(Entity entity, ref CameraComponent camera, ref TransformComponent transform)
    {
        if (!InternalTryGetLinked(ref camera, out var instance))
            return;

        InternalSyncProperties(ref camera, instance);
        InternalSyncTransform(ref transform, instance);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private bool InternalTryGetLinked(ref CameraComponent camera, [NotNullWhen(true)] out ICamera? instance)
    {
        instance = camera.LinkedCamera;
        
        if (instance is not null)
            return true;
        
        Logger.Trace("{entity} sync canceled, linked camera is null");
        return false;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void InternalSyncProperties(ref CameraComponent camera, ICamera instance)
    {
        instance.Size = camera.Size;
        instance.ZNear = camera.ZNear;
        instance.ZFar = camera.ZFar;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void InternalSyncTransform(ref TransformComponent transform, ICamera instance)
    {
        instance.Position = transform.LocalPosition;
        instance.Rotation = transform.LocalRotation;
        instance.Scale = transform.LocalScale;
    }
}
