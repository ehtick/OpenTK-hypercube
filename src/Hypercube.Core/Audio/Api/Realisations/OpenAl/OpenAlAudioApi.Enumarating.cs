using System.Diagnostics.CodeAnalysis;
using Silk.NET.OpenAL.Extensions.Enumeration;

namespace Hypercube.Core.Audio.Api.Realisations.OpenAl;

public sealed unsafe partial class OpenAlAudioApi
{
    private Enumeration? _enumerationExtension;
    
    private IReadOnlyList<string> DeviceSpecifiers
    {
        get
        {
            if (_captureExtension is null)
            {
                LogError("Capture extension is not loaded.");
                return [];
            }
            
            if (!TryGetStringList(GetEnumerationContextStringList.DeviceSpecifiers, out var devices))
                return [];
            
            return devices.ToList();
        }
    }
    
    private bool TryLoadEnumerating()
    {
        if (!_alc.TryGetExtension<Enumeration>(_device, out _enumerationExtension))
            return false;
   
        return true;
    }

    private bool TryGetStringList(GetEnumerationContextStringList type, [NotNullWhen(true)] out IEnumerable<string>? list)
    {
        list = null;
        if (_enumerationExtension is null)
            return false;
        
        list = _enumerationExtension.GetStringList(type);
        
        return true;
    }
}