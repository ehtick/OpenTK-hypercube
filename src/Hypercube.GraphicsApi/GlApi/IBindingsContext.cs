namespace Hypercube.GraphicsApi.GlApi;

public interface IBindingsContext
{
    nint GetProcAddress(string procName);
}