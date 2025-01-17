using Hypercube.Graphics.Rendering.Batching;
using Hypercube.Graphics.Rendering.Shaders;
using Hypercube.Graphics.Windowing;
using Hypercube.Mathematics;
using Hypercube.Mathematics.Matrices;
using Hypercube.Resources.Storage;

namespace Hypercube.Graphics.Rendering.Api;

public abstract partial class BaseRenderingApi : IRenderingApi
{
    public event InitHandler? OnInit;

    protected Color ClearColor { get; private set; } = Color.Black;
    
    private readonly List<Batch> _batches = [];

    private Vertex[] _batchVertices = [];
    private int _batchVerticesIndex;

    private uint[] _batchIndices = [];
    private int _batchIndicesIndex;
    
    private BatchData? _currentBatchData;
    
    public void Init(IContextInfo context, RenderingApiSettings settings)
    {
        ClearColor = settings.ClearColor;
        
        _batchVertices = new Vertex[settings.MaxVertices];
        _batchIndices = new uint[settings.MaxIndices];

        if (!InternalInit(context))
            throw new Exception();
        
        OnInit?.Invoke(InternalInfo);
    }

    public void Load()
    {
        throw new NotImplementedException();
    }

    public void Load(IResourceStorage resourceStorage)
    {
        InternalLoad(resourceStorage);
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

    public void EnsureBatch(PrimitiveTopology topology, uint shader, uint? texture)
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

    public void PushIndex(uint offset)
    {
        // TODO: Add clamping and warning for index
        _batchIndices[_batchIndicesIndex++] = (uint) _batchVerticesIndex + offset;
    }

    public void PushIndex(int index)
    {
        PushIndex((uint) index);
    }

    public IShader CreateShader(string source, ShaderType type)
    {
        return InternalCreateShader(source, type);
    }

    public IShaderProgram CreateShaderProgram(Dictionary<ShaderType, string> shaderSources)
    {
        var shaders = new IShader[shaderSources.Count];

        var index = 0;
        foreach (var (type, source) in shaderSources)
        {
            shaders[index++] = CreateShader(source, type);
        }
        
        return InternalCreateShaderProgram(shaders);
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