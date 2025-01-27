namespace Hypercube.Graphics.Rendering.Api;

public delegate void InitHandler(string info, RenderingApiSettings settings);
public delegate void DrawHandler();
public delegate void DebugInfoHandler(string info);