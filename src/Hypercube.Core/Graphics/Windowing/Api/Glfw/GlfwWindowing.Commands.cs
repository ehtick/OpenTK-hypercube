namespace Hypercube.Core.Graphics.Windowing.Api.Glfw;

public unsafe partial class GlfwWindowing
{   
    private void Raise(Command command)
    {
        _logger.Trace($"Handled command {command.GetType().Name} (multiThread: {_multiThread})");
        
        if (_multiThread)
        {
            _commandBridge.Raise(command);
            
            if (_waitEventsTimeout == 0)
                Graphics.Api.GlfwApi.Glfw.PostEmptyEvent();
            
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
                
                Graphics.Api.GlfwApi.Glfw.Terminate();
                
                Console.WriteLine("Terminate");
                break;
            
            case CommandWindowSetTitle commandWindowSetTitle:
                Graphics.Api.GlfwApi.Glfw.SetWindowTitle(commandWindowSetTitle.Window, commandWindowSetTitle.Title);
                break;
            
            case CommandCreateWindow commandCreateWindow:
                var size = commandCreateWindow.Settings.Size;
                var title = commandCreateWindow.Settings.Title;
                var monitor = commandCreateWindow.Settings.MonitorShare;
                var share = commandCreateWindow.Settings.ContextShare;
                
                var window = Graphics.Api.GlfwApi.Glfw.CreateWindow(size.X, size.Y, title, monitor is not null ? monitor.Handle : null, share is not null ? share.Handle : null);
                if (window == null)
                {
                    Raise(new EventWindowCreated(nint.Zero, commandCreateWindow.TaskCompletionSource));
                    throw new InvalidOperationException($"Failed to create window '{title}' with size {size.X}x{size.Y}. Ensure that the system supports OpenGL and that a valid window context is provided.");
                }
                
                Graphics.Api.GlfwApi.Glfw.MakeContextCurrent(window);
                
                Graphics.Api.GlfwApi.Glfw.SetWindowPositionCallback(window, _windowPositionCallback);
                Graphics.Api.GlfwApi.Glfw.SetWindowSizeCallback(window, _windowSizeCallback);
                Graphics.Api.GlfwApi.Glfw.SetWindowCloseCallback(window, _windowCloseCallback);
                Graphics.Api.GlfwApi.Glfw.SetWindowRefreshCallback(window, _windowRefreshCallback);
                Graphics.Api.GlfwApi.Glfw.SetWindowFocusCallback(window, _windowFocusCallback);
                Graphics.Api.GlfwApi.Glfw.SetWindowIconifyCallback(window, _windowIconifyCallback);
                Graphics.Api.GlfwApi.Glfw.SetWindowMaximizeCallback(window, _windowMaximizeCallback);
                Graphics.Api.GlfwApi.Glfw.SetFramebufferSizeCallback(window, _frameBufferSizeCallback);
                Graphics.Api.GlfwApi.Glfw.SetWindowContentScaleCallback(window, _windowContentScaleCallback);
                Graphics.Api.GlfwApi.Glfw.SetMouseButtonCallback(window, _mouseButtonCallback);
                Graphics.Api.GlfwApi.Glfw.SetCursorPositionCallback(window, _cursorPositionCallback);
                Graphics.Api.GlfwApi.Glfw.SetCursorEnterCallback(window, _cursorEnterCallback);
                Graphics.Api.GlfwApi.Glfw.SetScrollCallback(window, _scrollCallback);
                Graphics.Api.GlfwApi.Glfw.SetKeyCallback(window, _keyCallback);
                Graphics.Api.GlfwApi.Glfw.SetCharCallback(window, _charCallback);
                Graphics.Api.GlfwApi.Glfw.SetCharModsCallback(window, _charModificationCallback);
                Graphics.Api.GlfwApi.Glfw.SetDropCallback(window, _dropCallback);
                
                Raise(new EventWindowCreated((nint) window, commandCreateWindow.TaskCompletionSource));
                break;
        }
    }

    public nint WindowCreate()
    {
        return WindowCreate(new WindowCreateSettings());
    }
    
    public nint WindowCreate(WindowCreateSettings settings)
    {
        var task = WindowCreateAsync(settings);
        
        // Since we are blocking the event stream,
        // we need to process the events manually
        while (!task.IsCompleted)
        {
            // For future me, probably doesn't work due to calling in the wrong thread KEKW
            // Yes, it is
            // WaitEvents();
            
            _eventBridge.Wait();
            ProcessEvents(single: true);
        }

        return task.Result;
    }

    public Task<nint> WindowCreateAsync()
    {
        return WindowCreateAsync(new WindowCreateSettings());
    }

    public Task<nint> WindowCreateAsync(WindowCreateSettings settings)
    {
        var taskCompletionSource = new TaskCompletionSource<nint>();
        Raise(new CommandCreateWindow(settings, taskCompletionSource));

        return taskCompletionSource.Task;
    }
    
    public void WindowSetTitle(nint window, string title)
    {
        Raise(new CommandWindowSetTitle(window, title));
    }

    private abstract record Command;
    
    private record CommandTerminate : Command;
    private record CommandWindowSetTitle(nint Window, string Title) : Command;
    private record CommandCreateWindow(WindowCreateSettings Settings, TaskCompletionSource<nint>? TaskCompletionSource = null) : Command;
}
