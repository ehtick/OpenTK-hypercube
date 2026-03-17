using Hypercube.Core.Graphics.Rendering;
using Hypercube.Core.Graphics.Rendering.Context;
using Hypercube.Core.Resources;
using Hypercube.Core.Systems.Transform;
using Hypercube.Ecs;
using Hypercube.Ecs.Lifetime;
using Hypercube.Ecs.Queries;
using Hypercube.Utilities.Dependencies;

namespace Hypercube.Core.Systems.Rendering.Model;

public sealed class ModelSystem : PatchEntitySystem
{
    [Dependency] private readonly IResourceManager _resource = null!;
    
    private Query _modelQuery = null!;
    
    public override void Initialize()
    {
        _modelQuery = CreateQuery(new QueryMeta()
            .WithAll<TransformComponent>()
            .WithAll<ModelComponent>()
        );
        
        Subscribe<ModelComponent, AddedEvent>(OnAdded);
    }

    private void OnAdded(Entity entity, ref ModelComponent component, ref AddedEvent args)
    {
        component.Model = _resource.Load<Graphics.Resources.Model>(component.Path);
    }
    
    public override void Draw(IRenderContext renderer, DrawPayload payload)
    {
        _modelQuery.With<TransformComponent, ModelComponent>((_, ref transform, ref model) =>
        {
            var position = transform.LocalPosition;
            if (model.Model is null)
                return;
            
            renderer.DrawModel(model.Model, position, model.Rotation, model.Scale, model.Color);
        });
    }
}