
namespace Hypercube.GraphicsApi.GlApi.Enum;

// ReSharper disable InconsistentNaming

public enum ActiveUniform
{
    /// <remarks>
    /// <c>#define GL_INT 0x1404</c>
    /// </remarks>
    Int = 0x00001404,
    
    /// <remarks>
    /// <c>#define GL_UNSIGNED_INT 0x1405</c>
    /// </remarks>
    UnsignedInt = 0x00001405,
    
    /// <remarks>
    /// <c>#define GL_FLOAT 0x1406</c>
    /// </remarks>
    Float = 0x00001406,
    
    /// <remarks>
    /// <c>#define GL_DOUBLE 0x140A</c>
    /// </remarks>
    Double = 0x0000140A,
    
    /// <remarks>
    /// <c>#define GL_FLOAT_VEC2 0x8B50</c>
    /// </remarks>
    FloatVec2 = 0x00008B50,
    
    /// <remarks>
    /// <c>#define GL_FLOAT_VEC3 0x8B51</c>
    /// </remarks>
    FloatVec3 = 0x00008B51,
    
    /// <remarks>
    /// <c>#define GL_FLOAT_VEC4 0x8B52</c>
    /// </remarks>
    FloatVec4 = 0x00008B52,
    
    /// <remarks>
    /// <c>#define GL_INT_VEC2 0x8B53</c>
    /// </remarks>
    IntVec2 = 0x00008B53,
    
    /// <remarks>
    /// <c>#define GL_INT_VEC3 0x8B54</c>
    /// </remarks>
    IntVec3 = 0x00008B54,
    
    /// <remarks>
    /// <c>#define GL_INT_VEC4 0x8B55</c>
    /// </remarks>
    IntVec4 = 0x00008B55,
    
    /// <remarks>
    /// <c>#define GL_BOOL 0x8B56</c>
    /// </remarks>
    Bool = 0x00008B56,
    
    /// <remarks>
    /// <c>#define GL_BOOL_VEC2 0x8B57</c>
    /// </remarks>
    BoolVec2 = 0x00008B57,
    
    /// <remarks>
    /// <c>#define GL_BOOL_VEC3 0x8B58</c>
    /// </remarks>
    BoolVec3 = 0x00008B58,
    
    /// <remarks>
    /// <c>#define GL_BOOL_VEC4 0x8B59</c>
    /// </remarks>
    BoolVec4 = 0x00008B59,
    
    /// <remarks>
    /// <c>#define GL_FLOAT_MAT2 0x8B5A</c>
    /// </remarks>
    FloatMat2 = 0x00008B5A,
    
    /// <remarks>
    /// <c>#define GL_FLOAT_MAT3 0x8B5B</c>
    /// </remarks>
    FloatMat3 = 0x00008B5B,
    
    /// <remarks>
    /// <c>#define GL_FLOAT_MAT4 0x8B5C</c>
    /// </remarks>
    FloatMat4 = 0x00008B5C,
    
    /// <remarks>
    /// <c>#define GL_SAMPLER_1D 0x8B5D</c>
    /// </remarks>
    Sampler1D = 0x00008B5D,
    
    /// <remarks>
    /// <c>#define GL_SAMPLER_2D 0x8B5E</c>
    /// </remarks>
    Sampler2D = 0x00008B5E,
    
    /// <remarks>
    /// <c>#define GL_SAMPLER_3D 0x8B5F</c>
    /// </remarks>
    Sampler3D = 0x00008B5F,
    
    /// <remarks>
    /// <c>#define GL_SAMPLER_CUBE 0x8B60</c>
    /// </remarks>
    SamplerCube = 0x00008B60,
    
    /// <remarks>
    /// <c>#define GL_SAMPLER_1D_SHADOW 0x8B61</c>
    /// </remarks>
    Sampler1DShadow = 0x00008B61,
    
    /// <remarks>
    /// <c>#define GL_SAMPLER_2D_SHADOW 0x8B62</c>
    /// </remarks>
    Sampler2DShadow = 0x00008B62,
    
