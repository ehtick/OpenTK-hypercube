using Hypercube.Graphics.Models;
using Hypercube.Resources;
using Hypercube.Resources.FileSystems;
using Hypercube.Resources.Loaders;

namespace Hypercube.Graphics.Resources;

public sealed class ModelResourceLoader : ResourceLoader<Model>
{
    public override string[] Extensions => ["obj"];
    
    public override bool CanLoad(ResourcePath path, IFileSystem fileSystem)
    {
        return true;
    }

    public override Model Load(ResourcePath path, IFileSystem fileSystem)
    {
        return ModelObjLoader.Load(fileSystem.OpenRead(path));
    }
}