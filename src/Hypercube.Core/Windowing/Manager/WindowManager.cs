using Hypercube.Core.Graphics;
using Hypercube.Core.Windowing.Api;
using Hypercube.Core.Windowing.Manager.Exceptions;
using Hypercube.Core.Windowing.Settings;
using Hypercube.Mathematics.Vectors;
using Hypercube.Utilities.Debugging.Logger;
using Hypercube.Utilities.Dependencies;

namespace Hypercube.Core.Windowing.Manager;

[EngineInternal, UsedImplicitly]
public class WindowManager : IWindowManager
{
    [Dependency] private readonly ILogger _logger = default!;
    
    /// <inheritdoc/>
    public event Action<Vector2i>? OnMainWindowResized;
    
    /// <inheritdoc/>
    public event Action<IWindow>? OnWindowCreated;
    
    private readonly Dictionary<WindowHandle, IWindow> _windows = [];
    private IWindowingApi? _api;

    /// <inheritdoc/>
    public bool Initialized => Api.Initialized;
    
    /// <inheritdoc/>
    public IReadOnlyList<IWindow> Windows => _windows.Values.ToList();

    /// <inheritdoc/>
    public IWindow? MainWindow => Api.MainWindow is null ? null : _windows.TryGetValue(Api.MainWindow.Value, out var window) ? window : null;

    /// <inheritdoc/>
    public IWindowingApi Api => _api ?? throw new WindowingNotInitializedException();

    /// <inheritdoc/>
    public void Init(WindowingApiSettings settings)
    {
        _api = ApiFactory.Get(settings.Api, settings);
        
        _api.OnInit += OnInit; 
        _api.OnError += OnError;
        _api.OnWindowSize += (_, size) =>
        {
            OnMainWindowResized?.Invoke(size);
        };

        _api.Init();
    }

    /// <inheritdoc/>
    public void WaitInit(int sleepDelay)
    {
        while (!Initialized)
        {
            Thread.Sleep(sleepDelay);
        }
    }

    /// <inheritdoc/>
    public void Shutdown()
    {
        Api.Terminate();
    }

    /// <inheritdoc/>
    public void EnterLoop()
    {
        Api.EnterLoop();
    }

    /// <inheritdoc/>
    public void PollEvents()
    {
        Api.PollEvents();
    }

    /// <inheritdoc/>
    public IWindow Create(WindowCreateSettings settings)
    {
        var window = new Window(Api, Api.WindowCreateSync(settings), settings);

        window.OnDisposed += () =>
        {
            _windows.Remove(window.Handle);
        };
        
        _windows.Add(window.Handle, window);
        OnWindowCreated?.Invoke(window);
        
        return window;
    }
    
    /// <inheritdoc/>
    public void Dispose()
    {
        _api?.Dispose();
        GC.SuppressFinalize(this);
    }

    private void OnInit(string info)
    {
        _logger.Info($"Windowing Api ({Enum.GetName(Api.Type)}) info:\n{info}");
    }

    private void OnError(string description)
    {
        _logger.Critical(description);
    }
}