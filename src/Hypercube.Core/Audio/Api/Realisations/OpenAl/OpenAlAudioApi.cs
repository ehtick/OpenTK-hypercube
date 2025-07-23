using System.Runtime.CompilerServices;
using System.Text;
using Hypercube.Core.Audio.Api.Base;
using Silk.NET.OpenAL;

namespace Hypercube.Core.Audio.Api.Realisations.OpenAl;

public sealed unsafe class OpenAlAudioApi : AudioApi
{
    private AL _al = default!;
    private ALContext _alc = default!;
    
    private Device* _device;
    private Context* _context;

    public override string Info
    {
        get
        {
            var builder = new StringBuilder();
            builder.Append("Vendor: ");
            builder.AppendLine(_al.GetStateProperty(StateString.Vendor));
            builder.Append("Renderer: ");
            builder.AppendLine(_al.GetStateProperty(StateString.Renderer));
            builder.Append("Version: ");
            builder.AppendLine(_al.GetStateProperty(StateString.Version));
            builder.Append("Extensions: ");
            builder.Append(_al.GetStateProperty(StateString.Extensions));
            return builder.ToString();
        }
    }
    
    public override AudioHandle CreateStream(in AudioData data)
    {
        return GenerateBuffer(in data);
    }

    public override void DisposeStream(AudioStream stream)
    {
        DeleteBuffer(stream.Handle);
    }

    protected override bool LoadDevice()
    {
        _al = AL.GetApi();
        _alc = ALContext.GetApi();
        
        _device = _alc.OpenDevice(null);
        if (HandleError("Failed loading open device"))
            return false;

        if (_device is not null)
            return true;
        
        LogError("OpenAl internal error: Unable to open device");
        return false;
    }

    protected override void CreateContext()
    {
        var contextAttributes = stackalloc int[]
        {
            0 // Null-terminated list
        };
        
        _context = _alc.CreateContext(_device, contextAttributes);
        if (_context is null)
        {
            LogError("Failed to create OpenAL context.");
            return;
        }

        if (!_alc.MakeContextCurrent(_context))
            LogError("Failed to make OpenAL context current.");
    }

    private bool HandleError(string message = "")
    {
        var error = _al.GetError();
        if (error == AudioError.NoError)
            return false;
        
        LogError($"OpenAl internal error {error}: {message}");
        return true;
    }

    private AudioHandle GenerateBuffer(in AudioData data)
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

    public override AudioHandle CreateSource(AudioStream stream)
    {
        var source = _al.GenSource();
        
        _al.SetSourceProperty(source, SourceInteger.Buffer, stream.Handle);
        HandleError("Unable generate source");

        return new AudioHandle(source);
    }

    public override void DeleteSource(AudioHandle source)
    {
        throw new NotImplementedException();
    }

    public override void SourcePlay(AudioHandle source)
    {
        _al.SourcePlay(source);
        HandleError();
    }

    public override void SourceStop(AudioHandle source)
    {
        _al.SourceStop(source);
        HandleError();
    }

    public override void SourcePause(AudioHandle source)
    {
        _al.SourcePause(source);
        HandleError();
    }

    public override void SourceRewind(AudioHandle source)
    {
        _al.SourceRewind(source);
        HandleError();
    }

    public override void SourceSetGain(AudioHandle source, float value)
    {
        SetSource(source, SourceFloat.Gain, value);
    }

    public override float SourceGetGain(AudioHandle source)
    {
        return GetSource(source, SourceFloat.Gain);
    }

    public override void SourceSetPitch(AudioHandle source, float value)
    {
        SetSource(source, SourceFloat.Pitch, value);
    }

    public override float SourceGetPitch(AudioHandle source)
    {
        return GetSource(source, SourceFloat.Pitch);
    }

    public override void SourceSetLopping(AudioHandle source, bool value)
    {
        SetSource(source, SourceBoolean.Looping, value);
    }

    public override bool SourceGetLopping(AudioHandle source)
    {
        return GetSource(source, SourceBoolean.Looping);
    }

    public override bool SourcePlaying(AudioHandle source)
    {
        return GetSourceState(source) == SourceState.Playing;
    }

    public override bool SourceStopped(AudioHandle source)
    {
        return GetSourceState(source) == SourceState.Stopped;;
    }

    public override bool SourcePaused(AudioHandle source)
    {
        return GetSourceState(source) == SourceState.Paused;
    }

    private void DeleteBuffer(AudioHandle handle)
    {
        _al.DeleteBuffer(handle);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void SetSource(AudioHandle source, SourceBoolean target, bool value)
    {
        _al.SetSourceProperty(source, target, value);
        HandleError();
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void SetSource(AudioHandle source, SourceFloat target, float value)
    {
        _al.SetSourceProperty(source, target, value);
        HandleError();
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private bool GetSource(AudioHandle source, SourceBoolean target)
    {
        _al.GetSourceProperty(source, target, out var value);
        HandleError();
        return value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private float GetSource(AudioHandle source, SourceFloat target)
    {
        _al.GetSourceProperty(source, target, out var value);
        HandleError();
        return value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private int GetSource(AudioHandle source, GetSourceInteger target)
    {
        _al.GetSourceProperty(source, target, out var value);
        HandleError();
        return value;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private SourceState GetSourceState(AudioHandle source)
    {
        return (SourceState) GetSource(source, GetSourceInteger.SourceState);
    }
}