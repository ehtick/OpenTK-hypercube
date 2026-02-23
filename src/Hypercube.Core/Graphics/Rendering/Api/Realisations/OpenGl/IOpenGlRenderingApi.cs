using Hypercube.Core.Graphics.Rendering.Shaders;
using Silk.NET.OpenGL;

using ShaderType = Hypercube.Core.Graphics.Rendering.Shaders.ShaderType;

namespace Hypercube.Core.Graphics.Rendering.Api.Realisations.OpenGl;

public interface IOpenGlRenderingApi
{
    event Action OnBeforeBufferSwap;
    
    public GL Gl { get; }
    
    public OpenGlRenderingApi.ArrayObject GenArrayObject();
    public OpenGlRenderingApi.ArrayObject GenArrayObject(string label);
    public OpenGlRenderingApi.BufferObject GenBufferObject(BufferTargetARB target);
    public OpenGlRenderingApi.BufferObject GenBufferObject(BufferTargetARB target, string label);

    public IShader CreateShader(string source, ShaderType type);
    public IShaderProgram CreateShaderProgram(IEnumerable<IShader> shaders);
    public IShaderProgram CreateShaderProgram(List<IShader> shaders);
}