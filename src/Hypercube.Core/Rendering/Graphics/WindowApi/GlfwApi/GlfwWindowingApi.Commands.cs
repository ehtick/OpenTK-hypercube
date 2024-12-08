using Hypercube.Core.Rendering.Graphics.Api.GlfwApi;
using Hypercube.Core.Rendering.Graphics.Window;

namespace Hypercube.Core.Rendering.Graphics.WindowApi.GlfwApi;

public unsafe partial class GlfwWindowingApi
{   
    private void Raise(Command command)
    {
        _logger.Trace($"Handled command {command.GetType().Name} (multiThread: {_multiThread})");
        
        if (_multiThread)
        {
            _commandBridge.Raise(command);
            
            if (_waitEventsTimeout == 0)
                Glfw.PostEmptyEvent();
            
            return;
        }
        
        Process(command);
    }
    
    private void Process(Command command)
    {
        switch (command)
        {
            case CommandTerminate:
                _running = false;
                _eventBridge.CompleteWrite();
                
                Glfw.Terminate();
                
                Console.WriteLine("Terminate");
                break;
            
            case CommandCreateWindow commandCreateWindow:
                var size = commandCreateWindow.Settings.Size;
                var title = commandCreateWindow.Settings.Title;
                var monitor = commandCreateWindow.Settings.MonitorShare;
                var share = commandCreateWindow.Settings.ContextShare;
                
                var window = Glfw.CreateWindow(size.X, size.Y, title, monitor is not null ? monitor.Handle : null, share is not null ? share.Handle : null);
                if (window == null)
                    throw new InvalidOperationException($"Failed to create window '{title}' with size {size.X}x{size.Y}. Ensure that the system supports OpenGL and that a valid window context is provided.");
                
                Glfw.MakeContextCurrent(window);
                
                Glfw.SetWindowPositionCallback(window, _windowPositionCallback);
                Glfw.SetWindowSizeCallback(window, _windowSizeCallback);
                Glfw.SetWindowCloseCallback(window, _windowCloseCallback);
                Glfw.SetWindowRefreshCallback(window, _windowRefreshCallback);
                Glfw.SetWindowFocusCallback(window, _windowFocusCallback);
                Glfw.SetWindowIconifyCallback(window, _windowIconifyCallback);
                Glfw.SetWindowMaximizeCallback(window, _windowMaximizeCallback);
                Glfw.SetFramebufferSizeCallback(window, _frameBufferSizeCallback);
                Glfw.SetWindowContentScaleCallback(window, _windowContentScaleCallback);
                Glfw.SetMouseButtonCallback(window, _mouseButtonCallback);
                Glfw.SetCursorPositionCallback(window, _cursorPositionCallback);
                Glfw.SetCursorEnterCallback(window, _cursorEnterCallback);
                Glfw.SetScrollCallback(window, _scrollCallback);
                Glfw.SetKeyCallback(window, _keyCallback);
                Glfw.SetCharCallback(window, _charCallback);
                Glfw.SetCharModsCallback(window, _charModificationCallback);
                Glfw.SetDropCallback(window, _dropCallback);
                break;
        }
    }

    public void WindowCreate()
    {
        WindowCreate(new WindowCreateSettings());
    }
    
    public void WindowCreate(WindowCreateSettings settings)
    {
        Raise(new CommandCreateWindow(settings));
    }

    private abstract record Command;
    private record CommandTerminate : Command;
    private record CommandCreateWindow(WindowCreateSettings Settings) : Command;
}