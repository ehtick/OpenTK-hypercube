using Hypercube.Core.Viewports;
using Hypercube.Core.Windowing.Windows;

namespace Hypercube.Core.Graphics.Rendering;

public readonly struct DrawPayload
{
    public readonly IWindow Window;
    public readonly ICamera Camera;

    public DrawPayload(IWindow window, ICamera camera)
    {
        Window = window;
        Camera = camera;
    }
}
