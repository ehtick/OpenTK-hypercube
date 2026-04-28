namespace Hypercube.Core.Execution.Timing;

/// <summary>
/// Represents the global runtime time service.
/// Provides timing information and frame synchronization for the runtime loop.
/// </summary>
public interface ITime
{
    /// <summary>
    /// Gets or sets the target ticks per second.
    /// </summary>
    double TickRate { get; set; }

    /// <summary>
    /// Gets the interval between ticks.
    /// </summary>
    TimeSpan TickInterval { get; }

    /// <summary>
    /// Gets the delta time between the current and previous frame.
    /// </summary>
    TimeSpan Delta { get; }

    /// <summary>
    /// Gets the total elapsed runtime time.
    /// </summary>
    TimeSpan Elapsed { get; }

    /// <summary>
    /// Gets the current frame number.
    /// </summary>
    long Frame { get; }

    /// <summary>
    /// Gets delta time in seconds.
    /// </summary>
    double DeltaSeconds { get; }

    /// <summary>
    /// Gets delta time in milliseconds.
    /// </summary>
    double DeltaMilliseconds { get; }

    /// <summary>
    /// Gets elapsed time in seconds.
    /// </summary>
    double ElapsedSeconds { get; }

    /// <summary>
    /// Gets elapsed time in milliseconds.
    /// </summary>
    double ElapsedMilliseconds { get; }

    /// <summary>
    /// Gets or sets the waiting mode between ticks.
    /// </summary>
    TimeWaitMode WaitMode { get; set; }

    /// <summary>
    /// Gets whether the timer is currently running.
    /// </summary>
    bool IsRunning { get; }

    /// <summary>
    /// Starts the timer.
    /// </summary>
    void Start();

    /// <summary>
    /// Stops the timer.
    /// </summary>
    void Stop();

    /// <summary>
    /// Restarts the timer and resets state.
    /// </summary>
    void Restart();

    /// <summary>
    /// Advances to the next frame if the tick interval has elapsed.
    /// </summary>
    /// <returns>
    /// True if the frame advanced; otherwise false.
    /// </returns>
    bool NextFrame();

    /// <summary>
    /// Sets the target tick rate.
    /// </summary>
    /// <param name="tickRate">Ticks per second.</param>
    void SetTickRate(double tickRate);

    /// <summary>
    /// Sets the target tick interval.
    /// </summary>
    /// <param name="interval">Interval between ticks.</param>
    void SetTickInterval(TimeSpan interval);
}
