using Hypercube.Core.Graphics.Rendering;
using Hypercube.Core.Graphics.Rendering.Context;
using Hypercube.Core.Resources;
using Hypercube.Core.Systems.Transform;
using Hypercube.Ecs;
using Hypercube.Utilities.Dependencies;

namespace Hypercube.Core.Systems.Rendering.Model;

// [RegisterEntitySystem]
public sealed class ModelSystem : PatchEntitySystem
{
    [Dependency] private readonly IResourceManager _resource = null!;
    
    private EntityQuery _query = null!;
    
    public override void Startup()
    {
        base.Startup();

        _query = EntityQueryBuilder
            .With<TransformComponent>()
            .With<ModelComponent>()
            .Build();
        
        Subscribe<ModelComponent, AddedEvent>(OnAdded);
    }

    private void OnAdded(ref Entity entity, ref ModelComponent component, ref AddedEvent args)
    {
        component.Model = _resource.Load<Graphics.Resources.Model>(component.Path);
    }
    
    public override void Draw(IRenderContext renderer, DrawPayload payload)
    {
        var enumerator = _query.GetEnumerator;
        while (enumerator.MoveNext(out var entity))
        {
            var transformComponent = GetComponent<TransformComponent>(entity);
            var modelComponent = GetComponent<ModelComponent>(entity);

            var position = transformComponent.LocalPosition;
  
            if (modelComponent.Model is null)
                continue;
            
            renderer.DrawModel(modelComponent.Model, position, modelComponent.Rotation, modelComponent.Scale, modelComponent.Color);
        }
    }
}