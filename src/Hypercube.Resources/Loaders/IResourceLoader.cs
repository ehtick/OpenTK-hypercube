using Hypercube.Resources.FileSystems;
using JetBrains.Annotations;

namespace Hypercube.Resources.Loaders;

[UsedImplicitly(ImplicitUseTargetFlags.WithInheritors)]
public interface IResourceLoader
{
    string[] Extensions { get; }
    Type ResourceType { get; }
    
    public bool CanLoad(ResourcePath path, IFileSystem fileSystem);
    public Resource Load(ResourcePath path, IFileSystem fileSystem);
}