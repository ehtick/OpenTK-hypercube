using System.Text;
using Hypercube.Core.Windowing.Api;
using Hypercube.Core.Windowing.Monitors.Data;

namespace Hypercube.Core.Windowing.Monitors;

public sealed class Monitor : IMonitor
{
    public IWindowingApi Api { get; }
    public MonitorHandle Handle { get; }
    
    public string Name { private set; get; } = string.Empty;
    public bool Primary { private set; get; }
    
    public Vector2 Position { private set; get; }
    public Vector2 PhysicalSize { private set; get; }
    public Vector2 Dpi { private set; get; }
    public Vector2 ContentScale { get; }
    
    public WorkArea WorkArea { private set; get; }
    
    public VideoMode CurrentVideoMode { private set; get; }
    public IReadOnlyCollection<VideoMode> VideoModes { private set; get; } = [];

    private Monitor(IWindowingApi api, MonitorHandle handle)
    {
        Api = api;
        Handle = handle;
    }
    
    public Monitor(IWindowingApi api, MonitorHandle handle, MonitorCreateSettings settings) : this(api, handle)
    {
        Name = settings.Name;
        Primary = settings.Primary;
        
        Position = settings.Position;
        PhysicalSize = settings.PhysicalSize;
        Dpi = settings.Dpi;
        ContentScale = settings.ContentScale;
        
        WorkArea = settings.WorkArea;
        
        CurrentVideoMode = settings.CurrentVideoMode;
        VideoModes = settings.VideoModes;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"{Name} [0x{Handle:x8}]:");
        sb.AppendLine($"  Primary        : {Primary}");
    
        sb.AppendLine($"  Position       : {Position}");
        sb.AppendLine($"  Physical Size  : {PhysicalSize}");
        sb.AppendLine($"  DPI            : {Dpi}");
        sb.AppendLine($"  Content Scale  : {ContentScale}");
    
        sb.AppendLine($"  Work Area      : {WorkArea}");
    
        sb.AppendLine($"  Current Mode   : {CurrentVideoMode}");
    
        sb.AppendLine($"  Video Modes ({VideoModes.Count}):");
        foreach (var mode in VideoModes)
        {
            sb.AppendLine($"  - {mode}");
        }

        return sb.ToString();
    }
}
