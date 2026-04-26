using System.Diagnostics.CodeAnalysis;
using Hypercube.Core.Execution.LifeCycle;
using Hypercube.Core.Graphics.Rendering;
using Hypercube.Core.Graphics.Rendering.Context;
using Hypercube.Core.UI.Alignment;
using Hypercube.Mathematics.Shapes;
using Hypercube.Utilities.Dependencies;

namespace Hypercube.Core.UI.Elements;

[PublicAPI]
public class Element
{
    private const HorizontalAlignment DefaultHorizontalAlignment = HorizontalAlignment.Stretch;
    private const VerticalAlignment DefaultVerticalAlignment = VerticalAlignment.Stretch;

    private readonly List<Element> _children = [];

    public event Action<Element>? OnChildAdded;
    public event Action<Element>? OnChildRemoved;

    public string? Name { get; set; }

    public Element? Parent { get; private set; }

    public IDependenciesContainer? Dependencies { get; private set; }

    public IReadOnlyList<Element> Children => _children;

    public int Count => _children.Count;

    public HorizontalAlignment HorizontalAlignment { get; set; } = DefaultHorizontalAlignment;

    public VerticalAlignment VerticalAlignment { get; set; } = DefaultVerticalAlignment;

    public Vector2 Position { get; protected set; }

    public Vector2 Size { get; protected set; }

    public bool Visible { get; set; } = true;

    public Vector2 MinSize { get; set; } = Vector2.Zero;

    public Vector2 MaxSize { get; set; } = Vector2.PositiveInfinity;

    public Rect2 Margin { get; set; }

    public void Render(IRenderContext context, DrawPayload payload)
    {
        if (!Visible)
            return;

        OnRender(context, payload);

        foreach (var child in _children)
            child.Render(context, payload);
    }

    public void Update(FrameEventArgs args)
    {
        OnUpdate(args);

        foreach (var child in _children)
            child.Update(args);
    }

    public void Arrange(in Rect2 availableRect)
    {
        if (!Visible)
            return;

        var size = CalculateSize(availableRect.Size);
        var position = CalculatePosition(availableRect, size);

        Position = position;
        Size = size;
    }

    public Element Find(string name)
    {
        return TryFind(name, out var element)
            ? element
            : throw new InvalidOperationException($"Element with name '{name}' was not found.");
    }

    public bool TryFind(string name, [NotNullWhen(true)] out Element? result)
    {
        var queue = new Queue<Element>();
        queue.Enqueue(this);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            if (current.Name == name)
            {
                result = current;
                return true;
            }

            foreach (var child in current._children)
                queue.Enqueue(child);
        }

        result = null;
        return false;
    }

    public void AddChild(Element child)
    {
        ValidateChild(child);

        _children.Add(child);
        child.Parent = this;

        if (Dependencies is not null)
            child.SetDependencies(Dependencies);

        OnChildAdded?.Invoke(child);
    }

    public void RemoveChild(Element child)
    {
        if (child.Parent != this)
            throw new InvalidOperationException(
                "Element is not a child of this parent.");

        _children.Remove(child);
        child.Parent = null;

        OnChildRemoved?.Invoke(child);
    }

    public override string ToString()
    {
        return Name is null
            ? GetType().Name
            : $"{GetType().Name} ({Name})";
    }

    protected virtual void OnRender(
        IRenderContext context,
        DrawPayload payload)
    {
    }

    protected virtual void OnUpdate(FrameEventArgs args)
    {
    }

    internal virtual void SetDependencies(IDependenciesContainer dependencies)
    {
        if (Dependencies is not null)
            return;

        Dependencies = dependencies;
        dependencies.Inject(this);
        
        foreach (var child in _children)
        {
            child.SetDependencies(dependencies);
        }
    }

    private Vector2 CalculateSize(Vector2 availableSize)
    {
        return availableSize.Clamp(MinSize, MaxSize);
    }

    private Vector2 CalculatePosition(Rect2 rect, Vector2 size)
    {
        var x = CalculateHorizontalPosition(rect, size.X);
        var y = CalculateVerticalPosition(rect, size.Y);

        return new Vector2(x, y);
    }

    private float CalculateHorizontalPosition(Rect2 rect, float width)
    {
        return HorizontalAlignment switch
        {
            HorizontalAlignment.Left => rect.TopLeft.X,
            HorizontalAlignment.Center => rect.TopLeft.X + (rect.Size.X - width) / 2,
            HorizontalAlignment.Right => rect.TopLeft.X + rect.Size.X - width,
            HorizontalAlignment.Stretch => rect.TopLeft.X,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private float CalculateVerticalPosition(Rect2 rect, float height)
    {
        return VerticalAlignment switch
        {
            VerticalAlignment.Top => rect.TopLeft.Y,
            VerticalAlignment.Center => rect.TopLeft.Y + (rect.Size.Y - height) / 2,
            VerticalAlignment.Bottom => rect.TopLeft.Y + rect.Size.Y - height,
            VerticalAlignment.Stretch => rect.TopLeft.Y,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private void ValidateChild(Element child)
    {
        if (child == this)
            throw new InvalidOperationException("Element cannot be its own child.");

        if (child.Parent is not null)
            throw new InvalidOperationException("Element already has a parent.");

        var parent = Parent;

        while (parent is not null)
        {
            if (parent == child)
                throw new InvalidOperationException("Circular hierarchy detected.");

            parent = parent.Parent;
        }
    }
}
