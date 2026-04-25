using Hypercube.Core.Windowing.Monitors;

namespace Hypercube.Core.Windowing.Api;

public readonly struct InitInfo
{
    public readonly string Message;
    public readonly IReadOnlyCollection<MonitorInstance> Monitors;

    public InitInfo(string message, IReadOnlyCollection<MonitorInstance> monitors)
    {
        Message = message;
        Monitors = monitors;
    }
}
