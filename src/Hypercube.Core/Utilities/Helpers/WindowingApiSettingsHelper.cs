using Hypercube.Core.Windowing.Api;

namespace Hypercube.Core.Utilities.Helpers;

public static class WindowingApiSettingsHelper
{
    public static WindowingApiSettings FromConfig()
    {
        return new WindowingApiSettings
        {
            Api = Config.Windowing,
            WaitEventsTimeout = Config.WindowingWaitEventsTimeout,
            EventBridgeBufferSize = Config.WindowingThreadEventBridgeBufferSize
        };
    }
}