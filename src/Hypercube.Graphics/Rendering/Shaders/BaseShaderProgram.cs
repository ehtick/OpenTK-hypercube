using Hypercube.Mathematics;
using Hypercube.Mathematics.Matrices;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Graphics.Rendering.Shaders;

public abstract partial class BaseShaderProgram : IShaderProgram
{
    public uint Handle { get; }

    protected BaseShaderProgram(uint handle)
    {
        Handle = handle;
    }

    public void Use()
    {
        throw new NotImplementedException();
    }

    public void Stop()
    {
        throw new NotImplementedException();
    }

    public void SetUniform(string name, int value)
    {
        throw new NotImplementedException();
    }

    public void SetUniform(string name, float value)
    {
        throw new NotImplementedException();
    }

    public void SetUniform(string name, double value)
    {
        throw new NotImplementedException();
    }

    public void SetUniform(string name, Vector2 value)
    {
        throw new NotImplementedException();
    }

    public void SetUniform(string name, Vector2i value)
    {
        throw new NotImplementedException();
    }

    public void SetUniform(string name, Vector3 value)
    {
        throw new NotImplementedException();
    }

    public void SetUniform(string name, Vector3i value)
    {
        throw new NotImplementedException();
    }

    public void SetUniform(string name, Vector4 value)
    {
        throw new NotImplementedException();
    }

    public void SetUniform(string name, Matrix3x3 value, bool transpose = false)
    {
        throw new NotImplementedException();
    }

    public void SetUniform(string name, Matrix4x4 value, bool transpose = false)
    {
        throw new NotImplementedException();
    }

    public void SetUniform(string name, Color value)
    {
        throw new NotImplementedException();
    }

    public void Label(string name)
    {
        InternalLabel(name);
    }

    public void Dispose()
    {
        // TODO release managed resources here
    }
}