using Hypercube.Utilities.Debugging.Logger;
using Hypercube.Utilities.Dependencies;

namespace Hypercube.Core.Ecs;

public abstract class EntitySystem : EntitySystemOriginal
{
    [Dependency] protected readonly ILogger Logger = null!;
}
