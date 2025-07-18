using Hypercube.Analyzers;
using Hypercube.Core.Graphics;
using Hypercube.Core.Windowing.Api;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Core.Windowing;

/// <summary>
/// Represents a platform-independent window interface used for rendering and user interaction.
/// </summary>
public interface IWindow : IEquatable<IWindow>, IContextInfo, IDisposable
{
    /// <summary>
    /// Occurs when the window's title has actually changed on the underlying system.
    /// </summary>
    /// <remarks>
    /// This event may not be raised immediately after assigning a new value to <see cref="Title"/>.
    /// It reflects the actual change as detected by the windowing system.
    /// </remarks>
    event Action<string>? OnChangedTitle;
    
    /// <summary>
    /// Occurs when the window's position has actually changed on the underlying system.
    /// </summary>
    /// <remarks>
    /// This event may not be raised immediately after assigning a new value to <see cref="Position"/>.
    /// It reflects the actual change as detected by the windowing system.
    /// </remarks>
    event Action<Vector2i>? OnChangedPosition;
    
    /// <summary>
    /// Occurs when the window's size has actually changed on the underlying system.
    /// </summary>
    /// <remarks>
    /// This event may not be raised immediately after assigning a new value to <see cref="Size"/>.
    /// It reflects the actual change as detected by the windowing system.
    /// </remarks>
    event Action<Vector2i>? OnChangedSize;

    /// <summary>
    /// Gets the internal windowing API implementation.
    /// </summary>
    /// <remarks>
    /// This property is intended for engine-level access only.
    /// </remarks>
    [EngineInternal]
    IWindowingApi Api { get; }
    
    /// <summary>
    /// Gets the native window handle.
    /// </summary>
    /// <remarks>
    /// This property is intended for engine-level access only.
    /// </remarks>
    [EngineInternal]
    nint Handle { get; }
    
    /// <summary>
    /// Gets the current graphics context associated with this window.
    /// </summary>
    /// <remarks>
    /// This property is intended for engine-level access only.
    /// </remarks>
    [EngineInternal]
    nint CurrentContext { get; }

    /// <summary>
    /// Gets the windowing backend type used to manage this window (e.g., Glfw, Sdl, Headless).
    /// </summary>
    WindowingApi Type { get; }
    
    /// <summary>
    /// Gets or sets the window title.
    /// </summary>
    /// <remarks>
    /// The setter is thread-safe and schedules an asynchronous update to the window's title.
    /// The getter returns the last known (cached) title, which updates before <see cref="OnChangedTitle"/> is raised.
    /// </remarks>
    string Title { get; set; }
    
    /// <summary>
    /// Gets or sets the window position.
    /// </summary>
    /// <remarks>
    /// The setter is thread-safe and schedules an asynchronous update to the window's title.
    /// The getter returns the last known (cached) position, which updates before <see cref="OnChangedPosition"/> is raised.
    /// </remarks>
    Vector2i Position { get; set; }
    
    /// <summary>
    /// Gets or sets the window size.
    /// </summary>
    /// <remarks>
    /// The setter is thread-safe and schedules an asynchronous update to the window's title.
    /// The getter returns the last known (cached) size, which updates before <see cref="OnChangedSize"/> is raised.
    /// </remarks>
    Vector2i Size { get; set; }

    /// <summary>
    /// Makes this window's graphics context the current one for rendering.
    /// </summary>
    void MakeCurrent();
    
    /// <summary>
    /// Swaps the front and back buffers, presenting the current rendered frame to the screen.
    /// </summary>
    void SwapBuffers();
}
