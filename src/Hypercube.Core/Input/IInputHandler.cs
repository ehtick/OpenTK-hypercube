using Hypercube.Core.Windowing;

namespace Hypercube.Core.Input;

/// <summary>
/// Interface for handling and simulating keyboard input states across one or multiple windows.
/// Provides low-level access to key state queries and input simulation.
/// </summary>
public interface IInputHandler
{
    /// <summary>
    /// Clears all recorded key input states (Held and Released keys) for all tracked windows.
    /// </summary>
    void Clear();
    
    /// <summary>
    /// Checks if the specified key in a given window is currently in the specified state.
    /// </summary>
    /// <param name="window">The native handle of the window to check.</param>
    /// <param name="key">The key to query.</param>
    /// <param name="state">The key state to compare against.</param>
    /// <returns>True if the key is in the specified state; otherwise, false.</returns>
    bool IsKeyState(WindowHandle window, Key key, KeyState state);
    
    /// <summary>
    /// Returns whether the specified key is currently held down in the given window.
    /// </summary>
    /// <param name="window">The native window handle.</param>
    /// <param name="key">The key to query.</param>
    /// <returns>True if the key is held; otherwise, false.</returns>
    bool IsKeyHeld(WindowHandle window, Key key);
    
    /// <summary>
    /// Returns whether the specified key was pressed during the current frame in the given window.
    /// </summary>
    /// <param name="window">The native window handle.</param>
    /// <param name="key">The key to query.</param>
    /// <returns>True if the key was pressed this frame; otherwise, false.</returns>
    bool IsKeyPressed(WindowHandle window, Key key);
    
    /// <summary>
    /// Returns whether the specified key was released during the current frame in the given window.
    /// </summary>
    /// <param name="window">The native window handle.</param>
    /// <param name="key">The key to query.</param>
    /// <returns>True if the key was released this frame; otherwise, false.</returns>
    bool IsKeyReleased(WindowHandle window, Key key);
    
    /// <summary>
    /// Checks if the specified key in the currently active window is in the given state.
    /// </summary>
    /// <param name="key">The key to query.</param>
    /// <param name="state">The key state to compare against.</param>
    /// <returns>True if the key is in the specified state; otherwise, false.</returns>
    bool IsKeyState(Key key, KeyState state);
    
    /// <summary>
    /// Returns whether the specified key is currently held down in the currently active window.
    /// </summary>
    /// <param name="key">The key to query.</param>
    /// <returns>True if the key is held; otherwise, false.</returns>
    bool IsKeyHeld(Key key);
    
    /// <summary>
    /// Returns whether the specified key was pressed during the current frame in the currently active window.
    /// </summary>
    /// <param name="key">The key to query.</param>
    /// <returns>True if the key was pressed this frame; otherwise, false.</returns>
    bool IsKeyPressed(Key key);
    
    /// <summary>
    /// Returns whether the specified key was released during the current frame in the currently active window.
    /// </summary>
    /// <param name="key">The key to query.</param>
    /// <returns>True if the key was released this frame; otherwise, false.</returns>
    bool IsKeyReleased(Key key);
    
    /// <summary>
    /// Simulates a key state change event in the currently active window.
    /// Typically used for testing or synthetic input events.
    /// </summary>
    /// <param name="state">The key state change to simulate.</param>
    void Simulate(KeyStateChangedArgs state);
    
    /// <summary>
    /// Simulates a key state change event in a specific window.
    /// Typically used for testing or synthetic input events in multi-window setups.
    /// </summary>
    /// <param name="window">The native handle of the window to simulate the event for.</param>
    /// <param name="state">The key state change to simulate.</param>
    void Simulate(WindowHandle window, KeyStateChangedArgs state);
}