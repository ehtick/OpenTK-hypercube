namespace Hypercube.Core.Audio;

public readonly ref struct AudioData
{
    public readonly ReadOnlySpan<byte> Source;
    public readonly AudioMetaData MetaData;
    
    public bool IsEmpty => Source.IsEmpty;
    public int Length => Source.Length;
    
    public AudioData(ReadOnlySpan<byte> source, AudioMetaData metaData)
    {
        Source = source;
        MetaData = metaData;
    }
    
    public string ToByteString(string separator = " ")
        => string.Join(separator, Source.ToArray().Select(b => b.ToString()));
}