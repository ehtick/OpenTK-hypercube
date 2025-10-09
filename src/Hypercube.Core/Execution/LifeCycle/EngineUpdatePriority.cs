using Hypercube.Core.Ecs;
using Hypercube.Core.Graphics.Rendering.Manager;
using Hypercube.Core.Input;
using Hypercube.Utilities.Collections;

namespace Hypercube.Core.Execution.LifeCycle;

public enum EngineUpdatePriority
{
    /// <see cref="IInputHandler"/>
    InputHandler,
    
    /// <see cref="IRenderManager"/>
    RendererUpdate,
    
    /// <see cref="IEntitySystemManager"/>
    EntitySystemManager,
    
    /// <see cref="IRenderManager"/>
    RendererRender
}

public static class EngineUpdatePriorityExtensions
{
    public static void Add<T>(this ISubscribableOrderedActions<T> actions, Action<T> action, EngineUpdatePriority priority)
    {
        actions.Add(action, (int) priority);
    }
}
