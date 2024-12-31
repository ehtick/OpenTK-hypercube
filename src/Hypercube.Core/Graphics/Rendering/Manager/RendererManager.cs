using Hypercube.Core.Graphics.Windowing.Manager;
using Hypercube.Graphics;
using Hypercube.Graphics.Enums;
using Hypercube.Graphics.Rendering.Api;
using Hypercube.Graphics.Rendering.Batching;
using Hypercube.Graphics.Windowing;
using Hypercube.GraphicsApi;
using Hypercube.GraphicsApi.GlApi;
using Hypercube.GraphicsApi.GlApi.Enum;
using Hypercube.GraphicsApi.Objects;
using Hypercube.Mathematics;
using Hypercube.Mathematics.Matrices;
using Hypercube.Utilities.Debugging.Logger;
using Hypercube.Utilities.Dependencies;
using JetBrains.Annotations;
using PolygonFace = Hypercube.Graphics.Enums.PolygonFace;
using PolygonMode = Hypercube.Graphics.Enums.PolygonMode;

namespace Hypercube.Core.Graphics.Rendering.Manager;

[PublicAPI]
public class RendererManager : IRendererManager
{
    [Dependency] private readonly DependenciesContainer _container = default!;
    [Dependency] private readonly ILogger _logger = default!;

    private IRendererApi _rendererApi = default!;

    private readonly List<Batch> _batches = [];

    private Vertex[] _batchVertices = default!;
    private int _batchVertexIndex;

    private uint[] _batchIndices = default!;
    private int _batchIndexIndex;

    private IArrayObject _vao = default!;
    private IBufferObject _vbo = default!;
    private IBufferObject _ebo = default!;
    
    /// <summary>
    /// Contains info about currently running batch.
    /// </summary>
    private BatchData? _currentBatchData;

    public void Init(IBindingsContext context)
    {
        InitRenderApi(context);
        
        _batchVertices = new Vertex[Config.RenderBatchingMaxVertices];
        _batchIndices = new uint[Config.RenderBatchingMaxVertices * Config.RenderBatchingIndicesPerVertex];

        _vao = _rendererApi.GenArrayObject();
        _vbo = _rendererApi.GenBufferObject(BufferTarget.ArrayBuffer);
        _ebo = _rendererApi.GenBufferObject(BufferTarget.ElementArrayBuffer);
    }

    private void InitRenderApi(IBindingsContext context)
    {
        _rendererApi = ApiFactory.CreateApi(Config.Rendering);
        _container.Inject(_rendererApi);
        _rendererApi.Init(context);
        _logger.Info($"Render API info:\n\r{_rendererApi.Info}");
    }

    private void SetupRender()
    {
        _rendererApi.Enable(Feature.Blend);
        _rendererApi.Disable(Feature.ScissorTest);

        //GL.BlendEquation(BlendEquationMode.FuncAdd);
        //GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

        _rendererApi.SetPolygonMode(PolygonFace.FrontBack, PolygonMode.Fill);
        _rendererApi.ClearColor(Color.Black);
    }

    private void Clear()
    {
        Array.Clear(_batchVertices, 0, _batchVertexIndex);
        Array.Clear(_batchIndices, 0, _batchIndexIndex);

        _batchVertexIndex = 0;
        _batchIndexIndex = 0;
        
        _currentBatchData = null;
        _batches.Clear();
    }

    private void Render(WindowHandle window)
    {
        Clear();

        // GL.Viewport(window.Size);
        _rendererApi.Clear(ClearBufferMask.ColorBufferBit);
        
        BreakCurrentBatch();
        SetupRender();

        _vao.Bind();
        _vbo.SetData(_batchVertices);
        _ebo.SetData(_batchIndices);

        foreach (var batch in _batches)
        {
            Render(batch);
        }

        _vao.Unbind();
        _vbo.Unbind();
        _ebo.Unbind();
        
        // var evUI = new RenderAfterDrawingEvent();
        // _eventBus.Raise(ref evUI);
        
        // _windowing.WindowSwapBuffers(window);
    }

    private void Render(Batch batch)
    {
        // var shader = _primitiveShaderProgram;
        // if (batch.TextureHandle is not null)
        // {
        //    GL.ActiveTexture(TextureUnit.Texture0);
        //    GL.BindTexture(TextureTarget.Texture2D, batch.TextureHandle.Value);
        //    shader = _texturingShaderProgram;
        // }

        // shader.Use();
        // shader.SetUniform("model", batch.Model);
        // shader.SetUniform("view", _cameraManager.View);
        // shader.SetUniform("projection", _cameraManager.Projection);

        _vao.DrawElements(batch.Start * sizeof(uint), batch.Size);
        
        // shader.Stop();
        // GLHelper.UnbindTexture(TextureTarget.Texture2D);
    }

    /// <summary>
    /// Preserves the batches data to allow multiple primitives to be rendered in one batch,
    /// note that for this to work, all current parameters must match a past call to <see cref="EnsureBatch"/>.
    /// Use this instead of directly adding the batches, and it will probably reduce their number.
    /// </summary>
    private void EnsureBatch(PrimitiveTopology topology, int shader, int? texture)
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

        _currentBatchData = new BatchData(_batchIndexIndex, texture, shader, topology);
    }
    
    /// <summary>
    /// In case we need to get current batch, or start new one
    /// </summary>
    private void BreakCurrentBatch()
    {
        if (_currentBatchData is null)
            return;

        GenerateBatch();
        _currentBatchData = null;
    }
    
    private void GenerateBatch()
    {
        if (_currentBatchData is null)
            throw new NullReferenceException();

        var data = _currentBatchData.Value;
        var currentIndex = _batchIndexIndex;

        var batch = new Batch(
            data.Start,
            currentIndex - data.Start,
            data.Texture,
            data.PrimitiveTopology,
            Matrix4x4.Identity);

        _batches.Add(batch);
    }
}