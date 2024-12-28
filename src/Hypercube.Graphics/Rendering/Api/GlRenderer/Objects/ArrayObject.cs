using System.Diagnostics;
using Hypercube.GraphicsApi.GlApi;

namespace Hypercube.Graphics.Rendering.Api.GlRenderer.Objects;

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
        Gl.LabelVertexArray(Handle, name);
    }

    public void DrawElements(int start, int count)
    {
        Gl.DrawElements(start, count);
    }

    public void Dispose()
    {
        Delete();
    }
}