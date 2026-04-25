using Hypercube.Core.Windowing.Api;

namespace Hypercube.Core.Windowing.Monitors;

public partial interface IMonitor
{
    /// <summary>
    /// Gets the internal windowing API implementation.
    /// </summary>
    /// <remarks>
    /// This property is intended for engine-level access only.
    /// </remarks>
    [EngineInternal]
    IWindowingApi Api { get; }
    
    /// <summary>
    /// Gets the native monitor handle.
    /// </summary>
    /// <remarks>
    /// This property is intended for engine-level access only.
    /// </remarks>
    [EngineInternal]
    MonitorHandle Handle { get; }
}
