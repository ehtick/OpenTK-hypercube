using Hypercube.Graphics;
using Hypercube.Graphics.Windowing.Api;
using Hypercube.Graphics.Windowing.Settings;
using Hypercube.Utilities.Debugging.Logger;
using Hypercube.Utilities.Dependencies;

namespace Hypercube.Core.Graphics.Windowing.Manager;

public class WindowManager : IWindowManager
{
    [Dependency] private readonly ILogger _logger = default!;
    
    private IWindowingApi _windowApi = default!;

    public bool Ready => _windowApi.Ready;

    public void Init(bool multiThread = false)
    {
        _windowApi = Api.Get(Config.Windowing);
        _windowApi.Init(new WindowingApiSettings
        {
            MultiThread = multiThread
        });

        _windowApi.OnError += OnError;
    }

    public void Terminate()
    {
        _windowApi.Terminate();
    }

    public void WaitInit(int sleepDelay)
    {
        while (!Ready)
        {
            Thread.Sleep(sleepDelay);
        }
    }

    public void EnterLoop()
    {
        _windowApi.EnterLoop();
    }

    public void PollEvents()
    {
        _windowApi.PollEvents();
    }

    public void Create(WindowCreateSettings settings)
    {
        _windowApi.WindowCreateSync(settings);
    }

    private void OnError(string description)
    {
        _logger.Critical(description);
    }

    public IntPtr GetProcAddress(string procName)
    {
        throw new NotImplementedException();
    }
}