    /// <remarks>
    /// <c>#define GL_SAMPLER_2D_RECT 0x8B63</c>
    /// </remarks>
    Sampler2DRect = 0x00008B63,
    
    /// <remarks>
    /// <c>#define GL_SAMPLER_2D_RECT_SHADOW 0x8B64</c>
    /// </remarks>
    Sampler2DRectShadow = 0x00008B64,
    
    /// <remarks>
    /// <c>#define GL_FLOAT_MAT2x3 0x8B65</c>
    /// </remarks>
    FloatMatrix2x3 = 0x00008B65,
    
    /// <remarks>
    /// <c>#define GL_FLOAT_MAT2x4 0x8B66</c>
    /// </remarks>
    FloatMatrix2x4 = 0x00008B66,
    
    /// <remarks>
    /// <c>#define GL_FLOAT_MAT3x2 0x8B67</c>
    /// </remarks>
    FloatMatrix3x2 = 0x00008B67,
    
    /// <remarks>
    /// <c>#define GL_FLOAT_MAT3x4 0x8B68</c>
    /// </remarks>
    FloatMatrix3x4 = 0x00008B68,
    
    /// <remarks>
    /// <c>#define GL_FLOAT_MAT4x2 0x8B69</c>
    /// </remarks>
    FloatMatrix4x2 = 0x00008B69,
    
    /// <remarks>
    /// <c>#define GL_FLOAT_MAT4x3 0x8B6A</c>
    /// </remarks>
    FloatMatrix4x3 = 0x00008B6A,
    
    /// <remarks>
    /// <c>#define GL_SAMPLER_1D_ARRAY 0x8DC0</c>
    /// </remarks>
    Sampler1DArray = 0x00008DC0,
    
    /// <remarks>
    /// <c>#define GL_SAMPLER_2D_ARRAY 0x8DC1</c>
    /// </remarks>
    Sampler2DArray = 0x00008DC1,
    
    /// <remarks>
    /// <c>#define GL_SAMPLER_BUFFER 0x8DC2</c>
    /// </remarks>
    SamplerBuffer = 0x00008DC2,
    
    /// <remarks>
    /// <c>#define GL_SAMPLER_1D_ARRAY_SHADOW 0x8DC3</c>
    /// </remarks>
    Sampler1DArrayShadow = 0x00008DC3,
    
    /// <remarks>
    /// <c>#define GL_SAMPLER_2D_ARRAY_SHADOW 0x8DC4</c>
    /// </remarks>
    Sampler2DArrayShadow = 0x00008DC4,
    
    /// <remarks>
    /// <c>#define GL_SAMPLER_CUBE_SHADOW 0x8DC5</c>
    /// </remarks>
    SamplerCubeShadow = 0x00008DC5,
    
    /// <remarks>
    /// <c>#define GL_UNSIGNED_INT_VEC2 0x8DC6</c>
    /// </remarks>
    UnsignedIntVec2 = 0x00008DC6,
    
    /// <remarks>
    /// <c>#define GL_UNSIGNED_INT_VEC3 0x8DC7</c>
    /// </remarks>
    UnsignedIntVec3 = 0x00008DC7,
    
    /// <remarks>
    /// <c>#define GL_UNSIGNED_INT_VEC4 0x8DC8</c>
    /// </remarks>
    UnsignedIntVec4 = 0x00008DC8,
    
    /// <remarks>
    /// <c>#define GL_INT_SAMPLER_1D 0x8DC9</c>
    /// </remarks>
    IntSampler1D = 0x00008DC9,
    
    /// <remarks>
    /// <c>#define GL_INT_SAMPLER_2D 0x8DCA</c>
    /// </remarks>
    IntSampler2D = 0x00008DCA,
    
    /// <remarks>
    /// <c>#define GL_INT_SAMPLER_3D 0x8DCB</c>
    /// </remarks>
    IntSampler3D = 0x00008DCB,
    
    /// <remarks>
    /// <c>#define GL_INT_SAMPLER_CUBE 0x8DCC</c>
    /// </remarks>
    IntSamplerCube = 0x00008DCC,
    
