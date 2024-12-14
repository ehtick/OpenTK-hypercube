using System.Threading.Channels;
using Hypercube.Core.Debugging.Logger;
using Hypercube.Core.Dependencies;
using Hypercube.Core.Utilities.Threads;
using JetBrains.Annotations;

namespace Hypercube.Core.Graphics.Windowing.Api.Glfw;

[PublicAPI]
public unsafe partial class GlfwWindowing : IWindowingApi
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

        Graphics.Api.GlfwApi.Glfw.SetErrorCallback(_errorCallback);
    
        if (!Graphics.Api.GlfwApi.Glfw.Init())
        {
            var errorCode = Graphics.Api.GlfwApi.Glfw.GetError(out var description);
            throw new Exceptions.WindowManagerInitException($"Failed to init Glfw ({errorCode}) {description}");
        }
        
        _thread = Thread.CurrentThread;
        
        Graphics.Api.GlfwApi.Glfw.SetMonitorCallback(_monitorCallback);
        Graphics.Api.GlfwApi.Glfw.SetJoystickCallback(_joystickCallback);

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
        
        Graphics.Api.GlfwApi.Glfw.PollEvents();
    }

    private void WaitEvents()
    {
        if (_waitEventsTimeout == 0)
        {
            Graphics.Api.GlfwApi.Glfw.WaitEvents();
            return;
        }

        Graphics.Api.GlfwApi.Glfw.WaitEventsTimeout(_waitEventsTimeout);
    }

    public void Dispose()
    {
        // TODO release managed resources here
    }
}

