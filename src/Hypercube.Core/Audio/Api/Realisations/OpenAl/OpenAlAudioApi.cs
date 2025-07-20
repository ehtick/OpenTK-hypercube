using Hypercube.Core.Audio.Api.Base;
using Silk.NET.OpenAL;

namespace Hypercube.Core.Audio.Api.Realisations.OpenAl;

public sealed unsafe class OpenAlAudioApi : AudioApi
{
    private AL _al = default!;
    private ALContext _alc = default!;
    
    private Device* _device;
    private Context* _context;

    public override AudioStream CreateStream(ReadOnlyMemory<byte> data, AudioFormat audioFormat, TimeSpan length, int sampleRate)
    {
        var buffer = _al.GenBuffer();
        HandleError("Unable generate audio stream buffer");

        fixed (byte* pointer = data.Span)
        {
            _al.BufferData(buffer, (BufferFormat) audioFormat, pointer, data.Length, sampleRate);
            HandleError("Unable apply data for buffer");
        }

        var audioSteam = new AudioStream(0, audioFormat, length, sampleRate);
        return audioSteam;
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
}