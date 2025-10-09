using Hypercube.Core.Graphics.Rendering;
using Hypercube.Core.Utilities.Helpers;
using Hypercube.Core.Windowing;

namespace Hypercube.Core.Utilities.Extensions;

public static class RendererExtensions
{
    public static void Init(this IRenderer renderer)
    {
        renderer.Init(SettingsHelper.RendererSettingsFromConfig());
    }

    public static IWindow CreateMainWindow(this IRenderer renderer)
    {
        return renderer.CreateMainWindow(SettingsHelper.WindowCreateSettingsFromConfig());
    }
}