using Hypercube.Core.Ecs;
using Hypercube.Mathematics.Vectors;
using Hypercube.Mathematics.Quaternions;

namespace Hypercube.Core.Systems.Transform;

[UsedImplicitly]
public sealed class TransformComponent : Component
{
    public Entity? Parent;
    
    public Vector3 LocalPosition = Vector3.Zero;
    
    public Quaternion LocalRotation = Quaternion.Identity;
    
    public Vector3 LocalScale = Vector3.One;
}
