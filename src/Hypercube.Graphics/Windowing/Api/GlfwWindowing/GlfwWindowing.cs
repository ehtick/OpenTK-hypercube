using System.Threading.Channels;
using Hypercube.Graphics.Windowing.Api.Exceptions;
using Hypercube.GraphicsApi.GlfwApi;
using Hypercube.Utilities.Threads;
using JetBrains.Annotations;

namespace Hypercube.Graphics.Windowing.Api.GlfwWindowing;

[PublicAPI]
public unsafe partial class GlfwWindowing : IWindowingApi
{
    private const int EventBridgeBufferSize = 32;

    private ThreadBridge<ICommand> _commandBridge = default!;
    private ThreadBridge<IEvent> _eventBridge = default!;

    private Thread? _thread;
    private bool _multiThread;
    private bool _running;
    private float _waitEventsTimeout;

    public bool Ready => _thread is not null;

    public void Init(bool multiThread = false)
    {
        _multiThread = multiThread;
        
        // Init channels
        _commandBridge = new ThreadBridge<ICommand>(new UnboundedChannelOptions
        {
            SingleReader = true,
            SingleWriter = false
        });
        
        _eventBridge = new ThreadBridge<IEvent>(new BoundedChannelOptions(EventBridgeBufferSize)
        {
            FullMode = BoundedChannelFullMode.Wait,
            SingleReader = true,
            SingleWriter = true,
            AllowSynchronousContinuations = true
        });
        
        InitCallbacks();

        Glfw.SetErrorCallback(_errorCallback);
    
        if (!Glfw.Init())
        {
            var errorCode = Glfw.GetError(out var description);
            throw new WindowManagerInitException($"Failed to init Glfw ({errorCode}) {description}");
        }
        
        _thread = Thread.CurrentThread;
        
        Glfw.SetMonitorCallback(_monitorCallback);
        Glfw.SetJoystickCallback(_joystickCallback);
    }

    public void Terminate()
    {
        TerminateLoop();
        
        _thread = null;
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

    public void TerminateLoop()
    {
        Raise(new CommandTerminate());
        
        // That's last command whose need send 
        _commandBridge.CompleteWrite();
    }

    public void PollEvents()
    {
        if (_multiThread)
        {
            ProcessEvents();
            return;
        }
        
        Glfw.PollEvents();
    }

    private void WaitEvents()
    {
        if (_waitEventsTimeout == 0)
        {
            Glfw.WaitEvents();
            return;
        }

        Glfw.WaitEventsTimeout(_waitEventsTimeout);
    }

    public void Dispose()
    {
        // TODO release managed resources here
    }
}

