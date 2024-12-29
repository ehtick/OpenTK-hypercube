using Hypercube.Graphics.Windowing;
using Hypercube.GraphicsApi.GlApi;

namespace Hypercube.Core.Graphics.Windowing.Manager;

public interface IWindowManager : IBindingsContext
{
    bool Ready { get; }
    
    /// <summary>
    /// Initializes the library for window management.
    /// </summary>
    /// <returns>True if initialization is successful; otherwise, False.</returns>
    void Init(bool multiThread = false);

    void WaitInit(int sleepDelay);
    
    void EnterLoop();
    
    /// <summary>
    /// Processes window events.
    /// </summary>
    void PollEvents();
    
    /// <summary>
    /// Creates a new window with the default settings.
    /// </summary>
    WindowHandle WindowCreate();

    WindowHandle WindowCreate(WindowCreateSettings settings);
    
    Task<WindowHandle> WindowCreateAsync();
    
    void WindowSetTitle(WindowHandle window, string title);
}