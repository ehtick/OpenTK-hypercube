namespace Hypercube.Core.Audio.Api;

[PublicAPI]
public partial interface IAudioApi
{
    event InfoHandler? OnInfo;
    event ErrorHandler? OnError;
    
    string Info { get; }
    bool Ready { get; }
    
    bool Init();
    AudioHandle CreateBuffer(in AudioData data);
    void DeleteBuffer(AudioHandle handle);
}
