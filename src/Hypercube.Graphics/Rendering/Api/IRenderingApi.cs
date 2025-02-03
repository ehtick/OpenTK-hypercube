using Hypercube.Graphics.Rendering.Batching;
using Hypercube.Graphics.Rendering.Shaders;
using Hypercube.Graphics.Windowing;

namespace Hypercube.Graphics.Rendering.Api;

public interface IRenderingApi
{
    event InitHandler? OnInit;
    event DrawHandler? OnDraw;
    event DebugInfoHandler? OnDebugInfo;

    IShaderProgram? PrimitiveShaderProgram { get; }
    IShaderProgram? TexturingShaderProgram { get; }
    int BatchVerticesIndex { get; }
    int BatchIndicesIndex { get; }
    
    void Init(IContextInfo context, RenderingApiSettings settings);
    void Load();
    
    void Terminate();
    void Render(IWindow window);
    
    /// <summary>
    /// Preserves the batches data to allow multiple primitives to be rendered in one batch,
    /// note that for this to work, all current parameters must match a past call to <see cref="EnsureBatch"/>.
    /// Use this instead of directly adding the batches, and it will probably reduce their number.
    /// </summary>
    void EnsureBatch(PrimitiveTopology topology, uint shader, uint? texture);
    
    /// <summary>
    /// In case we need to get current batch, or start new one
    /// </summary>
    void BreakCurrentBatch();

    void PushVertex(Vertex vertex);
    void PushIndex(uint start, uint offset);
    void PushIndex(int start, int index);
    
    IShader CreateShader(string source, ShaderType type);
    IShaderProgram CreateShaderProgram(Dictionary<ShaderType, string> shaderSources);
}