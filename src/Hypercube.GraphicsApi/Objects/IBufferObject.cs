using Hypercube.GraphicsApi.GlApi.Enum;

namespace Hypercube.GraphicsApi.Objects;

public interface IBufferObject : IDisposable
{
    int Handle { get; }
    void Bind();
    void Unbind();
    void Delete();
    void Label(string name);
    
    // TODO: Fuck me pls
    public void SetData(int size, nint data, BufferUsageHint hint = BufferUsageHint.StaticDraw);
    public void SetData<T>(T[] data, BufferUsageHint hint = BufferUsageHint.StaticDraw)
        where T : unmanaged;
    
    public void SetSubData(int size, nint data);
    public void SetSubData<T>(T[] data)
        where T : unmanaged;
}