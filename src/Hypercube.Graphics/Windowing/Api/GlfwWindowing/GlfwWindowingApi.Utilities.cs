using Hypercube.Graphics.Windowing.Settings;
using Silk.NET.GLFW;
using ContextApi = Hypercube.Graphics.Windowing.Settings.ContextApi;

namespace Hypercube.Graphics.Windowing.Api.GlfwWindowing;

public sealed partial class GlfwWindowingApi
{
    private static ClientApi ToClientApi(ContextApi api)
    {
        return api switch
        {
            ContextApi.None => ClientApi.NoApi,
            ContextApi.Vulkan => ClientApi.NoApi,
            ContextApi.OpenGl => ClientApi.OpenGL,
            ContextApi.OpenGles => ClientApi.OpenGLES,
            _ => throw new ArgumentOutOfRangeException(nameof(api), api, null)
        };
    }
    
    private static OpenGlProfile ToGlProfile(ContextProfile profile)
    {
        return profile switch
        {
            ContextProfile.Compatability => OpenGlProfile.Compat,
            ContextProfile.Core => OpenGlProfile.Core,
            _ => throw new ArgumentOutOfRangeException(nameof(profile), profile, null)
        };
    }
}