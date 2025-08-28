using Hypercube.Core.Graphics.Rendering.Api;
using Hypercube.Core.Graphics.Rendering.Api.Handlers;
using Hypercube.Core.Graphics.Rendering.Api.Settings;
using Hypercube.Core.Graphics.Rendering.Shaders;
using Hypercube.Core.Windowing;

namespace Hypercube.Core.Graphics.Rendering.Manager;

public interface IRenderManager
{
    event DrawHandler? OnDraw;
    
    [EngineInternal]
    IRenderingApi Api { get; }
    int BatchCount { get; }
    int VerticesCount { get; }
    double Fps { get; }
    
    void Init(IContextInfo context, RenderingApiSettings settings);
    void Load();
    void Shutdown();
    void Render(IWindow window);
    
    IShaderProgram CreateShaderProgram(string source);
}