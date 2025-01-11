using Hypercube.GraphicsApi;

namespace Hypercube.Graphics.Rendering.Api;

public readonly struct RenderingApiSettings
{
    public RenderingApi Api { get; init; }
    public int MaxVertices { get; init; }
    public int IndicesPerVertex { get; init; }

    public int MaxIndices => MaxVertices * IndicesPerVertex;
}