using Hypercube.Core.Ecs;
using Hypercube.Core.Graphics.Patching;
using Hypercube.Core.Graphics.Rendering.Context;
using Hypercube.Utilities.Dependencies;

namespace Hypercube.Core.Systems;

public abstract class PatchEntitySystem : EntitySystem, IPatch, IPostInject
{
    [Dependency] protected readonly IPatchManager PatchManager = default!;

    public virtual int Priority => 0;
    
    public abstract void Draw(IRenderContext renderer);

    public virtual void PostInject()
    {
        PatchManager.AddPatch(this);
    }
}