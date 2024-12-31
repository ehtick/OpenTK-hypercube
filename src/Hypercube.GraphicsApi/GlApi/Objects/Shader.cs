using Hypercube.GraphicsApi.Exceptions;
using Hypercube.GraphicsApi.GlApi.Enum;
using Hypercube.GraphicsApi.Objects;
using JetBrains.Annotations;

namespace Hypercube.GraphicsApi.GlApi.Objects;

[PublicAPI]
public class Shader : IShader
{
    public int Handle { get; }
    public ShaderType Type { get; }

    public Shader(string source, ShaderType type)
    {
        Handle = Gl.CreateShader(type);
        Type = type;
        
        Gl.ShaderSource(Handle, source);
        Gl.CompileShader(Handle);
    }

    public void Dispose()
    {
        Gl.DeleteShader(Handle);
    }

    private void Compile()
    {
        Gl.CompileShader(Handle);
        Gl.GetShader(Handle, ShaderParameter.CompileStatus, out var code);
        
        if (code == (int) All.True)
            return;
        
        var infoLog = Gl.GetShaderInfoLog(Handle);
        throw new ShaderCompilationException(Handle, infoLog);
    }
}