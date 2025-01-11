using System.Text;
using Hypercube.Graphics.Rendering.Batching;
using Hypercube.Graphics.Utilities.Extensions;
using Hypercube.Mathematics;
using Silk.NET.OpenGL;

namespace Hypercube.Graphics.Rendering.Api.OpenGlRenderer;

public sealed partial class OpenGlRenderingApi : BaseRenderingApi
{
    //  I don't want to think about nulls,
    // let's accept the fact that it's not null
    private GL _gl = default!;

    private ArrayObject? _vao;
    private BufferObject? _vbo;
    private BufferObject? _ebo;
    
    protected override string InternalInfo
    {
        get
        {
            var vendor = _gl.GetStringExt(StringName.Vendor);
            var renderer = _gl.GetStringExt(StringName.Renderer);
            var version = _gl.GetStringExt(StringName.Version);
            var shading = _gl.GetStringExt(StringName.ShadingLanguageVersion);
            
            var result = new StringBuilder();
            
            result.AppendLine($"Vendor: {vendor}");
            result.AppendLine($"Renderer: {renderer}");
            result.AppendLine($"Version: {version}, Shading: {shading}");
            result.Append($"Thread: {Thread.CurrentThread.Name ?? "unnamed"} ({Environment.CurrentManagedThreadId})");
            // result.AppendLine($"Swap interval: {SwapInterval}");

            return result.ToString();
        }
    }
    
    protected override bool InternalInit(IContextInfo contextInfo)
    {
        _gl = GL.GetApi(contextInfo.GetProcAddress);
        
        _gl.Enable(EnableCap.DebugOutput);
        _gl.Enable(EnableCap.DebugOutputSynchronous);
        
        _gl.DebugMessageCallback(DebugProcCallback, nint.Zero);

        if (_gl.HasErrors())
            return false;
        
        _vao = GenArrayObject("Main VAO");
        _vbo = GenBufferObject(BufferTargetARB.ArrayBuffer, "Main VBO");
        _ebo = GenBufferObject(BufferTargetARB.ElementArrayBuffer, "Main EBO");
        
        return true;
    }

    protected override void InternalTerminate()
    {
        _vao?.Delete();
        _vbo?.Delete();
        _ebo?.Delete();
    }

    protected override void InternalRenderSetup()
    {
        _gl.Enable(EnableCap.Blend);
        _gl.Disable(EnableCap.ScissorTest);

        _gl.BlendEquation(BlendEquationModeEXT.FuncAdd);
        _gl.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

        _gl.PolygonMode(TriangleFace.FrontAndBack, PolygonMode.Fill);
        _gl.ClearColor(Color.Black);
    }

    protected override void InternalRenderSetupData(Vertex[] vertices, uint[] indices)
    {
        _vao?.Bind();
        _vbo?.SetData(vertices);
        _ebo?.SetData(indices);
    }
    
    protected override void InternalRender(Batch batch)
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
        
        _gl.DrawElements(batch.PrimitiveTopology, batch.Start * sizeof(uint), DrawElementsType.UnsignedInt, batch.Size);
        
        // shader.Stop();
        _gl.BindTexture(TextureTarget.Texture2D, 0);
    }

    protected override void InternalRenderUnsetup()
    {
        _vao?.Unbind();
        _vbo?.Unbind();
        _ebo?.Unbind();
    }

    private void DebugProcCallback(GLEnum source, GLEnum type, int id, GLEnum severity, int length, nint message, nint userparam)
    {
        throw new NotImplementedException();
    }
}