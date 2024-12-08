using System.Runtime.InteropServices;
using Hypercube.Core.Rendering.Graphics.Api.GlfwApi;
using Hypercube.Core.Rendering.Graphics.Api.GlfwApi.Enums;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Core.Rendering.Graphics.WindowApi.GlfwApi;

public unsafe partial class GlfwWindowingApi
{
    private GlfwCallbacks.GLProcess _glProcessCallback = default!;
    private GlfwCallbacks.VKProcess _vkProcessCallback = default!;
    private GlfwCallbacks.Allocate _allocateCallback = default!;
    private GlfwCallbacks.Reallocate _reallocateCallback = default!;
    private GlfwCallbacks.Deallocate _deallocateCallback = default!;
    private GlfwCallbacks.Error _errorCallback = default!;
    private GlfwCallbacks.WindowPosition _windowPositionCallback = default!;
    private GlfwCallbacks.WindowSize _windowSizeCallback = default!;
    private GlfwCallbacks.WindowClose _windowCloseCallback = default!;
    private GlfwCallbacks.WindowRefresh _windowRefreshCallback = default!;
    private GlfwCallbacks.WindowFocus _windowFocusCallback = default!;
    private GlfwCallbacks.WindowIconify _windowIconifyCallback = default!;
    private GlfwCallbacks.WindowMaximize _windowMaximizeCallback = default!;
    private GlfwCallbacks.FrameBufferSize _frameBufferSizeCallback = default!;
    private GlfwCallbacks.WindowContentScale _windowContentScaleCallback = default!;
    private GlfwCallbacks.MouseButton _mouseButtonCallback = default!;
    private GlfwCallbacks.CursorPosition _cursorPositionCallback = default!;
    private GlfwCallbacks.CursorEnter _cursorEnterCallback = default!;
    private GlfwCallbacks.Scroll _scrollCallback = default!;
    private GlfwCallbacks.Key _keyCallback = default!;
    private GlfwCallbacks.Char _charCallback = default!;
    private GlfwCallbacks.CharModification _charModificationCallback = default!;
    private GlfwCallbacks.Drop _dropCallback = default!;
    private GlfwCallbacks.Monitor _monitorCallback = default!;
    private GlfwCallbacks.Joystick _joystickCallback = default!;

    private void InitCallbacks()
    {
        _glProcessCallback = OnGlProcess;
        _vkProcessCallback = OnVkProcess;
        
        _allocateCallback = OnAllocate;
        _reallocateCallback = OnReallocate;
        _deallocateCallback = OnDeallocate;

        _errorCallback = OnError;
        
        _windowPositionCallback = OnWindowPosition;
        _windowSizeCallback = OnWindowSize;
        _windowCloseCallback = OnWindowClose;
        _windowRefreshCallback = OnWindowRefresh;
        _windowFocusCallback = OnWindowFocus;
        _windowIconifyCallback = OnWindowIconify;
        _windowMaximizeCallback = OnWindowMaximize;
        _frameBufferSizeCallback = OnFrameBufferSize;
        _windowContentScaleCallback = OnWindowContentScale;
        _mouseButtonCallback = OnMouseButton;
        _cursorPositionCallback = OnCursorPosition;
        _cursorEnterCallback = OnCursorEnter;
        _scrollCallback = OnScroll;
        _keyCallback = OnKey;
        _charCallback = OnChar;
        _charModificationCallback = OnCharModification;
        _dropCallback = OnDrop;
        _monitorCallback = OnMonitor;
        _joystickCallback = OnJoystick;
    }

    private void OnJoystick(int jid, int @event)
    {

    }

    private void OnDrop(IntPtr* window, int pathcount, byte*[] paths)
    {

    }

    private void OnCharModification(IntPtr* window, uint codepoint, int mods)
    {

    }

    private void OnFrameBufferSize(IntPtr* window, int width, int height)
    {

    }

    private void OnWindowMaximize(IntPtr* window, int maximized)
    {

    }

    private void OnWindowRefresh(IntPtr* window)
    {

    }

    private void OnGlProcess()
    {

    }
    
    private void OnVkProcess()
    {

    }

    private void* OnAllocate(nuint size, void* user)
    {
        return (void*) Marshal.AllocHGlobal((int) size);
    }
    
    private void* OnReallocate(void* block, nuint size, void* user)
    {
        return (void*) Marshal.ReAllocHGlobal((nint) block, (nint) size);
    }

    private void OnDeallocate(void* block, void* user)
    {

    }

    private void OnError(int errorCode, byte* description)
    {
        var desc = Marshal.PtrToStringUTF8((nint)description) ?? "";
        _logger.Warning($"Glfw error ({errorCode}) {desc}");
    }

    private void OnMonitor(nint* monitor, int @event)
    {

    }

    private void OnChar(nint* window, uint codepoint)
    {
        Raise(new EventChar((nint) window, codepoint));
    }

    private void OnCursorPosition(nint* window, double xPosition, double yPosition)
    {
        Raise(new EventCursorPosition((nint) window, new Vector2d(xPosition, yPosition)));
    }

    private void OnCursorEnter(nint* window, int entered)
    {
        Raise(new EventCursorEnter((nint) window, entered == GlfwNative.True));
    }

    private void OnKey(nint* window, int key, int scancode, int action, int mods)
    {
        Raise(new EventKey((nint) window, (Key) key, scancode, (InputAction) action, (KeyModifier) mods));
    }

    private void OnMouseButton(nint* window, int button, int action, int mods)
    {
        Raise(new EventMouseButton((nint) window, (MouseButton) button, (InputAction) action, (KeyModifier) mods));
    }

    private void OnScroll(nint* window, double xOffset, double yOffset)
    {
        Raise(new EventScroll((nint) window, new Vector2d(xOffset, yOffset)));
    }

    private void OnWindowClose(nint* window)
    {
        Raise(new EventWindowClose((nint) window));
    }

    private void OnWindowPosition(nint* window, int xPosition, int yPosition)
    {
        Raise(new EventWindowPosition((nint) window, new Vector2i(xPosition, yPosition)));
    }

    private void OnWindowSize(nint* window, int width, int height)
    {
        Raise(new EventWindowSize((nint) window, new Vector2i(width, height)));
    }

    private void OnWindowContentScale(nint* window, float xScale, float yScale)
    {
        Raise(new EventWindowContentScale((nint) window, new Vector2(xScale, yScale)));
    }

    private void OnWindowIconify(nint* window, int iconified)
    {
        Raise(new EventWindowIconify((nint) window, iconified == GlfwNative.True));
    }

    private void OnWindowFocus(nint* window, int focused)
    { 
        Raise(new EventWindowFocus((nint) window, focused == GlfwNative.True));
    }
    
}