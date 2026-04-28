using System.Diagnostics;

namespace Hypercube.Core.Execution.Timing;

/// <inheritdoc />
[UsedImplicitly]
public sealed class Time : ITime
{
    public const double DefaultTickRate = 60d;
    
    private readonly Stopwatch _stopwatch = new();

    private TimeSpan _previous;
    private TimeSpan _tickInterval;
    private double _tickRate;

    /// <inheritdoc />
    public bool IsRunning => _stopwatch.IsRunning;

    /// <inheritdoc />
    public long Frame { get; private set; }

    /// <inheritdoc />
    public TimeSpan Delta { get; private set; }

    /// <inheritdoc />
    public TimeSpan Elapsed => _stopwatch.Elapsed;

    /// <inheritdoc />
    public double DeltaSeconds => Delta.TotalSeconds;

    /// <inheritdoc />
    public double DeltaMilliseconds => Delta.TotalMilliseconds;

    /// <inheritdoc />
    public double ElapsedSeconds => Elapsed.TotalSeconds;

    /// <inheritdoc />
    public double ElapsedMilliseconds => Elapsed.TotalMilliseconds;

    /// <inheritdoc />
    public TimeSpan TickInterval => _tickInterval;

    /// <inheritdoc />
    public TimeWaitMode WaitMode { get; set; } = TimeWaitMode.Yield;

    /// <inheritdoc />
    public double TickRate
    {
        get => _tickRate;
        set => SetTickRate(value);
    }

    public Time()
    {
        SetTickRate(DefaultTickRate);
    }

    /// <inheritdoc />
    public void Start()
    {
        _stopwatch.Start();
        _previous = _stopwatch.Elapsed;

        Delta = TimeSpan.Zero;
        Frame = 0;
    }

    /// <inheritdoc />
    public void Stop()
    {
        _stopwatch.Stop();
    }

    /// <inheritdoc />
    public void Restart()
    {
        _stopwatch.Restart();

        _previous = TimeSpan.Zero;
        Delta = TimeSpan.Zero;
        Frame = 0;
    }

    /// <inheritdoc />
    public bool NextFrame()
    {
        var current = _stopwatch.Elapsed;
        var delta = current - _previous;

        if (delta < _tickInterval)
        {
            Wait();
            return false;
        }

        _previous = current;
        Delta = delta;
        Frame++;

        return true;
    }

    /// <inheritdoc />
    public void SetTickRate(double tickRate)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(tickRate);

        _tickRate = tickRate;
        _tickInterval = TimeSpan.FromSeconds(1d / tickRate);
    }

    /// <inheritdoc />
    public void SetTickInterval(TimeSpan interval)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(interval.Ticks);

        _tickInterval = interval;
        _tickRate = 1d / interval.TotalSeconds;
    }

    private void Wait()
    {
        switch (WaitMode)
        {
            case TimeWaitMode.None:
                return;

            case TimeWaitMode.Yield:
                Thread.Yield();
                return;

            case TimeWaitMode.Sleep:
                Thread.Sleep(1);
                return;

            case TimeWaitMode.SpinWait:
                Thread.SpinWait(1);
                return;

            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
