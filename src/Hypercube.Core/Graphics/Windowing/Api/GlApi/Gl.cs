using System.Runtime.InteropServices;
using Hypercube.Core.Graphics.Rendering.Api.GlRenderer.Enums;
using Hypercube.Core.Graphics.Windowing.Api.GlApi.Enum;
using Hypercube.Core.Utilities.Extensions;
using Hypercube.Mathematics;

namespace Hypercube.Core.Graphics.Windowing.Api.GlApi;

public static unsafe class Gl
{
    public static void Clear(ClearBufferMask mask)
    {
        GlNative.glClear((uint) mask);
    }
    
    public static void ClearColor(Color color)
    {
        GlNative.glClearColor(color.R, color.G, color.B, color.A);
    }

    public static void ClearStencil(int s)
    {
        GlNative.glClearStencil(s);
    }

    public static void ClearDepth(double depth)
    {
        GlNative.glClearDepth(depth);
    }

    public static void StencilMask(uint mask)
    {
        GlNative.glStencilMask(mask);
    }

    public static void ColorMask(bool red, bool green, bool blue, bool alpha)
    {
        GlNative.glColorMask(red.ToInt(), green.ToInt(), blue.ToInt(), alpha.ToInt());
    }
    
    public static void CullFace(CullFaceMode mode)
    {
        GlNative.glCullFace((uint) mode);
    }

    public static string GetString(StringName name)
    {
        var pointer = GlNative.glGetString((uint) name);
        var str = Marshal.PtrToStringUTF8((nint) pointer) ?? string.Empty;
        return str;
    }
}