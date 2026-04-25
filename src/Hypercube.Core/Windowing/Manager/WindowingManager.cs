using System.Text;
using Hypercube.Core.Graphics;
using Hypercube.Core.Windowing.Api;
using Hypercube.Core.Windowing.Manager.Exceptions;
using Hypercube.Core.Windowing.Monitors;
using Hypercube.Core.Windowing.Windows;
using Hypercube.Mathematics.Vectors;
using Hypercube.Utilities.Debugging.Logger;
using Hypercube.Utilities.Dependencies;

using Monitor = Hypercube.Core.Windowing.Monitors.Monitor;

namespace Hypercube.Core.Windowing.Manager;

[EngineInternal, UsedImplicitly]
public class WindowingManager : IWindowingManager
{
    [Dependency] private readonly ILogger _logger = null!;
    
    /// <inheritdoc/>
    public event Action<Vector2i>? OnMainWindowResized;
    
    /// <inheritdoc/>
    public event Action<IWindow>? OnWindowCreated;
    
    private readonly Dictionary<WindowHandle, IWindow> _windows = [];
    private readonly Dictionary<MonitorHandle, IMonitor> _monitors = [];
    
    private IWindowingApi? _api;

    /// <inheritdoc/>
    public bool Initialized => Api.Initialized;
    
    /// <inheritdoc/>
    public IReadOnlyList<IWindow> Windows => _windows.Values.ToList();
    public IReadOnlyList<IMonitor> Monitors => _monitors.Values.ToList();

    /// <inheritdoc/>
    public IWindow MainWindow => Api.MainWindow is null
        ? null!
        : _windows.TryGetValue(Api.MainWindow.Value, out var window)
            ? window
            : null!;

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
        var handle = Api.WindowCreateSync(settings);
        var window = new Window(Api, handle, settings);

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

    private void OnInit(InitInfo info)
    {
        foreach (var monitor in info.Monitors)
            ProcessMonitor(monitor);

        var builder = new StringBuilder();
        builder.AppendLine($"Windowing Api ({Enum.GetName(Api.Type)}) info:");
        builder.AppendLine(info.Message);
        builder.AppendLine();
        
        builder.AppendLine("Monitors:");
        
        foreach (var (_, monitor) in _monitors)
            builder.AppendLine(monitor.ToString());
        
        _logger.Info(builder.ToString());
    }

    private void OnError(string description)
    {
        _logger.Error($"[{Enum.GetName(Api.Type)}] {description}");
    }

    private IMonitor ProcessMonitor(MonitorInstance instance)
    {
        var monitor = new Monitor(Api, instance.Handle, instance.Settings);
        _monitors.Add(monitor.Handle, monitor);
        return monitor;
    }
}