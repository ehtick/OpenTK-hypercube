namespace Hypercube.Core.Execution;

public interface IRuntimeLoop
{
    bool Running { get; }
    void Run();
    void Shutdown();
}