using Hypercube.Core.Graphics;
using Hypercube.Core.Windowing.Settings;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Core.Windowing.Api;

/// <summary>
/// A layer between the API for handling windows, events, input and context and the engine.
/// </summary>
[PublicAPI]
public interface  IWindowingApi : IDisposable
{
    WindowingApi Type { get; }
    
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
    
    bool Ready { get; }
    WindowHandle Context { get; set; }
    
    void Init(WindowingApiSettings settings);
    void EnterLoop();
    void PollEvents();
    void Terminate();

    void SwapInterval(int value);
    
    void WindowSetTitle(WindowHandle window, string title);
    void WindowSetPosition(WindowHandle window, Vector2i position);
    void WindowSetSize(WindowHandle window, Vector2i size);
    void WindowCreate(WindowCreateSettings settings);
    WindowHandle WindowCreateSync(WindowCreateSettings settings);
    void WindowDestroy(WindowHandle window);
    void WindowSwapBuffers(WindowHandle window);
    nint GetProcAddress(string name);
}