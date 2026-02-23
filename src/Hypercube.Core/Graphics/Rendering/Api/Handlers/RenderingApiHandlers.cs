namespace Hypercube.Core.Graphics.Rendering.Api.Handlers;

public delegate void InitHandler(string info);
public delegate void DrawHandler(DrawPayload payload);
public delegate void DebugInfoHandler(string info);