using Hypercube.Core.Graphics.Rendering.Context;

namespace Hypercube.Core.Graphics.Patching;

public abstract class Patch : IPatch
{
    public abstract void Draw(IRenderContext renderer);
}