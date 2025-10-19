using Hypercube.Core.Graphics.Rendering.Api;
using Hypercube.Core.Graphics.Rendering.Api.Realisations.Headless;
using Hypercube.Core.Graphics.Rendering.Api.Realisations.OpenGl;
using Hypercube.Core.Graphics.Rendering.Api.Settings;
using Hypercube.Core.Windowing.Api;
using Hypercube.Core.Windowing.Api.Realisations.Glfw;
using Hypercube.Core.Windowing.Api.Realisations.Headless;

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
    /// <param name="settings"></param>
    /// <returns>An instance of <see cref="IWindowingApi"/> implementing the specified windowing backend.</returns>
    /// <exception cref="NotImplementedException">
    /// Thrown when the requested <see cref="WindowingApi"/> is not yet implemented.
    /// </exception>
    public static IWindowingApi Get(WindowingApi windowingApi, WindowingApiSettings settings)
    {
        return windowingApi switch
        {
            WindowingApi.Headless => new HeadlessWindowingApi(settings),
            WindowingApi.Glfw => new GlfwWindowingApi(settings),
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
    public static IRenderingApi Get(RenderingApi renderingApi, RenderingApiSettings settings, IWindowingApi windowingApi)
    {
        return renderingApi switch
        {
            RenderingApi.Headless => new HeadlessRenderingApi(settings, windowingApi),
            RenderingApi.OpenGl => new OpenGlRenderingApi(settings, windowingApi),
            RenderingApi.Vulkan => throw new NotImplementedException("Vulkan rendering API is not implemented yet."),
            _ => throw new NotImplementedException($"Rendering API '{renderingApi}' is not supported.")
        };
    }
}