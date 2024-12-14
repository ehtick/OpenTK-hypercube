using Hypercube.Core.Graphics.Api.GlfwApi.Enums;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Core.Graphics.Windowing.Api.Glfw;

public partial class GlfwWindowing
{
    private void Raise(Event ev)
    {
        if (_multiThread)
        {
            _eventBridge.Raise(ev);
            
            if (_waitEventsTimeout == 0)
                Graphics.Api.GlfwApi.Glfw.PostEmptyEvent();
            
            return;
        }
        
        Process(ev);
    }

    private void ProcessEvents(bool single = false)
    {
        foreach (var ev in _eventBridge.Process())
        {
            Process(ev);
            
            if (single)
                break;
        }
    }
    
    private void Process(Event command)
    {
        switch (command)
        {
            case EventWindowCreated windowCreated:
                windowCreated.TaskCompletionSource?.TrySetResult(windowCreated.Window);
                break;
        }
    }
    
    private abstract record Event;

    private record EventCursorPosition(
        nint Window,
        Vector2d Position
    ) : Event;

    private record EventCursorEnter(
        nint Window,
        bool Entered
    ) : Event;

    private record EventScroll(
        nint Window,
        Vector2d Offset
    ) : Event;

    private record EventKey(
        nint Window,
        Key Key,
        int ScanCode,
        InputAction Action,
        KeyModifier Modifier
    ) : Event;
    
    private record EventMouseButton(
        nint Window,
        MouseButton Button,
        InputAction Action,
        KeyModifier Mods
    ) : Event;
    
    private record EventChar
    (
        nint Window,
        uint CodePoint
    ) : Event;

    private record EventWindowClose
    (
        nint Window
    ) : Event;

    private record EventWindowSize
    (
        nint Window,
        Vector2i Size
    ) : Event;

    private record EventWindowPosition
    (
        nint Window,
        Vector2i Position
    ) : Event;

    private record EventWindowCreated
    (
        nint Window,
        TaskCompletionSource<nint>? TaskCompletionSource = null
    ) : Event;
    
    private record EventWindowContentScale
    (
        nint Window,
        Vector2 Scale
    ) : Event;

    private record EventWindowIconify
    (
        nint Window,
        bool Iconified
    ) : Event;

    private record EventWindowFocus
    (
        nint Window,
        bool Focused
    ) : Event;

    private record EventMonitorDestroy
    (
        int Id
    ) : Event;
}