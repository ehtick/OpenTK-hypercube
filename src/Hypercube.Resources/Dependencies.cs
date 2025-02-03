using Hypercube.Resources.Loader;
using Hypercube.Resources.Storage;
using Hypercube.Utilities.Dependencies;

namespace Hypercube.Resources;

public static class Dependencies
{
    public static void Register(DependenciesContainer container)
    {
        container.Register<IResourceLoader, ResourceLoader>();
        container.Register<IResourceStorage, ResourceStorage>();
    }
}