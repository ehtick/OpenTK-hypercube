using Hypercube.Core.Graphics.Rendering.Context;

namespace Hypercube.Core.Graphics.Patching;

/// <summary>
/// Represents a drawable patch that can be rendered using a rendering context.
/// Patches can be ordered by <see cref="Priority"/> to control draw order.
/// </summary>
public interface IPatch
{
    /// <summary>
    /// Gets the priority of this patch.
    /// Patches with higher priority values are rendered later 
    /// (on top of patches with lower priority).
    /// </summary>
    int Priority { get; }
    
    /// <summary>
    /// Renders the patch using the provided rendering context.
    /// </summary>
    /// <param name="renderer">The rendering context used to draw the patch.</param>
    void Draw(IRenderContext renderer);
}