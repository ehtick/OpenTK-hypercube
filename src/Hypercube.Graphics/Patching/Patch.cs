using Hypercube.Graphics.Rendering;

namespace Hypercube.Graphics.Patching;

public abstract class Patch : IPatch
{
    public abstract void Draw(IRenderer renderer);
}