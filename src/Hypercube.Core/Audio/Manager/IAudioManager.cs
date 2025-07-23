using Hypercube.Core.Audio.Api;
using Hypercube.Core.Resources;

namespace Hypercube.Core.Audio.Manager;

public interface IAudioManager
{
    [EngineInternal]
    IAudioApi Api { get; }
    bool Ready { get; }
    void Init();
    
    AudioSource CreateSource(AudioStream stream);
    AudioStream CreateStream(in AudioData data);
}