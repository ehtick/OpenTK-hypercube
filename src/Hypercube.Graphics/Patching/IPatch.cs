using Hypercube.Graphics.Rendering.Context;

namespace Hypercube.Graphics.Patching;

public interface IPatch
{
    void Draw(IRenderContext renderer);
}