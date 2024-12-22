using Hypercube.Core.Graphics.Rendering;

namespace Hypercube.Core.Graphics.Patching;

public abstract class Patch : IPatch
{
    public abstract void Draw(IRenderer renderer);
}