using Hypercube.Graphics.Windowing.Settings;
using Hypercube.Mathematics.Vectors;
using JetBrains.Annotations;

namespace Hypercube.Graphics.Windowing.Api;

/// <summary>
/// A layer between the API for handling windows, events, input and context and the engine.
/// </summary>
[PublicAPI]
public interface IWindowingApi : IDisposable
{
    event ErrorHandler? OnError; 
    event MonitorHandler? OnMonitor;
    event JoystickHandler? OnJoystick;
    event WindowCloseHandler? OnWindowClose;
    event WindowPositionHandler? OnWindowPosition; 
    event WindowSizeHandler? OnWindowSize; 
    event WindowFocusHandler? OnWindowFocus; 
    
    bool Ready { get; }
    
    void Init(WindowingApiSettings settings);
    void EnterLoop();
    void PollEvents();
    void Terminate();
    
    void WindowSetTitle(nint window, string title);
    void WindowSetPosition(nint window, Vector2i position);
    void WindowSetSize(nint window, Vector2i size);
    void WindowCreate(WindowCreateSettings settings);
    nint WindowCreateSync(WindowCreateSettings settings);
    void WindowSwapBuffers(nint window);
    
    void MakeContextCurrent(nint window);

    nint GetProcAddress(string name);
}