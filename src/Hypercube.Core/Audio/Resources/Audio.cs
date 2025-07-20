using Hypercube.Core.Resources.Loaders;

namespace Hypercube.Core.Audio.Resources;

public sealed class Audio : Resource
{
    public AudioStream Stream { get; private set; }

    public Audio(AudioStream stream)
    {
        Stream = stream;
    }

    public override void Dispose()
    {
        Stream.Dispose();
    }
}