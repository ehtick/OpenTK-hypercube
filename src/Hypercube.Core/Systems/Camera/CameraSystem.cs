using Hypercube.Core.Systems.Transform;
using Hypercube.Ecs;
using Hypercube.Ecs.Queries;
using Hypercube.Ecs.System;

namespace Hypercube.Core.Systems.Camera;

public sealed class CameraSystem : EntitySystem
{
    private Query _query = null!;

    public override void Initialize()
    {
        _query = CreateQuery(new QueryMeta().WithAll<CameraComponent>().WithAll<TransformComponent>());
    }

    public override void AfterUpdate(float deltaTime)
    {
        _query.With<CameraComponent, TransformComponent>((entity, ref camera, ref transform) =>
        {
            Sync(entity, ref camera, ref transform);
        });
    }

    public void Sync(Entity entity, ref CameraComponent camera, ref TransformComponent transform)
    {
        var instance = camera.LinkedCamera;
        if (instance is null)
            return;

        instance.Position = transform.LocalPosition;
        instance.Rotation = transform.LocalRotation;
        instance.Scale    = transform.LocalScale;
        
        instance.Size     = camera.Size;
        instance.ZNear    = camera.ZNear;
        instance.ZFar     = camera.ZFar;
    }
}
