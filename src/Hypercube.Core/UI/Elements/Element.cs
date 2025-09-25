using Hypercube.Core.Graphics.Rendering.Context;

namespace Hypercube.Core.UI.Elements;

[PublicAPI]
public class Element
{
    public event Action<Element>? OnChildAdded; 
    public event Action<Element>? OnChildRemoved; 
    
    public string? Name;
    public Element? Parent { get; private set; }
    
    private readonly List<Element> _children = [];
    
    public IReadOnlyList<Element> Children => _children;
    public int Count => _children.Count;

    public virtual void Render(IRenderContext context)
    {
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
