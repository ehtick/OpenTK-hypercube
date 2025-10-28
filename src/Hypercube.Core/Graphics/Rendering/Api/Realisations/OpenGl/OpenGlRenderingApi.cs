using System.Runtime.InteropServices;
using System.Text;
using Hypercube.Core.Graphics.Rendering.Api.Handlers;
using Hypercube.Core.Graphics.Rendering.Api.Realisations.OpenGl.Objects;
using Hypercube.Core.Graphics.Rendering.Api.Settings;
using Hypercube.Core.Graphics.Rendering.Batching;
using Hypercube.Core.Graphics.Rendering.Shaders;
using Hypercube.Core.Graphics.Texturing;
using Hypercube.Core.Graphics.Utilities.Extensions;
using Hypercube.Core.Resources;
using Hypercube.Core.Viewports;
using Hypercube.Core.Windowing;
using Hypercube.Core.Windowing.Api;
using Hypercube.Mathematics.Shapes;
using Hypercube.Utilities.Dependencies;
using Silk.NET.OpenGL;
using Shader = Hypercube.Core.Graphics.Resources.Shader;
using ShaderType = Hypercube.Core.Graphics.Rendering.Shaders.ShaderType;

namespace Hypercube.Core.Graphics.Rendering.Api.Realisations.OpenGl;

[EngineInternal]
public sealed partial class OpenGlRenderingApi : BaseRenderingApi
{
    public override RenderingApi Type => RenderingApi.OpenGl;
    
    [Dependency] private readonly ICameraManager _cameraManager = default!;
    [Dependency] private readonly IResourceManager _resource = default!;

    public override event DrawHandler? OnDraw;
    public override event DebugInfoHandler? OnDebugInfo;

    private GL _gl = default!;
    private ArrayObject _vao = default!;
    private BufferObject _vbo = default!;
    private BufferObject _ebo = default!;

    protected override string InternalInfo
    {
        get
        {
            var vendor = _gl.GetStringExt(StringName.Vendor);
            var renderer = _gl.GetStringExt(StringName.Renderer);
            var version = _gl.GetStringExt(StringName.Version);
            var shading = _gl.GetStringExt(StringName.ShadingLanguageVersion);

            var result = new StringBuilder();

            result.AppendLine($"Version: {version}");
            result.AppendLine($"Shading: {shading}");
            result.AppendLine($"Vendor: {vendor}");
            result.AppendLine($"Renderer: {renderer}");
            result.Append($"Thread: {Thread.CurrentThread.Name ?? "unnamed"} ({Environment.CurrentManagedThreadId})");
            // result.AppendLine($"Swap interval: {SwapInterval}");

            return result.ToString();
        }
    }

    public OpenGlRenderingApi(RenderingApiSettings settings, IWindowingApi windowingApi) : base(settings, windowingApi)
    {
    }

