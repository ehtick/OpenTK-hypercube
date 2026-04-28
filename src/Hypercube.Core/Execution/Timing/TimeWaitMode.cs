namespace Hypercube.Core.Execution.Timing;

/// <summary>
/// Defines the waiting strategy between ticks.
/// </summary>
public enum TimeWaitMode
{
    /// <summary>
    /// Does not wait between ticks.
    /// Maximum CPU usage, minimum latency.
    /// </summary>
    None,

    /// <summary>
    /// Yields the current thread execution to another thread.
    /// Balanced CPU usage and responsiveness.
    /// </summary>
    Yield,

    /// <summary>
    /// Sleeps for a short amount of time.
    /// Lower CPU usage, less precise timing.
    /// </summary>
    Sleep,

    /// <summary>
    /// Spins actively until the next tick.
    /// Highest precision, highest CPU usage.
    /// </summary>
    SpinWait
}
