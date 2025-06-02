using Hypercube.Core.Ecs;
using Hypercube.Core.Ecs.Attributes;
using Hypercube.Core.Serialization;
using Hypercube.Graphics.Resources;
using Hypercube.Mathematics;
using Hypercube.Mathematics.Vectors;
using Hypercube.Resources;

namespace Hypercube.Core.Systems.Rendering;

[RegisterComponent]
public sealed class SpriteComponent : Component
{
    public Texture? Texture;

    [DataField("texture")]
    public ResourcePath Path = ResourcePath.Empty;

    [DataField]
    public Vector2 Scale = Vector2.One;

    [DataField]
    public Angle Rotation = Angle.Zero;

    [DataField]
    public Vector2 Offset = Vector2.Zero;

    [DataField]
    public Color Color = Color.White;
}