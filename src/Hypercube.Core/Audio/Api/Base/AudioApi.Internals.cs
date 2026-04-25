namespace Hypercube.Core.Audio.Api.Base;

public abstract partial class AudioApi
{
    public abstract AudioHandle CreateBuffer(in AudioData data);
    public abstract void DeleteBuffer(AudioHandle handle);

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
    
    public abstract IReadOnlyList<string> CaptureDevices { get; }
    public abstract bool IsRecording { get; }
    public abstract bool OpenCaptureDevice(string? deviceName, int sampleRate, int channels, int bufferSize);
    public abstract void CloseCaptureDevice();
    public abstract void StartRecording();
    public abstract void StopRecording();
    public abstract int GetRecordedSampleCount();
    public abstract int ReadRecordedData(float[] buffer, int offset, int count);
    public abstract AudioData GetRecordedAudioData();
}