using Hypercube.Core.Analyzers;
using JetBrains.Annotations;

namespace Hypercube.Graphics.Patching;

[EngineCore]
public class PatchManager : IPatchManager
{
    private readonly Dictionary<Type, IPatch> _patches = new();

    public IEnumerable<IPatch> Patches => _patches.Values;

    /// <summary>
    /// Adds a patch to the dictionary if it doesn't exist already.
    /// </summary>
    public bool AddPatch(IPatch patch)
    {
        return _patches.TryAdd(patch.GetType(), patch);
    }

    /// <summary>
    /// Removes a specific patch from the dictionary.
    /// </summary> 
    public bool RemovePatch(IPatch patch)
    {
        return _patches.Remove(patch.GetType());
    }

    /// <summary>
    /// Removes a patch by its Type from the dictionary.
    /// </summary>
    public bool RemovePatch(Type patch)
    {
        return _patches.Remove(patch);
    }

    /// <summary>
    /// Removes a patch by its generic Type parameter.
    /// </summary>
    public bool RemovePatch<T>() where T : IPatch
    {
        var patchType = typeof(T);
        return _patches.Remove(patchType);
    }

    /// <summary>
    /// Checks if a patch of a specific Type exists in the dictionary.
    /// </summary>
    public bool HasPatch(Type patch)
    {
        return _patches.ContainsKey(patch);
    }

    /// <summary>
    /// Checks if a patch of a specific generic Type exists in the dictionary.
    /// </summary>
    public bool HasPatch<T>() where T : IPatch
    {
        return _patches.ContainsKey(typeof(T));
    }
}