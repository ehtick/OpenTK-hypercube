namespace Hypercube.Core.Execution;

public readonly struct FrameEventArgs
{
    public readonly float DeltaSeconds;
    
    public FrameEventArgs(float deltaSeconds)
    {
        DeltaSeconds = deltaSeconds;
    }
}