using Hypercube.Core.Graphics.Windowing.Api.Exceptions;
using Hypercube.Core.Input;

namespace Hypercube.Core.Graphics.Windowing.Api.Base;

public abstract partial class BaseWindowingApi
{
    private void Process(IEvent ev)
    {
        switch (ev)
        {
            case EventSync evSync:
                evSync.Command.TrySetResult();
                break;
            
            case EventSync<nint> evSync:
                evSync.Command.TrySetResult(evSync.Result);
                break;
            
            case EventError evError:
                OnError?.Invoke(evError.Description);
                break;

            case EventMonitor evMonitor:
                OnMonitor?.Invoke(evMonitor.Monitor, evMonitor.State);
                break;
            
            case EventJoystick evJoystick:
                OnJoystick?.Invoke(evJoystick.Joystick, evJoystick.State);
                break;
            
            case EventWindowClose evWindowClose:
                OnWindowClose?.Invoke(evWindowClose.Window);
                break;
            
            case EventWindowTitle evWindowTitle:
                OnWindowTitle?.Invoke(evWindowTitle.Window, evWindowTitle.Title);
                break;
            
            case EventWindowSize evWindowSize:
                OnWindowSize?.Invoke(evWindowSize.Window, evWindowSize.Size);
                break;
            
            case EventWindowPosition evWindowPosition:
                OnWindowPosition?.Invoke(evWindowPosition.Window, evWindowPosition.Position);
                break;
            
            case EventWindowFocus evWindowFocus:
                OnWindowFocus?.Invoke(evWindowFocus.Window, evWindowFocus.Focused);
                break;
            
            case EventWindowKey evWindowKey:
                OnWindowKey?.Invoke(evWindowKey.Window, new KeyStateChangedArgs(evWindowKey.Key, evWindowKey.State, evWindowKey.Modifier, evWindowKey.ScanCode));
                break;
            
            case EventWindowScroll evWindowScroll:
                OnWindowScroll?.Invoke(evWindowScroll.Window, evWindowScroll.Offset);
                break;
            
            case EventWindowMouseButton evWindowMouseButton:
                OnWindowMouseButton?.Invoke(evWindowMouseButton.Window, new MouseButtonChangedArgs(evWindowMouseButton.Button, evWindowMouseButton.State, evWindowMouseButton.Modifier));
                break;
            
            case EventWindowChar evWindowChar:
                OnWindowChar?.Invoke(evWindowChar.Window, evWindowChar.CodePoint);
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