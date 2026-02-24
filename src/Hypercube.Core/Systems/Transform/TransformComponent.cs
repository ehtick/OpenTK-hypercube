using Hypercube.Core.Systems.Map;
using Hypercube.Ecs;
using Hypercube.Ecs.Components;
using Hypercube.Mathematics.Quaternions;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Core.Systems.Transform;

[UsedImplicitly]
public struct TransformComponent() : IComponent
{
    public Entity? Parent;

    public MapId Map;
    public Vector3 LocalPosition = Vector3.Zero;
    public Quaternion LocalRotation = Quaternion.Identity;
    public Vector3 LocalScale = Vector3.One;
}
