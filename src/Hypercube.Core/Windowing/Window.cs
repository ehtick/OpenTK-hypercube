using System.Runtime.CompilerServices;
using Hypercube.Core.Graphics;
using Hypercube.Core.Windowing.Api;
using Hypercube.Core.Windowing.Settings;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Core.Windowing;

/// <inheritdoc/>
[EngineInternal]
public sealed class Window : IWindow
{
    #region Public Events

    /// <inheritdoc/>
    public event Action<string>? OnChangedTitle;
    
    /// <inheritdoc/>
    public event Action<Vector2i>? OnChangedPosition;
    
    /// <inheritdoc/>
    public event Action<Vector2i>? OnChangedSize;

    public event Action? OnClose;

    public event Action? OnDisposed;

    #endregion
    
    private readonly WindowHandle _handle;

    #region Cached
    
    // I think it is worth explaining.
    // When the engine is running in thread mode for window processing
    // we need to send a request to get a response,
    // which in asynchronous operation
    // will mean that we need to wait for a shuffle.
    // This is either asynchronous code where we don't want it,
    // or freezing the main thread,
    // which is what I was trying to avoid
    //
    // So I just do hashing,
    // we subscribe to update the window parameters,
    // some of which I specifically call at the point of creation.
    // Yes, in fact we do not update immediately,
    // but we avoid synchronization problems.
    // There are no such problems at all,
    // when stream processing is turned off.
    //
    // (And yes, we can't use _glfw.GetWindowSize since technically GLFW is in a different thread)
    
    private string _cachedTitle;
    private Vector2i _cachedSize;
    private Vector2i _cachedPosition;
    
    #endregion

    private bool _disposed;
    private bool _destroyed;

    /// <inheritdoc/>
    public IWindowingApi Api { get; }
    
    /// <inheritdoc/>
    public WindowHandle Handle => _destroyed ? throw new InvalidOperationException() : _handle;

    /// <inheritdoc/>
    public WindowHandle Context => Api.Context;

    /// <inheritdoc/>
    public WindowingApi Type => Api.Type;

    /// <inheritdoc/>
    public string Title
    {
        get => _cachedTitle;
        set => Api.WindowSetTitle(Handle, value);
    }

    /// <inheritdoc/>
    public Vector2i Position
    {
        get => _cachedPosition;
        set => Api.WindowSetPosition(Handle, value);
    }

    /// <inheritdoc/>
    public Vector2i Size
    {
        get => _cachedSize;
        set => Api.WindowSetSize(Handle, value);
    }

    public bool IsMain { get; set; }
    
    public Window(IWindowingApi api, WindowHandle handle, WindowCreateSettings settings)
    {
        Api = api;
        
        _handle = handle;

        _cachedTitle = settings.Title;
        _cachedSize = settings.Size;

        Api.OnWindowTitle += OnApiTitle;
        Api.OnWindowPosition += OnApiPosition;
        Api.OnWindowSize += OnApiSize;
        Api.OnWindowClose += OnApiClose;
    }

    ~Window()
    {
        Dispose(false);
    }

    /// <inheritdoc/>
    public void MakeCurrent()
    {
        Api.Context = Handle;
    }

    /// <inheritdoc/>
    public void SwapBuffers()
    {
        Api.WindowSwapBuffers(Handle);
    }

    /// <inheritdoc/>
    public nint GetProcAddress(string name)
    {
        return Api.GetProcAddress(name);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        if (disposing)
        {
            // Managed
            Api.OnWindowTitle -= OnApiTitle;
            Api.OnWindowPosition -= OnApiPosition;
            Api.OnWindowSize -= OnApiSize;
        }
        
        // Unmanaged
        Destroy();
        
        OnDisposed?.Invoke();
        _disposed = true;
    }

    public bool Equals(IWindow? other)
    {
        return other is not null && Handle == other.Handle;
    }

    public override bool Equals(object? obj)
    {
        return obj is Window window && Equals(window);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Handle);
    }

    public override string ToString()
    {
        return $"{Handle} ({Enum.GetName(Type)})";
    }

    private void OnApiTitle(WindowHandle window, string title)
    {
        if (window != Handle)
            return;

        _cachedTitle = title;
        OnChangedTitle?.Invoke(title);
    }

    private void OnApiPosition(WindowHandle window, Vector2i position)
    {
        if (window != Handle)
            return;

        _cachedPosition = position;
        OnChangedPosition?.Invoke(position);
    }

    private void OnApiSize(WindowHandle window, Vector2i size)
    {
       if (window != Handle)
           return;

       _cachedSize = size;
       OnChangedSize?.Invoke(size);
    }

    private void OnApiClose(WindowHandle window)
    {
        if (window != Handle)
            return;
        
        OnClose?.Invoke();
    }

    private void Destroy()
    {
        Api.WindowDestroy(Handle);
        _destroyed = true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(Window left, Window right)
    {
        return left.Equals(right);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Window left, Window right)
    {
        return !left.Equals(right);
    }
}
