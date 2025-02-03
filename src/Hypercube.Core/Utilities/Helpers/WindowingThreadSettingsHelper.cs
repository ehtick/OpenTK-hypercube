using Hypercube.Graphics.Rendering;

namespace Hypercube.Core.Utilities.Helpers;

public static class WindowingThreadSettingsHelper
{
    public static WindowingThreadSettings? FromConfig()
    {
        return Config.WindowingThreading ? new WindowingThreadSettings
        {
            Name = Config.WindowingThreadName,
            StackSize = Config.WindowingThreadStackSize,
            Priority = Config.WindowingThreadPriority,
        } : null;
    }
}