namespace Hypercube.Core.Graphics.Monitors;

public sealed unsafe class MonitorHandle
{
    [EngineInternal]
    public nint* Handle { get; init; }
    
    public static explicit operator nint*(MonitorHandle windowHandle)
    {
        return windowHandle.Handle;
    }
}