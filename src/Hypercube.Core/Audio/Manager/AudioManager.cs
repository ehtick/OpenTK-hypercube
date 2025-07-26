using Hypercube.Core.Audio.Api;
using Hypercube.Core.Audio.Api.Realisations.OpenAl;
using Hypercube.Core.Audio.Exceptions;
using Hypercube.Utilities.Debugging.Logger;
using Hypercube.Utilities.Dependencies;

namespace Hypercube.Core.Audio.Manager;

[UsedImplicitly]
public sealed class AudioManager : IAudioManager
{
    [Dependency] private readonly ILogger _logger = default!;
    
    private IAudioApi? _api;

    public bool Ready => _api?.Ready ?? false;
    public IAudioApi Api => _api ?? throw new AudioManagerNotInitializedException();
    
    public void Init()
    {
        _api = new OpenAlAudioApi();
        _api.OnError += OnError;
        _api.Init();
        
        _logger.Info($"Audio Api (OpenAL) info:\n{_api.Info}");
    }

    public AudioSource CreateSource(AudioStream stream)
    {
        return new AudioSource(Api, Api.CreateSource(stream));
    }

    public AudioStream CreateStream(in AudioData data)
    {
        return new AudioStream(Api, Api.CreateBuffer(in data), data.MetaData);
    }

    private void OnError(string message)
    {
        _logger.Critical(message);
    }
}