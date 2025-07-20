namespace Hypercube.Core.Audio.Api.Base;

public partial class AudioApi
{
    public abstract AudioStream CreateStream(ReadOnlyMemory<byte> data, AudioFormat audioFormat, TimeSpan length, int sampleRate);
    protected abstract bool LoadDevice();
    protected abstract void CreateContext();
}