using Hypercube.Core.Graphics.Rendering.Shaders;
using Hypercube.Core.Graphics.Texturing;
using Hypercube.Core.Windowing;

namespace Hypercube.Core.Graphics.Rendering.Api;

public abstract partial class BaseRenderingApi
{
    public abstract TextureHandle CreateTexture(int width, int height, int channels, byte[] data);
    public abstract void DeleteTexture(TextureHandle handle);
    
    protected abstract string InternalInfo { get; }
    
    protected abstract bool InternalInit(IContextInfo contextInfo);
    protected abstract void InternalLoad();
    protected abstract void InternalTerminate();

    protected abstract IShader InternalCreateShader(string source, ShaderType type);
    protected abstract IShaderProgram InternalCreateShaderProgram(IEnumerable<IShader> shaders);
    protected abstract IShaderProgram InternalCreateShaderProgram(List<IShader> shaders);
}