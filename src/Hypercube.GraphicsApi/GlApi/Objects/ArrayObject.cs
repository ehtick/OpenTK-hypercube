using System.Diagnostics;
using Hypercube.GraphicsApi.GlApi.Enum;
using Hypercube.GraphicsApi.Objects;

namespace Hypercube.GraphicsApi.GlApi.Objects;

[DebuggerDisplay("{Handle}")]
public class ArrayObject : IArrayObject
{
    public int Handle { get; } = Gl.GenVertexArray();
    private bool _bound;

    public void Bind()
    {
        if (_bound)
            return;

        _bound = true;
        Gl.BindVertexArray(Handle);
    }

    public void Unbind()
    {
        if (!_bound)
            return;

        _bound = false;
        Gl.BindVertexArray(Gl.NullArray);
    }

    public void Delete()
    {
        Gl.DeleteVertexArray(Handle);
    }

    public void Label(string name)
    {
        Bind();
        Gl.ObjectLabel(LabelIdentifier.VertexArray, Handle, name);
    }

    public void DrawElements(int count, int start)
    {
        Gl.DrawElements(count, start);
    }

    public void Dispose()
    {
        Delete();
    }
}