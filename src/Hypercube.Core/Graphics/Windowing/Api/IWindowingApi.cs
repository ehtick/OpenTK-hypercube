using Hypercube.Core.Graphics.Windowing.Settings;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Core.Graphics.Windowing.Api;

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
    nint ContextCurrent { get; set; }
    
    void Init(WindowingApiSettings settings);
    void EnterLoop();
    void PollEvents();
    void Terminate();
    
    void WindowSetTitle(nint window, string title);
    void WindowSetPosition(nint window, Vector2i position);
    void WindowSetSize(nint window, Vector2i size);
    void WindowCreate(WindowCreateSettings settings);
    nint WindowCreateSync(WindowCreateSettings settings);
    void WindowDestroy(nint window);
    void WindowSwapBuffers(nint window);

    nint GetProcAddress(string name);
}