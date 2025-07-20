using Hypercube.Core.Audio.Manager;

namespace Hypercube.Core.Audio;

/// <summary>
/// Provides information about the loaded audio file to the external environment
/// and contains all the information necessary to create a <see cref="IAudioSource"/>.
/// </summary>
/// <seealso cref="IAudioManager.CreateSource(AudioStream)"/>
public struct AudioStream : IDisposable
{
    public readonly int Id;
    public readonly AudioFormat AudioFormat;
    public readonly TimeSpan Length;
    public readonly int SampleRate;

    public AudioStream(int id, AudioFormat audioFormat, TimeSpan length, int sampleRate)
    {
        Id = id;
        AudioFormat = audioFormat;
        Length = length;
        SampleRate = sampleRate;
    }

    public void Dispose()
    {
        
    }
}
