using Hypercube.Core.Audio.Api;
using Hypercube.Core.Audio.Api.Realisations.Headless;
using Hypercube.Core.Audio.Api.Realisations.OpenAl;
using Hypercube.Core.Audio.Exceptions;
using Hypercube.Utilities.Debugging.Logger;
using Hypercube.Utilities.Dependencies;

namespace Hypercube.Core.Audio.Manager;

[UsedImplicitly]
public sealed class AudioManager : IAudioManager
{
    [Dependency] private readonly ILogger _logger = null!;
    
    private IAudioApi? _api;

    public bool Ready => _api?.Ready ?? false;
    
    public IAudioApi Api => _api ?? throw new AudioManagerNotInitializedException();
    
    
    public void Initialize()
    {
        _api = new OpenAlAudioApi();
        _api.OnInfo += OnInfo;
        _api.OnError += OnError;
        
        if (!_api.Init())
        {
            _api.OnInfo -= OnInfo;
            _api.OnError -= OnError;
            
            _logger.Warning("Audio Manager failed to initialize API. Switch to headless mode");
            
            _api = new HeadlessAudioApi();
            
            // It doesn't really matter,
            // but in fact it's correct
            _api.Init();
        }
        
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

    public bool StartRecording(AudioRecordingSettings? settings = null)
    {
        return StartRecordingInternal(null, settings ?? AudioRecordingSettings.Default);
    }

    public bool StartRecording(string name, AudioRecordingSettings? settings = null)
    {
        return StartRecordingInternal(name, settings ?? AudioRecordingSettings.Default);
    }
    
    private bool StartRecordingInternal(string? name, AudioRecordingSettings settings)
    {
        if (!Api.OpenCaptureDevice(name, settings.SampleRate, settings.Channels, settings.SampleRate * 30))
            return false;
        
        Api.StartRecording();
        return true;
    }

    public void StopRecording()
    {
        Api.StopRecording();
        Api.CloseCaptureDevice();
    }

    public AudioData GetRecordedAudioData()
    {
        return Api.GetRecordedAudioData();
    }

    private void OnInfo(string message) => _logger.Info($"[AudioApi] {message}");

    private void OnError(string message) => _logger.Error($"[AudioApi] {message}");
}