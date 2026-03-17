using Hypercube.Ecs;
using Hypercube.Ecs.System;

namespace Hypercube.Core.Systems.Map;

public sealed class MapSystem : EntitySystem
{
    /*
    public Entity<MapComponent> CreateMap(MapId mapId)
    {
        var entity = EntityCreate();
        ref var component = ref AddComponent<MapComponent>(entity);
        
        component.Id =  mapId;
        
        return new Entity<MapComponent>(entity, component);
    }
    */
}