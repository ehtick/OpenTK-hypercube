using Hypercube.Core.Graphics;
using Hypercube.Core.Windowing.Settings;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Core.Windowing.Api;

/// <summary>
/// A layer between the API for handling windows, events, input and context and the engine.
/// </summary>
[PublicAPI]
public interface IWindowingApi : IDisposable
{
    WindowingApi Type { get; }

    #region Events

    event InitHandler? OnInit;
    event ErrorHandler? OnError; 
    event MonitorHandler? OnMonitor;
    event JoystickHandler? OnJoystick;
    event WindowCloseHandler? OnWindowClose;
    event WindowTitleHandler? OnWindowTitle; 
    event WindowPositionHandler? OnWindowPosition; 
    event WindowSizeHandler? OnWindowSize; 
    event WindowFocusHandler? OnWindowFocus; 
    event WindowKey? OnWindowKey;
    event WindowScroll? OnWindowScroll;
    event WindowMouseButton? OnWindowMouseButton;
    event WindowChar? OnWindowChar;

    #endregion
    
    bool Initialized { get; }
    bool Terminated { get; }
    
    WindowHandle Context { get; set; }

    #region Life cycle

    void Init();
    void EnterLoop();
    void PollEvents();
    void Terminate();
    
    #endregion

    #region Window

    void WindowSetTitle(WindowHandle window, string title);
    void WindowSetPosition(WindowHandle window, Vector2i position);
    void WindowSetSize(WindowHandle window, Vector2i size);
    
    WindowHandle WindowCreateSync(WindowCreateSettings settings);
    WindowHandle WindowCreateMainSync(WindowCreateSettings settings);
    
    void WindowSwapBuffers(WindowHandle window);
    
    void WindowDestroy(WindowHandle window);

    #endregion
    
    void SwapInterval(int interval);
    nint GetProcAddress(string name);
}