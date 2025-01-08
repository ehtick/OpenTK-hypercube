using Hypercube.Graphics.Rendering.Api;
using Hypercube.Graphics.Rendering.Api.GlRenderer;
using Hypercube.Graphics.Windowing.Api;
using Hypercube.Graphics.Windowing.Api.GlfwWindowing;
using Hypercube.GraphicsApi;

namespace Hypercube.Graphics;

public static class Api
{
    public static IWindowingApi Get(WindowingApi windowingApi)
    {
        return windowingApi switch
        {
            WindowingApi.Glfw => new GlfwWindowingApi(),
            _ => throw new NotImplementedException()
        };
    }
    
    public static IRendererApi Get(RenderingApi renderingApi)
    {
        return renderingApi switch
        {
            RenderingApi.OpenGl => new GlApiRendering(),
            // RenderingApi.Vulkan => new VulkanApiRendering(),
            _ => throw new NotImplementedException()
        };
    }
}