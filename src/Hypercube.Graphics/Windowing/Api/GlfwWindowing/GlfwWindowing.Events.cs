using Hypercube.GraphicsApi.GlfwApi;
using Hypercube.GraphicsApi.GlfwApi.Enums;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Graphics.Windowing.Api.GlfwWindowing;

public partial class GlfwWindowing
{
    private void Raise(IEvent ev)
    {
        if (_multiThread)
        {
            _eventBridge.Raise(ev);
            
            if (_waitEventsTimeout == 0)
                Glfw.PostEmptyEvent();
            
            return;
        }
        
        Process(ev);
    }

    private void ProcessEvents(bool single = false)
    {
        while (_eventBridge.TryRead(out var ev))
        {
            Process(ev);
            
            if (single)
                break;
        }
    }
    
    private void Process(IEvent command)
    {
        switch (command)
        {
            case EventWindowCreated windowCreated:
                windowCreated.TaskCompletionSource?.TrySetResult(windowCreated.Window);
                break;
        }
    }

    private interface IEvent;

    private record struct EventCursorPosition(
        nint Window,
        Vector2d Position
    ) : IEvent;

    private record struct EventCursorEnter(
        nint Window,
        bool Entered
    ) : IEvent;

    private record struct EventScroll(
        nint Window,
        Vector2d Offset
    ) : IEvent;

    private record struct EventKey(
        nint Window,
        Key Key,
        int ScanCode,
        InputAction Action,
        KeyModifier Modifier
    ) : IEvent;
    
    private record struct EventMouseButton(
        nint Window,
        MouseButton Button,
        InputAction Action,
        KeyModifier Mods
    ) : IEvent;
    
    private record struct EventChar
    (
        nint Window,
        uint CodePoint
    ) : IEvent;

    private record struct EventWindowClose
    (
        nint Window
    ) : IEvent;

    private record struct EventWindowSize
    (
        nint Window,
        Vector2i Size
    ) : IEvent;

    private record struct EventWindowPosition
    (
        nint Window,
        Vector2i Position
    ) : IEvent;

    private record struct EventWindowCreated
    (
        nint Window,
        TaskCompletionSource<nint>? TaskCompletionSource = null
    ) : IEvent;
    
    private record struct EventWindowContentScale
    (
        nint Window,
        Vector2 Scale
    ) : IEvent;

    private record struct EventWindowIconify
    (
        nint Window,
        bool Iconified
    ) : IEvent;

    private record struct EventWindowFocus
    (
        nint Window,
        bool Focused
    ) : IEvent;

    private record struct EventMonitorDestroy
    (
        int Id
    ) : IEvent;
}