using Hypercube.Graphics.Windowing.Api;
using Hypercube.Graphics.Windowing.Settings;
using Hypercube.Utilities.Debugging.Logger;
using Hypercube.Utilities.Dependencies;

namespace Hypercube.Graphics.Windowing.Manager;

public class WindowManager : IWindowManager
{
    [Dependency] private readonly ILogger _logger = default!;
    
    private IWindowingApi _windowApi = default!;

    public bool Ready => _windowApi.Ready;

    public void Init(WindowingApiSettings settings)
    {
        _windowApi = Graphics.ApiFactory.Get(settings.Api);
        _windowApi.Init(settings);
        
        _windowApi.OnError += OnError;
        _windowApi.OnWindowPosition += (window, position) =>
        {
            _windowApi.WindowSetTitle(window, $"{window} - {position}");
        };
    }

    public void WaitInit(int sleepDelay)
    {
        while (!Ready)
        {
            Thread.Sleep(sleepDelay);
        }
    }

    public void Shutdown()
    {
        _windowApi.Terminate();
    }

    public void EnterLoop()
    {
        _windowApi.EnterLoop();
    }

    public void PollEvents()
    {
        _windowApi.PollEvents();
    }

    public IWindow Create(WindowCreateSettings settings)
    {
        var handle = _windowApi.WindowCreateSync(settings);
        var window = new Window(_windowApi, handle);

        return window;
    }

    private void OnError(string description)
    {
        _logger.Critical(description);
    }
}