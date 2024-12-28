using Hypercube.Core.Debugging.Logger;
using Hypercube.Core.Dependencies;
using Hypercube.Graphics;
using Hypercube.Graphics.Windowing;
using Hypercube.Graphics.Windowing.Api;

namespace Hypercube.Core.Graphics.Windowing.Manager;

public class WindowManager : IWindowManager
{
    [Dependency] private readonly DependenciesContainer _container = default!;
    [Dependency] private readonly ILogger _logger = default!;
    
    private IWindowingApi _windowApi = default!;

    public bool Ready => _windowApi.Ready;

    public void Init(bool multiThread = false)
    {
        _windowApi = ApiFactory.CreateApi(Config.Windowing);
        _container.Inject(_windowApi);
        _windowApi.Init(multiThread);
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
    
    public WindowHandle WindowCreate()
    {
        return new WindowHandle(_windowApi.WindowCreate());
    }
    
    public WindowHandle WindowCreate(WindowCreateSettings settings)
    {
        return new WindowHandle(_windowApi.WindowCreate(settings));
    }

    public async Task<WindowHandle> WindowCreateAsync()
    {
        var pointer = await _windowApi.WindowCreateAsync();
        return new WindowHandle(pointer);
    }

    public void WindowSetTitle(WindowHandle window, string title)
    {
        _windowApi.WindowSetTitle((nint) window, title);
    }

    public void Terminate()
    {
        _windowApi.Terminate();
    }

    public void PollEvents()
    {
        _windowApi.PollEvents();
    }
}