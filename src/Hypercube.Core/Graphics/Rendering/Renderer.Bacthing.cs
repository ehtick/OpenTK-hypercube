using Hypercube.Core.Graphics.Rendering.Batching;

namespace Hypercube.Core.Graphics.Rendering;

public partial class Renderer
{
    private readonly List<Batch> _batches = [];
    
    private Vertex[] _batchVertices;
    private int _batchVertexIndex;
    
    private uint[] _batchIndices;
    private int _batchIndexIndex;

    private void InitBatching()
    {
        _batchVertices = new Vertex[Config.RenderBatchingMaxVertices];
        _batchIndices = new uint[Config.RenderBatchingMaxVertices * Config.RenderBatchingIndicesPerVertex];
    }
    
    private void SetupRender()
    {

    }
}