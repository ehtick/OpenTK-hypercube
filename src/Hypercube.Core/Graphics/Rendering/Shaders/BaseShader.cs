using System.Diagnostics;

namespace Hypercube.Core.Graphics.Rendering.Shaders;

[DebuggerDisplay("Shader {Handle} ({TypeName})")]
public abstract partial class BaseShader : IShader
{
    public uint Handle { get; }
    public ShaderType Type { get; }

    private string TypeName => Enum.GetName(Type) ?? Type.ToString();

    protected BaseShader(uint handle, ShaderType type)
    {
        Handle = handle;
        Type = type;
    }
    
    public void Dispose()
    {
        InternalDelete();
    }
}