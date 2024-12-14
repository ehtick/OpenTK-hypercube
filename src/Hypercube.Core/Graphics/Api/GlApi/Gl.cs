using System.Runtime.InteropServices;
using Hypercube.Core.Graphics.Api.GlApi.Enum;

namespace Hypercube.Core.Graphics.Api.GlApi;

public static unsafe class Gl
{
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