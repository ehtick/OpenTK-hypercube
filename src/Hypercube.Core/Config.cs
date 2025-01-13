using Hypercube.Graphics;
using Hypercube.GraphicsApi;
using Hypercube.Utilities.Configuration;

namespace Hypercube.Core;

[Config("engine.json")]
public static class Config
{
    /**
     * Mounting
     */

    public static readonly ConfigField<Dictionary<string, string>> MountFolders =
        new("MountFolders", new Dictionary<string, string> 
        {
            { ".", "/" },
            { "resources", "/" },
            { "resources/audio", "/" },
            { "resources/textures", "/" },
            { "resources/shaders", "/" },
        });
    
    /** 
     * API
     */
    
    public static readonly ConfigField<WindowingApi> Windowing =
        new("Windowing", WindowingApi.Glfw);
    
    public static readonly ConfigField<RenderingApi> Rendering =
        new("Rendering", RenderingApi.OpenGl);
    
    /**
     * Render threading
     */
    
    public static readonly ConfigField<bool> RenderThreading =
        new("RenderThreading", true);

    public static readonly ConfigField<string> RenderThreadName =
        new("RenderThreadName", "Windowing");
    
    public static readonly ConfigField<ThreadPriority> RenderThreadPriority =
        new("RenderThreadPriority", ThreadPriority.AboveNormal);
    
    public static readonly ConfigField<int> RenderThreadStackSize =
        new("RenderThreadStackSize", 8 * 1024 * 1024); // 8MByte
    
    public static readonly ConfigField<int> RenderThreadReadySleepDelay =
        new("RenderThreadReadySleepDelay", 10);
 
    /**
     *  Render batching
     */
   
    public static readonly ConfigField<int> RenderBatchingMaxVertices =
        new("RenderBatchingMaxVertices", 65532);
    
    public static readonly ConfigField<int> RenderBatchingIndicesPerVertex =
        new("RenderBatchingIndicesPerVertex", 6);
    
    /**
     * Main window
     */

    public static readonly ConfigField<string> MainWindowTitle =
        new("MainWindowTitle", "Hypercube window");
    
    public static readonly ConfigField<bool> MainWindowResizable =
        new("MainWindowResizable", true);
    
    public static readonly ConfigField<bool> MainWindowVisible =
        new("MainWindowVisible", true);
    
    public static readonly ConfigField<bool> MainWindowTransparentFramebuffer =
        new("MainWindowTransparentFramebuffer", false);
    
    public static readonly ConfigField<bool> MainWindowDecorated =
        new("MainWindowDecorated", true);
    
    public static readonly ConfigField<bool> MainWindowFloating =
        new("MainWindowFloating", true);
    
    //public static readonly ConfigField<Vector2i> MainWindowSize =
    //    new("MainWindowSize", new Vector2i(800, 600));
}