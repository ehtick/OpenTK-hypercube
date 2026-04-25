using Hypercube.Ecs;

namespace Hypercube.Core.Systems.Map;

[UsedImplicitly]
public sealed class MapSystem : EntitySystem
{
    [PublicAPI]
    public Entity CreateMap(MapId mapId)
    {
        var entity = EntityCreate();
        ref var component = ref AddComponent<MapComponent>(entity);
        
        component.Id = mapId;
        
        return entity;
    }
}
