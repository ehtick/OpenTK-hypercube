namespace Hypercube.Core.Graphics.Patching;

[EngineInternal, UsedImplicitly]
public class PatchManager : IPatchManager
{
    private readonly Dictionary<Type, IPatch> _patches = new();
    
    private List<IPatch> _sorted = [];
    private bool _dirty = true;

    /// <inheritdoc/>
    public IEnumerable<IPatch> Patches => GetPatches();

    /// <inheritdoc/>
    public bool AddPatch(IPatch patch)
    {
        if (!_patches.TryAdd(patch.GetType(), patch))
            return false;

        _dirty = true;
        return true;
    }

    /// <inheritdoc/>
    public bool RemovePatch(Type patch)
    {
        if (!_patches.Remove(patch))
            return false;

        _dirty = true;
        return true;
    }

    /// <inheritdoc/>
    public bool RemovePatch(IPatch patch) => RemovePatch(patch.GetType());

    /// <inheritdoc/>
    public bool RemovePatch<T>() where T : IPatch => RemovePatch(typeof(T));

    /// <inheritdoc/>
    public bool HasPatch(Type patch) => _patches.ContainsKey(patch);

    /// <inheritdoc/>
    public bool HasPatch<T>() where T : IPatch => HasPatch(typeof(T));
    
    private List<IPatch> GetPatches()
    {
        if (!_dirty)
            return _sorted;
        
        _sorted = _patches.Values
            .OrderByDescending(p => p.Priority)
            .ToList();

        _dirty = false;
        return _sorted;
    }
}
