namespace Hypercube.Core.Audio;

public ref struct AudioData
{
    public readonly ReadOnlySpan<byte> Source;
    public readonly AudioMetaData MetaData;
    
    public AudioData(ReadOnlySpan<byte> source, AudioMetaData metaData)
    {
        Source = source;
        MetaData = metaData;
    }
}