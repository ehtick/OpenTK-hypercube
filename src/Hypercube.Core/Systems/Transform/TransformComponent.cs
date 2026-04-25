using Hypercube.Core.Systems.Map;
using Hypercube.Core.Transform;
using Hypercube.Ecs;
using Hypercube.Ecs.Components;
using Hypercube.Mathematics.Quaternions;

namespace Hypercube.Core.Systems.Transform;

[PublicAPI]
public struct TransformComponent() : IComponent
{
    public Entity Parent = Entity.Invalid;

    public MapId Map
    {
        get => Local.Map;
        set => Local.Map = value;
    }
    
    public Vector3 LocalPosition
    {
        get => Local.Position;
        set => Local.Position = value;
    }
    
    public Quaternion LocalRotation
    {
        get => Local.Rotation;
        set => Local.Rotation = value;
    }
    
    public Vector3 LocalScale
    {
        get => Local.Scale;
        set => Local.Scale = value;
    }
    
    public MapTransformation Local = new();
}
