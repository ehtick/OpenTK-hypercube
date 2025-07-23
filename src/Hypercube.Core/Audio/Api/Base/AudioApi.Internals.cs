namespace Hypercube.Core.Audio.Api.Base;

public partial class AudioApi
{
    public abstract void DisposeStream(AudioStream stream);

    public abstract AudioHandle CreateStream(in AudioData data);
    protected abstract bool LoadDevice();
    protected abstract void CreateContext();
    
    public abstract AudioHandle CreateSource(AudioStream stream);
    public abstract void DeleteSource(AudioHandle source);
    public abstract void SourcePlay(AudioHandle source);
    public abstract void SourceStop(AudioHandle source);
    public abstract void SourcePause(AudioHandle source);
    public abstract void SourceRewind(AudioHandle source);
    public abstract void SourceSetGain(AudioHandle source, float value);
    public abstract float SourceGetGain(AudioHandle source);
    public abstract void SourceSetPitch(AudioHandle source, float value);
    public abstract float SourceGetPitch(AudioHandle source);
    public abstract void SourceSetLopping(AudioHandle source, bool value);
    public abstract bool SourceGetLopping(AudioHandle source);
    public abstract bool SourcePlaying(AudioHandle source);
    public abstract bool SourceStopped(AudioHandle source);
    public abstract bool SourcePaused(AudioHandle source);
}