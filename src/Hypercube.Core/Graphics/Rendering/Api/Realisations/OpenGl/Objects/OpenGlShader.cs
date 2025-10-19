using Hypercube.Core.Graphics.Rendering.Shaders;
using Hypercube.Core.Graphics.Rendering.Shaders.Exceptions;
using Silk.NET.OpenGL;
using ShaderType = Hypercube.Core.Graphics.Rendering.Shaders.ShaderType;

namespace Hypercube.Core.Graphics.Rendering.Api.Realisations.OpenGl.Objects;

public sealed class OpenGlShader : BaseShader
{
    private readonly GL _gl;
        
    public OpenGlShader(GL gl, uint handle, ShaderType type, string source) : base(handle, type)
    {
        _gl = gl;
        _gl.ShaderSource(Handle, source);
        _gl.CompileShader(Handle);
        _gl.GetShader(Handle, ShaderParameterName.CompileStatus, out var code);
        
        if (code == (int) GLEnum.True)
            return;

        var info = _gl.GetShaderInfoLog(Handle);
        throw new ShaderCompilationException(Handle, info);
    }

    protected override void InternalDelete()
    {
        _gl.DeleteShader(Handle);
    }
}
