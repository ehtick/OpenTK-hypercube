using Hypercube.Graphics.Rendering;
using Hypercube.Graphics.Rendering.Api;
using Hypercube.Graphics.Rendering.Api.OpenGlRenderer;
using Hypercube.Graphics.Windowing.Api;
using Hypercube.Graphics.Windowing.Api.GlfwWindowing;

namespace Hypercube.Graphics;

public static class ApiFactory
{
    public static IWindowingApi Get(WindowingApi windowingApi)
    {
        return windowingApi switch
        {
            WindowingApi.Glfw => new GlfwBaseWindowingApi(),
            WindowingApi.Sdl => throw new NotImplementedException(),
            _ => throw new NotImplementedException()
        };
    }
    
    public static IRenderingApi Get(RenderingApi renderingApi)
    {
        return renderingApi switch
        {
            RenderingApi.OpenGl => new OpenGlRenderingApi(),
            RenderingApi.Vulkan => throw new NotImplementedException(),
            _ => throw new NotImplementedException()
        };
    }
}