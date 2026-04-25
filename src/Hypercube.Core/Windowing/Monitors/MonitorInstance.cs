namespace Hypercube.Core.Windowing.Monitors;

public readonly struct MonitorInstance
{
    public readonly MonitorHandle Handle;
    public readonly MonitorCreateSettings Settings;

    public MonitorInstance(MonitorHandle handle, MonitorCreateSettings settings)
    {
        Handle = handle;
        Settings = settings;
    }
}
