using System.Text;
using Hypercube.Graphics.Enums;
using Hypercube.GraphicsApi;
using Hypercube.GraphicsApi.GlApi;
using Hypercube.GraphicsApi.GlApi.Enum;
using Hypercube.GraphicsApi.GlApi.Objects;
using Hypercube.GraphicsApi.Objects;
using Hypercube.Mathematics;
using PolygonFace = Hypercube.Graphics.Enums.PolygonFace;
using PolygonMode = Hypercube.Graphics.Enums.PolygonMode;

namespace Hypercube.Graphics.Rendering.Api.GlRenderer;

public class GlApiRendering : IRendererApi
{
    private const int SwapInterval = 1;

    public string Info
    {
        get
        {
            var vendor = Gl.GetString(StringName.Vendor);
            var renderer = Gl.GetString(StringName.Renderer);
            var version = Gl.GetString(StringName.Version);
            var shading = Gl.GetString(StringName.ShadingLanguageVersion);

            var result = new StringBuilder();
            
            result.AppendLine($"Vendor: {vendor}");
            result.AppendLine($"Renderer: {renderer}");
            result.AppendLine($"Version: {version}, Shading: {shading}");
            result.AppendLine($"Thread: {Thread.CurrentThread.Name ?? "unnamed"} ({Environment.CurrentManagedThreadId})");
            result.AppendLine($"Swap interval: {SwapInterval}");

            return result.ToString();
        }
    }

    public void Init(IBindingsContext context)
    {
        Gl.LoadBindings(context);
    }

    public void Disable(Feature feature)
    {
        Gl.Disable(Cast(feature));
    }

    public void Enable(Feature feature)
    {
        Gl.Enable(Cast(feature));
    }

    public void ClearColor(Color color)
    {
        Gl.ClearColor(color);
    }

    public void ClearStencil(int s)
    {
        Gl.ClearStencil(s);
    }

    public void SetPolygonMode(PolygonFace face, PolygonMode mode)
    {
        Gl.PolygonMode(Cast(face), Cast(mode));
    }

    public IArrayObject GenArrayObject()
    {
        return new ArrayObject();
    }

    public void Clear(ClearBufferMask mask)
    {
        Gl.Clear(mask);
    }

    private GraphicsApi.GlApi.Enum.PolygonFace Cast(PolygonFace face)
    {
        return face switch
        {
            PolygonFace.Back =>  GraphicsApi.GlApi.Enum.PolygonFace.Back,
            PolygonFace.Front =>  GraphicsApi.GlApi.Enum.PolygonFace.Front,
            PolygonFace.FrontBack =>  GraphicsApi.GlApi.Enum.PolygonFace.FrontAndBack,
            _ => throw new NotImplementedException()
        };
    }
    
    private GraphicsApi.GlApi.Enum.PolygonMode Cast(PolygonMode mode)
    {
        return mode switch
        {
            PolygonMode.Point =>  GraphicsApi.GlApi.Enum.PolygonMode.Point,
            PolygonMode.Line =>  GraphicsApi.GlApi.Enum.PolygonMode.Line,
            PolygonMode.Fill =>  GraphicsApi.GlApi.Enum.PolygonMode.Fill,
            _ => throw new NotImplementedException()
        };
    }
    
    private EnableCap Cast(Feature feature)
    {
        return feature switch
        {
            Feature.Blend => EnableCap.Blend,
            Feature.CullFace => EnableCap.CullFace,
            Feature.DepthTest => EnableCap.DepthTest,
            Feature.ScissorTest => EnableCap.ScissorTest,
            _ => throw new NotImplementedException()
        };
    }
}