namespace Hypercube.GraphicsApi.GlApi.Enum;

public enum ShaderType
{
    /// <remarks>
    /// <c>#define GL_FRAGMENT_SHADER 0x8B30</c>
    /// </remarks>
    FragmentShader = 0x00008B30,
    
    /// <remarks>
    /// <c>#define GL_FRAGMENT_SHADER_ARB 0x8B30</c>
    /// </remarks>
    FragmentShaderArb = 0x00008B30,
    
    /// <remarks>
    /// <c>#define GL_VERTEX_SHADER 0x8B31</c>
    /// </remarks>
    VertexShader = 0x00008B31,
    
    /// <remarks>
    /// <c>#define GL_VERTEX_SHADER_ARB 0x8B31</c>
    /// </remarks>
    VertexShaderArb = 0x00008B31,
    
    /// <remarks>
    /// <c>#define GL_GEOMETRY_SHADER 0x8DD9</c>
    /// </remarks>
    GeometryShader = 0x00008DD9,
    
    /// <remarks>
    /// <c>#define GL_TESS_EVALUATION_SHADER 0x8E87</c>
    /// </remarks>
    TessEvaluationShader = 0x00008E87,
    
    /// <remarks>
    /// <c>#define GL_TESS_CONTROL_SHADER 0x8E88</c>
    /// </remarks>
    TessControlShader = 0x00008E88,
    
    /// <remarks>
    /// <c>#define GL_COMPUTE_SHADER 0x91B9</c>
    /// </remarks>
    ComputeShader = 0x000091B9,
}