using Hypercube.Utilities.Collections;

namespace Hypercube.Core.Execution.LifeCycle;

public interface IRuntimeLoop
{
    ISubscribableOrderedActions<FrameEventArgs> Actions { get; }
    
    bool Running { get; }
    
    /// <summary>
    /// Starts the main run loop of the application or system.  
    /// This method blocks the current (main) thread and continuously invokes <see cref="Actions"/> 
    /// until <see cref="Running"/> is set to <c>false</c>.  
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// Thrown when attempting to start the loop while it is already running.
    /// </exception>
    void Run();
    
    void Shutdown();
}