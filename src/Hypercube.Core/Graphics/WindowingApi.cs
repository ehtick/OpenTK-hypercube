namespace Hypercube.Core.Graphics;

/// <summary>
/// Specifies the underlying windowing system or backend used to manage a window.
/// </summary>
public enum WindowingApi
{
    /// <summary>
    /// No windowing system is used (e.g., offscreen rendering or testing environment).
    /// </summary>
    Headless,
    
    /// <summary>
    /// The window is managed using the GLFW library.
    /// </summary>
    Glfw,
    
    /// <summary>
    /// The window is managed using the SDL library.
    /// </summary>
    Sdl
}