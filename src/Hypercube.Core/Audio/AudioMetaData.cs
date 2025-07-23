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
    
    public AudioMetaData(AudioFormat audioFormat, TimeSpan length, int sampleRate)
    {
        AudioFormat = audioFormat;
        Length = length;
        SampleRate = sampleRate;
    }
    
    public override string ToString()
    {
        return $"Format: {AudioFormat}, Length: {Length}, SampleRate: {SampleRate} Hz";
    }
}