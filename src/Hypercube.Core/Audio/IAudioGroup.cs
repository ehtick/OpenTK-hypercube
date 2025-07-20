namespace Hypercube.Core.Audio;

public interface IAudioGroup
{
    float Gain { get; set; }
    void Pause();
    void Stop();
}
