using Hypercube.Core.Graphics.Rendering.Api.Components;
using Hypercube.Core.Graphics.Rendering.Api.Handlers;
using Hypercube.Core.Graphics.Rendering.Api.Settings;
using Hypercube.Core.Graphics.Rendering.Batching;
using Hypercube.Core.Graphics.Rendering.Shaders;
using Hypercube.Core.Windowing;
using Hypercube.Core.Windowing.Api;
using Hypercube.Mathematics;
using Hypercube.Mathematics.Matrices;
using Hypercube.Mathematics.Shapes;
using InitHandler = Hypercube.Core.Graphics.Rendering.Api.Handlers.InitHandler;

namespace Hypercube.Core.Graphics.Rendering.Api;

public abstract partial class BaseRenderingApi : IRenderingApi
{
    public abstract RenderingApi Type { get; }
    
    public event InitHandler? OnInit;
    public abstract event DrawHandler? OnDraw;
    public abstract event DebugInfoHandler? OnDebugInfo;

    public IShaderProgram? PrimitiveShaderProgram { get; protected set; }
    public IShaderProgram? TexturingShaderProgram { get; protected set; }
    public int BatchVerticesIndex { get; protected set; }
    public int BatchIndicesIndex { get; protected set; }

    protected readonly IWindowingApi WindowingApi;
    protected readonly List<Batch> Batches = [];
    protected readonly Vertex[] BatchVertices;
    protected readonly uint[] BatchIndices;
    private BatchData? _currentBatchData;

    protected Color ClearColor { get; private set; }

    public int BatchCount { get; private set; }
    public int VerticesCount { get; private set; }

    protected BaseRenderingApi(RenderingApiSettings settings, IWindowingApi windowingApi)
    {
        ClearColor = settings.ClearColor;
        BatchVertices = new Vertex[settings.MaxVertices];
        BatchIndices = new uint[settings.MaxIndices];
        WindowingApi = windowingApi;
    }

    public void Init(IContextInfo context)
    {
        if (!InternalInit(context))
            throw new Exception();
        
        OnInit?.Invoke(InternalInfo);
    }

    public void Load()
    {
        InternalLoad();
    }

    public void Terminate()
    {
        InternalTerminate();
    }

    public abstract void Render(IWindow window);

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

        _currentBatchData = new BatchData(BatchIndicesIndex, texture, shader, topology);
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
        BatchVertices[BatchVerticesIndex++] = vertex;
    }

    public void PushIndex(uint start,uint offset)
    {
        // TODO: Add clamping and warning for index
        BatchIndices[BatchIndicesIndex++] = start + offset;
    }

    public void PushIndex(int start, int index)
    {
        PushIndex((uint) start, (uint) index);
    }

    public IShaderProgram CreateShaderProgram(string source)
    {
        var sections = RenderingApiShaderLoader.ParseSections(source);
        var shaders = new IShader[sections.Count];

        var index = 0;
        foreach (var section in sections)
        {
            shaders[index++] = InternalCreateShader(section.Source, section.Type);
        }
        
        return InternalCreateShaderProgram(shaders);
    }

    public abstract void SetScissor(bool value);
    public abstract void SetScissorRect(Rect2i rect);

    protected void UpdateBatchCount()
    {
        BatchCount = Batches.Count;
        VerticesCount = BatchVerticesIndex;
    }
    
    protected void Clear()
    {
        // TODO: optimize
        Array.Clear(BatchVertices, 0, BatchVerticesIndex);
        Array.Clear(BatchIndices, 0, BatchIndicesIndex);

        BatchVerticesIndex = 0;
        BatchIndicesIndex = 0;
        
        _currentBatchData = null;
        Batches.Clear();
    }
    
    private void GenerateBatch()
    {
        if (_currentBatchData is null)
            throw new NullReferenceException();

        var data = _currentBatchData.Value;
        var currentIndex = BatchIndicesIndex;

        var batch = new Batch(
            data.Start,
            currentIndex - data.Start,
            data.Texture,
            data.PrimitiveTopology,
            Matrix4x4.Identity,
            WindowingApi.Context
        );

        Batches.Add(batch);
    }
}