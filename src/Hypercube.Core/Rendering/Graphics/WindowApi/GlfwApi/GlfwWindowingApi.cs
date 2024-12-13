using System.Threading.Channels;
using Hypercube.Core.Debugging.Logger;
using Hypercube.Core.Dependencies;
using Hypercube.Core.Rendering.Graphics.Api.GlfwApi;
using Hypercube.Core.Utilities.Threads;
using JetBrains.Annotations;

namespace Hypercube.Core.Rendering.Graphics.WindowApi.GlfwApi;

[PublicAPI]
public unsafe partial class GlfwWindowingApi : IWindowingApi
{
    private const int EventBridgeBufferSize = 32;

    [Dependency] private readonly ILogger _logger = default!;
    
    private ThreadBridge<Command> _commandBridge = default!;
    private ThreadBridge<Event> _eventBridge = default!;

    private Thread? _thread;
    private bool _multiThread;
    private bool _running;
    private float _waitEventsTimeout;

    public bool Ready => _thread is not null;

    public void Init(bool multiThread = false)
    {
        _multiThread = multiThread;
        
        // Init channels
        _commandBridge = new ThreadBridge<Command>(new UnboundedChannelOptions
        {
            SingleReader = true,
            SingleWriter = false
        });
        
        _eventBridge = new ThreadBridge<Event>(new BoundedChannelOptions(EventBridgeBufferSize)
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
            throw new Exceptions.WindowManagerInitException($"Failed to init Glfw ({errorCode}) {description}");
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
        _logger.Debug("Started event loop, suspend window thread");
        
        _running = true;
        while (_running)
        {
            WaitEvents();
            
            foreach (var command in _commandBridge.Process())
            {
                _logger.Trace($"Process command {command.GetType().Name}");
                Process(command);
            }
        }
        
        _logger.Debug("Shutdown event loop, unsuspend window thread");
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

