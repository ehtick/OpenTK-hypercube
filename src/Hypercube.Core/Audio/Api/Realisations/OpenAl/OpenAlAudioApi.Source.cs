using Silk.NET.OpenAL;

namespace Hypercube.Core.Audio.Api.Realisations.OpenAl;

public partial class OpenAlAudioApi
{
    public override AudioHandle CreateSource(AudioStream stream)
    {
        var source = _al.GenSource();
        
        _al.SetSourceProperty(source, SourceInteger.Buffer, stream.Handle);
        HandleError("Unable generate source");

        return new AudioHandle(source);
    }
    
    public override void DeleteSource(AudioHandle source)
    {
        _al.DeleteSource(source);
    }
}