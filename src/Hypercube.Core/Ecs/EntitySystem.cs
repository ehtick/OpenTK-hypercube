using Hypercube.Core.Execution.LifeCycle;
using Hypercube.Utilities.Debugging.Logger;
using Hypercube.Utilities.Dependencies;

namespace Hypercube.Core.Ecs;

public abstract class EntitySystem : Hypercube.Ecs.System.EntitySystem<FrameEventArgs>
{
    [Dependency] protected readonly ILogger Logger = null!;
}
