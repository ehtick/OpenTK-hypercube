using Hypercube.Graphics.Rendering.Shaders;
using Hypercube.Graphics.Utilities.Extensions;
using Silk.NET.OpenGL;

namespace Hypercube.Graphics.Rendering.Api.OpenGlRenderer;

public sealed partial class OpenGlRenderingApi
{
    private sealed class ShaderProgram : BaseShaderProgram
    {
        private readonly GL _gl;
        
        public ShaderProgram(GL gl, uint handle, IEnumerable<IShader> shaders) : base(handle)
        {
            _gl = gl;
            
            Setup(shaders as IShader[] ?? shaders.ToArray());      
        }

        private void Setup(IShader[] shaders)
        {
            if (shaders.Length == 0)
                throw new InvalidOperationException();
            
            foreach (var shader in shaders)
            {
                Attach(shader);
            }

            Link();

            foreach (var shader in shaders)
            {
                Detach(shader);
            }
        }
        
        private void Link()
        {
            _gl.LinkProgram(Handle);
            
            _gl.GetProgram(Handle, ProgramPropertyARB.LinkStatus, out var code);

            if (code == (int) GLEnum.True)
                return;

            _gl.GetProgramInfoLog(Handle, out var info);
            throw new Exception($"Error occurred whilst linking Program {Handle} ({info})");
        }
        
        private void Attach(IShader shader)
        {
            _gl.AttachShader(Handle, shader.Handle);
        }

        private void Detach(IShader shader)
        {
            _gl.DetachShader(Handle, shader.Handle);
        }

        protected override void InternalLabel(string name)
        {
            _gl.ObjectLabel(ObjectIdentifier.Program, Handle, name);
        }
    }
}