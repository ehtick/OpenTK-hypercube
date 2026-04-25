namespace Hypercube.Core.Graphics.Patching;

/// <summary>
/// Provides management functionality for registering, querying, and removing render patches.
/// Patches are typically executed in an order defined by their <see cref="IPatch.Priority"/>.
/// </summary>
public interface IPatchManager
{
    /// <summary>
    /// Gets the collection of currently registered patches.
    /// </summary>
    IEnumerable<IPatch> Patches { get; }
    
    /// <summary>
    /// Adds a patch to the manager.
    /// </summary>
    /// <param name="patch">The patch instance to add.</param>
    /// <returns>
    /// <see langword="true"/> if the patch was successfully added; otherwise, <see langword="false"/>
    /// (for example, if a patch of the same type is already registered).
    /// </returns>
    bool AddPatch(IPatch patch);
    
    /// <summary>
    /// Removes the specified patch instance from the manager.
    /// </summary>
    /// <param name="patch">The patch instance to remove.</param>
    /// <returns>
    /// <see langword="true"/> if the patch was successfully removed; otherwise, <see langword="false"/>.
    /// </returns>
    bool RemovePatch(IPatch patch);

    /// <summary>
    /// Removes a patch of the specified type from the manager.
    /// </summary>
    /// <param name="patch">The type of the patch to remove.</param>
    /// <returns>
    /// <see langword="true"/> if a matching patch was found and removed; otherwise, <see langword="false"/>.
    /// </returns>
    bool RemovePatch(Type patch);

    /// <summary>
    /// Removes a patch of the specified generic type from the manager.
    /// </summary>
    /// <typeparam name="T">The type of the patch to remove.</typeparam>
    /// <returns>
    /// <see langword="true"/> if a matching patch was found and removed; otherwise, <see langword="false"/>.
    /// </returns>
    bool RemovePatch<T>() where T : IPatch;

    /// <summary>
    /// Determines whether a patch of the specified type is registered.
    /// </summary>
    /// <param name="patch">The type of the patch to check.</param>
    /// <returns>
    /// <see langword="true"/> if a matching patch exists; otherwise, <see langword="false"/>.
    /// </returns>
    bool HasPatch(Type patch);

    /// <summary>
    /// Determines whether a patch of the specified generic type is registered.
    /// </summary>
    /// <typeparam name="T">The type of the patch to check.</typeparam>
    /// <returns>
    /// <see langword="true"/> if a matching patch exists; otherwise, <see langword="false"/>.
    /// </returns>
    bool HasPatch<T>() where T : IPatch;
}
