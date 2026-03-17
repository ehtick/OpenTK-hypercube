using Hypercube.Ecs;
using Hypercube.Ecs.Components;
using Hypercube.Ecs.Events;
using Hypercube.Ecs.Queries;

namespace Hypercube.Core.Ecs;

public partial class EntitySystemManager
{
    public readonly IWorld GlobalWorld = new World();
    
    public IEventBus Events => GlobalWorld.Events;
    
    public Entity Create() => GlobalWorld.Create();

    public void Delete(Entity entity) => GlobalWorld.Delete(entity);

    public bool Validate(Entity entity) => GlobalWorld.Validate(entity);

    public ref T Add<T>(Entity entity) where T : struct, IComponent
        => ref GlobalWorld.Add<T>(entity);

    public ref T Add<T>(Entity entity, in T component) where T : struct, IComponent
        => ref GlobalWorld.Add(entity, in component);

    public ref T Get<T>(Entity entity) where T : struct, IComponent
        => ref GlobalWorld.Get<T>(entity) ;

    public bool Has<T>(Entity entity) where T : struct, IComponent
        => GlobalWorld.Has<T>(entity);

    public void Remove<T>(Entity entity) where T : struct, IComponent
        => GlobalWorld.Remove<T>(entity);

    public Query CreateQuery(in QueryMeta meta)
        => GlobalWorld.CreateQuery(meta);
}