using Hypercube.Core.Graphics.Rendering.Api;
using Hypercube.Core.Graphics.Rendering.Api.GlRenderer;
using Hypercube.Core.Graphics.Rendering.Api.VulkanRenderer;
using Hypercube.Core.Graphics.Windowing.Core;
using Hypercube.Core.Graphics.Windowing.Core.GlfwWindowing;
using Hypercube.GraphicsApi;

namespace Hypercube.Core.Graphics;

public static class ApiFactory
{
    public static IWindowingApi GetApi(WindowingApi windowingApi)
    {
        return windowingApi switch
        {
            WindowingApi.Glfw => new GlfwWindowing(),
            _ => throw new NotImplementedException()
        };
    }
    
    public static IRendererApi GetApi(RenderingApi renderingApi)
    {
        return renderingApi switch
        {
            RenderingApi.OpenGl => new GlApiRendering(),
            RenderingApi.Vulkan => new VulkanApiRendering(),
            _ => throw new NotImplementedException()
        };
    }
}