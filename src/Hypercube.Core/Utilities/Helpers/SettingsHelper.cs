using Hypercube.Core.Graphics.Rendering;
using Hypercube.Core.Graphics.Rendering.Api.Settings;
using Hypercube.Core.Windowing.Api;
using Hypercube.Core.Windowing.Settings;

namespace Hypercube.Core.Utilities.Helpers;

public static class SettingsHelper
{
    public static WindowCreateSettings WindowCreateSettingsFromConfig()
    {
        return new WindowCreateSettings
        {
            Api = new ApiSettings
            {
                Api = ContextApi.OpenGl,
                Flags = ContextFlags.Debug,
                Profile = ContextProfile.Core,
                Version = new Version(4, 6)
            },
            Title = Config.MainWindowTitle,
            Resizable = Config.MainWindowResizable,
            Decorated = Config.MainWindowDecorated,
            Floating = Config.MainWindowFloating,
            Visible = Config.MainWindowVisible,
            TransparentFramebuffer = Config.MainWindowTransparentFramebuffer
        };
    }

    public static RendererSettings RendererSettingsFromConfig()
    {
        return new RendererSettings
        {
            Thread = Config.WindowingThreading ? new WindowingThreadSettings
            {
                Name = Config.WindowingThreadName,
                StackSize = Config.WindowingThreadStackSize,
                Priority = Config.WindowingThreadPriority,
            } : null,
            WindowingApi = new WindowingApiSettings
            {
                Api = Config.Windowing,
                WaitEventsTimeout = Config.WindowingWaitEventsTimeout,
                EventBridgeBufferSize = Config.WindowingThreadEventBridgeBufferSize
            },
            RenderingApi = new RenderingApiSettings
            {
                Api = Config.Rendering,
                ClearColor = Config.RenderingClearColor,
                MaxVertices = Config.RenderingMaxVertices,
                IndicesPerVertex = Config.RenderingIndicesPerVertex
            },
            ReadySleepDelay = Config.WindowingThreadReadySleepDelay
        };
    }
}