using Silk.NET.OpenAL;

namespace Hypercube.Core.Audio.Api.Realisations.OpenAl;

public partial class OpenAlAudioApi
{
    public override void SourcePlay(AudioHandle source) => _al.SourcePlay(source);
    public override void SourceStop(AudioHandle source) => _al.SourceStop(source);
    public override void SourcePause(AudioHandle source) => _al.SourcePause(source);
    public override void SourceRewind(AudioHandle source) => _al.SourceRewind(source);
    public override void SourceSetGain(AudioHandle source, float value) => _al.SetSourceProperty(source, SourceFloat.Gain, value);
    public override float SourceGetGain(AudioHandle source) => _al.GetSourceProperty(source, SourceFloat.Gain);
    public override void SourceSetPitch(AudioHandle source, float value) => _al.SetSourceProperty(source, SourceFloat.Pitch, value);
    public override float SourceGetPitch(AudioHandle source) => _al.GetSourceProperty(source, SourceFloat.Pitch);
    public override void SourceSetLopping(AudioHandle source, bool value) => _al.SetSourceProperty(source, SourceBoolean.Looping, value);
    public override bool SourceGetLopping(AudioHandle source) => _al.GetSourceProperty(source, SourceBoolean.Looping);
    public override bool SourcePlaying(AudioHandle source) => _al.GetSourceProperty(source, GetSourceInteger.SourceState) == (int) SourceState.Playing;
    public override bool SourceStopped(AudioHandle source) => _al.GetSourceProperty(source, GetSourceInteger.SourceState) == (int) SourceState.Stopped;
    public override bool SourcePaused(AudioHandle source) => _al.GetSourceProperty(source, GetSourceInteger.SourceState) == (int) SourceState.Paused;
}