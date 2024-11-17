using JetBrains.Annotations;

namespace Hypercube.Graphics.Windowing;

/// <summary>
/// A layer between the API for handling windows, events, input and context and the engine.
/// </summary>
[PublicAPI]
public interface IWindowing
{
    Thread? CurrentThread { get; }
    
    /// <summary>
    /// Initializes the implementation in the current thread,
    /// after which it will not be possible to work with it from another thread.
    /// </summary>
    bool Init();
    
    /// <summary>
    /// Completes the work of implementation, as well as exiting the basic life cycles.
    /// Automatically called when disposed.
    /// </summary>
    void Shutdown();
}