    public override unsafe TextureHandle CreateTexture(int width, int height, int channels, byte[] data)
    {
        var handle = _gl.GenTexture();
        _gl.BindTexture(TextureTarget.Texture2D, handle);

        var internalFormat = channels switch
        {
            1 => InternalFormat.R8,
            2 => InternalFormat.RG8,
            3 => InternalFormat.Rgb8,
            4 => InternalFormat.Rgba8,
            _ => throw new ArgumentException($"Unsupported channel count: {channels}")
        };

        var format = channels switch
        {
            1 => PixelFormat.Red,
            2 => PixelFormat.RG,
            3 => PixelFormat.Rgb,
            4 => PixelFormat.Rgba,
            _ => throw new ArgumentException($"Unsupported channel count: {channels}")
        };
        
        fixed (byte* dataPointer = data)
            _gl.TexImage2D(TextureTarget.Texture2D, 0, (int) internalFormat, (uint) width, (uint) height, 0, format, PixelType.UnsignedByte, dataPointer);
        
        _gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int) TextureMinFilter.Nearest);
        _gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int) TextureMagFilter.Nearest);
        _gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int) TextureWrapMode.ClampToEdge);
        _gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int) TextureWrapMode.ClampToEdge);
        
        _gl.BindTexture(TextureTarget.Texture2D, 0);
        
        return new TextureHandle(handle);
    }

    public override void DeleteTexture(TextureHandle handle)
    {
        if (!handle.HasValue)
            return;
        
        _gl.DeleteTexture(handle);
    }

    public override void SetScissor(bool value)
    {
        _gl.SetScissor(value);
    }

    public override void SetScissorRect(Rect2i rect)
    {
        _gl.Scissor(rect.Left, rect.Top, (uint) rect.Width, (uint) rect.Height);
    }

    protected override bool InternalInit(IContextInfo contextInfo)
    {
        _gl = GL.GetApi(contextInfo.GetProcAddress);

        if (_gl.HasErrors())
            return false;

        _gl.DebugMessageCallback(DebugProcCallback, in nint.Zero);
        
        _gl.Enable(EnableCap.DebugOutput);
        _gl.Enable(EnableCap.DebugOutputSynchronous);
        
        _vao = GenArrayObject("Main VAO");
        _vbo = GenBufferObject(BufferTargetARB.ArrayBuffer, "Main VBO");
        _ebo = GenBufferObject(BufferTargetARB.ElementArrayBuffer, "Main EBO");
                
        _vao.Bind();
        _vbo.SetData(BatchVertices);
        _ebo.SetData(BatchIndices);

        var pointer = nint.Zero;
        
        // aPos
        _gl.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, Vertex.Size, pointer);
        _gl.EnableVertexAttribArray(0);
        
        // aPos offset
        pointer += 3 * sizeof(float);

        // aColor
        _gl.VertexAttribPointer(1, 4, VertexAttribPointerType.Float, false, Vertex.Size, pointer);
        _gl.EnableVertexAttribArray(1);
        
        // aColor offset
        pointer += 4 * sizeof(float);

        // aTexCoords
        _gl.VertexAttribPointer(2, 2, VertexAttribPointerType.Float, false, Vertex.Size, pointer);
        _gl.EnableVertexAttribArray(2);
        
        // aTexCoords offset
        pointer += 2 * sizeof(float);
        
        // aNormal
        _gl.VertexAttribPointer(3, 3, VertexAttribPointerType.Float, false, Vertex.Size, pointer);
        _gl.EnableVertexAttribArray(3);
        
        // aNormal offset
        pointer += 3 * sizeof(float);
        
        _vao.Unbind();
        _vbo.Unbind();
        _ebo.Unbind();
        
        return true;
    }

    protected override void InternalLoad()
    {
        PrimitiveShaderProgram = _resource.Load<Shader>("/shaders/base_primitive.shd");
        TexturingShaderProgram = _resource.Load<Shader>("/shaders/base_texturing.shd");
    }

    protected override void InternalTerminate()
    {
        _vao.Delete();
        _vbo.Delete();
        _ebo.Delete();
    }

    public override void Render(IWindow window)
    {
        Clear();

        _gl.Viewport(window);
        _gl.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        
        OnDraw?.Invoke();

        BreakCurrentBatch();
        UpdateBatchCount();

        _gl.Enable(EnableCap.Blend);
        _gl.Disable(EnableCap.ScissorTest);

        _gl.BlendEquation(BlendEquationModeEXT.FuncAdd);
        _gl.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

        _gl.PolygonMode(TriangleFace.FrontAndBack, PolygonMode.Fill);
        _gl.ClearColor(ClearColor);
        
        _vao.Bind();
        _vbo.SetData(BatchVertices);
        _ebo.SetData(BatchIndices);
        
        foreach (var batch in Batches)
        {
            Render(batch);
        }

        _vao.Unbind();
        _vbo.Unbind();
        _ebo.Unbind();
        
        window.SwapBuffers();
    }

    private void Render(Batch batch)
    {
        var shader = PrimitiveShaderProgram;
        
        if (batch.TextureHandle is not null)
        {
            _gl.ActiveTexture(TextureUnit.Texture0);
            _gl.BindTexture(TextureTarget.Texture2D, batch.TextureHandle.Value);
            shader = TexturingShaderProgram;
        }
        
        if (shader is null)
            throw new Exception();
        
        shader.Use();
        shader.SetUniform("model", batch.Model);
        shader.SetUniform("view", _cameraManager.MainCamera.View);
        shader.SetUniform("projection", _cameraManager.MainCamera.Projection);

        _gl.DrawElements(batch.PrimitiveTopology, batch.Size, DrawElementsType.UnsignedInt, batch.Start * sizeof(uint));

        shader.Stop();
        
        _gl.BindTexture(TextureTarget.Texture2D, 0);
    }

    protected override IShader InternalCreateShader(string source, ShaderType type)
    {
        var handle = _gl.CreateShader(type);
        return new OpenGlShader(_gl, handle, type, source);
    }

    protected override IShaderProgram InternalCreateShaderProgram(IEnumerable<IShader> shaders)
    {
        var handle = _gl.CreateProgram();
        return new OpenGlShaderProgram(_gl, handle, shaders);
    }

    protected override IShaderProgram InternalCreateShaderProgram(List<IShader> shaders)
    {
        var handle = _gl.CreateProgram();
        return new OpenGlShaderProgram(_gl, handle, shaders);
    }

    private void DebugProcCallback(GLEnum source, GLEnum type, int id, GLEnum severity, int length, nint message, nint userParam)
    {
        var messageString = Marshal.PtrToStringAnsi(message) ?? "Unknown message";
        OnDebugInfo?.Invoke($"[OpenGL] Source: {source}, Type: {type}, ID: {id}, Severity: {severity}, Message: {messageString}");
    }
}