    /// <remarks>
    /// <c>#define GL_INT_SAMPLER_2D_RECT 0x8DCD</c>
    /// </remarks>
    IntSampler2DRect = 0x00008DCD,
    
    /// <remarks>
    /// <c>#define GL_INT_SAMPLER_1D_ARRAY 0x8DCE</c>
    /// </remarks>
    IntSampler1DArray = 0x00008DCE,
    
    /// <remarks>
    /// <c>#define GL_INT_SAMPLER_2D_ARRAY 0x8DCF</c>
    /// </remarks>
    IntSampler2DArray = 0x00008DCF,
    
    /// <remarks>
    /// <c>#define GL_INT_SAMPLER_BUFFER 0x8DD0</c>
    /// </remarks>
    IntSamplerBuffer = 0x00008DD0,
    
    /// <remarks>
    /// <c>#define GL_UNSIGNED_INT_SAMPLER_1D 0x8DD1</c>
    /// </remarks>
    UnsignedIntSampler1D = 0x00008DD1,
    
    /// <remarks>
    /// <c>#define GL_UNSIGNED_INT_SAMPLER_2D 0x8DD2</c>
    /// </remarks>
    UnsignedIntSampler2D = 0x00008DD2,
    
    /// <remarks>
    /// <c>#define GL_UNSIGNED_INT_SAMPLER_3D 0x8DD3</c>
    /// </remarks>
    UnsignedIntSampler3D = 0x00008DD3,
    
    /// <remarks>
    /// <c>#define GL_UNSIGNED_INT_SAMPLER_CUBE 0x8DD4</c>
    /// </remarks>
    UnsignedIntSamplerCube = 0x00008DD4,
    
    /// <remarks>
    /// <c>#define GL_UNSIGNED_INT_SAMPLER_2D_RECT 0x8DD5</c>
    /// </remarks>
    UnsignedIntSampler2DRect = 0x00008DD5,
    
    /// <remarks>
    /// <c>#define GL_UNSIGNED_INT_SAMPLER_1D_ARRAY 0x8DD6</c>
    /// </remarks>
    UnsignedIntSampler1DArray = 0x00008DD6,
    
    /// <remarks>
    /// <c>#define GL_UNSIGNED_INT_SAMPLER_2D_ARRAY 0x8DD7</c>
    /// </remarks>
    UnsignedIntSampler2DArray = 0x00008DD7,
    
    /// <remarks>
    /// <c>#define GL_UNSIGNED_INT_SAMPLER_BUFFER 0x8DD8</c>
    /// </remarks>
    UnsignedIntSamplerBuffer = 0x00008DD8,
    
    /// <remarks>
    /// <c>#define GL_DOUBLE_VEC2 0x8FFC</c>
    /// </remarks>
    DoubleVec2 = 0x00008FFC,
    
    /// <remarks>
    /// <c>#define GL_DOUBLE_VEC3 0x8FFD</c>
    /// </remarks>
    DoubleVec3 = 0x00008FFD,
    
    /// <remarks>
    /// <c>#define GL_DOUBLE_VEC4 0x8FFE</c>
    /// </remarks>
    DoubleVec4 = 0x00008FFE,
    
    /// <remarks>
    /// <c>#define GL_SAMPLER_CUBE_MAP_ARRAY 0x900C</c>
    /// </remarks>
    SamplerCubeMapArray = 0x0000900C,
    
    /// <remarks>
    /// <c>#define GL_SAMPLER_CUBE_MAP_ARRAY_SHADOW 0x900D</c>
    /// </remarks>
    SamplerCubeMapArrayShadow = 0x0000900D,
    
    /// <remarks>
    /// <c>#define GL_INT_SAMPLER_CUBE_MAP_ARRAY 0x900E</c>
    /// </remarks>
    IntSamplerCubeMapArray = 0x0000900E,

    /// <remarks>
    /// <c>#define GL_UNSIGNED_INT_SAMPLER_CUBE_MAP_ARRAY 0x900F</c>
    /// </remarks>
    UnsignedIntSamplerCubeMapArray = 0x0000900F,
    
