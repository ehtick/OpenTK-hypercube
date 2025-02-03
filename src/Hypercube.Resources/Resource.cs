using Hypercube.Utilities.Dependencies;
using JetBrains.Annotations;

namespace Hypercube.Resources;

[PublicAPI]
public abstract class Resource
{
    public bool Loaded { get; private set; }
    
    public bool HasFallback => FallbackPath is not null;
    public virtual ResourcePath? FallbackPath => null;

    public abstract void Init(DependenciesContainer container);
    
    public void Load(ResourcePath path)
    {
        if (Loaded)
            return;
        
        OnLoad(path);
        Loaded = true;
    }

    public void Reload(ResourcePath path)
    {
        OnReload(path);
    }

    protected virtual void OnLoad(ResourcePath path)
    {
        // Do nothing...
    }

    public virtual void OnReload(ResourcePath path)
    {
        // Do nothing...
    }
}