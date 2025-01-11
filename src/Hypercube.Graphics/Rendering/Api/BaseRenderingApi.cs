using Hypercube.Graphics.Rendering.Batching;
using Hypercube.Graphics.Windowing;
using Hypercube.Mathematics.Matrices;

namespace Hypercube.Graphics.Rendering.Api;

public abstract partial class BaseRenderingApi : IRenderingApi
{
    public event InitHandler? OnInit;
    
    private readonly List<Batch> _batches = [];

    private Vertex[] _batchVertices = [];
    private int _batchVerticesIndex;

    private uint[] _batchIndices = [];
    private int _batchIndicesIndex;
    
    private BatchData? _currentBatchData;
    
    public void Init(IContextInfo context, RenderingApiSettings settings)
    {
        _batchVertices = new Vertex[settings.MaxVertices];
        _batchIndices = new uint[settings.MaxIndices];
        
        if (!InternalInit(context))
            throw new Exception();
        
        OnInit?.Invoke(InternalInfo);
    }

    public void Terminate()
    {
        InternalTerminate();
    }

    public void Render(IWindow window)
    {
        Clear();
        BreakCurrentBatch();
        
        InternalRenderSetup();
        InternalRenderSetupData(_batchVertices, _batchIndices);
        
        foreach (var batch in _batches)
        {
            InternalRender(batch);
        }

        InternalRenderUnsetup();
        
        window.SwapBuffers();
    }

    public void EnsureBatch(PrimitiveTopology topology, int shader, int? texture)
    {
        if (_currentBatchData is not null)
        {
            // It's just similar batch,
            // we need changing nothing to render different things
            if (_currentBatchData.Value.Equals(topology, texture, shader))
                return;

            // Creating a real batch
            GenerateBatch();
        }

        _currentBatchData = new BatchData(_batchIndicesIndex, texture, shader, topology);
    }

    public void BreakCurrentBatch()
    {
        if (_currentBatchData is null)
            return;

        GenerateBatch();
        _currentBatchData = null;
    }
    
    public void PushVertex(Vertex vertex)
    {
        // TODO: Add clamping and warning for index
        _batchVertices[_batchVerticesIndex++] = vertex;
    }

    public void PushIndex(uint index)
    {
        // TODO: Add clamping and warning for index
        _batchIndices[_batchIndicesIndex++] = index;
    }

    public void PushIndex(int index)
    {
        PushIndex((uint) index);
    }
    
    private void Clear()
    {
        // TODO: optimize
        Array.Clear(_batchVertices, 0, _batchVerticesIndex);
        Array.Clear(_batchIndices, 0, _batchIndicesIndex);

        _batchVerticesIndex = 0;
        _batchIndicesIndex = 0;
        
        _currentBatchData = null;
        _batches.Clear();
    }
    
    private void GenerateBatch()
    {
        if (_currentBatchData is null)
            throw new NullReferenceException();

        var data = _currentBatchData.Value;
        var currentIndex = _batchIndicesIndex;

        var batch = new Batch(
            data.Start,
            currentIndex - data.Start,
            data.Texture,
            data.PrimitiveTopology,
            Matrix4x4.Identity);

        _batches.Add(batch);
    }
}