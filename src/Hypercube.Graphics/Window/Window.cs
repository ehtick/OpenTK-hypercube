using System.Runtime.InteropServices;
using Hypercube.Graphics.Api.Glfw;
using Hypercube.Graphics.Api.Glfw.Enums;
using Hypercube.Graphics.WindowManager;
using Hypercube.Mathematics.Vectors;
using JetBrains.Annotations;

namespace Hypercube.Graphics.Window;

[PublicAPI]
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
        get => Marshal.PtrToStringAnsi((nint) Glfw.GetWindowTitle(_windowHandle.Pointer)) ?? string.Empty;
        set {}
    }

    public Vector2i Position
    {
        get
        {
            var x = 0;
            var y = 0;
            Glfw.GetWindowPos(_windowHandle.Pointer, &x, &y);
            return new Vector2i(x, y);
        }
        set => Glfw.SetWindowPos(_windowHandle.Pointer, value.X, value.Y);
    }

    public Vector2i Size
    {
        get
        {
            var x = 0;
            var y = 0;
            Glfw.GetWindowSize(_windowHandle.Pointer, &x, &y);
            return new Vector2i(x, y);
        }
        set => Glfw.SetWindowSize(_windowHandle.Pointer, value.X, value.Y);
    }

    public float Opacity
    {
        get => Glfw.GetWindowOpacity(_windowHandle.Pointer);
        set => Glfw.SetWindowOpacity(_windowHandle.Pointer, value);
    }

    public bool Visibility
    {
        get => Glfw.GetWindowAttrib(_windowHandle.Pointer, (int) WindowHintBool.Visible) == GlfwNative.True;
        set => Glfw.SetWindowAttrib(_windowHandle.Pointer, (int) WindowHintBool.Visible,
            value ? GlfwNative.True : GlfwNative.False);
    }

    public bool Focused
    {
        get => Glfw.GetWindowAttrib(_windowHandle.Pointer, (int) WindowHintBool.Focused) == GlfwNative.True;
        set => Glfw.SetWindowAttrib(_windowHandle.Pointer, (int) WindowHintBool.Focused,
            value ? GlfwNative.True : GlfwNative.False);
    }
    
    public bool ShouldClosed
    {
        get => Glfw.WindowShouldClose(_windowHandle.Pointer) == GlfwNative.True;
        set => Glfw.SetWindowShouldClose(_windowHandle.Pointer, value ? GlfwNative.True : GlfwNative.False);
    }

    public void Show()
    {
        Visibility = true;
    }

    public void Hide()
    {
        Visibility = false;
    }

    public void Focus()
    {
        Focused = true;
    }

    public void RequestAttention()
    {
        Glfw.RequestWindowAttention(_windowHandle.Pointer);
    }

    public void SwapBuffers()
    {
        Glfw.SwapBuffers(_windowHandle.Pointer);
    }

    public void Close()
    {
        ShouldClosed = true;
    }
}
