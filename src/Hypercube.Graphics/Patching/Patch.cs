using Hypercube.Graphics.Rendering.Context;

namespace Hypercube.Graphics.Patching;

public abstract class Patch : IPatch
{
    public abstract void Draw(IRenderContext renderer);
}