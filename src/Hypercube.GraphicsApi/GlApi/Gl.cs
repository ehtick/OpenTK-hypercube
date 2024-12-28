using System.Runtime.InteropServices;
using Hypercube.GraphicsApi.GlApi.Enum;
using Hypercube.Mathematics;
using Hypercube.Utilities.Extensions;

namespace Hypercube.GraphicsApi.GlApi;

public static unsafe class Gl
{
    public const int NullArray = 0;
    
    public static void PolygonMode(PolygonFace face, PolygonMode mode)
    {
        GlNative.glPolygonMode((uint) face, (uint) mode);
    }
    
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

    public static void Disable(EnableCap cap)
    {
        GlNative.glDisable((uint) cap);
    }
    
    public static void Enable(EnableCap cap)
    {
        GlNative.glEnable((uint) cap);
    }
    
    public static string GetString(StringName name)
    {
        var pointer = GlNative.glGetString((uint) name);
        var str = Marshal.PtrToStringUTF8((nint) pointer) ?? string.Empty;
        return str;
    }
    
    public static void BindVertexArray(int array)
    {
        GlNative.glBindVertexArray((uint) array);
    }
    
    public static void BindVertexArray(uint array)
    {
        GlNative.glBindVertexArray(array);
    }
    
    public static int GenVertexArray()
    {
        uint id;
        GlNative.glGenVertexArrays(1, &id);
        return (int) id;
    }

    public static void DeleteVertexArray(int handle)
    {
        var local = (uint) handle;
        GlNative.glDeleteVertexArrays(1, &local);
    }
    
    public static void DeleteVertexArray(uint handle)
    {
        GlNative.glDeleteVertexArrays(1, &handle);
    }

    public static void LabelVertexArray(int handle, string label)
    {
        var pointer = Marshal.StringToHGlobalAnsi(label);
        
        GlNative.glObjectLabel((uint) LabelIdentifier.VertexArray, (uint) handle, label.Length, (byte*) pointer);
        
        if (pointer != nint.Zero)
            Marshal.FreeHGlobal(pointer);
    }

    public static void DrawElements(int start, int count)
    {
        var pointer = (void*)&start;
        GlNative.glDrawElements((uint) PrimitiveType.Triangles, count, (uint) DrawElementsType.UnsignedShort, pointer);
    }
}