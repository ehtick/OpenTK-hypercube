using Hypercube.Core.Graphics.Rendering.Context;

namespace Hypercube.Core.Graphics.Patching;

/// <inheritdoc/>
public abstract class Patch : IPatch
{
    /// <inheritdoc/>
    public virtual int Priority => 0;
    
    /// <inheritdoc/>
    public abstract void Draw(IRenderContext renderer);
}