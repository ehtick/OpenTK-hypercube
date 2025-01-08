using Hypercube.Core.Graphics.Patching;
using Hypercube.Core.Graphics.Rendering.Manager;
using Hypercube.Core.Graphics.Windowing.Manager;
using Hypercube.Graphics;
using Hypercube.Graphics.Windowing;
using Hypercube.Graphics.Windowing.Settings;
using Hypercube.Utilities.Debugging.Logger;
using Hypercube.Utilities.Dependencies;
using Hypercube.Utilities.Extensions;

namespace Hypercube.Core.Graphics.Rendering;

public partial class Renderer : IRenderer
{
    [Dependency] private readonly IWindowManager _windowManager = default!;
    [Dependency] private readonly IPatchManager _patchManager = default!;
    
    private readonly ManualResetEvent _readyEvent = new(false);
    
    private Thread? _thread;
    
    public void Init(bool multiThread = false)
    {
        InitAsync(multiThread).Wait();
    }

    public void CreateMainWindow()
    {
        _windowManager.Create(new WindowCreateSettings
        {
            Api = new ApiSettings
            {
                Api = ContextApi.OpenGl,
                Flags = ContextFlags.Debug,
                Profile = ContextProfile.Core,
                Version = new Version(4, 6)
            },
            Title = Config.MainWindowTitle,
            Resizable = Config.MainWindowResizable,
            Visible = Config.MainWindowVisible,
            Decorated = Config.MainWindowDecorated,
            TransparentFramebuffer = Config.MainWindowTransparentFramebuffer,
            Floating = Config.MainWindowFloating
        });
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
        
        _readyEvent.Set();
        
        _windowManager.EnterLoop();
    }
}