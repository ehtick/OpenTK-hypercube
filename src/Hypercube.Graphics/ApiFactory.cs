using Hypercube.Graphics.Rendering.Api;
using Hypercube.Graphics.Rendering.Api.GlRenderer;
using Hypercube.Graphics.Rendering.Api.VulkanRenderer;
using Hypercube.Graphics.Windowing.Api;
using Hypercube.Graphics.Windowing.Api.GlfwWindowing;
using Hypercube.GraphicsApi;

namespace Hypercube.Graphics;

public static class ApiFactory
{
    public static IWindowingApi CreateApi(WindowingApi windowingApi)
    {
        return windowingApi switch
        {
            WindowingApi.Glfw => new GlfwWindowing(),
            _ => throw new NotImplementedException()
        };
    }
    
    public static IRendererApi CreateApi(RenderingApi renderingApi)
    {
        return renderingApi switch
        {
            RenderingApi.OpenGl => new GlApiRendering(),
            // RenderingApi.Vulkan => new VulkanApiRendering(),
            _ => throw new NotImplementedException()
        };
    }
}