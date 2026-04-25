using Hypercube.Core.Windowing.Api;

namespace Hypercube.Core.Windowing.Windows;

public partial interface IWindow
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
    /// Gets the native window handle.
    /// </summary>
    /// <remarks>
    /// This property is intended for engine-level access only.
    /// </remarks>
    [EngineInternal]
    WindowHandle Handle { get; }
    
    /// <summary>
    /// Gets the current graphics context associated with this window.
    /// </summary>
    /// <remarks>
    /// This property is intended for engine-level access only.
    /// </remarks>
    [EngineInternal]
    WindowHandle Context { get; }
}
