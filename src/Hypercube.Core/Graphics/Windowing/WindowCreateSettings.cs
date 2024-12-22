using Hypercube.Core.Graphics.Monitors;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Core.Graphics.Windowing;

public struct WindowCreateSettings
{
    /// <summary>
    /// The title of the window.
    /// </summary>
    public string Title { get; init; } = "Default Window";

    /// <summary>
    /// The position of the window on the screen.
    /// </summary>
    public Vector2i Position { get; init; } = Vector2i.Zero;

    /// <summary>
    /// The initial size of the window (width and height).
    /// </summary>
    public Vector2i Size { get; init; } = new(800, 600);

    /// <summary>
    /// Flag indicating whether the window should be in fullscreen mode.
    /// </summary>
    public bool FullScreen { get; init; } = false;

    /// <summary>
    /// Flag indicating whether the window should be resizable.
    /// </summary>
    public bool Resizable { get; init; } = true;

    /// <summary>
    /// Flag indicating whether the window should be visible immediately upon creation.
    /// </summary>
    public bool Visible { get; init; } = true;

    public bool Decorated { get; init; } = true;

    public bool TransparentFramebuffer { get; init; } = false;
    
    public bool Floating { get; init; } = false;

    /// <summary>
    /// Optional context information for initializing the window's rendering context (e.g., OpenGL or Vulkan).
    /// </summary>
    public IContextInfo? ContextInfo { get; init; } = null;

    /// <summary>
    /// The window handle of another window that will be used to share the context with the current window.
    /// </summary>
    public WindowHandle? ContextShare { get; init; } = null;
    
    public MonitorHandle? MonitorShare { get; init; } = null;
    
    public WindowCreateSettings()
    {
    }
}