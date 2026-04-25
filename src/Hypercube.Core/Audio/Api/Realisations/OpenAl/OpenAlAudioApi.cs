using Hypercube.Core.Audio.Api.Base;
using Silk.NET.OpenAL;

namespace Hypercube.Core.Audio.Api.Realisations.OpenAl;

public sealed unsafe partial class OpenAlAudioApi : AudioApi
{
    private AL _al = null!;
    private ALContext _alc = null!;
    
    private Device* _device;
    private Context* _context;
    
    protected override bool LoadDevice()
    {
        _al = AL.GetApi();
        _alc = ALContext.GetApi();
        _device = _alc.OpenDevice(null);
        
        if (HandleError("Failed loading open device"))
            return false;

        if (!TryLoadEnumerating())
            LogInfo("Unable to load enumerating ext");
        
        if (!TryLoadCapture())
            LogInfo("Unable to load capturing ext");
        
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