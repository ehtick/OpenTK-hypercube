using Hypercube.Core.Resources.FileSystems;
using Hypercube.Core.Resources.Loaders;
using Hypercube.Core.Resources.Preloading;
using Hypercube.Utilities.Dependencies;
using Hypercube.Utilities.Helpers;

namespace Hypercube.Core.Resources;

[UsedImplicitly]
public sealed class ResourceManager : IResourceManager, IDisposable
{
    public readonly IFileSystem FileSystem;
    public readonly DependenciesContainer? Container;
    
    private readonly Dictionary<Type, IResourceLoader> _loaders = [];
    private readonly Dictionary<ResourcePath, Resource> _cache = [];

    public ResourceManager(IFileSystem? fileSystem = null, DependenciesContainer? container = null)
    {
        FileSystem = fileSystem ?? new PhysicalFileSystem();
        Container = container;
    }

    /// <inheritdoc/>
    public void Mount(Dictionary<ResourcePath, ResourcePath> mountFolders)
    {
        FileSystem.Mount(mountFolders);
    }

    /// <inheritdoc/>
    public void Mount(Dictionary<string, string> mountFolders)
    {
        FileSystem.Mount(mountFolders);
    }

    /// <inheritdoc/>
    public void Mount(ResourcePath physicalPath, ResourcePath relativePath)
    {
        FileSystem.Mount(physicalPath, relativePath);
    }

    /// <inheritdoc/>
    public void Unmount(ResourcePath relativePath)
    {
        FileSystem.Unmount(relativePath);
    }

    public void AddLoader<T>(IResourceLoader loader) where T : Resource
    {
        if (_loaders.ContainsKey(typeof(T)))
            throw new Exception();
        
        _loaders.Add(typeof(T), loader);
    }

    public void AddAllLoaders()
    {
        foreach (var loader in GetAllLoaders(Container))
        {
            if (!_loaders.TryAdd(loader.ResourceType, loader))
                throw new Exception();
        }
    }

    public bool HasLoader<T>() where T : Resource
    {
        return _loaders.ContainsKey(typeof(T));
    }

    public void RemoveLoader<T>() where T : Resource
    {
        if (!_loaders.ContainsKey(typeof(T)))
            throw new Exception();

        _loaders.Remove(typeof(T));
    }

    public T Get<T>(ResourcePath path) where T : Resource
    {
        if (_cache.TryGetValue(path, out var resource))
            return resource as T ?? throw new Exception();

        return Load<T>(path);
    }

    public IEnumerable<T> GetAllCached<T>() where T : Resource
    {
        foreach (var resource in _cache.Values)
        {
            if (resource is T typedResource)
                yield return typedResource;
        }
    }

    public bool HasCache<T>(ResourcePath path) where T : Resource
    {
        return _cache.ContainsKey(path);
    }

    public T Load<T>(ResourcePath path) where T : Resource
    {
        return (T) Load(path, typeof(T));
    }

    public Resource Load(ResourcePath path, Type type)
    {
        if (!_loaders.TryGetValue(type, out var loader))
            throw new Exception();

        if (_cache.TryGetValue(path, out var cache))
            return cache;
        
        var resource = loader.Load(path, FileSystem);
        _cache[path] = resource;
        
        return resource;
    }

    public Resource Load(ResourcePath path)
    {
        if (_cache.TryGetValue(path, out var cache))
            return cache;
        
        foreach (var (_, loader) in _loaders)
        {
            if (loader.Extensions.Contains(path.Extension))
                return loader.Load(path, FileSystem);
        }

        throw new Exception();
    }

    public void Unload(ResourcePath path)
    {
        if (!_cache.Remove(path, out var resource))
            throw new Exception();

        resource.Dispose();
    }

    public void UnloadAll()
    {
        foreach (var (path, _) in _cache)
        {
            Unload(path);
        }
    }

    public PreloadContext CreatePreloadContext()
    {
        return new PreloadContext(this);
    }

    public void Dispose()
    {
        UnloadAll();
    }

    private static List<IResourceLoader> GetAllLoaders(DependenciesContainer? container)
    {
        var result = new List<IResourceLoader>();
        var types = ReflectionHelper.GetAllInstantiableSubclassOf(typeof(IResourceLoader));
        
        foreach (var type in types)
        {
            var constructors = type.GetConstructors();
            if (constructors.Length != 1)
                throw new InvalidOperationException();

            var constructor = constructors[0];
            var parameters = constructor.GetParameters();
            if (parameters.Length != 0)
                throw new InvalidOperationException();

            var instance = (IResourceLoader) constructor.Invoke(null);
            container?.Inject(instance);
            result.Add(instance);
        }

        return result;
    }
}