    /// <remarks>
    /// <c>#define GL_IMAGE_1D 0x904C</c>
    /// </remarks>
    Image1D = 0x0000904C,
    
    /// <remarks>
    /// <c>#define GL_IMAGE_2D 0x904D</c>
    /// </remarks>
    Image2D = 0x0000904D,
    
    /// <remarks>
    /// <c>#define GL_IMAGE_3D 0x904E</c>
    /// </remarks>
    Image3D = 0x0000904E,
    
    /// <remarks>
    /// <c>#define GL_IMAGE_2D_RECT 0x904F</c>
    /// </remarks>
    Image2DRect = 0x0000904F,
    
    /// <remarks>
    /// <c>#define GL_IMAGE_CUBE 0x9050</c>
    /// </remarks>
    ImageCube = 0x00009050,
    
    /// <remarks>
    /// <c>#define GL_IMAGE_BUFFER 0x9051</c>
    /// </remarks>
    ImageBuffer = 0x00009051,
    
    /// <remarks>
    /// <c>#define GL_IMAGE_1D_ARRAY 0x9052</c>
    /// </remarks>
    Image1DArray = 0x00009052,
    
    /// <remarks>
    /// <c>#define GL_IMAGE_2D_ARRAY 0x9053</c>
    /// </remarks>
    Image2DArray = 0x00009053,
    
    /// <remarks>
    /// <c>#define GL_IMAGE_CUBE_MAP_ARRAY 0x9054</c>
    /// </remarks>
    ImageCubeMapArray = 0x00009054,
    
    /// <remarks>
    /// <c>#define GL_IMAGE_2D_MULTISAMPLE 0x9055</c>
    /// </remarks>
    Image2DMultisample = 0x00009055,
    
    /// <remarks>
    /// <c>#define GL_IMAGE_2D_MULTISAMPLE_ARRAY 0x9056</c>
    /// </remarks>
    Image2DMultisampleArray = 0x00009056,
    
    /// <remarks>
    /// <c>#define GL_INT_IMAGE_1D 0x9057</c>
    /// </remarks>
    IntImage1D = 0x00009057,
    
    /// <remarks>
    /// <c>#define GL_INT_IMAGE_2D 0x9058</c>
    /// </remarks>
    IntImage2D = 0x00009058,
    
    /// <remarks>
    /// <c>#define GL_INT_IMAGE_3D 0x9059</c>
    /// </remarks>
    IntImage3D = 0x00009059,
    
    /// <remarks>
    /// <c>#define GL_INT_IMAGE_2D_RECT 0x905A</c>
    /// </remarks>
    IntImage2DRect = 0x0000905A,
    
    /// <remarks>
    /// <c>#define GL_INT_IMAGE_CUBE 0x905B</c>
    /// </remarks>
    IntImageCube = 0x0000905B,
    
    /// <remarks>
    /// <c>#define GL_INT_IMAGE_BUFFER 0x905C</c>
    /// </remarks>
    IntImageBuffer = 0x0000905C,
    
    /// <remarks>
    /// <c>#define GL_INT_IMAGE_1D_ARRAY 0x905D</c>
    /// </remarks>
    IntImage1DArray = 0x0000905D,
    
    /// <remarks>
    /// <c>#define GL_INT_IMAGE_2D_ARRAY 0x905E</c>
    /// </remarks>
    IntImage2DArray = 0x0000905E,
    
    /// <remarks>
    /// <c>#define GL_INT_IMAGE_CUBE_MAP_ARRAY 0x905F</c>
    /// </remarks>
    IntImageCubeMapArray = 0x0000905F,
    
    /// <remarks>
    /// <c>#define GL_INT_IMAGE_2D_MULTISAMPLE 0x9060</c>
    /// </remarks>
    IntImage2DMultisample = 0x00009060,
    
    /// <remarks>
    /// <c>#define GL_INT_IMAGE_2D_MULTISAMPLE_ARRAY 0x9061</c>
    /// </remarks>
    IntImage2DMultisampleArray = 0x00009061,
    
