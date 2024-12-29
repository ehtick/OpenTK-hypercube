namespace Hypercube.GraphicsApi.Objects;

public interface IArrayObject : IDisposable
{
    int Handle { get; }
    void Bind();
    void Unbind();
    void Delete();
    void Label(string name);
    void DrawElements(int start, int count);
}