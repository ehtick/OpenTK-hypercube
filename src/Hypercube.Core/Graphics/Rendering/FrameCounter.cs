using System.Diagnostics;

namespace Hypercube.Core.Graphics.Rendering;

[PublicAPI]
public sealed class FrameCounter
{
    private const double SmoothFactor = 0.1;
    
    private readonly Stopwatch _stopwatch = new();
    
    private double _periodTime;
    private int _periodFrames;
    private double _periodMinDelta = double.MaxValue;
    private double _periodMaxDelta = double.MinValue;
    private double _lastTime;
    private double _smoothDeltaTime;
    
    public double Fps { get; private set; }
    public double DeltaTime { get; private set; }
    public double FrameTimeMs => DeltaTime * 1000;
    public double MinFps { get; private set; }
    public double MaxFps { get; private set; }
    public double AvgFps { get; private set; }
    
    public void Start()
    {
        _stopwatch.Start();
        _lastTime = _stopwatch.Elapsed.TotalSeconds;
    }

    public void Update()
    {
        var currentTime = _stopwatch.Elapsed.TotalSeconds;
        
        DeltaTime = currentTime - _lastTime;
        _lastTime = currentTime;
        
        _smoothDeltaTime = _smoothDeltaTime * (1.0 - SmoothFactor) + (DeltaTime * SmoothFactor);
        
        if (_smoothDeltaTime > 0)
            Fps = 1.0 / _smoothDeltaTime;
        
        _periodFrames++;
        _periodTime += DeltaTime;
        
        if (DeltaTime < _periodMinDelta)
            _periodMinDelta = DeltaTime;
        
        if (DeltaTime > _periodMaxDelta)
            _periodMaxDelta = DeltaTime;

        if (_periodTime < 1.0)
            return;
        
        AvgFps = _periodFrames / _periodTime;
            
        MinFps = 1.0 / _periodMaxDelta;
        MaxFps = 1.0 / _periodMinDelta;
            
        _periodTime = 0;
        _periodFrames = 0;
        _periodMinDelta = double.MaxValue;
        _periodMaxDelta = double.MinValue;
    }
}