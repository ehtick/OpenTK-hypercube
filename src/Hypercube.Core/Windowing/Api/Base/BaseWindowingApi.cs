using System.Threading.Channels;
using Hypercube.Core.Graphics;
using Hypercube.Core.Windowing.Api.Exceptions;
using Hypercube.Core.Windowing.Settings;
using Hypercube.Mathematics.Vectors;
using Hypercube.Utilities.Extensions;
using Hypercube.Utilities.Threads;

namespace Hypercube.Core.Windowing.Api.Base;

public abstract partial class BaseWindowingApi : IWindowingApi
{
    public abstract WindowingApi Type { get; }
    
    #region Events
    
    public event InitHandler? OnInit;
    public event ErrorHandler? OnError;
    
    public event MonitorHandler? OnMonitor;
    public event JoystickHandler? OnJoystick;
    
    public event WindowCloseHandler? OnWindowClose;
    public event WindowTitleHandler? OnWindowTitle;
    public event WindowPositionHandler? OnWindowPosition;
    public event WindowSizeHandler? OnWindowSize;
    public event WindowFocusHandler? OnWindowFocus;
    public event WindowKey? OnWindowKey;
    public event WindowScroll? OnWindowScroll;
    public event WindowMouseButton? OnWindowMouseButton;
    public event WindowChar? OnWindowChar;
    
    #endregion

    #region Thread

    private readonly ThreadBridge<IEvent>? _eventBridge;
    private readonly ThreadBridge<ICommand> _commandBridge;
    
    protected Thread? Thread { get; private set; }
    
    #endregion

    private readonly float _waitEventsTimeout;
    private bool _running;
    
    public bool Initialized { get; private set; }
    public bool Terminated { get; private set; }

    public readonly List<WindowHandle> Windows = [];
    public WindowHandle? MainWindow { get; protected set; }

    public WindowHandle Context
    {
        get => InternalGetCurrentContext();
        set => InternalMakeContextCurrent(value);
    }

    protected BaseWindowingApi(WindowingApiSettings settings)
    {
        _waitEventsTimeout = settings.WaitEventsTimeout;
        
        _eventBridge = new ThreadBridge<IEvent>(new BoundedChannelOptions(settings.EventBridgeBufferSize)
        {
            FullMode = BoundedChannelFullMode.Wait,
            SingleReader = true,
            SingleWriter = true,
            AllowSynchronousContinuations = true
        });
        
        _commandBridge = new ThreadBridge<ICommand>(new UnboundedChannelOptions
        {
            SingleReader = true,
            SingleWriter = false
        });
    }

    public void Init()
    {
        if (!InternalInit())
            throw new WindowingApiInitializationException();
        
        Thread = Thread.CurrentThread;
        Initialized = true;
        
        OnInit?.Invoke(Info);
    }

    public void EnterLoop()
    {
        _running = true;
        
        while (_running)
        {
            WaitEvents();
            ProcessCommands();
        }
    }
    
    public void PollEvents()
    {
        if (Thread.CurrentThread == Thread)
        {
            InternalPollEvents();
            return;
        }

        ProcessEvents();
    }
    
    public void Terminate()
    {
        if (!Initialized)
            throw new WindowingApiNotInitializedException();

        if (!Terminated)
            throw new Exception();
        
        // By doing this, we will effectively cause:
        // Stop();
        // InternalTerminate();
        
        // But we don't do it here, because of multithreading,
        // we need to kill the API in
        // the thread where it was initialized
        Execute(new CommandTerminate());
        
        // After sending the command to terminate,
        // we can no longer send any commands,
        // so we close the bridge
        _commandBridge.CompleteWrite();
        
        // Prohibition of repeated termination
        Terminated = true;
    }

    public void WindowSetTitle(WindowHandle window, string title)
    {
        Execute(new CommandWindowSetTitle(window, title, Thread.CurrentThread));
    }

    public void WindowSetPosition(WindowHandle window, Vector2i position)
    {
        Execute(new CommandWindowSetPosition(window, position));
    }

    public void WindowSetSize(WindowHandle window, Vector2i size)
    {
        Execute(new CommandWindowSetSize(window, size));
    }

    public WindowHandle WindowCreateSync(WindowCreateSettings settings)
    {
        var tempContext = Context;
        
        try
        {
            var tcs = new TaskCompletionSource<nint>();
            var command = new CommandWindowCreateSync(settings, tcs, Thread.CurrentThread);
        
            Execute(command);
            var window = new WindowHandle(WaitCommand(tcs));

            Windows.Add(window);
            
            Context = window;
            SwapInterval(settings.VSync.ToInt());

            return window;
        }
        finally
        {
            Context = tempContext;
        }
    }

    public WindowHandle WindowCreateMainSync(WindowCreateSettings settings)
    {
        if (MainWindow is not null)
            throw new Exception();
        
        MainWindow = WindowCreateSync(settings);
        return MainWindow.Value;
    }

    public void WindowDestroy(WindowHandle window)
    {
        Windows.Remove(window);
        InternalWindowDestroy(window);
    }

    public void WindowSwapBuffers(WindowHandle window)
    {
        InternalSwapBuffers(window);
    }

    public void Dispose()
    {
        InternalTerminate();
        GC.SuppressFinalize(this);
    }

    public abstract void SwapInterval(int interval);

    public abstract nint GetProcAddress(string name);

    private void Stop()
    {
        if (_eventBridge is null)
            throw new WindowingApiNotInitializedException();
        
        _running = false;
        _eventBridge.CompleteWrite();
    }

    private void WaitEvents()
    {
        if (_waitEventsTimeout == 0)
        { 
            InternalWaitEvents();
            return;
        }

        InternalWaitEventsTimeout(_waitEventsTimeout);
    }

    [PublicAPI]
    private void WaitCommand(TaskCompletionSource tsc)
    {
        if (_eventBridge is null)
            throw new WindowingApiNotInitializedException();
        
        while (!tsc.Task.IsCompleted)
        {
            _eventBridge.Wait();
            ProcessEvents(single: true);
        }
    }

    private TResult WaitCommand<TResult>(TaskCompletionSource<TResult> tsc)
    {
        if (_eventBridge is null)
            throw new WindowingApiNotInitializedException();
        
        while (!tsc.Task.IsCompleted)
        {
            _eventBridge.Wait();
            ProcessEvents(single: true);
        }

        return tsc.Task.Result;
    }
}