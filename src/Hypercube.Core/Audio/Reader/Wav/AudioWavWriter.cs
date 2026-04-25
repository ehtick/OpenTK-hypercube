namespace Hypercube.Core.Audio.Reader.Wav;

public class AudioWavWriter
{
    private static ReadOnlySpan<byte> RiffChunkId => "RIFF"u8;
    private static ReadOnlySpan<byte> WaveChunkId => "WAVE"u8;
    private static ReadOnlySpan<byte> FmtChunkId  => "fmt "u8;
    private static ReadOnlySpan<byte> DataChunkId => "data"u8;
    
    public static void Write(Stream stream, short[] samples, int sampleRate)
    {
        using var bw = new BinaryWriter(stream);

        var dataSize = samples.Length * 2;

        bw.Write(RiffChunkId);
        bw.Write(36 + dataSize);
        bw.Write(WaveChunkId);
        bw.Write(FmtChunkId);
        bw.Write(16);
        bw.Write((short) 1); // PCM
        bw.Write((short) 1); // mono
        bw.Write(sampleRate);
        bw.Write(sampleRate * 2);
        bw.Write((short) 2);
        bw.Write((short) 16);

        bw.Write(DataChunkId);
        bw.Write(dataSize);

        foreach (var s in samples)
            bw.Write(s);
    }
}