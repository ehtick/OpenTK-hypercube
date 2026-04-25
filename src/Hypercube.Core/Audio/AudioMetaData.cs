namespace Hypercube.Core.Audio;

/// <summary>
/// Encapsulates essential metadata about an audio stream.
/// </summary>
[PublicAPI]
public readonly struct AudioMetaData
{
    /// <summary>
    /// Audio format of the audio (e.g., Mono8, Stereo16).
    /// </summary>
    public readonly AudioFormat AudioFormat;
    
    /// <summary>
    /// Duration of the audio.
    /// </summary>
    public readonly TimeSpan Length;
    
    /// <summary>
    /// Number of samples per second in Hertz (Hz).
    /// </summary>
    public readonly int SampleRate;

    public int Channels => AudioFormat switch
    {
        AudioFormat.Mono8 => 1,
        AudioFormat.Mono16 => 1,
        AudioFormat.Stereo8 => 2,
        AudioFormat.Stereo16 => 2,
        _ => 0
    };
    
    public AudioMetaData(AudioFormat audioFormat, TimeSpan length, int sampleRate)
    {
        AudioFormat = audioFormat;
        Length = length;
        SampleRate = sampleRate;
    }

    public AudioMetaData WithLength(TimeSpan length) => new(AudioFormat, length, SampleRate);

    public override string ToString()
    {
        return $"Format: {AudioFormat}, Length: {Length}, SampleRate: {SampleRate} Hz";
    }
}