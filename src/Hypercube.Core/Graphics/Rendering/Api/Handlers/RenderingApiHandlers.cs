using Hypercube.Core.Graphics.Rendering.Api.Settings;

namespace Hypercube.Core.Graphics.Rendering.Api.Handlers;

public delegate void InitHandler(string info, RenderingApiSettings settings);
public delegate void DrawHandler();
public delegate void DebugInfoHandler(string info);