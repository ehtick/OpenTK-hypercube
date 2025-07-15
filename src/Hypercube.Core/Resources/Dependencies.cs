using Hypercube.Utilities.Dependencies;

namespace Hypercube.Core.Resources;

public static class Dependencies
{
    public static void Register(DependenciesContainer container)
    {
        container.Register<IResourceManager>(new ResourceManager(container: container));
    }
}