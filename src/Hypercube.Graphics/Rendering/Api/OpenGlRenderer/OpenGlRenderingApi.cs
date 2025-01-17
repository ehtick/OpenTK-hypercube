using System.Runtime.InteropServices;
using System.Text;
using Hypercube.Graphics.Rendering.Batching;
using Hypercube.Graphics.Rendering.Resources;
using Hypercube.Graphics.Rendering.Shaders;
using Hypercube.Graphics.Utilities.Extensions;
using Hypercube.Resources.Storage;
using Silk.NET.OpenGL;
using ShaderType = Hypercube.Graphics.Rendering.Shaders.ShaderType;

namespace Hypercube.Graphics.Rendering.Api.OpenGlRenderer;

public sealed partial class OpenGlRenderingApi : BaseRenderingApi
{
    private IShaderProgram? _primitiveShaderProgram;
    private IShaderProgram? _texturingShaderProgram;

    //  I don't want to think about nulls,
    // let's accept the fact that it's not null
    private GL? _gl;

    private ArrayObject? _vao;
    private BufferObject? _vbo;
    private BufferObject? _ebo;

    protected override string InternalInfo
    {
        get
        {
            var vendor = Gl.GetStringExt(StringName.Vendor);
            var renderer = Gl.GetStringExt(StringName.Renderer);
            var version = Gl.GetStringExt(StringName.Version);
            var shading = Gl.GetStringExt(StringName.ShadingLanguageVersion);

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

    private GL Gl
    {
        get => _gl ?? throw new NullReferenceException();
        set => _gl = value;
    }

    protected override bool InternalInit(IContextInfo contextInfo)
    {
        Gl = GL.GetApi(contextInfo.GetProcAddress);

        if (Gl.HasErrors())
            return false;

        Gl.Enable(EnableCap.DebugOutput);
        Gl.Enable(EnableCap.DebugOutputSynchronous);

        Gl.DebugMessageCallback(DebugProcCallback, nint.Zero);

        _vao = GenArrayObject("Main VAO");
        _vbo = GenBufferObject(BufferTargetARB.ArrayBuffer, "Main VBO");
        _ebo = GenBufferObject(BufferTargetARB.ElementArrayBuffer, "Main EBO");

        return true;
    }

    protected override void InternalLoad(IResourceStorage resourceStorage)
    {
        _primitiveShaderProgram = resourceStorage.GetResource<ResourceShader>("/shaders/base_primitive").ShaderProgram;
        _texturingShaderProgram = resourceStorage.GetResource<ResourceShader>("/shaders/base_texturing").ShaderProgram;
    }

    protected override void InternalTerminate()
    {
        _vao?.Delete();
        _vbo?.Delete();
        _ebo?.Delete();
    }

    protected override void InternalRenderSetup()
    {
        Gl.Enable(EnableCap.Blend);
        Gl.Disable(EnableCap.ScissorTest);

        Gl.BlendEquation(BlendEquationModeEXT.FuncAdd);
        Gl.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

        Gl.PolygonMode(TriangleFace.FrontAndBack, PolygonMode.Fill);

        Gl.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        Gl.ClearColor(ClearColor);
    }

    protected override void InternalRenderSetupData(Vertex[] vertices, uint[] indices)
    {
        _vao?.Bind();
        _vbo?.SetData(vertices);
        _ebo?.SetData(indices);
    }

    protected override void InternalRender(Batch batch)
    {
        var shader = _primitiveShaderProgram;
        if (batch.TextureHandle is not null)
        {
            Gl.ActiveTexture(TextureUnit.Texture0);
            Gl.BindTexture(TextureTarget.Texture2D, batch.TextureHandle.Value);
            shader = _texturingShaderProgram;
        }

        if (shader is null)
            throw new Exception();
        
        shader.Use();
        shader.SetUniform("model", batch.Model);
        // shader.SetUniform("view", _cameraManager.View);
        // shader.SetUniform("projection", _cameraManager.Projection);

        Gl.DrawElements(batch.PrimitiveTopology, batch.Start * sizeof(uint), DrawElementsType.UnsignedInt, batch.Size);

        shader.Stop();
        Gl.BindTexture(TextureTarget.Texture2D, 0);
    }

    protected override void InternalRenderUnsetup()
    {
        _vao?.Unbind();
        _vbo?.Unbind();
        _ebo?.Unbind();
    }

    protected override IShader InternalCreateShader(string source, ShaderType type)
    {
        var handle = Gl.CreateShader(type);
        return new Shader(Gl, handle, type, source);
    }

    protected override IShaderProgram InternalCreateShaderProgram(IEnumerable<IShader> shaders)
    {
        var handle = Gl.CreateProgram();
        return new ShaderProgram(Gl, handle, shaders);
    }

    protected override IShaderProgram InternalCreateShaderProgram(List<IShader> shaders)
    {
        var handle = Gl.CreateProgram();
        return new ShaderProgram(Gl, handle, shaders);
    }

    private void DebugProcCallback(GLEnum source, GLEnum type, int id, GLEnum severity, int length, nint message,
        nint userparam)
    {
        var messageString = Marshal.PtrToStringAnsi(message) ?? "Unknown message";
        Console.WriteLine(
            $"[OpenGL Debug] Source: {source}, Type: {type}, ID: {id}, Severity: {severity}, Message: {messageString}");
    }
}