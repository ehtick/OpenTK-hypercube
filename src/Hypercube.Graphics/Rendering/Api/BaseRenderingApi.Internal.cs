using Hypercube.Graphics.Rendering.Batching;
using Hypercube.Graphics.Rendering.Shaders;
using Hypercube.Resources.Storage;

namespace Hypercube.Graphics.Rendering.Api;

public abstract partial class BaseRenderingApi
{
    protected abstract string InternalInfo { get; }
    
    protected abstract bool InternalInit(IContextInfo contextInfo);
    protected abstract void InternalLoad(IResourceStorage resourceStorage);
    protected abstract void InternalTerminate();
    protected abstract void InternalRender(Batch batch);
    protected abstract void InternalRenderSetup();
    protected abstract void InternalRenderSetupData(Vertex[] vertices, uint[] indices);
    protected abstract void InternalRenderUnsetup();

    protected abstract IShader InternalCreateShader(string source, ShaderType type);
    protected abstract IShaderProgram InternalCreateShaderProgram(IEnumerable<IShader> shaders);
    protected abstract IShaderProgram InternalCreateShaderProgram(List<IShader> shaders);
}