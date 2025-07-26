using Silk.NET.OpenAL;

namespace Hypercube.Core.Audio.Api.Realisations.OpenAl;

public unsafe partial class OpenAlAudioApi
{
    public override AudioHandle CreateBuffer(in AudioData data)
    {
        var buffer = _al.GenBuffer();
        HandleError("Unable generate audio stream buffer");

        fixed (byte* pointer = data.Source)
        {
            _al.BufferData(buffer, (BufferFormat) data.MetaData.AudioFormat, pointer, data.Source.Length, data.MetaData.SampleRate);
            HandleError("Unable apply data for buffer");
        }

        return new AudioHandle(buffer);
    }
    
    public override void DeleteBuffer(AudioHandle handle)
    {
        _al.DeleteBuffer(handle);
    }
}