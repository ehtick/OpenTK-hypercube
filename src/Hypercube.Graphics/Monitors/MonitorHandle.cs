namespace Hypercube.Graphics.Windowing;

public sealed class MonitorHandle
{
    public nint Handle { get; init; }
    
    public static explicit operator nint(MonitorHandle windowHandle)
    {
        return windowHandle.Handle;
    }
}