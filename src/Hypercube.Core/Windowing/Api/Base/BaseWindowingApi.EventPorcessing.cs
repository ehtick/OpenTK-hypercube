using Hypercube.Core.Input;
using Hypercube.Core.Windowing.Api.Exceptions;

namespace Hypercube.Core.Windowing.Api.Base;

public abstract partial class BaseWindowingApi
{
    private void Process(IEvent processed)
    {
        switch (processed)
        {
            case EventSync @event:
                @event.Command.TrySetResult();
                break;
            
            case EventSync<nint> @event:
                @event.Command.TrySetResult(@event.Result);
                break;
            
            case EventError @event:
                OnError?.Invoke(@event.Description);
                break;

            case EventMonitor @event:
                OnMonitor?.Invoke(@event.Monitor, @event.State);
                break;
            
            case EventJoystick @event:
                OnJoystick?.Invoke(@event.Joystick, @event.State);
                break;
            
            case EventWindowCursorPosition @event:
                break;
            
            case EventCursorEnter @event:
                break;
            
            case EventWindowClose @event:
                OnWindowClose?.Invoke(@event.Window);
                break;
            
            case EventWindowTitle @event:
                OnWindowTitle?.Invoke(@event.Window, @event.Title);
                break;
            
            case EventWindowSize @event:
                OnWindowSize?.Invoke(@event.Window, @event.Size);
                break;
            
            case EventWindowPosition @event:
                OnWindowPosition?.Invoke(@event.Window, @event.Position);
                break;
            
            case EventWindowContentScale @event:
                break;
            
            case EventWindowIconify @event:
                break;
            
            case EventWindowFocus @event:
                OnWindowFocus?.Invoke(@event.Window, @event.Focused);
                break;
            
            case EventMonitorDestroy @event:
                break;
            
            case EventWindowKey @event:
                OnWindowKey?.Invoke(@event.Window, new KeyStateChangedArgs(@event.Key, @event.State, @event.Modifier, @event.ScanCode));
                break;
            
            case EventWindowScroll @event:
                OnWindowScroll?.Invoke(@event.Window, @event.Offset);
                break;
            
            case EventWindowMouseButton @event:
                OnWindowMouseButton?.Invoke(
                    @event.Window,
                    new MouseButtonChangedArgs(
                        @event.Button,
                        @event.State,
                        @event.Modifier
                    )
                );
                break;
            
            case EventWindowChar @event:
                OnWindowChar?.Invoke(@event.Window, @event.CodePoint);
                break;
        }
    }

    private void ProcessEvents(bool single = true)
    {
        if (_eventBridge is null)
            throw new WindowingApiNotInitializedException();
        
        while (_eventBridge.TryRead(out var ev))
        {
            Process(ev);
            
            if (single)
                break;
        }
    }
    
    protected void Raise(IEvent ev)
    {
        Raise(ev, false);
    }
    
    private void Raise(IEvent ev, bool outOfThread)
    {
        if (_eventBridge is null)
            throw new WindowingApiNotInitializedException();

        if (Thread.CurrentThread == Thread && !outOfThread)
        {
            Process(ev);
            return;
        }
        
        _eventBridge.Raise(ev);
    }
}