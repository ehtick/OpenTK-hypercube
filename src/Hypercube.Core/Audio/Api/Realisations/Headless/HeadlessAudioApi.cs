using Hypercube.Core.Audio.Api.Base;

namespace Hypercube.Core.Audio.Api.Realisations.Headless;

public class HeadlessAudioApi : AudioApi
{
    public override string Info => "Headless, no information available";

    protected override bool LoadDevice()
    {
        return true;
    }

    protected override void CreateContext()
    {
    }

    public override AudioHandle CreateBuffer(in AudioData data)
    {
        return AudioHandle.Zero;
    }

    public override void DeleteBuffer(AudioHandle handle)
    {
    }

    public override AudioHandle CreateSource(AudioStream stream)
    {
        return AudioHandle.Zero;
    }

    public override void DeleteSource(AudioHandle source)
    {
    }

    public override void SourcePlay(AudioHandle source)
    {
    }

    public override void SourceStop(AudioHandle source)
    {
    }

    public override void SourcePause(AudioHandle source)
    {
    }

    public override void SourceRewind(AudioHandle source)
    {
    }

    public override void SourceSetGain(AudioHandle source, float value)
    {
    }

    public override float SourceGetGain(AudioHandle source)
    {
        return 0f;
    }

    public override void SourceSetPitch(AudioHandle source, float value)
    {
    }

    public override float SourceGetPitch(AudioHandle source)
    {
        return 0f;
    }

    public override void SourceSetLopping(AudioHandle source, bool value)
    {
    }

    public override bool SourceGetLopping(AudioHandle source)
    {
        return false;
    }

    public override bool SourcePlaying(AudioHandle source)
    {
        return false;
    }

    public override bool SourceStopped(AudioHandle source)
    {
        return false;
    }

    public override bool SourcePaused(AudioHandle source)
    {
        return false;
    }
}