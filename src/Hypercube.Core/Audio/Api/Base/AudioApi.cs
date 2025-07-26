namespace Hypercube.Core.Audio.Api.Base;

public abstract partial class AudioApi : IAudioApi
{
    public event ErrorHandler? OnError;

    public abstract string Info { get; }
    private Thread? Thread { get; set; }
    
    public bool Ready => Thread is not null;

    public bool Init()
    {
        if (!LoadDevice())
            return false;
        
        CreateContext();
        Thread = Thread.CurrentThread;
        return true;
    }
    
    protected void LogError(string message)
    {
        OnError?.Invoke(message);
    }
}