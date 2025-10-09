namespace Hypercube.Core.Execution.LifeCycle;

public readonly struct FrameEventArgs
{
    public readonly float DeltaSeconds;
    
    public FrameEventArgs(float deltaSeconds)
    {
        DeltaSeconds = deltaSeconds;
    }
}