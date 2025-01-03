using System.Diagnostics;
using Hypercube.Core.Graphics.Resources;
using Hypercube.Core.Resources.Loader;
using Hypercube.Core.Resources.Storage;
using Hypercube.Utilities.Debugging.Logger;
using Hypercube.Utilities.Dependencies;

namespace Hypercube.Core;

public class GraphicsPreloader
{
    [Dependency] private readonly ILogger _logger = default!;
    [Dependency] private readonly IResourceLoader _resourceLoader = default!;
    [Dependency] private readonly IResourceStorage _resourceStorage = default!;
    
    public void PreloadShaders()
    {
        _logger.Info("Preloading shaders...");
        var stopwatch = Stopwatch.StartNew();
        var count = 0;
        
        foreach (var path in _resourceLoader.FindContentFiles("/Shaders/"))
        {
            if (path.Extension != ".frag" && path.Extension != ".vert")
                continue;
            
            var basePath = $"{path.ParentDirectory}/{path.Filename}";
            if (_resourceStorage.Cached<ResourceShader>(basePath))
                continue;
            
            var resource = new ResourceShader(basePath);
            _resourceStorage.CacheResource(basePath, resource);
            count++;
        }
        
        stopwatch.Stop();
        _logger.Info($"Preloaded {count} shaders in {stopwatch.Elapsed}");
    }
}