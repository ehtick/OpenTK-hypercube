using System.Diagnostics;

namespace Hypercube.Core.Execution.Timing;

public class Timing : ITiming
{
    private readonly Stopwatch _stopwatch = new();

    public uint Tick { get; private set; }
    public uint Frame { get; private set; }
    
    public TimeSpan AsyncTime => _stopwatch.Elapsed;

    public Timing()
    {
        _stopwatch.Start();
    }

    public void TickUpdate()
    {
        Tick++;
    }

    public void FrameUpdate()
    {
        Frame++;
    }
}