using Hypercube.Graphics.Enums;
using Hypercube.GraphicsApi.GlApi;
using Hypercube.GraphicsApi.GlApi.Enum;
using Hypercube.Mathematics;
using PolygonFace = Hypercube.Graphics.Enums.PolygonFace;
using PolygonMode = Hypercube.Graphics.Enums.PolygonMode;

namespace Hypercube.Graphics.Rendering.Api.GlRenderer;

public class GlApiRendering : IRendererApi
{
    private const int SwapInterval = 1;
    
    public void Init()
    {
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