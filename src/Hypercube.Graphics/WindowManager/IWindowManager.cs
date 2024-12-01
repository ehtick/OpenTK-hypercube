using System.Diagnostics.CodeAnalysis;
using Hypercube.Graphics.Window;
using JetBrains.Annotations;

namespace Hypercube.Graphics.WindowManager;

/// <summary>
/// A layer between the API for handling windows, events, input and context and the engine.
/// </summary>
[PublicAPI]
public interface IWindowManager : IDisposable
{
    public event Action? OnWindowLoopUpdate;
    
    /// <summary>
    /// Initializes the library for window management.
    /// </summary>
    /// <returns>True if initialization is successful; otherwise, False.</returns>
    bool Init();

    /// <summary>
    /// Terminates the library and releases all associated resources.
    /// </summary>
    void Terminate();

    /// <summary>
    /// Enters the main event processing loop.
    /// </summary>
    void EnterWindowLoop();

    /// <summary>
    /// Processes window events.
    /// </summary>
    void PollEvents();

    /// <summary>
    /// Creates a new window with the specified settings.
    /// </summary>
    /// <param name="settings">The window creation settings.</param>
    /// <param name="window"></param>
    /// <returns>A result indicating the success and window handle of the created window.</returns>
    bool WindowCreate(WindowCreateSettings settings, [NotNullWhen(true)] IWindow? window);

    /// <summary>
    /// Makes the specified window's context current.
    /// </summary>
    /// <param name="window">The window handle.</param>
    void MakeContextCurrent(WindowHandle? window);

    /// <summary>
    /// Retrieves the address of the specified function.
    /// </summary>
    /// <param name="procName">The name of the function.</param>
    /// <returns>The address of the function.</returns>
    nint GetProcAddress(string procName);
}