using Hypercube.Core.Graphics.Api.GlApi.Enum;

namespace Hypercube.Core.Graphics.Api.GlApi;

public static unsafe class Gl
{
    public static void CullFace(CullFaceMode mode)
    {
        GlNative.glCullFace((uint) mode);
    }
}