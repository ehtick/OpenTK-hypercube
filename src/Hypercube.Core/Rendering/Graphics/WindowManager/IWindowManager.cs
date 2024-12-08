namespace Hypercube.Core.Rendering.Graphics.WindowManager;

public interface IWindowManager
{
    /// <summary>
    /// Initializes the library for window management.
    /// </summary>
    /// <returns>True if initialization is successful; otherwise, False.</returns>
    void Init(bool multiThread = false);
    
    /// <summary>
    /// Processes window events.
    /// </summary>
    void PollEvents();
    
    /// <summary>
    /// Creates a new window with the default settings.
    /// </summary>
    void WindowCreate();
}