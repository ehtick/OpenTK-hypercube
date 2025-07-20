namespace Hypercube.Core.Audio.Api;

public interface IAudioApi
{
    event InfoHandler? OnInfo;
    event ErrorHandler? OnError;
    
    bool Ready { get; }
    
    bool Init();
    AudioStream CreateStream(ReadOnlyMemory<byte> data , AudioFormat audioFormat, TimeSpan length, int sampleRate);
}