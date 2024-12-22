namespace Hypercube.Core.Graphics.Patching;

public interface IPatchManager
{
    IEnumerable<IPatch> Patches { get; }
    
    bool AddPatch(IPatch patch);
    
    bool RemovePatch(IPatch patch);
    bool RemovePatch(Type patch);
    bool RemovePatch<T>() where T : IPatch;

    bool HasPatch(Type patch);
    bool HasPatch<T>() where T : IPatch;
}