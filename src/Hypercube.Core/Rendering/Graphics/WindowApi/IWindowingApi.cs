using Hypercube.Core.Rendering.Graphics.Window;
using JetBrains.Annotations;

namespace Hypercube.Core.Rendering.Graphics.WindowApi;

/// <summary>
/// A layer between the API for handling windows, events, input and context and the engine.
/// </summary>
[PublicAPI]
public interface IWindowingApi : IDisposable
{
    bool Ready { get; }
    
    /// <summary>
    /// Initializes the library for window management.
    /// </summary>
    /// <returns>True if initialization is successful; otherwise, False.</returns>
    void Init(bool multiThread = false);

    /// <summary>
    /// Terminates the library and releases all associated resources.
    /// </summary>
    void Terminate();

    /// <summary>
    /// Enters the main event processing loop.
    /// </summary>
    void EnterLoop();

    /// <summary>
    /// Terminates the main event processing loop.
    /// </summary>
    void TerminateLoop();
    
    /// <summary>
    /// Processes window events.
    /// </summary>
    void PollEvents();

    /// <summary>
    /// Creates a new window with the default settings.
    /// </summary>
    void WindowCreate();
    
    /// <summary>
    /// Creates a new window with the specified settings.
    /// </summary>
    /// <param name="settings">The window creation settings.</param>
    void WindowCreate(WindowCreateSettings settings);

    /// <summary>
    /// Makes the specified window's context current.
    /// </summary>
    /// <param name="window">The window handle.</param>
    // void MakeContextCurrent(WindowHandle? window);

    /// <summary>
    /// Retrieves the address of the specified function.
    /// </summary>
    /// <param name="procName">The name of the function.</param>
    /// <returns>The address of the function.</returns>
    // nint GetProcAddress(string procName);
}