using System.Threading.Channels;
using Hypercube.Core.Graphics;
using Hypercube.Core.Windowing.Api.Exceptions;
using Hypercube.Core.Windowing.Settings;
using Hypercube.Mathematics.Vectors;
using Hypercube.Utilities.Extensions;
using Hypercube.Utilities.Threads;

namespace Hypercube.Core.Windowing.Api.Base;

public abstract partial class BaseWindowingApi : IWindowingApi, IWindowingApiInternal
{
    public abstract WindowingApi Type { get; }
    
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
    
    private ThreadBridge<ICommand>? _commandBridge;
    private ThreadBridge<IEvent>? _eventBridge;

    private bool _running;
    
    private float _waitEventsTimeout;

    public bool Ready => Thread is not null;

    protected Thread? Thread { get; private set; }

    public nint ContextCurrent
    {
        get => InternalGetCurrentContext();
        set => InternalMakeContextCurrent(value);
    }

    public void Init(WindowingApiSettings settings)
    {
        _waitEventsTimeout = settings.WaitEventsTimeout;
        
        _commandBridge = new ThreadBridge<ICommand>(new UnboundedChannelOptions
        {
            SingleReader = true,
            SingleWriter = false
        });
        
        _eventBridge = new ThreadBridge<IEvent>(new BoundedChannelOptions(settings.EventBridgeBufferSize)
        {
            FullMode = BoundedChannelFullMode.Wait,
            SingleReader = true,
            SingleWriter = true,
            AllowSynchronousContinuations = true
        });
        
        if (!InternalInit())
            throw new Exception();
        
        Thread = Thread.CurrentThread;
        
        OnInit?.Invoke(InternalInfo);
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
        if (_commandBridge is null)
            throw new WindowingApiNotInitializedException();
        
        Execute(new CommandTerminate());
        
        // That's last command whose need send 
        _commandBridge.CompleteWrite();
        Thread = null;
    }

    public void SwapInterval(int value)
    {
        InternalSwapInterval(value);
    }
    
    public void WindowSetTitle(nint window, string title)
    {
        Execute(new CommandWindowSetTitle(window, title, Thread.CurrentThread));
    }
    
    public void WindowSetPosition(nint window, Vector2i position)
    {
        Execute(new CommandWindowSetPosition(window, position));
    }
    
    public void WindowSetSize(nint window, Vector2i size)
    {
        Execute(new CommandWindowSetSize(window, size));
    }

    public void WindowCreate(WindowCreateSettings settings)
    {
        Execute(new CommandWindowCreate(settings));
    }

    public nint WindowCreateSync(WindowCreateSettings settings)
    {
        var tempContext = ContextCurrent;
        
        try
        {
            var tcs = new TaskCompletionSource<nint>();
            var command = new CommandWindowCreateSync(settings, tcs, Thread.CurrentThread);
        
            Execute(command);
            var context =  WaitCommand(tcs);

            ContextCurrent = context;
            SwapInterval(settings.VSync.ToInt());

            return context;
        }
        finally
        {
            ContextCurrent = tempContext;
        }
    }

    public void WindowDestroy(nint window)
    {
        InternalWindowDestroy(window);
    }

    public void WindowSwapBuffers(nint window)
    {
        InternalSwapBuffers(window);
    }
    
    public nint GetProcAddress(string name)
    {
        return InternalGetProcAddress(name);
    }

    public void Dispose()
    {
        InternalTerminate();
        GC.SuppressFinalize(this);
    }

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