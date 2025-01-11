using System.Runtime.InteropServices;
using Hypercube.Graphics.Rendering.Batching;
using Hypercube.Mathematics;
using Silk.NET.OpenGL;

namespace Hypercube.Graphics.Utilities.Extensions;

public static class SilkGLExtension
{
    public static unsafe string GetStringExt(this GL gl, StringName name)
    {
        var pointer = gl.GetString(name);
        return Marshal.PtrToStringUTF8((nint) pointer) ?? string.Empty;
    }

    public static void ObjectLabel(this GL gl, ObjectIdentifier identifier, uint handle, string name)
    {
        gl.ObjectLabel(identifier, handle, (uint) name.Length, name);
    }

    public static bool HasErrors(this GL gl)
    {
        return gl.GetError() != (int) ErrorCode.NoError;
    }

    public static void ClearColor(this GL gl, Color color)
    {
        gl.ClearColor(color.R, color.G, color.B, color.A);
    }

    public static unsafe void DrawElements(this GL gl, PrimitiveTopology topology, int count, DrawElementsType type, int indices)
    {
        var pointer = (void*)&indices;
        gl.DrawElements(ToPrimitiveType(topology), (uint) count, type, pointer);
    }

    private static PrimitiveType ToPrimitiveType(PrimitiveTopology primitiveTopology)
    {
        return primitiveTopology switch
        {
            PrimitiveTopology.PointList => PrimitiveType.Points,
            PrimitiveTopology.LineList => PrimitiveType.Lines,
            PrimitiveTopology.LineStrip => PrimitiveType.LineStrip,
            PrimitiveTopology.LineLoop => PrimitiveType.LineLoop,
            PrimitiveTopology.TriangleList => PrimitiveType.Triangles,
            PrimitiveTopology.TriangleFan => PrimitiveType.TriangleFan,
            PrimitiveTopology.TriangleStrip => PrimitiveType.TriangleStrip,
            _ => throw new ArgumentOutOfRangeException(nameof(primitiveTopology), primitiveTopology, null)
        };
    }
}