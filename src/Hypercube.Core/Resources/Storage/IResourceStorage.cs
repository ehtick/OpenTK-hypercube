using System.Diagnostics.CodeAnalysis;
using Hypercube.Core.Resources.Loader;

namespace Hypercube.Core.Resources.Storage;

/// <summary>
/// Provides methods to manage and retrieve resources from specified paths. 
/// This includes caching, retrieval, and checking if a resource exists in the cache.
/// </summary>
/// <seealso cref="Resource"/>
/// <seealso cref="ResourcePath"/>
/// <seealso cref="IResourceLoader"/>
public interface IResourceStorage
{
    /// <summary>
    /// Retrieves a resource from the specified path. 
    /// Optionally, uses a fallback mechanism if the resource is not found.
    /// </summary>
    /// <typeparam name="T">The type of resource to retrieve.</typeparam>
    /// <param name="path">The path to the resource.</param>
    /// <param name="useFallback">Indicates whether to use a fallback if the resource is not found. Defaults to true.</param>
    /// <returns>The resource of type <typeparamref name="T"/>.</returns>
    T GetResource<T>(ResourcePath path, bool useFallback = true)
        where T : Resource, new();

    /// <summary>
    /// Tries to retrieve a resource from the specified path.
    /// Returns a boolean indicating whether the resource was found, and if so, outputs the resource.
    /// </summary>
    /// <typeparam name="T">The type of resource to retrieve.</typeparam>
    /// <param name="path">The path to the resource.</param>
    /// <param name="resource">The resource found at the specified path, or null if not found.</param>
    /// <returns>True if the resource was found, otherwise false.</returns>
    bool TryGetResource<T>(ResourcePath path, [NotNullWhen(true)] out T? resource)
        where T : Resource, new();

    /// <summary>
    /// Attempts to cache the specified resource at the given path.
    /// Returns a boolean indicating whether the caching operation was successful.
    /// </summary>
    /// <typeparam name="T">The type of resource to cache.</typeparam>
    /// <param name="path">The path where the resource should be cached.</param>
    /// <param name="resource">The resource to cache.</param>
    /// <returns>True if the resource was successfully cached, otherwise false.</returns>
    bool TryCacheResource<T>(ResourcePath path, T resource)
        where T : Resource, new();

    /// <summary>
    /// Caches the specified resource at the given path.
    /// This method will always succeed and may overwrite existing resources.
    /// </summary>
    /// <typeparam name="T">The type of resource to cache.</typeparam>
    /// <param name="path">The path where the resource should be cached.</param>
    /// <param name="resource">The resource to cache.</param>
    void CacheResource<T>(ResourcePath path, T resource)
        where T : Resource, new();

    /// <summary>
    /// Checks if a resource of the specified type is already cached at the given path.
    /// </summary>
    /// <typeparam name="T">The type of resource to check.</typeparam>
    /// <param name="path">The path to check for the cached resource.</param>
    /// <returns>True if the resource is cached, otherwise false.</returns>
    bool Cached<T>(ResourcePath path)
        where T : Resource;
}