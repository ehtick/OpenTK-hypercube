using Hypercube.Core.Graphics.Rendering.Api;
using Hypercube.Core.Graphics.Rendering.Batching;
using Hypercube.Core.Viewports;
using Hypercube.Core.Windowing.Windows;
using Hypercube.Mathematics.Matrices;
using Hypercube.Mathematics.Quaternions;

namespace Hypercube.Core.Graphics.Rendering.Context;

public partial class RenderContext
{
    public IDisposable UseRenderState(Matrix4x4 view, Matrix4x4 projection)
    {
        return new RenderStateScope(this, view, projection);
    }
    
    public IDisposable UseRenderState(ICameraManager cameraManager)
    {
        return new RenderStateScope(this, cameraManager.MainCamera.View, cameraManager.MainCamera.Projection);
    }
    
    public IDisposable UseRenderView(Matrix4x4 view)
    {
        return new RenderViewScope(this, view);
    }
    
    public IDisposable UseRenderProjection(Matrix4x4 projection)
    {
        return new RenderProjectionScope(this, projection);
    }
    
    public IDisposable UseWindowSpace(IWindow window)
    {
        return new WindowSpaceScope(this, window);
    }
    
    public readonly struct RenderStateScope : IDisposable
    {
        private readonly RenderContext _context;
        private readonly RenderStateId _previousRenderStateId;

        public RenderStateScope(RenderContext context, Matrix4x4 view, Matrix4x4 projection)
        {
            _context = context;
            _previousRenderStateId = context._renderingApi.GetCurrentRenderStateId();
            _context._renderingApi.SetRenderState(view, projection);
        }

        public void Dispose()
        {
            var previousState = _context._renderingApi.GetRenderState(_previousRenderStateId);
            _context._renderingApi.SetRenderState(previousState.View, previousState.Projection);
        }
    }
    
    public readonly struct RenderViewScope : IDisposable
    {
        private readonly RenderContext _context;
        private readonly RenderStateId _previousRenderStateId;

        public RenderViewScope(RenderContext context, Matrix4x4 view)
        {
            _context = context;
            _previousRenderStateId = context._renderingApi.GetCurrentRenderStateId();
            _context._renderingApi.SetRenderView(view);
        }

        public void Dispose()
        {
            var previousState = _context._renderingApi.GetRenderState(_previousRenderStateId);
            _context._renderingApi.SetRenderView(previousState.View);
        }
    }
    
    public readonly struct RenderProjectionScope : IDisposable
    {
        private readonly RenderContext _context;
        private readonly RenderStateId _previousRenderStateId;

        public RenderProjectionScope(RenderContext context, Matrix4x4 projection)
        {
            _context = context;
            _previousRenderStateId = context._renderingApi.GetCurrentRenderStateId();
            _context._renderingApi.SetRenderProjection(projection);
        }

        public void Dispose()
        {
            var previousState = _context._renderingApi.GetRenderState(_previousRenderStateId);
            _context._renderingApi.SetRenderProjection(previousState.Projection);
        }
    }
    
    public readonly struct WindowSpaceScope : IDisposable
    {
        private readonly RenderContext _context;
        private readonly RenderStateId _previousRenderStateId;

        public WindowSpaceScope(RenderContext context, IWindow window)
        {
            _context = context;
            _previousRenderStateId = context._renderingApi.GetCurrentRenderStateId();

            
            var projection = Matrix4x4.CreateOrthographicTopLeft(window.Size.X, window.Size.Y, -1f, 100).Transposed;
            
            _context._renderingApi.SetRenderState(Matrix4x4.Identity, projection);
        }

        public void Dispose()
        {
            var previousState = _context._renderingApi.GetRenderState(_previousRenderStateId);
            _context._renderingApi.SetRenderState(previousState.View, previousState.Projection);
        }
    }

}
