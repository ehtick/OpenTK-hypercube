using System.Diagnostics;
using System.Runtime.InteropServices;
using Hypercube.GraphicsApi.GlApi.Enum;
using Hypercube.GraphicsApi.Objects;

namespace Hypercube.GraphicsApi.GlApi.Objects;

[DebuggerDisplay("{Handle} ({BufferTargetName})")]
public class BufferObject : IBufferObject
{
    public int Handle { get; } = Gl.GenBuffer();
    private readonly BufferTarget _bufferTarget;
    
    private bool _bound;
    
    private string BufferTargetName => System.Enum.GetName(_bufferTarget) ?? _bufferTarget.ToString();

    public BufferObject(BufferTarget target)
    {
        _bufferTarget = target;
    }

    public void Bind()
    {
        if (_bound)
            return;

        _bound = true;
        Gl.BindBuffer(_bufferTarget, Handle);
    }

    public void Unbind()
    {
        if (!_bound)
            return;

        _bound = false;
        Gl.UnbindBuffer(_bufferTarget);
    }

    public void Delete()
    {
        Gl.DeleteBuffer(Handle);
    }
    
    public void SetData(int size, nint data, BufferUsageHint hint = BufferUsageHint.StaticDraw)
    {
        Bind();
        Gl.BufferData(_bufferTarget, size, data, hint);
    }

    public void SetData<T>(T[] data, BufferUsageHint hint = BufferUsageHint.StaticDraw)
        where T : unmanaged
    {
        Bind();
        Gl.BufferData(_bufferTarget, data.Length * Marshal.SizeOf(default(T)), data, hint);
    }

    public void SetSubData(int size, nint data)
    {
        Bind();
        Gl.BufferSubData(_bufferTarget, nint.Zero, size, data);
    }
    
    public void SetSubData<T>(T[] data)
        where T : unmanaged
    {
        Bind();
        Gl.BufferSubData(_bufferTarget, nint.Zero, data.Length * Marshal.SizeOf<T>(), data);
    }
    
    public void Label(string name)
    {
        Bind();
        Gl.ObjectLabel(LabelIdentifier.Buffer, Handle, name);
    }

    public void Dispose()
    {
        Delete();
    }
}