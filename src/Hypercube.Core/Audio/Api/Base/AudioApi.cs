namespace Hypercube.Core.Audio.Api.Base;

public abstract partial class AudioApi : IAudioApi
{
    public event InfoHandler? OnInfo;
    public event ErrorHandler? OnError;
    
    public abstract string Info { get; }
    public bool Ready { get; }

    public bool Init()
    {
        if (!LoadDevice())
            return false;
        
        CreateContext();
        return true;
    }

    protected void LogInfo(string message)
    {
        OnInfo?.Invoke(message);
    }

    protected void LogError(string message)
    {
        OnError?.Invoke(message);
    }
}