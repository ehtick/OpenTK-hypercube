using Hypercube.Core.Graphics.Objects.Texturing;
using Hypercube.Core.Windowing.Windows;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Core.Windowing.Api;

/// <summary>
/// A layer between the API for handling windows, events, input and context and the engine.
/// </summary>
[PublicAPI]
public partial interface IWindowingApi : IDisposable, IContextInfoProvider
{
    WindowingApi Type { get; }

    bool Initialized { get; }
    bool Terminated { get; }
    
    IReadOnlyList<WindowHandle> Windows { get; }
    WindowHandle? MainWindow { get; }
    WindowHandle Context { get; set; }

    IReadOnlyList<MonitorHandler> Monitors { get; }

    #region Life cycle

    void Init();
    void EnterLoop();
    void PollEvents();
    void Terminate();
    
    #endregion

    #region Window

    void WindowSetTitle(WindowHandle window, string title);
    void WindowSetPosition(WindowHandle window, Vector2i position);
    void WindowSetSize(WindowHandle window, Vector2i size);
    void WindowSetFramebufferSize(WindowHandle window, Vector2i size);
    void WindowSetIcon(WindowHandle window, IImage icon);
    
    WindowHandle WindowCreateSync(WindowCreateSettings settings);
    
    void WindowSwapBuffers(WindowHandle window);
    
    void WindowDestroy(WindowHandle window);

    #endregion
    
    void SwapInterval(int interval);
}