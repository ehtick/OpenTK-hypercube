using System.Diagnostics.CodeAnalysis;

namespace Hypercube.Core.Resources.Root;

public interface IContentRoot
{
    bool TryGetFile(ResourcePath path, [NotNullWhen(true)] out Stream? stream);
    IEnumerable<ResourcePath> FindFiles(ResourcePath path);
}