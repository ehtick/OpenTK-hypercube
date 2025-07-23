using Hypercube.Core.Audio.Reader.Wav;

namespace Hypercube.Core.Audio.Utilities;

public static class AudioWavReaderExtension
{
    public static void Read(this AudioWavReader reader, out AudioData data)
    {
        reader.Read(out var span, out var format, out var length, out _, out _, out var sampleRate, out _, out _, out _);
        data = new AudioData(span, new AudioMetaData(format, length, sampleRate));
    }
}