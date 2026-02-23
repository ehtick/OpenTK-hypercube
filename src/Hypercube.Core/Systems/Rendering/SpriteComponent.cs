using Hypercube.Core.Ecs;
using Hypercube.Core.Graphics.Resources;
using Hypercube.Core.Resources;
using Hypercube.Core.Serialization;
using Hypercube.Mathematics;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Core.Systems.Rendering;

public sealed class SpriteComponent : Component
{
    public Texture? Texture;
    
    public ResourcePath Path = ResourcePath.Empty;
    public Vector2 Scale = Vector2.One;
    public Angle Rotation = Angle.Zero;
    public Vector2 Offset = Vector2.Zero;
    public Color Color = Color.White;
}
