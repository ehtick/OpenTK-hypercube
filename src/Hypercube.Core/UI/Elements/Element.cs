using Hypercube.Core.Graphics.Rendering.Context;
using Hypercube.Core.UI.Alignment;
using Hypercube.Mathematics.Shapes;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Core.UI.Elements;

[PublicAPI]
public class Element
{
    private const HorizontalAlignment DefaultHorizontalAlignment = HorizontalAlignment.Stretch;
    private const VerticalAlignment DefaultVerticalAlignment = VerticalAlignment.Stretch;
    
    public event Action<Element>? OnChildAdded; 
    public event Action<Element>? OnChildRemoved; 
    
    public string? Name;
    public Element? Parent { get; private set; }
    
    private readonly List<Element> _children = [];
    
    public IReadOnlyList<Element> Children => _children;
    public int Count => _children.Count;

    public HorizontalAlignment HorizontalAlignment = DefaultHorizontalAlignment;
    public VerticalAlignment VerticalAlignment = DefaultVerticalAlignment;
    public Vector2 Position;
    public bool Visible = true;

    public Vector2 Size;
    public Vector2 MinSize = Vector2.Zero;
    public Vector2 MaxSize = Vector2.PositiveInfinity;

    public Rect2 Margin;

    public virtual void Render(IRenderContext context)
    {
    }

    public void Arrange(in Rect2 parentRect)
    {
        if (!Visible)
            return;

        var baseRect = parentRect;
        var baseSize = baseRect.Size;
        
        var origin = parentRect.TopLeft;
        var size = parentRect.Size;

        // Constraints
        size = size.Clamp(MinSize, MaxSize);
        
        switch (HorizontalAlignment)
        {
            case HorizontalAlignment.Left:
                // Skip because origin by default left
                break;
            
            case HorizontalAlignment.Right:
                origin = origin.WithX(baseSize.X - size.X);
                break;

            case HorizontalAlignment.Stretch:
            case HorizontalAlignment.Center:
                origin = origin.WithX((baseSize.X - size.X) / 2);
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }

        switch (VerticalAlignment)
        {
            case VerticalAlignment.Top:
                // Skip because origin by default top
                break;

            case VerticalAlignment.Bottom:
                origin = origin.WithY(baseSize.Y - size.Y);
                break;
            
            case VerticalAlignment.Stretch:
            case VerticalAlignment.Center:
                origin = origin.WithY((baseSize.Y - size.Y) / 2);
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }
       Position = origin;
        Size = size;
    }
    
    public Element Find(string name)
    {
        var queue = new Queue<Element>();
        queue.Enqueue(this);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            if (current.Name == name)
                return current;

            foreach (var child in current._children)
            {
                queue.Enqueue(child);
            }
        }

        throw new IndexOutOfRangeException($"Element with name '{name}' not found.");
    }
    
    public void AddChild(Element element)
    {
        if (element == this)
            throw new InvalidOperationException();
        
        if (element.Parent is not null)
            throw new InvalidOperationException();

        var parent = element.Parent;
        while (parent is not null)
        {
            if (element == parent)
                throw new InvalidOperationException();

            parent = parent.Parent;
        }
        
        _children.Add(element);
        element.Parent = this;
        
        OnChildAdded?.Invoke(element);
    }

    public void RemoveChild(Element element)
    {
        if (element == this)
            throw new InvalidOperationException();

        if (element.Parent != this)
            throw new InvalidOperationException();
        
        _children.Remove(element);
        element.Parent = null;
        
        OnChildRemoved?.Invoke(element);
    }
    
    public override string ToString()
    {
        var type = GetType();
        return Name is null ? type.Name : $"{type.Name} ({Name})";
    }
}
