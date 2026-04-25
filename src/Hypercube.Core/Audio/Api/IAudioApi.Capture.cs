namespace Hypercube.Core.Audio.Api;

public partial interface IAudioApi
{
    IReadOnlyList<string> CaptureDevices { get; }
    bool IsRecording { get; }
    
    bool OpenCaptureDevice(string? deviceName, int sampleRate, int channels, int bufferSize);
    void CloseCaptureDevice();

    void StartRecording();
    void StopRecording();
    
    int GetRecordedSampleCount();
    int ReadRecordedData(float[] buffer, int offset, int count);
    
    AudioData GetRecordedAudioData();
}
