namespace Hypercube.Core.Audio.Api;

public partial interface IAudioApi
{
    AudioHandle CreateSource(AudioStream stream);
    void DeleteSource(AudioHandle source);
    void SourcePlay(AudioHandle source);
    void SourceStop(AudioHandle source);
    void SourcePause(AudioHandle source);
    void SourceRewind(AudioHandle source);
    void SourceSetGain(AudioHandle source, float value);
    float SourceGetGain(AudioHandle source);
    void SourceSetPitch(AudioHandle source, float value);
    float SourceGetPitch(AudioHandle source);
    void SourceSetLopping(AudioHandle source, bool value);
    bool SourceGetLopping(AudioHandle source);
    bool SourcePlaying(AudioHandle source);
    bool SourceStopped(AudioHandle source);
    bool SourcePaused(AudioHandle source);
}
