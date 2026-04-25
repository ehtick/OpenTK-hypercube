using Hypercube.Core.Windowing.Monitors.Data;

namespace Hypercube.Core.Windowing.Monitors;

/// <summary>
/// Represents a physical display monitor and its properties.
/// Provides information about positioning, scaling, and supported video modes.
/// </summary>
public partial interface IMonitor
{
    /// <summary>
    /// Gets the human-readable name of the monitor.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets a value indicating whether this monitor is the primary display.
    /// </summary>
    bool Primary { get; }

    /// <summary>
    /// Gets the position of the monitor in the virtual desktop coordinate space.
    /// </summary>
    Vector2 Position { get; }

    /// <summary>
    /// Gets the physical size of the monitor, typically in millimeters.
    /// </summary>
    Vector2 PhysicalSize { get; }

    /// <summary>
    /// Gets the DPI (dots per inch) scaling values for the monitor.
    /// </summary>
    Vector2 Dpi { get; }

    /// <summary>
    /// Gets the content scaling factor used for high-DPI rendering.
    /// </summary>
    Vector2 ContentScale { get; }

    /// <summary>
    /// Gets the usable work area of the monitor, excluding taskbars and system UI.
    /// </summary>
    WorkArea WorkArea { get; }

    /// <summary>
    /// Gets the currently active video mode of the monitor.
    /// </summary>
    VideoMode CurrentVideoMode { get; }

    /// <summary>
    /// Gets the collection of video modes supported by the monitor.
    /// </summary>
    IReadOnlyCollection<VideoMode> VideoModes { get; }
}
