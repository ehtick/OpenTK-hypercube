using Hypercube.Utilities.Dependencies;
using JetBrains.Annotations;

namespace Hypercube.Core.Resources;

[PublicAPI]
public abstract class Resource
{
    public bool Loaded { get; private set; }
    
    public bool HasFallback => FallbackPath is not null;
    public virtual ResourcePath? FallbackPath => null;

    public void Load(ResourcePath path, DependenciesContainer container)
    {
        if (Loaded)
            return;
        
        OnLoad(path, container);
        Loaded = true;
    }

    public void Reload(ResourcePath path, DependenciesContainer container)
    {
        OnReload(path, container);
    }

    protected virtual void OnLoad(ResourcePath path, DependenciesContainer container)
    {
        // Do nothing...
    }

    public virtual void OnReload(ResourcePath path, DependenciesContainer container)
    {
        // Do nothing...
    }
}