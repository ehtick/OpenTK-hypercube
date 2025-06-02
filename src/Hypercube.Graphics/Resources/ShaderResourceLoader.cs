using Hypercube.Graphics.Rendering.Manager;
using Hypercube.Resources;
using Hypercube.Resources.FileSystems;
using Hypercube.Resources.Loaders;
using Hypercube.Utilities.Dependencies;

namespace Hypercube.Graphics.Resources;

public sealed class ShaderResourceLoader : ResourceLoader<Shader>
{
    [Dependency] private readonly IRenderManager _renderManager = default!;

    public override string[] Extensions => ["shd"];
    
    public override bool CanLoad(ResourcePath path, IFileSystem fileSystem)
    {
        return true;
    }

    public override Shader Load(ResourcePath path, IFileSystem fileSystem)
    {
        return new Shader(_renderManager.CreateShaderProgram(fileSystem.OpenRead(path).ReadToEnd()));
    }
}