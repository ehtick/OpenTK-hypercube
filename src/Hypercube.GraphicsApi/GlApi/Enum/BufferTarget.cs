namespace Hypercube.GraphicsApi.GlApi.Enum;

public enum BufferTarget
{
    /// <remarks>
    /// <c>#define GL_ARRAY_BUFFER 0x8892</c>
    /// </remarks>
    ArrayBuffer = 0x00008892,
    
    /// <remarks>
    /// <c>#define GL_ELEMENT_ARRAY_BUFFER 0x8893</c>
    /// </remarks>
    ElementArrayBuffer = 0x00008893,
    
    /// <remarks>
    /// <c>#define GL_PIXEL_PACK_BUFFER 0x88EB</c>
    /// </remarks>
    PixelPackBuffer = 0x000088EB,
    
    /// <remarks>
    /// <c>#define GL_PIXEL_UNPACK_BUFFER 0x88EC</c>
    /// </remarks>
    PixelUnpackBuffer = 0x000088EC,
    
    /// <remarks>
    /// <c>#define GL_UNIFORM_BUFFER 0x8A11</c>
    /// </remarks>
    UniformBuffer = 0x00008A11,
    
    /// <remarks>
    /// <c>#define GL_TEXTURE_BUFFER 0x8C2A</c>
    /// </remarks>
    TextureBuffer = 0x00008C2A,
    
    /// <remarks>
    /// <c>#define GL_TRANSFORM_FEEDBACK_BUFFER 0x8C8E</c>
    /// </remarks>
    TransformFeedbackBuffer = 0x00008C8E,
    
    /// <remarks>
    /// <c>#define GL_COPY_READ_BUFFER 0x8F36</c>
    /// </remarks>
    CopyReadBuffer = 0x00008F36,
    
    /// <remarks>
    /// <c>#define GL_COPY_WRITE_BUFFER 0x8F37</c>
    /// </remarks>
    CopyWriteBuffer = 0x00008F37,
    
    /// <remarks>
    /// <c>#define GL_DRAW_INDIRECT_BUFFER 0x8F3F</c>
    /// </remarks>
    DrawIndirectBuffer = 0x00008F3F,
    
    /// <remarks>
    /// <c>#define GL_SHADER_STORAGE_BUFFER 0x90D2</c>
    /// </remarks>
    ShaderStorageBuffer = 0x000090D2,
    
    /// <remarks>
    /// <c>#define GL_DISPATCH_INDIRECT_BUFFER 0x90EE</c>
    /// </remarks>
    DispatchIndirectBuffer = 0x000090EE,
    
    /// <remarks>
    /// <c>#define GL_QUERY_BUFFER 0x9192</c>
    /// </remarks>
    QueryBuffer = 0x00009192,
    
    /// <remarks>
    /// <c>#define GL_ATOMIC_COUNTER_BUFFER 0x92C0</c>
    /// </remarks>
    AtomicCounterBuffer = 0x000092C0,
}