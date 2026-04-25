using Silk.NET.OpenAL;
using Silk.NET.OpenAL.Extensions.EXT;

namespace Hypercube.Core.Audio.Api.Realisations.OpenAl;

public sealed unsafe partial class OpenAlAudioApi
{
    private Capture? _captureExtension;
    
    private Device* _captureDevice;
    private CaptureDeviceMetaData _captureDeviceMetaData;
    
    private bool _capturing;
    
    public override IReadOnlyList<string> CaptureDevices => DeviceSpecifiers;
    public override bool IsRecording => _captureDevice is not null && _capturing;
    
    public override bool OpenCaptureDevice(string? deviceName, int sampleRate, int channels, int bufferSize)
    {
        if (_captureExtension is null)
        {
            LogError("Capture extension is not loaded.");
            return false;
        }
        
        var format = channels switch
        {
            1 => BufferFormat.Mono16,
            2 => BufferFormat.Stereo16,
            _ => throw new NotSupportedException($"Unsupported channel count: {channels}")
        };

        _captureDeviceMetaData = new CaptureDeviceMetaData((AudioFormat) format, sampleRate, bufferSize);
        _captureDevice = _captureExtension.CaptureOpenDevice(deviceName, (uint) sampleRate, format, bufferSize);
        
        if (_captureDevice is not null)
            return true;
        
        LogError($"Failed to open capture device '{deviceName}'");
        return false;
    }

    public override void CloseCaptureDevice()
    {
        if (_captureExtension is null)
        {
            LogError("Capture extension is not loaded.");
            return;
        }
        
        if (_captureDevice is null)
        {
            LogError("No capture device opened.");
            return;
        }
    
        if (IsRecording)
            StopRecording();
    
        _captureExtension.CaptureCloseDevice(_captureDevice);
        _captureDevice = null;
    }


    public override void StartRecording()
    {
        if (_captureExtension is null)
        {
            LogError("Capture extension is not loaded.");
            return;
        }
        
        if (_captureDevice is null)
        {
            LogError("No capture device opened.");
            return;
        }

        _captureExtension.CaptureStart(_captureDevice);
        _capturing = true;
    }

    public override void StopRecording()
    {
        if (_captureExtension is null)
        {
            LogError("Capture extension is not loaded.");
            return;
        }
        
        if (_captureDevice is null)
        {
            LogError("No capture device opened.");
            return;
        }

        _captureExtension.CaptureStop(_captureDevice);
        _capturing = false;
    }

    public override int GetRecordedSampleCount()
    {
        if (_captureExtension is null)
        {
            LogError("Capture extension is not loaded.");
            return 0;
        }
        
        if (_captureDevice is null)
        {
            LogError("No capture device opened.");
            return 0;
        }
        
        return _captureExtension.GetAvailableSamples(_captureDevice);
    }

    public override int ReadRecordedData(float[] buffer, int offset, int count)
    {
        throw new NotImplementedException();
    }

    public override AudioData GetRecordedAudioData()
    {
        throw new NotImplementedException();
    }

    private bool TryLoadCapture()
    {
        if (_alc.TryGetExtension<Capture>(_device, out _captureExtension))
            return true;
            
        LogError("Failed to load Capture extension");
        return false;
    }
}

[PublicAPI]
public readonly struct CaptureDeviceMetaData
{
    public readonly AudioFormat AudioFormat;
    public readonly int SampleRate;
    public readonly int BufferSize;
    
    public CaptureDeviceMetaData(AudioFormat audioFormat, int sampleRate, int bufferSize)
    {
        AudioFormat = audioFormat;
        SampleRate = sampleRate;
        BufferSize = bufferSize;
    }
}