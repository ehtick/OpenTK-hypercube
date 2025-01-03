using System.Diagnostics.CodeAnalysis;
using Hypercube.Utilities.Debugging.Logger;
using Hypercube.Utilities.Helpers;

namespace Hypercube.Core.Resources.Root;

public class DirContentRoot : IContentRoot
{
    private readonly DirectoryInfo _directory;
    private readonly ILogger _logger;

    public DirContentRoot(DirectoryInfo directory, ILogger logger)
    {
        _directory = directory;
        _logger = logger;
    }
    
    public bool TryGetFile(ResourcePath path, [NotNullWhen(true)] out Stream? stream)
    {
        if (!FileExists(path))
        {
            stream = null;
            return false;
        }
        
        try
        {
            stream = File.Open(GetPath(path), FileMode.Open, FileAccess.Read);
            return true;
        }
        catch (Exception ex)
        {
            _logger.Critical(ex.Message);
            stream = null;
        }
        return false;
    }
    
    private bool FileExists(ResourcePath relPath)
    {
        var path = GetPath(relPath);
        return File.Exists(path);
    }
    
    private string GetPath(ResourcePath path)
    {
        return Path.GetFullPath(Path.Combine(_directory.FullName, path));
    }

    public IEnumerable<ResourcePath> FindFiles(ResourcePath path)
    {
        var fullPath = GetPath(path);
        if (!Directory.Exists(fullPath))
            yield break;
        
        var paths = PathHelper.GetFiles(fullPath);
        
        foreach (var filePath in paths)
        {
            var relPath = filePath.Substring(_directory.FullName.Length);
            yield return ResourcePath.FromRelativeSystemPath(relPath, OperatingSystem.IsWindows() ? '\\' : '/');
        }
    }
}