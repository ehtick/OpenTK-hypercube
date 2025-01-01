using System.Collections.Frozen;
using Hypercube.GraphicsApi.GlApi.Enum;
using Hypercube.GraphicsApi.Objects;
using Hypercube.Mathematics.Matrices;
using Hypercube.Mathematics.Vectors;
using JetBrains.Annotations;

namespace Hypercube.GraphicsApi.GlApi.Objects;

[PublicAPI]
public class ShaderProgram : IShaderProgram
{
    public int Handle { get; private set; }

    private readonly FrozenDictionary<string, int> _uniformLocations;

    public ShaderProgram(string vertSource, string fragSource)
    {
        var shaders = new[]
        {
            CreateShader(vertSource, ShaderType.VertexShader),
            CreateShader(fragSource, ShaderType.FragmentShader)
        };

        Handle = Gl.CreateProgram();

        foreach (var shader in shaders)
        {
            Attach(shader);
        }

        LinkProgram();

        // When the shader program is linked, it no longer needs the individual shaders attached to it; the compiled code is copied into the shader program.
        // Detach them, and then delete them.
        foreach (var shader in shaders)
        {
            Detach(shader);
        }

        _uniformLocations = GetUniformLocations();
    }

    public ShaderProgram(IEnumerable<KeyValuePair<ShaderType, string>> sources)
    {
        var shaders = new List<IShader>();
        foreach (var (type, shader) in sources)
        {
            shaders.Add(CreateShader(shader, type));
        }

        Handle = Gl.CreateProgram();
        
        foreach (var shader in shaders)
        {
            Attach(shader);
        }

        LinkProgram();

        // When the shader program is linked, it no longer needs the individual shaders attached to it; the compiled code is copied into the shader program.
        // Detach them, and then delete them.
        foreach (var shader in shaders)
        {
            Detach(shader);
        }

        _uniformLocations = GetUniformLocations();
    }

    public ShaderProgram(HashSet<IShader> shaders)
    {

        _uniformLocations = GetUniformLocations();
    }

    public void Use()
    {
        Gl.UseProgram(Handle);
    }

    public void Stop()
    {
        Gl.UseProgram(0);
    }

    public void Attach(IShader shader)
    {
        Gl.AttachShader(Handle, shader.Handle);
    }

    public void Detach(IShader shader)
    {
        Gl.DetachShader(Handle, shader.Handle);
    }
    
    public void SetUniform(string name, int value)
    {
        Gl.Uniform1i(_uniformLocations[name], value);
    }

    public void SetUniform(string name, float value)
    {
        Gl.Uniform1f(_uniformLocations[name], value);
    }

    public void SetUniform(string name, double value)
    {
        Gl.Uniform1d(_uniformLocations[name], value);
    }

    public void SetUniform(string name, Vector2 value)
    {
        Gl.Uniform2f(_uniformLocations[name], value.X, value.Y);
    }

    public void SetUniform(string name, Vector2i value)
    {
        Gl.Uniform2i(_uniformLocations[name], value.X, value.Y);
    }

    public void SetUniform(string name, Vector3 value)
    {
        Gl.Uniform3f(_uniformLocations[name], value.X, value.Y, value.Z);
    }

    public unsafe void SetUniform(string name, Matrix3x3 value, bool transpose = false)
    {
        var matrix = transpose ? Matrix3x3.Transpose(value) : new Matrix3x3(value);
        Gl.UniformMatrix3(Gl.GetUniformLocation(Handle, name), 1, false, (float*) &matrix);
    }

    public unsafe void SetUniform(string name, Matrix4x4 value, bool transpose = false)
    {
        var matrix = transpose ? Matrix4x4.Transpose(value) : new Matrix4x4(value);
        Gl.UniformMatrix4(Gl.GetUniformLocation(Handle, name), 1, false, (float*)&matrix);
    }

    public void Label(string name)
    {
        Gl.ObjectLabel(LabelIdentifier.Program, Handle, name);    
    }

    public void Dispose()
    {
        Gl.DeleteProgram(Handle);
    }

    private FrozenDictionary<string, int> GetUniformLocations()
    {
        var uniforms = Gl.GetProgram(Handle, ProgramParameter.ActiveUniforms);
       
        var uniformLocations = new Dictionary<string, int>();
        for (var i = 0; i < uniforms; i++)
        {
            Gl.GetActiveUniform(Handle, i, out _, out _, out _, out var key);
            
            var location = Gl.GetUniformLocation(Handle, key);
            uniformLocations.Add(key, location);
        }

        return uniformLocations.ToFrozenDictionary();
    }
    
    private void LinkProgram()
    {
        Gl.LinkProgram(Handle);
        
        var code = Gl.GetProgram(Handle, ProgramParameter.LinkStatus);
        if (code == GlNative.True)
            return;
        
        throw new Exception($"Error occurred whilst linking Program({Handle})");
    }

    public static IShader CreateShader(string source, ShaderType type)
    {
        return new Shader(source, type);
    }
}