using Hypercube.Graphics.Rendering.Api;
using Hypercube.Graphics.Rendering.Shaders;
using Hypercube.Graphics.Windowing;

namespace Hypercube.Graphics.Rendering.Manager;

public interface IRenderManager
{
    void Init(IContextInfo context, RenderingApiSettings settings);
    void Load();
    void Shutdown();
    void Render(IWindow window);
    
    IShaderProgram CreateShaderProgram(Dictionary<ShaderType, string> shaderSources);
}