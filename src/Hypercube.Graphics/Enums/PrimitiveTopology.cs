namespace Hypercube.Graphics.Enums;

public enum PrimitiveTopology
{
    Points = 0x0000,
    
    Lines = 0x0001,
    LineLoop = 0x0002,
    LineStrip = 0x0003,
    
    Triangles = 0x0004,
    TriangleStrip = 0x0005,
    TriangleFan = 0x0006,
    
    /// <remarks>
    /// Supports only by OpenGL rendering.
    /// </remarks>
    Quad = 0x0007,
}