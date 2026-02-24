using Hypercube.Core.Resources;
using Hypercube.Ecs.Components;
using Hypercube.Mathematics;
using Hypercube.Mathematics.Quaternions;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Core.Systems.Rendering.Model;

public struct ModelComponent() : IComponent
{
    public Graphics.Resources.Model? Model;
    
    public ResourcePath Path = ResourcePath.Empty;
    public Color Color = Color.White;

    public Vector3 Offset = Vector3.Zero;
    public Quaternion Rotation = Quaternion.FromEuler(Vector3.Zero);
    public Vector3 Scale = Vector3.One;
}