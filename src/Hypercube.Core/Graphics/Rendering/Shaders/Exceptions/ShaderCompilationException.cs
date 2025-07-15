namespace Hypercube.Core.Graphics.Rendering.Shaders.Exceptions;

public class ShaderCompilationException : Exception
{
    public ShaderCompilationException(uint handle, string info) : base($"Error occurred whilst compiling shader: {handle}.\n\r{info}")
    {
    }
}