using Hypercube.Core.Resources;
using Hypercube.Core.Resources.Loader;
using Hypercube.GraphicsApi.GlApi.Objects;
using Hypercube.GraphicsApi.Objects;
using Hypercube.Utilities.Dependencies;

namespace Hypercube.Core.Graphics.Resources;

public class ResourceShader : Resource, IDisposable
{
    public IShaderProgram ShaderProgram = default!;
    
    public string Base;
    public ResourcePath VertexPath;
    public ResourcePath FragmentPath;

    public ResourceShader()
    {
        Base = string.Empty;
        VertexPath = string.Empty;
        FragmentPath = string.Empty;
    }
    
    public ResourceShader(ResourcePath path)
    {
        Base = path;
        VertexPath = $"{path}.vert";
        FragmentPath =  $"{path}.frag";
    }
    
    protected override void OnLoad(ResourcePath path, DependenciesContainer container)
    {
        var resourceLoader = container.Resolve<IResourceLoader>();
        
        var vertSource = resourceLoader.ReadFileContentAllText($"{path}.vert");
        var fragSource = resourceLoader.ReadFileContentAllText($"{path}.frag");
        
        ShaderProgram = new ShaderProgram(vertSource, fragSource);
    }

    public void Dispose()
    {
        ShaderProgram.Dispose();
    }
}