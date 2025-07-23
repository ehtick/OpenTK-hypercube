using System.Runtime.CompilerServices;
using System.Text;

namespace Hypercube.Core.Audio.Reader.Wav;

/// <summary>
/// Reads audio data from a WAV stream.
/// This class is responsible for parsing the WAV file format and extracting audio information and data.
/// </summary>
public sealed class AudioWavReader : IDisposable
{
    private const int ChunkSize = 4 * sizeof(byte) + 1 * sizeof(uint);
    
    private static ReadOnlySpan<byte> RiffChunkId => "RIFF"u8;
    private static ReadOnlySpan<byte> WaveChunkId => "WAVE"u8;
    private static ReadOnlySpan<byte> FmtChunkId  => "fmt "u8;
    private static ReadOnlySpan<byte> DataChunkId => "data"u8;
    
    private readonly BinaryReader _reader;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="AudioWavReader"/> class.
    /// </summary>
    /// <param name="stream">The stream to read the WAV data from. The stream must be seekable.</param>
    /// <param name="leaveOpen">A value indicating whether to leave the stream open after the reader is disposed.</param>
    public AudioWavReader(Stream stream, bool leaveOpen = false)
    {
        if (!stream.CanSeek)
            throw new ArgumentException("Stream must be seekable.", nameof(stream));
        _reader = new BinaryReader(stream, Encoding.UTF8, leaveOpen);
    }

    /// <summary>
    /// Synchronously reads and parses the WAV data from the stream.
    /// </summary>
    /// <returns>An <see cref="AudioWavData"/> object containing the parsed WAV data.</returns>
    /// <exception cref="InvalidDataException">Thrown if the stream is not a valid WAV file.</exception>
    /// <remarks>
    /// This method reads the entire audio data chunk into memory. For very large files,
    /// consider a streaming approach to avoid potential OutOfMemoryException.
    /// </remarks>
    public void Read(out ReadOnlySpan<byte> data, out AudioFormat format, out TimeSpan duration, out short fromatType, out short channels, out int sampleRate, out int byteRate, out short blockAlign, out short bitsPerSample)
    {
        Span<byte> chunkIdBuffer = stackalloc byte[4];

        // 1. Read RIFF header
        ReadChunkFull(chunkIdBuffer, out var riffLength); // We don't use riffLength, but we must read it.
        if (!chunkIdBuffer.SequenceEqual(RiffChunkId))
            throw new InvalidDataException("Invalid WAV file: 'RIFF' chunk not found.");

        if (riffLength + ChunkSize != _reader.BaseStream.Length)
            throw new InvalidOperationException();
        
        // 2. Read WAVE format identifier
        ReadChunkId(chunkIdBuffer);
        if (!chunkIdBuffer.SequenceEqual(WaveChunkId))
            throw new InvalidDataException("Invalid WAV file: 'WAVE' identifier not found.");

        // 3. Read 'fmt ' chunk
        ReadChunkFull(chunkIdBuffer, out var fmtLength);
        if (!chunkIdBuffer.SequenceEqual(FmtChunkId))
            throw new InvalidDataException("Invalid WAV file: 'fmt ' chunk not found.");

        var fmtDataPosition = _reader.BaseStream.Position;
        
        fromatType = _reader.ReadInt16();
        channels = _reader.ReadInt16();
        sampleRate = _reader.ReadInt32();
        byteRate = _reader.ReadInt32();
        blockAlign = _reader.ReadInt16();
        bitsPerSample = _reader.ReadInt16();

        // Skip any extra format data to be compatible with non-standard 'fmt ' chunks.
        _reader.BaseStream.Position = fmtDataPosition + fmtLength;

        // 4. Find and read 'data' chunk
        SkipToChunk(DataChunkId, out var dataLength);
        
        data = _reader.ReadBytes((int) dataLength);
        format = GetFormat(channels, bitsPerSample);
        duration = GetDuration(data.Length, blockAlign, sampleRate);
    }

    private void SkipToChunk(ReadOnlySpan<byte> targetChunkId, out uint length)
    {
        Span<byte> currentChunkId = stackalloc byte[4];
        while (true)
        {
            ReadChunkFull(currentChunkId, out length);
            if (currentChunkId.SequenceEqual(targetChunkId))
                return;

            _reader.BaseStream.Seek(length, SeekOrigin.Current);
        }
    }

    private void ReadChunkFull(Span<byte> chunkIdBuffer, out uint length)
    {
        ReadChunkId(chunkIdBuffer);
        length = _reader.ReadUInt32();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void ReadChunkId(Span<byte> chunkIdBuffer)
    {
        chunkIdBuffer[0] = _reader.ReadByte();
        chunkIdBuffer[1] = _reader.ReadByte();
        chunkIdBuffer[2] = _reader.ReadByte();
        chunkIdBuffer[3] = _reader.ReadByte();
    }

    public void Dispose()
    {
        _reader.Dispose();
    }

    private static AudioFormat GetFormat(int channels, int bits)
    {
        return bits switch
        {   
            8 => channels switch
            {
                1 => AudioFormat.Mono8,
                2 => AudioFormat.Stereo8,
                _ => throw new InvalidOperationException()
            },
            16 => channels switch
            {
                1 => AudioFormat.Mono16,
                2 => AudioFormat.Stereo16,
                _ => throw new InvalidOperationException()
            },
            _ => throw new InvalidOperationException()
        };
    }

    private static TimeSpan GetDuration(int length, double blockAlign, int sampleRate)
    {
        return TimeSpan.FromSeconds(length / blockAlign / sampleRate);
    }
}
