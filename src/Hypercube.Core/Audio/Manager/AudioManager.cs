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
        _api.OnInfo += OnInfo;
        _api.OnError += OnError;
        _api.Init();
    }

    public IAudioSource CreateSource(AudioStream stream)
    {
        throw new NotImplementedException();
    }

    public AudioStream CreateStream(ReadOnlyMemory<byte> data , AudioFormat audioFormat, TimeSpan length, int sampleRate)
    {
        return Api.CreateStream(data, audioFormat, length, sampleRate);
    }

    private void OnInfo(string message)
    {
        _logger.Info(message);
    }

    private void OnError(string message)
    {
        _logger.Critical(message);
    }
}