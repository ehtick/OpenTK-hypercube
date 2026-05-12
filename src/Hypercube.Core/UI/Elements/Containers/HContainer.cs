using Hypercube.Core.UI.Elements.Containers.Abstract;

namespace Hypercube.Core.UI.Elements.Containers;

[PublicAPI]
public sealed class HContainer : ContainerLinear
{
    protected override float GetPrimarySize(Vector2 size) => size.X;
    
    protected override float GetSecondarySize(Vector2 size) => size.Y;

    protected override Vector2 SetPrimary(Vector2 pos, float value) => new(value, pos.Y);

    protected override Vector2 SetSecondary(Vector2 pos, float value) => new(pos.X, value);

    protected override float GetContentPrimarySize(Vector2 contentSize) => contentSize.X;
}
