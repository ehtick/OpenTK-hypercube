using Hypercube.Core.Graphics.Rendering.Context;

namespace Hypercube.Core.Graphics.Patching;

public interface IPatch
{
    void Draw(IRenderContext renderer);
}