    /// <remarks>
    /// <c>#define GL_UNSIGNED_INT_IMAGE_1D 0x9062</c>
    /// </remarks>
    UnsignedIntImage1D = 0x00009062,
    
    /// <remarks>
    /// <c>#define GL_UNSIGNED_INT_IMAGE_2D 0x9063</c>
    /// </remarks>
    UnsignedIntImage2D = 0x00009063,
    
    /// <remarks>
    /// <c>#define GL_UNSIGNED_INT_IMAGE_3D 0x9064</c>
    /// </remarks>
    UnsignedIntImage3D = 0x00009064,
    
    /// <remarks>
    /// <c>#define GL_UNSIGNED_INT_IMAGE_2D_RECT 0x9065</c>
    /// </remarks>
    UnsignedIntImage2DRect = 0x00009065,
    
    /// <remarks>
    /// <c>#define GL_UNSIGNED_INT_IMAGE_CUBE 0x9066</c>
    /// </remarks>
    UnsignedIntImageCube = 0x00009066,
    
    /// <remarks>
    /// <c>#define GL_UNSIGNED_INT_IMAGE_BUFFER 0x9067</c>
    /// </remarks>
    UnsignedIntImageBuffer = 0x00009067,
    
    /// <remarks>
    /// <c>#define GL_UNSIGNED_INT_IMAGE_1D_ARRAY 0x9068</c>
    /// </remarks>
    UnsignedIntImage1DArray = 0x00009068,
    
    /// <remarks>
    /// <c>#define GL_UNSIGNED_INT_IMAGE_2D_ARRAY 0x9069</c>
    /// </remarks>
    UnsignedIntImage2DArray = 0x00009069,
    
    /// <remarks>
    /// <c>#define GL_UNSIGNED_INT_IMAGE_CUBE_MAP_ARRAY 0x906A</c>
    /// </remarks>
    UnsignedIntImageCubeMapArray = 0x0000906A,
    
    /// <remarks>
    /// <c>#define GL_UNSIGNED_INT_IMAGE_2D_MULTISAMPLE 0x906B</c>
    /// </remarks>
    UnsignedIntImage2DMultisample = 0x0000906B,
    
    /// <remarks>
    /// <c>#define GL_UNSIGNED_INT_IMAGE_2D_MULTISAMPLE_ARRAY 0x906C</c>
    /// </remarks>
    UnsignedIntImage2DMultisampleArray = 0x0000906C,
    
    /// <remarks>
    /// <c>#define GL_SAMPLER_2D_MULTISAMPLE 0x9108</c>
    /// </remarks>
    Sampler2DMultisample = 0x00009108,
    
    /// <remarks>
    /// <c>#define GL_INT_SAMPLER_2D_MULTISAMPLE 0x9109</c>
    /// </remarks>
    IntSampler2DMultisample = 0x00009109,
    
    /// <remarks>
    /// <c>#define GL_UNSIGNED_INT_SAMPLER_2D_MULTISAMPLE 0x910A</c>
    /// </remarks>
    UnsignedIntSampler2DMultisample = 0x0000910A,
    
    /// <remarks>
    /// <c>#define GL_SAMPLER_2D_MULTISAMPLE_ARRAY 0x910B</c>
    /// </remarks>
    Sampler2DMultisampleArray = 0x0000910B,
    
    /// <remarks>
    /// <c>#define GL_INT_SAMPLER_2D_MULTISAMPLE_ARRAY 0x910C</c>
    /// </remarks>
    IntSampler2DMultisampleArray = 0x0000910C,
    
    /// <remarks>
    /// <c>#define GL_UNSIGNED_INT_SAMPLER_2D_MULTISAMPLE_ARRAY 0x910D</c>
    /// </remarks>
    UnsignedIntSampler2DMultisampleArray = 0x0000910D,
    
    /// <remarks>
    /// <c>#define GL_UNSIGNED_INT_ATOMIC_COUNTER 0x92DB</c>
    /// </remarks>
    UnsignedIntAtomicCounter = 0x000092DB,
    
}