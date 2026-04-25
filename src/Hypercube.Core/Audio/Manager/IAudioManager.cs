using Hypercube.Core.Audio.Api;

namespace Hypercube.Core.Audio.Manager;

public interface IAudioManager : IInitializable
{
    bool Ready { get; }

    [EngineInternal]
    IAudioApi Api { get; }

    AudioSource CreateSource(AudioStream stream);
    AudioStream CreateStream(in AudioData data);
    
    bool StartRecording(AudioRecordingSettings? settings = null);
    bool StartRecording(string name, AudioRecordingSettings? settings = null);
    void StopRecording();
    
    AudioData GetRecordedAudioData();
}

public record struct AudioRecordingSettings
{
    public static readonly AudioRecordingSettings Default = new(44100, 1);
    
    public readonly int SampleRate;
    public readonly int Channels;

    public AudioRecordingSettings(int sampleRate, int channels)
    {
        SampleRate = sampleRate;
        Channels = channels;
    }
}