using Hypercube.Mathematics.Dimensions;

namespace Hypercube.Core.UI.Elements.Containers.Abstract;

[PublicAPI]
public abstract class ContainerLinear : Container
{
    public Alignment AlignmentOpposite = Alignment.Start;
    
    public Alignment Alignment = Alignment.Start;
    
    public Direction Direction = Direction.Forward;
    
    public HDim Spacing = HDim.Zero;

    protected abstract float GetPrimarySize(Vector2 size);
    protected abstract float GetSecondarySize(Vector2 size);

    protected abstract Vector2 SetPrimary(Vector2 pos, float value);
    protected abstract Vector2 SetSecondary(Vector2 pos, float value);

    protected abstract float GetContentPrimarySize(Vector2 contentSize);

    protected float ResolveSpacing() => Spacing.Resolve(GetContentPrimarySize(ContentSize));

    protected override void OnUpdateLayout()
    {
        var children = Children.OrderBy(x => x.LayoutOrder).ToArray();
        if (children.Length == 0)
            return;

        var spacing = Spacing.Resolve(GetContentPrimarySize(ContentSize));
        var totalPrimary = children.Sum(c => GetPrimarySize(c.Size.Resolve(ContentSize)));

        totalPrimary += spacing * (children.Length - 1);
        
        var start = CalculateStartOffset(totalPrimary, spacing, children.Length);

        Layout(children, start, spacing);
    }

    private float CalculateStartOffset(float total, float spacing, int count)
    {
        var content = GetContentPrimarySize(ContentSize);

        return Alignment switch
        {
            Alignment.Start => 0f,
            Alignment.Center => (content - total) / 2f,
            Alignment.End => content - total,
            _ => 0f
        };
    }

    private void Layout(Element[] children, float start, float spacing)
    {
        var ordered = Direction == Direction.Forward
            ? children
            : children.Reverse().ToArray();

        var dynamicSpacing = spacing;
        var totalPrimary = ordered.Sum(c =>
            GetPrimarySize(c.Size.Resolve(ContentSize)));

        switch (Alignment)
        {
            case Alignment.SpaceBetween when ordered.Length > 1:
                dynamicSpacing = (GetContentPrimarySize(ContentSize) - totalPrimary)
                                 / (ordered.Length - 1);
                break;

            case Alignment.SpaceEvenly:
                dynamicSpacing = (GetContentPrimarySize(ContentSize) - totalPrimary)
                                 / (ordered.Length + 1);
                start = dynamicSpacing;
                break;

            case Alignment.SpaceAround:
                dynamicSpacing = (GetContentPrimarySize(ContentSize) - totalPrimary)
                                 / ordered.Length;
                start = dynamicSpacing / 2f;
                break;
        }

        var offset = start;

        foreach (var child in ordered)
        {
            var size = child.Size.Resolve(ContentSize);
            var secondary = AlignmentOpposite switch
            {
                Alignment.Start => 0f,
                Alignment.Center => (GetSecondarySize(ContentSize) - GetSecondarySize(size)) / 2f,
                Alignment.End => GetSecondarySize(ContentSize) - GetSecondarySize(size),
                _ => 0f
            };

            var pos = Vector2.Zero;
            pos = SetPrimary(pos, offset);
            pos = SetSecondary(pos, secondary);

            child.LayoutPosition = new HDim2(
                new HDim(0f, pos.X),
                new HDim(0f, pos.Y)
            );

            offset += GetPrimarySize(size) + dynamicSpacing;
        }
    }
}
