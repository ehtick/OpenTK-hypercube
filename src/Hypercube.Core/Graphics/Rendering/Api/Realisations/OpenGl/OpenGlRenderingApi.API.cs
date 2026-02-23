using Hypercube.Core.Graphics.Rendering.Shaders;

namespace Hypercube.Core.Graphics.Rendering.Api.Realisations.OpenGl;

public sealed partial class OpenGlRenderingApi
{
    public IShader CreateShader(string source, ShaderType type) => InternalCreateShader(source, type);
    public IShaderProgram CreateShaderProgram(IEnumerable<IShader> shaders) => InternalCreateShaderProgram(shaders);
    public IShaderProgram CreateShaderProgram(List<IShader> shaders) => InternalCreateShaderProgram(shaders);
}