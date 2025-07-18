using Hypercube.Core.Windowing.Api;
using Hypercube.Core.Windowing.Manager.Exceptions;
using Hypercube.Core.Windowing.Settings;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Core.Windowing.Manager;

/// <summary>
/// Represents the main interface responsible for managing the lifecycle of platform windows,
/// including initialization, event polling, and shutdown. All methods are thread-safe unless noted otherwise.
/// </summary>
public interface IWindowManager : IDisposable
{
    /// <summary>
    /// Occurs when the main window is resized and the new size has been confirmed by the system.
    /// 
    /// Note: This event may be raised asynchronously and not immediately after a resize request.
    /// It reflects the actual change reported by the windowing backend.
    /// </summary>
    event Action<Vector2i>? OnMainWindowResized;

    /// <summary>
    /// Gets the internal windowing API implementation used to create and manage windows.
    /// </summary>
    /// <remarks>
    /// Intended for engine-level use only.
    /// </remarks>
    /// <exception cref="WindowingNotInitializedException">
    /// Thrown if the windowing system has not been initialized <see cref="Init"/> before accessing this property.
    /// </exception>
    [EngineInternal]
    IWindowingApi Api { get; }

    /// <summary>
    /// Gets a value indicating whether the windowing system is fully initialized and ready to use.
    /// </summary>
    bool Ready { get; }
    
    /// <summary>
    /// Initializes the windowing system using the specified configuration settings.
    /// This method must be called before creating any windows.
    /// </summary>
    /// <param name="settings">The configuration settings for the windowing backend.</param>
    void Init(WindowingApiSettings settings);
    
    /// <summary>
    /// Blocks the calling thread until the windowing system is ready, checking readiness at a fixed interval.
    /// </summary>
    /// <param name="sleepDelay">The delay (in milliseconds) between readiness checks.</param>
    void WaitInit(int sleepDelay);
    
    /// <summary>
    /// Shuts down the windowing system and releases all associated resources.
    /// This should be called during application termination.
    /// </summary>
    void Shutdown();
    
    /// <summary>
    /// Enters the platform-specific main loop.
    /// Note: This is typically a blocking call and should be used only in environments that support it.
    /// </summary>
    void EnterLoop();
    
    /// <summary>
    /// Polls and processes pending platform events (e.g., input, resize, close).
    /// Should be called regularly in custom main loops.
    /// </summary>
    void PollEvents();
    
    /// <summary>
    /// Creates a new window using the provided creation settings.
    /// </summary>
    /// <param name="settings">The configuration settings for the new window.</param>
    /// <returns>A new <see cref="IWindow"/> instance.</returns>
    IWindow Create(WindowCreateSettings settings);
}