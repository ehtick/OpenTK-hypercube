using Hypercube.Core.Graphics.Rendering.Api;
using Hypercube.Core.Graphics.Rendering.Api.Realisations.Headless;
using Hypercube.Core.Graphics.Rendering.Api.Realisations.OpenGl;
using Hypercube.Core.Graphics.Windowing.Api;
using Hypercube.Core.Graphics.Windowing.Api.Realisations.Glfw;
using Hypercube.Core.Graphics.Windowing.Api.Realisations.Headless;

namespace Hypercube.Core.Graphics;

/// <summary>
/// Factory class responsible for creating instances of windowing and rendering APIs
/// based on the specified enum values.
/// </summary>
public static class ApiFactory
{
    /// <summary>
    /// Creates and returns an instance of <see cref="IWindowingApi"/> corresponding to the specified <see cref="WindowingApi"/> type.
    /// </summary>
    /// <param name="windowingApi">The windowing API type to instantiate.</param>
    /// <returns>An instance of <see cref="IWindowingApi"/> implementing the specified windowing backend.</returns>
    /// <exception cref="NotImplementedException">
    /// Thrown when the requested <see cref="WindowingApi"/> is not yet implemented.
    /// </exception>
    public static IWindowingApi Get(WindowingApi windowingApi)
    {
        return windowingApi switch
        {
            WindowingApi.Headless => new HeadlessWindowingApi(),
            WindowingApi.Glfw => new GlfwWindowingApi(),
            WindowingApi.Sdl => throw new NotImplementedException("SDL windowing API is not implemented yet."),
            _ => throw new NotImplementedException($"Windowing API '{windowingApi}' is not supported.")
        };
    }
    
    /// <summary>
    /// Creates and returns an instance of <see cref="IRenderingApi"/> corresponding to the specified <see cref="RenderingApi"/> type.
    /// </summary>
    /// <param name="renderingApi">The rendering API type to instantiate.</param>
    /// <returns>An instance of <see cref="IRenderingApi"/> implementing the specified rendering backend.</returns>
    /// <exception cref="NotImplementedException">
    /// Thrown when the requested <see cref="RenderingApi"/> is not yet implemented.
    /// </exception>
    public static IRenderingApi Get(RenderingApi renderingApi)
    {
        return renderingApi switch
        {
            RenderingApi.Headless => new HeadlessRenderingApi(),
            RenderingApi.OpenGl => new OpenGlRenderingApi(),
            RenderingApi.Vulkan => throw new NotImplementedException("Vulkan rendering API is not implemented yet."),
            _ => throw new NotImplementedException($"Rendering API '{renderingApi}' is not supported.")
        };
    }
}