using Hypercube.Core.Execution.LifeCycle;
using Hypercube.Core.Graphics.Rendering.Context;
using Hypercube.Mathematics;
using Hypercube.Mathematics.Dimensions;
using Hypercube.Utilities.Helpers;

namespace Hypercube.Core.UI.Elements;

[PublicAPI]
public class Element : IDisposable
{
    public IUIManager UI
    {
        get;
        set
        {
            if (UI is not null)
                throw new InvalidOperationException();

            field = value;
        }
    } = null!;

    public Element? Parent;
    
    public bool Started;

    public HDim2 Position = HDim2.Zero;
    public HDim2 Size = HDim2.Zero;
    public HDim Rotation = HDim.Zero;

    public HDimRect Padding;

    public Vector2 AnchorPoint;

    public int ZIndex;

    public int LayoutOrder;

    public bool Visible = true;

    private readonly List<Element> _children = [];

    private bool _disposed;

    public IReadOnlyList<Element> Children => _children;
    
    public Vector2 RelativePosition { get; private set; }
    public Angle RelativeRotation { get; private set; }
    
    public Vector2 AbsolutePosition { get; private set; }
    public Vector2 AbsoluteSize { get; private set; }
    public Angle AbsoluteRotation { get; private set; }
    
    public Vector2 ContentPosition { get; private set; }
    public Vector2 ContentSize { get; private set; }
    
    ~Element()
    {
        Dispose(false);
    }
    
    public void Render(IRenderContext renderer, UIDrawPayload payload)
    {
        OnRender(renderer, payload);

        foreach (var element in _children)
            element.Render(renderer, payload);
    }

    public void Update(FrameEventArgs args)
    {
        OnUpdate(args);
        
        foreach (var element in _children)
            element.Update(args);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    public void Dispose(bool disposing)
    {
        if (_disposed)
            return;
        
        if (disposing)
            OnDisposeManaged();
        
        OnDisposeUnmanaged();
        _disposed = true;
    }

    public void AddChild(Element element)
    {
        element.UI = UI;
        element.Parent = this;
        
        _children.Add(element);
        
        element.OnStartup();
        element.Started = true;
        
        UpdateLayout();
    }

    public void RemoveChild(Element element)
    {
        ReflectionHelper.SetField(element, nameof(Parent), null!);
        
        _children.Remove(element);
        
        UpdateLayout();
    }

    public void RemoveChildAtIndex(int index)
    {
        if (_children.Count <= index)
            return;
            
        RemoveChild(_children[index]);
    }
    
    public void UpdateLayout()
    {
        if (!Started)
            return;
        
        RelativePosition = Vector2.Zero;
        
        AbsoluteSize = Size.Resolve(UI.ViewportSize);
        AbsolutePosition = Position.Resolve(UI.ViewportSize) -
                           AbsoluteSize * AnchorPoint;

        if (Parent is not null)
        {
            RelativePosition = Position.Resolve(Parent.ContentSize);
            
            AbsoluteSize = Size.Resolve(Parent.ContentSize);
            AbsolutePosition = Parent.ContentPosition +
                               RelativePosition -
                               AbsoluteSize * AnchorPoint;
        }

        var left = Padding.Left.Resolve(AbsoluteSize.X);
        var right = Padding.Right.Resolve(AbsoluteSize.X);
        var top = Padding.Top.Resolve(AbsoluteSize.Y);
        var bottom = Padding.Bottom.Resolve(AbsoluteSize.Y);

        ContentPosition = AbsolutePosition + new Vector2(left, top);

        ContentSize = new Vector2(
            AbsoluteSize.X - left - right,
            AbsoluteSize.Y - top - bottom
        );

        foreach (var child in _children)
            child.UpdateLayout();
    }

    protected virtual void OnRender(IRenderContext renderer, UIDrawPayload payload)
    {
    }

    protected virtual void OnUpdate(FrameEventArgs args)
    {
    }

    protected virtual void OnStartup()
    {
    }

    protected virtual void OnMeasure()
    {
    }

    protected virtual void OnDisposeManaged()
    {
    }
    
    protected virtual void OnDisposeUnmanaged()
    {
    }
}
