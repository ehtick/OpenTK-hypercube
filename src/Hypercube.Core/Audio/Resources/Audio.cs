using Hypercube.Core.Resources.Loaders;

namespace Hypercube.Core.Audio.Resources;

public sealed class Audio : Resource
{
    public readonly AudioStream Stream;

    public Audio(AudioStream stream)
    {
        Stream = stream;
    }

    public override void Dispose()
    {
        Stream.Dispose();
    }

    public static implicit operator AudioStream(Audio audio)
    {
        return audio.Stream;
    }
}