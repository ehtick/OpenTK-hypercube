using Hypercube.Core.Graphics.Models;
using Hypercube.Core.Resources;
using Hypercube.Core.Resources.FileSystems;
using Hypercube.Core.Resources.Loaders;

namespace Hypercube.Core.Graphics.Resources;

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