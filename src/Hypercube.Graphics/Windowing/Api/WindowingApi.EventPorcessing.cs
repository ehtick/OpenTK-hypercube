using Hypercube.Graphics.Windowing.Api.Exceptions;

namespace Hypercube.Graphics.Windowing.Api;

public abstract partial class WindowingApi
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
            
            case EventWindowSize evWindowSize:
                OnWindowSize?.Invoke(evWindowSize.Window, evWindowSize.Size);
                break;
            
            case EventWindowPosition evWindowPosition:
                OnWindowPosition?.Invoke(evWindowPosition.Window, evWindowPosition.Position);
                break;
            
            case EventWindowFocus evWindowFocus:
                OnWindowFocus?.Invoke(evWindowFocus.Window, evWindowFocus.Focused);
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
    
    private void Raise(IEvent ev, bool outOfThread = false)
    {
        if (_eventBridge is null)
            throw new WindowingApiNotInitializedException();

        if (Thread.CurrentThread == _thread && !outOfThread)
        {
            Process(ev);
            return;
        }
        
        _eventBridge.Raise(ev);
    }
}