namespace Hypercube.GraphicsApi.GlApi.Enum;

public enum BufferUsageHint
{
    /// <remarks>
    /// <c>#define GL_STREAM_DRAW 0x88E0</c>
    /// </remarks>
    StreamDraw = 0x000088E0,
    
    /// <remarks>
    /// <c>#define GL_STREAM_READ 0x88E1</c>
    /// </remarks>
    StreamRead = 0x000088E1,
    
    /// <remarks>
    /// <c>#define GL_STREAM_COPY 0x88E1</c>
    /// </remarks>
    StreamCopy = 0x000088E2,
    
    /// <remarks>
    /// <c>#define GL_STATIC_DRAW 0x88E1</c>
    /// </remarks>
    StaticDraw = 0x000088E4,
    
    /// <remarks>
    /// <c>#define GL_STATIC_READ 0x88E1</c>
    /// </remarks>
    StaticRead = 0x000088E5,
    
    /// <remarks>
    /// <c>#define GL_STATIC_COPY 0x88E1</c>
    /// </remarks>
    StaticCopy = 0x000088E6,
    
    /// <remarks>
    /// <c>#define GL_DYNAMIC_DRAW 0x88E1</c>
    /// </remarks>
    DynamicDraw = 0x000088E8,
    
    /// <remarks>
    /// <c>#define GL_DYNAMIC_READ 0x88E1</c>
    /// </remarks>
    DynamicRead = 0x000088E9,
    
    /// <remarks>
    /// <c>#define GL_DYNAMIC_COPY 0x88E1</c>
    /// </remarks>
    DynamicCopy = 0x000088EA,
}