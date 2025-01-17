using System.Diagnostics;
using Hypercube.Graphics.Rendering.Resources;
using Hypercube.Resources.Loader;
using Hypercube.Resources.Storage;
using Hypercube.Utilities.Debugging.Logger;
using Hypercube.Utilities.Dependencies;

namespace Hypercube.Graphics;

public class GraphicsPreloader
{
    [Dependency] private readonly DependenciesContainer _dependencies = default!;
    
    [Dependency] private readonly ILogger _logger = default!;
    [Dependency] private readonly IResourceLoader _resourceLoader = default!;
    [Dependency] private readonly IResourceStorage _resourceStorage = default!;
    
    public void PreloadShaders()
    {
        _logger.Info("Preloading shaders...");
        
        var stopwatch = Stopwatch.StartNew();
        var count = 0;
        
        new ResourceShader().Init(_dependencies);
        
        foreach (var path in _resourceLoader.FindContentFiles("/shaders/"))
        {
            if (!ResourceShader.Extension.Values.Contains(path.Extension))
                continue;
            
            var basePath = $"{path.ParentDirectory}/{path.Filename}";
           
            if (_resourceStorage.Cached<ResourceShader>(basePath))
                continue;
            
            var resource = new ResourceShader();
            
            resource.Load(basePath);
            resource.ShaderProgram?.Label(path.Filename);

            if (!_resourceStorage.TryCacheResource(basePath, resource))
            {
                _logger.Critical($"Cached failed: {path}");
                continue;
            }
            
            count++;
        }
        
        stopwatch.Stop();
        
        _logger.Info($"Preloaded {count} shaders in {stopwatch.Elapsed}");
    }
}