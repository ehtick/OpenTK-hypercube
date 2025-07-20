using Silk.NET.OpenAL;

namespace Hypercube.Core.Audio.Api.Realisations.OpenAl;

public sealed class OpenAlAudioSource : IAudioSource
{
    private readonly AL _al;
    private readonly uint _source;
    
    public IAudioGroup? Group { get; }

    public bool Playing => State == SourceState.Playing;
    public bool Stopped => State == SourceState.Stopped;
    public bool Paused => State == SourceState.Paused;

    public bool Looping
    {
        get => GetSource(SourceBoolean.Looping);
        set => SetSource(SourceBoolean.Looping, value);
    }

    public float Pitch
    {
        get => GetSource(SourceFloat.Pitch);
        set => SetSource(SourceFloat.Pitch, value);
    }

    public float Gain
    {
        get => GetSource(SourceFloat.Gain);
        set => SetSource(SourceFloat.Gain, value);
    }

    private SourceState State => (SourceState) GetSource(GetSourceInteger.SourceState);

    public OpenAlAudioSource(AL al, uint source)
    {
        _al = al;
        _source = source;
    }
    
    public void Start()
    {
        _al.SourcePlay(_source);
    }

    public void Stop()
    {
        _al.SourceStop(_source);
    }

    public void Pause()
    {
        _al.SourcePause(_source);
    }
    
    public void Restart()
    {
        _al.SourceRewind(_source);
        _al.SourcePlay(_source);
    }
    
    public void Dispose()
    {
        _al.DeleteSource(_source);
    }

    private void SetSource(SourceBoolean target, bool value)
    {
        _al.SetSourceProperty(_source, target, value);
    }
    
    private void SetSource(SourceFloat target, float value)
    {
        _al.SetSourceProperty(_source, target, value);
    }
    
    private bool GetSource(SourceBoolean target)
    {
        _al.GetSourceProperty(_source, target, out var value);
        return value;
    }

    private float GetSource(SourceFloat target)
    {
        _al.GetSourceProperty(_source, target, out var value);
        return value;
    }

    private int GetSource(GetSourceInteger target)
    {
        _al.GetSourceProperty(_source, target, out var value);
        return value;
    }
}