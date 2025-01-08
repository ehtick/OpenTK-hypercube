using Hypercube.Graphics.Windowing.Api.Exceptions;

namespace Hypercube.Graphics.Windowing.Api;

public abstract unsafe partial class WindowingApi
{
    private void Process(IEvent ev)
    {
        switch (ev)
        {
            case EventError evError:
                OnError?.Invoke(evError.Description);
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
        if (_eventBridge is null)
            throw new WindowingApiNotInitializedException();
        
        if (_multiThread)
        {
            _eventBridge.Raise(ev);
        }
        
        Process(ev);
    }
}