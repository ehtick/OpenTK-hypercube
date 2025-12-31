namespace Hypercube.Core.Graphics.Rendering.Shaders;

public abstract partial class BaseShaderProgram
{
    protected abstract void InternalUseProgram(ShaderProgramHandle handle);
    protected abstract void InternalLabel(string name);
    protected abstract void InternalDelete(ShaderProgramHandle handle);
}