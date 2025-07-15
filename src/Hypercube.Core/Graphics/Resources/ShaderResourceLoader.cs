using Hypercube.Core.Graphics.Rendering.Manager;
using Hypercube.Core.Graphics.Utilities.Extensions;
using Hypercube.Core.Resources;
using Hypercube.Core.Resources.FileSystems;
using Hypercube.Core.Resources.Loaders;
using Hypercube.Utilities.Dependencies;

namespace Hypercube.Core.Graphics.Resources;

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