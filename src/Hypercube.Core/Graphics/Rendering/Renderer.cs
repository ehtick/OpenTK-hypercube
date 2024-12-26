using Hypercube.Core.Debugging.Logger;
using Hypercube.Core.Dependencies;
using Hypercube.Core.Graphics.Patching;
using Hypercube.Core.Graphics.Rendering.Manager;
using Hypercube.Core.Graphics.Windowing;
using Hypercube.Core.Graphics.Windowing.Api.GlApi;
using Hypercube.Core.Graphics.Windowing.Api.GlApi.Enum;
using Hypercube.Core.Graphics.Windowing.Manager;
using Hypercube.Core.Utilities.Extensions;

namespace Hypercube.Core.Graphics.Rendering;

public class Renderer : IRenderer
{
    [Dependency] private readonly IWindowManager _windowManager = default!;
    [Dependency] private readonly IRendererManager _rendererManager = default!;
    [Dependency] private readonly IPatchManager _patchManager = default!;
    [Dependency] private readonly ILogger _logger = default!;
    
    private readonly ManualResetEvent _readyEvent = new(false);

    private WindowHandle? _mainWindow;
    private Thread? _thread;
    
    public void Init(bool multiThread = false)
    {
        InitAsync(multiThread).Wait();
    }

    public async Task InitAsync(bool multiThread = false)
    {
        if (!multiThread)
            throw new NotImplementedException();
        
        _thread = new Thread(OnThreadStart, Config.RenderThreadStackSize)
        {
            IsBackground = false,
            Priority = Config.RenderThreadPriority,
            Name = Config.RenderThreadName
        };
            
        _thread.Start();
        
        await _readyEvent.AsTask();
    }

    public void Update()
    {
        _windowManager.PollEvents();
    }

    public void Render()
    {
        foreach (var patch in _patchManager.Patches)
        {
            patch.Draw(this);
        }   
    }

    public void Terminate()
    {

    }

    private void OnThreadStart()
    {
        _windowManager.Init(true);
        _windowManager.WaitInit(Config.RenderThreadReadySleepDelay);
        
        _mainWindow = _windowManager.WindowCreate(new WindowCreateSettings
        {
            Title = Config.MainWindowTitle,
            // Size = Config.MainWindowSize,
            TransparentFramebuffer = Config.MainWindowTransparentFramebuffer,
            Decorated = Config.MainWindowDecorated,
            Floating = Config.MainWindowFloating
        });
        
        _rendererManager.Init();
        
        _readyEvent.Set();
        _windowManager.EnterLoop();
    }
}