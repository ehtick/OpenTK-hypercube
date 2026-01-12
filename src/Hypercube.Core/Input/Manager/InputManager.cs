using Hypercube.Core.Execution.LifeCycle;
using Hypercube.Core.Input.Handler;
using Hypercube.Utilities.Dependencies;

namespace Hypercube.Core.Input.Manager;

/// <summary>
/// High-performance implementation of <see cref="IInputManager"/>.
/// Engine-core level, allocation-free, cache-friendly.
/// </summary>
[UsedImplicitly]
public sealed class InputManager : IInputManager, IPostInject
{
    [Dependency] private readonly IRuntimeLoop _runtimeLoop = null!;
    [Dependency] private readonly IInputHandler _inputHandler = null!;
    
    public void OnPostInject()
    {
        _runtimeLoop.Actions.Add(OnUpdate, EngineUpdatePriority.InputManager);
    }

    private void OnUpdate(FrameEventArgs obj)
    {
        // TODO
    }
}
