using System.Collections.Frozen;
using System.Diagnostics.CodeAnalysis;
using Hypercube.Utilities.Debugging.Logger;
using Hypercube.Utilities.Dependencies;
using Hypercube.Utilities.Helpers;

namespace Hypercube.Resources.Storage;

public class ResourceStorage : IResourceStorage
{
    [Dependency] private readonly ILogger _logger = default!;
    
    private readonly FrozenDictionary<Type, Dictionary<ResourcePath, Resource>> _cachedResources;
    
    public ResourceStorage()
    {
        var cachedResources = new Dictionary<Type, Dictionary<ResourcePath, Resource>>();
        
        foreach (var type in ReflectionHelper.GetAllInstantiableSubclassOf(typeof(Resource)))
        {
            cachedResources[type] = new Dictionary<ResourcePath, Resource>();
        }
           
        _cachedResources = cachedResources.ToFrozenDictionary();
    }
    
    public T GetResource<T>(ResourcePath path, bool useFallback = true)
        where T : Resource, new()
    {
        var cache = _cachedResources[typeof(T)];
        if (!cache.TryGetValue(path, out var resource))
            resource = new T();
        
        try
        {
            resource.Load(path);
        }
        catch (Exception exception)
        {
            // A mechanism to protect against crooked development,
            // akin to default textures or ERROR from source
            if (useFallback && resource.HasFallback)
                return GetResource<T>(resource.FallbackPath!.Value, false);
            
            _logger.Critical($"Exception while loading resource {exception}");
            throw;
        }
        
        cache[path] = resource;
        return (T)resource;
    }

    public bool TryGetResource<T>(ResourcePath path, [NotNullWhen(true)] out T? resource)
        where T : Resource, new()
    {
        var cache = _cachedResources[typeof(T)];
        resource = cache.TryGetValue(path, out var cachedResource) ? (T)cachedResource : new T();
   
        try
        {
            resource.Load(path);
        }
        catch (Exception exception)
        {
            if (exception is FileNotFoundException)
            {
                resource = null;
                return false;
            }
            
            _logger.Critical($"Exception while loading resource {exception}");
            throw;
        }
        
        cache[path] = resource;
        return true;
    }

    public bool TryCacheResource<T>(ResourcePath path, T resource)
        where T : Resource, new()
    {
        if (!_cachedResources.ContainsKey(typeof(T)))
            return false;

        CacheResource(path, resource);
        return true;
    }
    
    public void CacheResource<T>(ResourcePath path, T resource)
        where T : Resource, new()
    {
        _cachedResources[typeof(T)][path] = resource;
    }

    public bool Cached<T>(ResourcePath path) where T : Resource
    {
        return _cachedResources[typeof(T)].ContainsKey(path);
    }
}