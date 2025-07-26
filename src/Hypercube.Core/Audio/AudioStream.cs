using Hypercube.Core.Audio.Api;
using Hypercube.Core.Audio.Manager;

namespace Hypercube.Core.Audio;

/// <summary>
/// Provides information about the loaded audio file to the external environment
/// and contains all the information necessary to create a <see cref="AudioSource"/>.
/// </summary>
/// <seealso cref="IAudioManager.CreateSource(AudioStream)"/>
[PublicAPI]
public sealed class AudioStream : IDisposable
{
    public readonly AudioHandle Handle;
    public readonly AudioMetaData MetaData;

    private readonly IAudioApi _api;

    public AudioStream(IAudioApi api, AudioHandle handle, AudioMetaData metaData)
    {
        Handle = handle;
        MetaData = metaData;

        _api = api;
    }

    public void Dispose()
    {
        _api.DeleteBuffer(Handle);
    }

    public override string ToString()
    {
        return $"BufferId: {Handle}, MetaData: {{{MetaData}}}";
    }
}
