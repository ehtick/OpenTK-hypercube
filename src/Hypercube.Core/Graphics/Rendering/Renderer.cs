using Hypercube.Core.Debugging.Logger;
using Hypercube.Core.Dependencies;
using Hypercube.Core.Graphics.Api.GlApi;
using Hypercube.Core.Graphics.Api.GlApi.Enum;
using Hypercube.Core.Graphics.Rendering.Manager;
using Hypercube.Core.Graphics.Windowing.Manager;
using Hypercube.Core.Utilities.Extensions;

namespace Hypercube.Core.Graphics.Rendering;

public class Renderer : IRenderer
{
    [Dependency] private readonly IWindowManager _windowManager = default!;
    [Dependency] private readonly IRendererManager _rendererManager = default!;
    [Dependency] private readonly ILogger _logger = default!;
    
    private const ThreadPriority ThreadPriority = System.Threading.ThreadPriority.AboveNormal;
    private const int ThreadStackSize = 8 * 1024 * 1024;
    private const string ThreadName = "Renderer thread";
    private const int ThreadReadySleepDelay = 10;
    
    private readonly ManualResetEvent _readyEvent = new(false);
    private Thread? _thread;
    
    public void Init(bool multiThread = false)
    {
        InitAsync(multiThread).Wait();
    }

    public async Task InitAsync(bool multiThread = false)
    {
        if (multiThread)
        {
            _thread = new Thread(() =>
            {
                _windowManager.Init(multiThread);
                
                while (!_windowManager.Ready)
                {
                    Thread.Sleep(ThreadReadySleepDelay);
                }
                
                var window = _windowManager.WindowCreate();
                
                _readyEvent.Set();
                
                _windowManager.WindowSetTitle(window, "...");
            
                _logger.Info(Gl.GetString(StringName.Extensions));
                _logger.Info(Gl.GetString(StringName.Vendor));
                _logger.Info(Gl.GetString(StringName.Version));
                _logger.Info(Gl.GetString(StringName.ShadingLanguageVersion));
            
                _rendererManager.Init();

                _windowManager.EnterLoop();
            }, ThreadStackSize)
            {
                IsBackground = false,
                Priority = ThreadPriority,
                Name = ThreadName
            };
            
            _thread.Start();
            await _readyEvent.AsTask();
            return;
        }
    }

    public void Update()
    {
        _windowManager.PollEvents();
    }

    public void Terminate()
    {

    }
}