using Hypercube.Graphics.Rendering.Batching;

namespace Hypercube.Graphics.Rendering.Api;

public abstract partial class BaseRenderingApi
{
    protected abstract string InternalInfo { get; }
    
    protected abstract bool InternalInit(IContextInfo contextInfo);
    protected abstract void InternalTerminate();
    protected abstract void InternalRender(Batch batch);
    protected abstract void InternalRenderSetup();
    protected abstract void InternalRenderSetupData(Vertex[] vertices, uint[] indices);
    protected abstract void InternalRenderUnsetup();
}