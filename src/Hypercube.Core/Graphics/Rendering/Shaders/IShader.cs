namespace Hypercube.Core.Graphics.Rendering.Shaders;

/// <summary>
/// Part of the shader <see cref="IShaderProgram"/>, basically
/// a fragment or vertex shader.
/// </summary>
public interface IShader : IDisposable
{
    ShaderHandle Handle { get; }
    ShaderType Type { get; }
}