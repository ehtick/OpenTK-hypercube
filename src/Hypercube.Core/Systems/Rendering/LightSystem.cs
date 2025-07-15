using Hypercube.Core.Ecs.Attributes;
using Hypercube.Core.Ecs.Core.Query;
using Hypercube.Core.Graphics.Rendering.Context;
using Hypercube.Core.Systems.Transform;

namespace Hypercube.Core.Systems.Rendering;

[RegisterEntitySystem]
public sealed class LightSystem : PatchEntitySystem
{
    private EntityQuery _lightQuery = default!;

    public override void Startup()
    {
        _lightQuery = EntityQueryBuilder
            .With<TransformComponent>()
            .With<PointLightComponent>()
            .Build();
    }

    public override void Draw(IRenderContext renderer)
    {
        var query = _lightQuery.GetEnumerator;
        while (query.MoveNext(out var entity))
        {
            var transform = GetComponent<TransformComponent>(entity);
            var light = GetComponent<PointLightComponent>(entity);
            
            // renderer.DrawLight(transform.LocalPosition, light.Radius, light.Color, light.Intensity);
        }
    }
}
