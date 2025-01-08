using System.Threading.Channels;
using Hypercube.Graphics.Windowing.Api.Exceptions;
using Hypercube.Graphics.Windowing.Settings;
using Hypercube.Mathematics.Vectors;
using Hypercube.Utilities.Threads;

namespace Hypercube.Graphics.Windowing.Api;

public abstract unsafe partial class WindowingApi : IWindowingApi, IWindowingApiInternal
{
    public event ErrorHandler? OnError;
    
    private ThreadBridge<ICommand>? _commandBridge;
    private ThreadBridge<IEvent>? _eventBridge;

    private Thread? _thread;
    private bool _running;

    private bool _multiThread;
    private float _waitEventsTimeout;

    public bool Ready => _thread is not null;

    public void Init(WindowingApiSettings settings)
    {
        _multiThread = settings.MultiThread;
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
        
        _thread = Thread.CurrentThread;
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
        if (_multiThread)
        {
            ProcessEvents();
            return;
        }
        
        InternalPollEvents();
    }
    
    public void Terminate()
    {
        if (_commandBridge is null)
            throw new WindowingApiNotInitializedException();
        
        Execute(new CommandTerminate());
        
        // That's last command whose need send 
        _commandBridge.CompleteWrite();
        _thread = null;
    }

    public void WindowSetTitle(nint window, string title)
    {
        Execute(new CommandWindowSetTitle(window, title));
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
        // Calling this function in the current thread will freeze it,
        // which will not allow the command to be processed
        // and the application will hang
        if (Thread.CurrentThread == _thread)
            throw new WindowingApiInvalidThreadException(nameof(WindowCreateSync));

        var tcs = new TaskCompletionSource<nint>();
        var command = new CommandWindowCreateSync(settings, tcs);
        
        Execute(command);
        
        return WaitCommand(tcs);
    }

    public nint GetProcAddress(string name)
    {
        return InternalGetProcAddress(name);
    }

    public void Dispose()
    {
        // TODO release managed resources here
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