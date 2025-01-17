﻿using Hypercube.Graphics.Rendering.Api;

namespace Hypercube.Core.Utilities.Helpers;

public static class RenderingApiSettingsHelper
{
    public static RenderingApiSettings FromConfig()
    {
        return new RenderingApiSettings
        {
            Api = Config.Rendering,
            ClearColor = Config.RenderingClearColor,
            MaxVertices = Config.RenderingMaxVertices,
            IndicesPerVertex = Config.RenderingIndicesPerVertex
        };
    }
}