using System.Runtime.InteropServices;
using Hypercube.Graphics.Api.Glfw;
using Hypercube.Graphics.WindowManager;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Graphics.Window;

/*
public unsafe class Window : IWindow
{
    private readonly IWindowManager _windowManager;
    private readonly WindowHandle _windowHandle;

    public Window(IWindowManager windowManager, WindowHandle windowHandle)
    {
        _windowManager = windowManager;
        _windowHandle = windowHandle;
    }

    public string Title
    {
        get => Marshal.PtrToStringAnsi(GlfwNative.glfwGetWindowTitle((nint*) _windowHandle.Handle)) ?? string.Empty;
        set => _windowManager.WindowSetTitle(_windowHandle, value);
    }

    public Vector2i Position
    {
        get
        {
            int x, y;
            GlfwNative.glfwGetWindowPos((nint*)_windowHandle.Handle, &x, &y);
            return new Vector2i { X = x, Y = y };
        }
        set => _windowManager.WindowSetPosition(_windowHandle, value);
    }

    public Vector2i Size
    {
        get
        {
            int width, height;
            GlfwNative.glfwGetWindowSize((nint*)_windowHandle.Handle, &width, &height);
            return new Vector2i { X = width, Y = height };
        }
        set => _windowManager.WindowSetSize(_windowHandle, value);
    }

    public float Opacity
    {
        get => Glfw.GetWindowOpacity(_windowHandle);
        set => Glfw.SetWindowOpacity(_windowHandle, value);
    }

    public bool IsVisible
    {
        get => GlfwNative.glfwGetWindowAttrib((nint*)_windowHandle.Handle, GlfwNative.GLFW_VISIBLE) == GlfwNative.True;
        set => _windowManager.WindowSetVisible(_windowHandle, value);
    }

    public void Show()
    {
        _windowManager.WindowSetVisible(_windowHandle, true);
    }

    public void Hide()
    {
        _windowManager.WindowSetVisible(_windowHandle, false);
    }

    public void Focus()
    {
        _windowManager.WindowFocus(_windowHandle);
    }

    public void RequestAttention()
    {
        _windowManager.WindowRequestAttention(_windowHandle);
    }

    public void SwapBuffers()
    {
        _windowManager.WindowSwapBuffers(_windowHandle);
    }

    public void Close()
    {
        _windowManager.WindowDestroy(_windowHandle);
    }
}
*/