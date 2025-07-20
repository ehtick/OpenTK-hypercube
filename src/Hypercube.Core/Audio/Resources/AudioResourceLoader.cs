using Hypercube.Core.Audio.Manager;
using Hypercube.Core.Audio.Reader.Wav;
using Hypercube.Core.Resources;
using Hypercube.Core.Resources.FileSystems;
using Hypercube.Core.Resources.Loaders;
using Hypercube.Utilities.Dependencies;

namespace Hypercube.Core.Audio.Resources;

public class AudioResourceLoader : ResourceLoader<Audio>
{
    [Dependency] private readonly IAudioManager _audioManager = default!;
    
    public override string[] Extensions => ["wav"];
    
    public override bool CanLoad(ResourcePath path, IFileSystem fileSystem)
    {
        return Extensions.Contains(path.Extension, StringComparer.OrdinalIgnoreCase);
    }

    public override Audio Load(ResourcePath path, IFileSystem fileSystem)
    {
        var reader = new AudioWavReader(fileSystem.OpenRead(path));
        var data = reader.Read();
        return new Audio(_audioManager.CreateStream(data.Data, data.Format, data.Length, data.Channels));
    }
}