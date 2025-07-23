using Hypercube.Core.Audio.Api;
using Hypercube.Core.Audio.Manager;

namespace Hypercube.Core.Audio;

/// <summary>
/// Source created from <see cref="AudioStream"/>,
/// its implementation is the responsibility of the current
/// <see cref="IAudioManager"/> implementation.
/// </summary>
[PublicAPI]
public sealed class AudioSource : IDisposable
{
    private readonly IAudioApi _api;
    private readonly AudioHandle _source;

    public bool Playing => _api.SourcePlaying(_source);
    public bool Stopped => _api.SourceStopped(_source);
    public bool Paused => _api.SourcePaused(_source);

    public bool Looping
    {
        get => _api.SourceGetLopping(_source);
        set => _api.SourceSetLopping(_source, value);
    }

    public float Pitch
    {
        get => _api.SourceGetPitch(_source);
        set => _api.SourceSetPitch(_source, value);
    }

    public float Gain
    {
        get => _api.SourceGetGain(_source);
        set => _api.SourceSetGain(_source, value);
    }

    public AudioSource(IAudioApi api, AudioHandle source)
    {
        _api = api;
        _source = source;
    }
    
    public void Start()
    {
        _api.SourcePlay(_source);
    }

    public void Stop()
    {
        _api.SourceStop(_source);
    }

    public void Pause()
    {
        _api.SourcePause(_source);
    }
    
    public void Restart()
    {
        _api.SourceRewind(_source);
        _api.SourcePlay(_source);
    }
    
    public void Dispose()
    {
        _api.DeleteSource(_source);
    }
}
