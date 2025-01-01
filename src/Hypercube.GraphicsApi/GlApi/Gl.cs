using System.Runtime.InteropServices;
using Hypercube.GraphicsApi.GlApi.Enum;
using Hypercube.Mathematics;
using Hypercube.Mathematics.Vectors;
using Hypercube.Utilities.Extensions;
using JetBrains.Annotations;

// ReSharper disable CommentTypo
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace Hypercube.GraphicsApi.GlApi;

[PublicAPI]
public static unsafe class Gl
{
    public const int NullArray = 0;
    public const int NullBuffer = 0;
    
    public static void LoadBindings(IBindingsContext context)
    {
        GlNative.LoadBindings(context);
    }
    
    public static void PolygonMode(PolygonFace face, PolygonMode mode)
    {
        GlNative.glPolygonMode((uint) face, (uint) mode);
    }
    
    public static string GetString(StringName name)
    {
        var pointer = GlNative.glGetString((uint) name);
        var str = Marshal.PtrToStringUTF8((nint) pointer) ?? string.Empty;
        return str;
    }
    
    public static void CullFace(CullFaceMode mode)
    {
        GlNative.glCullFace((uint) mode);
    }
    
     public static void CullFace(uint mode)
    {
        GlNative.glCullFace(mode);
    }

    public static void FrontFace(uint mode)
    {
        GlNative.glFrontFace(mode);
    }

    public static void Hint(uint target, uint mode)
    {
        GlNative.glHint(target, mode);
    }

    public static void LineWidth(float width)
    {
        GlNative.glLineWidth(width);
    }

    public static void PointSize(float size)
    {
        GlNative.glPointSize(size);
    }

    public static void PolygonMode(uint face, uint mode)
    {
        GlNative.glPolygonMode(face, mode);
    }

    public static void Scissor(int x, int y, int width, int height)
    {
        GlNative.glScissor(x, y, width, height);
    }

    public static void TexParameterf(uint target, uint pname, float param)
    {
        GlNative.glTexParameterf(target, pname, param);
    }

    public static void TexParameterfv(uint target, uint pname, float* prms)
    {
        GlNative.glTexParameterfv(target, pname, prms);
    }

    public static void TexParameteri(uint target, uint pname, int param)
    {
        GlNative.glTexParameteri(target, pname, param);
    }

    public static void TexParameteriv(uint target, uint pname, int* prms)
    {
        GlNative.glTexParameteriv(target, pname, prms);
    }

    public static void TexImage1D(uint target, int level, int internalformat, int width, int border, uint format, uint type, void* pixels)
    {
        GlNative.glTexImage1D(target, level, internalformat, width, border, format, type, pixels);
    }

    public static void TexImage2D(uint target, int level, int internalformat, int width, int height, int border, uint format, uint type, void* pixels)
    {
        GlNative.glTexImage2D(target, level, internalformat, width, height, border, format, type, pixels);
    }

    public static void DrawBuffer(uint buf)
    {
        GlNative.glDrawBuffer(buf);
    }
    
    public static void Clear(ClearBufferMask mask)
    {
        GlNative.glClear((uint) mask);
    }

    public static void Clear(uint mask)
    {
        GlNative.glClear(mask);
    }
    
    public static void ClearColor(Color color)
    {
        GlNative.glClearColor(color.R, color.G, color.B, color.A);
    }

    public static void ClearColor(float red, float green, float blue, float alpha)
    {
        GlNative.glClearColor(red, green, blue, alpha);
    }

    public static void ClearStencil(int s)
    {
        GlNative.glClearStencil(s);
    }

    public static void ClearDepth(double depth)
    {
        GlNative.glClearDepth(depth);
    }

    public static void StencilMask(uint mask)
    {
        GlNative.glStencilMask(mask);
    }
    
    public static void ColorMask(bool red, bool green, bool blue, bool alpha)
    {
        GlNative.glColorMask(red.ToInt(), green.ToInt(), blue.ToInt(), alpha.ToInt());
    }

    public static void ColorMask(int red, int green, int blue, int alpha)
    {
        GlNative.glColorMask(red, green, blue, alpha);
    }

    public static void DepthMask(int flag)
    {
        GlNative.glDepthMask(flag);
    }

    public static void Disable(EnableCap cap)
    {
        GlNative.glDisable((uint) cap);
    }
    
    public static void Disable(uint cap)
    {
        GlNative.glDisable(cap);
    }
    
    public static void Enable(EnableCap cap)
    {
        GlNative.glEnable((uint) cap);
    }

    public static void Enable(uint cap)
    {
        GlNative.glEnable(cap);
    }

    public static void Finish()
    {
        GlNative.glFinish();
    }

    public static void Flush()
    {
        GlNative.glFlush();
    }

    public static void BlendFunc(uint sfactor, uint dfactor)
    {
        GlNative.glBlendFunc(sfactor, dfactor);
    }

    public static void LogicOp(uint opcode)
    {
        GlNative.glLogicOp(opcode);
    }

    public static void StencilFunc(uint func, int refer, uint mask)
    {
        GlNative.glStencilFunc(func, refer, mask);
    }

    public static void StencilOp(uint fail, uint zfail, uint zpass)
    {
        GlNative.glStencilOp(fail, zfail, zpass);
    }

    public static void DepthFunc(uint func)
    {
        GlNative.glDepthFunc(func);
    }

    public static void PixelStoref(uint pname, float param)
    {
        GlNative.glPixelStoref(pname, param);
    }

    public static void PixelStorei(uint pname, int param)
    {
        GlNative.glPixelStorei(pname, param);
    }

    public static void ReadBuffer(uint src)
    {
        GlNative.glReadBuffer(src);
    }

    public static void ReadPixels(int x, int y, int width, int height, uint format, uint type, void* pixels)
    {
        GlNative.glReadPixels(x, y, width, height, format, type, pixels);
    }

    public static void GetBooleanv(uint pname, int* data)
    {
        GlNative.glGetBooleanv(pname, data);
    }

    public static void GetDoublev(uint pname, double* data)
    {
        GlNative.glGetDoublev(pname, data);
    }

    public static uint GetError()
    {
        return GlNative.glGetError();
    }

    public static void GetFloatv(uint pname, float* data)
    {
        GlNative.glGetFloatv(pname, data);
    }

    public static void GetIntegerv(uint pname, int* data)
    {
        GlNative.glGetIntegerv(pname, data);
    }

    public static void GetTexImage(uint target, int level, uint format, uint type, void* pixels)
    {
        GlNative.glGetTexImage(target, level, format, type, pixels);
    }

    public static void GetTexParameterfv(uint target, uint pname, float* prms)
    {
        GlNative.glGetTexParameterfv(target, pname, prms);
    }

    public static void GetTexParameteriv(uint target, uint pname, int* prms)
    {
        GlNative.glGetTexParameteriv(target, pname, prms);
    }

    public static void GetTexLevelParameterfv(uint target, int level, uint pname, float* prms)
    {
        GlNative.glGetTexLevelParameterfv(target, level, pname, prms);
    }

    public static void GetTexLevelParameteriv(uint target, int level, uint pname, int* prms)
    {
        GlNative.glGetTexLevelParameteriv(target, level, pname, prms);
    }

    public static int IsEnabled(uint cap)
    {
        return GlNative.glIsEnabled(cap);
    }

    public static void DepthRange(double n, double f)
    {
        GlNative.glDepthRange(n, f);
    }

    public static void Viewport(int x, int y, int width, int height)
    {
        GlNative.glViewport(x, y, width, height);
    }

    public static void DrawArrays(uint mode, int first, int count)
    {
        GlNative.glDrawArrays(mode, first, count);
    }
    
    public static void DrawElements(int count, int indices)
    {
        DrawElements(PrimitiveType.Triangles, count, DrawElementsType.UnsignedShort, indices);
    }
    
    public static void DrawElements(PrimitiveType mode, int count, DrawElementsType type, int indices)
    {
        var pointer = (void*)&indices;
        GlNative.glDrawElements((uint) mode, count, (uint) type, pointer);
    }

    public static void DrawElements(uint mode, int count, uint type, void* indices)
    {
        GlNative.glDrawElements(mode, count, type, indices);
    }

    public static void GetPointerv(uint pname, void** prms)
    {
        GlNative.glGetPointerv(pname, prms);
    }

    public static void PolygonOffset(float factor, float units)
    {
        GlNative.glPolygonOffset(factor, units);
    }

    public static void CopyTexImage1D(uint target, int level, uint internalformat, int x, int y, int width, int border)
    {
        GlNative.glCopyTexImage1D(target, level, internalformat, x, y, width, border);
    }

    public static void CopyTexImage2D(uint target, int level, uint internalformat, int x, int y, int width, int height, int border)
    {
        GlNative.glCopyTexImage2D(target, level, internalformat, x, y, width, height, border);
    }

    public static void CopyTexSubImage1D(uint target, int level, int xoffset, int x, int y, int width)
    {
        GlNative.glCopyTexSubImage1D(target, level, xoffset, x, y, width);
    }

    public static void CopyTexSubImage2D(uint target, int level, int xoffset, int yoffset, int x, int y, int width, int height)
    {
        GlNative.glCopyTexSubImage2D(target, level, xoffset, yoffset, x, y, width, height);
    }

    public static void TexSubImage1D(uint target, int level, int xoffset, int width, uint format, uint type, void* pixels)
    {
        GlNative.glTexSubImage1D(target, level, xoffset, width, format, type, pixels);
    }

    public static void TexSubImage2D(uint target, int level, int xoffset, int yoffset, int width, int height, uint format, uint type, void* pixels)
    {
        GlNative.glTexSubImage2D(target, level, xoffset, yoffset, width, height, format, type, pixels);
    }

    public static void BindTexture(uint target, uint texture)
    {
        GlNative.glBindTexture(target, texture);
    }

    public static void DeleteTextures(int n, uint* textures)
    {
        GlNative.glDeleteTextures(n, textures);
    }

    public static void GenTextures(int n, uint* textures)
    {
        GlNative.glGenTextures(n, textures);
    }

    public static int IsTexture(uint texture)
    {
        return GlNative.glIsTexture(texture);
    }

    public static void DrawRangeElements(uint mode, uint start, uint end, int count, uint type, void* indices)
    {
        GlNative.glDrawRangeElements(mode, start, end, count, type, indices);
    }

    public static void TexImage3D(uint target, int level, int internalformat, int width, int height, int depth, int border, uint format, uint type, void* pixels)
    {
        GlNative.glTexImage3D(target, level, internalformat, width, height, depth, border, format, type, pixels);
    }

    public static void TexSubImage3D(uint target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, uint format, uint type, void* pixels)
    {
        GlNative.glTexSubImage3D(target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, pixels);
    }

    public static void CopyTexSubImage3D(uint target, int level, int xoffset, int yoffset, int zoffset, int x, int y, int width, int height)
    {
        GlNative.glCopyTexSubImage3D(target, level, xoffset, yoffset, zoffset, x, y, width, height);
    }

    public static void ActiveTexture(uint texture)
    {
        GlNative.glActiveTexture(texture);
    }

    public static void SampleCoverage(float value, int invert)
    {
        GlNative.glSampleCoverage(value, invert);
    }

    public static void CompressedTexImage3D(uint target, int level, uint internalformat, int width, int height, int depth, int border, int imageSize, void* data)
    {
        GlNative.glCompressedTexImage3D(target, level, internalformat, width, height, depth, border, imageSize, data);
    }

    public static void CompressedTexImage2D(uint target, int level, uint internalformat, int width, int height, int border, int imageSize, void* data)
    {
        GlNative.glCompressedTexImage2D(target, level, internalformat, width, height, border, imageSize, data);
    }

    public static void CompressedTexImage1D(uint target, int level, uint internalformat, int width, int border, int imageSize, void* data)
    {
        GlNative.glCompressedTexImage1D(target, level, internalformat, width, border, imageSize, data);
    }

    public static void CompressedTexSubImage3D(uint target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, uint format, int imageSize, void* data)
    {
        GlNative.glCompressedTexSubImage3D(target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, data);
    }

    public static void CompressedTexSubImage2D(uint target, int level, int xoffset, int yoffset, int width, int height, uint format, int imageSize, void* data)
    {
        GlNative.glCompressedTexSubImage2D(target, level, xoffset, yoffset, width, height, format, imageSize, data);
    }

    public static void CompressedTexSubImage1D(uint target, int level, int xoffset, int width, uint format, int imageSize, void* data)
    {
        GlNative.glCompressedTexSubImage1D(target, level, xoffset, width, format, imageSize, data);
    }

    public static void GetCompressedTexImage(uint target, int level, void* img)
    {
        GlNative.glGetCompressedTexImage(target, level, img);
    }

    public static void BlendFuncSeparate(uint sfactorRGB, uint dfactorRGB, uint sfactorAlpha, uint dfactorAlpha)
    {
        GlNative.glBlendFuncSeparate(sfactorRGB, dfactorRGB, sfactorAlpha, dfactorAlpha);
    }

    public static void MultiDrawArrays(uint mode, int* first, int* count, int drawcount)
    {
        GlNative.glMultiDrawArrays(mode, first, count, drawcount);
    }

    public static void MultiDrawElements(uint mode, int* count, uint type, void** indices, int drawcount)
    {
        GlNative.glMultiDrawElements(mode, count, type, indices, drawcount);
    }

    public static void PointParameterf(uint pname, float param)
    {
        GlNative.glPointParameterf(pname, param);
    }

    public static void PointParameterfv(uint pname, float* prms)
    {
        GlNative.glPointParameterfv(pname, prms);
    }

    public static void PointParameteri(uint pname, int param)
    {
        GlNative.glPointParameteri(pname, param);
    }

    public static void PointParameteriv(uint pname, int* prms)
    {
        GlNative.glPointParameteriv(pname, prms);
    }

    public static void BlendColor(float red, float green, float blue, float alpha)
    {
        GlNative.glBlendColor(red, green, blue, alpha);
    }

    public static void BlendEquation(uint mode)
    {
        GlNative.glBlendEquation(mode);
    }

    public static void GenQueries(int n, uint* ids)
    {
        GlNative.glGenQueries(n, ids);
    }

    public static void DeleteQueries(int n, uint* ids)
    {
        GlNative.glDeleteQueries(n, ids);
    }

    public static int IsQuery(uint id)
    {
        return GlNative.glIsQuery(id);
    }

    public static void BeginQuery(uint target, uint id)
    {
        GlNative.glBeginQuery(target, id);
    }

    public static void EndQuery(uint target)
    {
        GlNative.glEndQuery(target);
    }

    public static void GetQueryiv(uint target, uint pname, int* prms)
    {
        GlNative.glGetQueryiv(target, pname, prms);
    }

    public static void GetQueryObjectiv(uint id, uint pname, int* prms)
    {
        GlNative.glGetQueryObjectiv(id, pname, prms);
    }

    public static void GetQueryObjectuiv(uint id, uint pname, uint* prms)
    {
        GlNative.glGetQueryObjectuiv(id, pname, prms);
    }

    public static void UnbindBuffer(BufferTarget target)
    {
        BindBuffer(target, NullBuffer);
    }
    
    public static void BindBuffer(BufferTarget target, int buffer)
    {
        BindBuffer(target, (uint) buffer);
    }
    
    public static void BindBuffer(BufferTarget target, uint buffer)
    {
        GlNative.glBindBuffer((uint) target, buffer);
    }
    
    public static void BindBuffer(uint target, uint buffer)
    {
        GlNative.glBindBuffer(target, buffer);
    }
    
    public static void DeleteBuffer(int handle)
    {
        DeleteBuffer((uint) handle);
    }
    
    public static void DeleteBuffer(uint handle)
    {
        GlNative.glDeleteVertexArrays(1, &handle);
    }

    public static void DeleteBuffers(int n, uint* buffers)
    {
        GlNative.glDeleteBuffers(n, buffers);
    }
    
    public static int GenBuffer()
    {
        uint id;
        GlNative.glGenBuffers(1, &id);
        return (int) id;
    }

    public static void GenBuffers(int n, uint* buffers)
    {
        GlNative.glGenBuffers(n, buffers);
    }

    public static int IsBuffer(uint buffer)
    {
        return GlNative.glIsBuffer(buffer);
    }

    public static void BufferData(BufferTarget target, int size, nint data, BufferUsageHint usage)
    {
        GlNative.glBufferData((uint) target, size, (void*) data, (uint) usage);
    }
    
    public static void BufferData<T>(BufferTarget target, int size, T[] data, BufferUsageHint usage)
        where T : unmanaged
    {
        fixed (void* local = data)
        {
            GlNative.glBufferData((uint) target, size, local, (uint) usage);
        }
    }
    
    public static void BufferData(uint target, nint size, void* data, uint usage)
    {
        GlNative.glBufferData(target, size, data, usage);
    }

    public static void BufferSubData<T>(BufferTarget target, nint offset, int size, T[] data)
        where T : unmanaged
    {
        fixed (void* local = data)
        {
            GlNative.glBufferSubData((uint)target, offset, size, local);
        }
    }
    
    public static void BufferSubData(BufferTarget target, nint offset, int size, nint data)
    {
        GlNative.glBufferSubData((uint) target, offset, size, (void*) data);
    }
    
    public static void BufferSubData(uint target, nint offset, nint size, void* data)
    {
        GlNative.glBufferSubData(target, offset, size, data);
    }

    public static void GetBufferSubData(uint target, nint offset, nint size, void* data)
    {
        GlNative.glGetBufferSubData(target, offset, size, data);
    }

    public static int UnmapBuffer(uint target)
    {
        return GlNative.glUnmapBuffer(target);
    }

    public static void GetBufferParameteriv(uint target, uint pname, int* prms)
    {
        GlNative.glGetBufferParameteriv(target, pname, prms);
    }

    public static void GetBufferPointerv(uint target, uint pname, void** prms)
    {
        GlNative.glGetBufferPointerv(target, pname, prms);
    }

    public static void BlendEquationSeparate(uint modeRGB, uint modeAlpha)
    {
        GlNative.glBlendEquationSeparate(modeRGB, modeAlpha);
    }

    public static void DrawBuffers(int n, uint* bufs)
    {
        GlNative.glDrawBuffers(n, bufs);
    }

    public static void StencilOpSeparate(uint face, uint sfail, uint dpfail, uint dppass)
    {
        GlNative.glStencilOpSeparate(face, sfail, dpfail, dppass);
    }

    public static void StencilFuncSeparate(uint face, uint func, int refer, uint mask)
    {
        GlNative.glStencilFuncSeparate(face, func, refer, mask);
    }

    public static void StencilMaskSeparate(uint face, uint mask)
    {
        GlNative.glStencilMaskSeparate(face, mask);
    }

    public static void AttachShader(int program, int shader)
    {
        GlNative.glAttachShader((uint) program, (uint) shader);
    }
    
    public static void AttachShader(uint program, uint shader)
    {
        GlNative.glAttachShader(program, shader);
    }

    public static void BindAttribLocation(uint program, uint index, byte* name)
    {
        GlNative.glBindAttribLocation(program, index, name);
    }

    public static void CompileShader(int shader)
    {
        GlNative.glCompileShader((uint) shader);
    }

    public static int CreateProgram()
    {
        return (int) GlNative.glCreateProgram();
    }

    public static int CreateShader(ShaderType type)
    {
        return (int) GlNative.glCreateShader((uint) type);
    }

    public static void DeleteProgram(int program)
    {
        GlNative.glDeleteProgram((uint) program);
    }
    
    public static void DeleteProgram(uint program)
    {
        GlNative.glDeleteProgram(program);
    }

    public static void DeleteShader(int shader)
    {
        GlNative.glDeleteShader((uint) shader);
    }
    
    public static void DeleteShader(uint shader)
    {
        GlNative.glDeleteShader(shader);
    }
    
    public static void DetachShader(int program, int shader)
    {
        GlNative.glDetachShader((uint) program, (uint) shader);
    }

    public static void DetachShader(uint program, uint shader)
    {
        GlNative.glDetachShader(program, shader);
    }

    public static void DisableVertexAttribArray(uint index)
    {
        GlNative.glDisableVertexAttribArray(index);
    }

    public static void EnableVertexAttribArray(uint index)
    {
        GlNative.glEnableVertexAttribArray(index);
    }

    public static void GetActiveAttrib(uint program, uint index, int bufSize, int* length, int* size, uint* type, byte* name)
    {
        GlNative.glGetActiveAttrib(program, index, bufSize, length, size, type, name);
    }

    public static void GetActiveUniform(int program, int uniformIndex, out int length, out int size, out ActiveUniform type, out string name)
    {
        var maxLength = GetProgram(program, ProgramParameter.ActiveUniformMaxLength);
        var nameLength = maxLength == 0 ? 1 : maxLength;

        var lengthPointer = 0;
        var sizePointer = 0;
        var typePointer = 0u;
        var namePointer = (byte) 0;
        GlNative.glGetActiveUniform((uint) program, (uint) uniformIndex, nameLength, &lengthPointer, &sizePointer, &typePointer, &namePointer);

        length = lengthPointer;
        size = sizePointer;
        type = (ActiveUniform) typePointer;
        name = Marshal.PtrToStringUTF8(namePointer) ?? string.Empty;
    }
    
    public static void GetActiveUniform(uint program, uint index, int bufSize, int* length, int* size, uint* type, byte* name)
    {
        GlNative.glGetActiveUniform(program, index, bufSize, length, size, type, name);
    }

    public static void GetAttachedShaders(uint program, int maxCount, int* count, uint* shaders)
    {
        GlNative.glGetAttachedShaders(program, maxCount, count, shaders);
    }

    public static int GetAttribLocation(uint program, byte* name)
    {
        return GlNative.glGetAttribLocation(program, name);
    }

    public static int GetProgram(int program, ProgramParameter parameter)
    {
        var parametrs = 0;
        GlNative.glGetProgramiv((uint) program, (uint) parameter, &parametrs);
        return parametrs;
    }

    public static void GetProgram(uint program, uint name, int* parametrs)
    {
        GlNative.glGetProgramiv(program, name, parametrs);
    }
    
    public static void GetProgramInfoLog(uint program, int bufSize, int* length, byte* infoLog)
    {
        GlNative.glGetProgramInfoLog(program, bufSize, length, infoLog);
    }
    
    public static int GetShader(int shader, ShaderParameter parameter)
    {
        var parametrs = 0;
        GlNative.glGetShaderiv((uint) shader, (uint) parameter, &parametrs);
        return parametrs;
    }

    public static void GetShader(uint shader, uint name, int* parametrs)
    {
        GlNative.glGetShaderiv(shader, name, parametrs);
    }

    public static string GetShaderInfoLog(int shader)
    {
        var parametrs = GetShader(shader, ShaderParameter.InfoLogLength);
        if (parametrs == 0)
            return string.Empty;
        
        GetShaderInfoLog((uint) shader, parametrs * 2, out _, out var info);
        return info;
    }

    public static void GetShaderInfoLog(uint shader, int bufferSize, out int length, out string info)
    {
        fixed (int* lengthPtr = &length)
        {
            var pointer = Marshal.AllocHGlobal((nint) (bufferSize + 1));
            GlNative.glGetShaderInfoLog(shader, bufferSize, lengthPtr, (byte*) pointer);
            info = Marshal.PtrToStringUTF8(pointer) ?? string.Empty;
            Marshal.FreeHGlobal(pointer);
        }
    }

    public static void GetShaderInfoLog(uint shader, int bufferSize, int* length, byte* infoLog)
    {
        GlNative.glGetShaderInfoLog(shader, bufferSize, length, infoLog);
    }

    public static void GetShaderSource(uint shader, int bufSize, int* length, byte* source)
    {
        GlNative.glGetShaderSource(shader, bufSize, length, source);
    }

    public static int GetUniformLocation(int program, string name)
    {
        var pointer = Marshal.StringToHGlobalAnsi(name);
        
        try
        {
            return GlNative.glGetUniformLocation((uint) program,  (byte*) pointer);
        }
        finally
        {
            if (pointer != nint.Zero)
                Marshal.FreeHGlobal(pointer);
        }
    }
    
    public static int GetUniformLocation(uint program, byte* name)
    {
        return GlNative.glGetUniformLocation(program, name);
    }

    public static void GetUniformfv(uint program, int location, float* prms)
    {
        GlNative.glGetUniformfv(program, location, prms);
    }

    public static void GetUniformiv(uint program, int location, int* prms)
    {
        GlNative.glGetUniformiv(program, location, prms);
    }

    public static void GetVertexAttribdv(uint index, uint pname, double* prms)
    {
        GlNative.glGetVertexAttribdv(index, pname, prms);
    }

    public static void GetVertexAttribfv(uint index, uint pname, float* prms)
    {
        GlNative.glGetVertexAttribfv(index, pname, prms);
    }

    public static void GetVertexAttribiv(uint index, uint pname, int* prms)
    {
        GlNative.glGetVertexAttribiv(index, pname, prms);
    }

    public static void GetVertexAttribPointerv(uint index, uint pname, void** pointer)
    {
        GlNative.glGetVertexAttribPointerv(index, pname, pointer);
    }

    public static int IsProgram(uint program)
    {
        return GlNative.glIsProgram(program);
    }

    public static int IsShader(uint shader)
    {
        return GlNative.glIsShader(shader);
    }

    public static void LinkProgram(int program)
    {
        GlNative.glLinkProgram((uint) program);
    }
    
    public static void LinkProgram(uint program)
    {
        GlNative.glLinkProgram(program);
    }
    
    public static void ShaderSource(int shader, string source)
    {
        var pointer = Marshal.StringToHGlobalAnsi(source);
        var length = source.Length;
        
        GlNative.glShaderSource((uint) shader, 1, (byte**) pointer, &length);
        
        if (pointer != nint.Zero)
            Marshal.FreeHGlobal(pointer);
    }
    
    public static void ShaderSource(uint shader, int count, byte** str, int* length)
    {
        GlNative.glShaderSource(shader, count, str, length);
    }

    public static void UseProgram(int program)
    {
        GlNative.glUseProgram((uint) program);
    }
    
    public static void UseProgram(uint program)
    {
        GlNative.glUseProgram(program);
    }
    
    public static void Uniform1f(int location, float v0)
    {
        GlNative.glUniform1f(location, v0);
    }

    public static void Uniform2f(int location, float v0, float v1)
    {
        GlNative.glUniform2f(location, v0, v1);
    }

    public static void Uniform3f(int location, float v0, float v1, float v2)
    {
        GlNative.glUniform3f(location, v0, v1, v2);
    }

    public static void Uniform4f(int location, float v0, float v1, float v2, float v3)
    {
        GlNative.glUniform4f(location, v0, v1, v2, v3);
    }

    public static void Uniform1i(int location, int v0)
    {
        GlNative.glUniform1i(location, v0);
    }

    public static void Uniform2i(int location, int v0, int v1)
    {
        GlNative.glUniform2i(location, v0, v1);
    }

    public static void Uniform3i(int location, int v0, int v1, int v2)
    {
        GlNative.glUniform3i(location, v0, v1, v2);
    }

    public static void Uniform4i(int location, int v0, int v1, int v2, int v3)
    {
        GlNative.glUniform4i(location, v0, v1, v2, v3);
    }

    public static void Uniform1fv(int location, int count, float* value)
    {
        GlNative.glUniform1fv(location, count, value);
    }

    public static void Uniform2fv(int location, int count, float* value)
    {
        GlNative.glUniform2fv(location, count, value);
    }

    public static void Uniform3fv(int location, int count, float* value)
    {
        GlNative.glUniform3fv(location, count, value);
    }

    public static void Uniform4fv(int location, int count, float* value)
    {
        GlNative.glUniform4fv(location, count, value);
    }

    public static void Uniform1iv(int location, int count, int* value)
    {
        GlNative.glUniform1iv(location, count, value);
    }

    public static void Uniform2iv(int location, int count, int* value)
    {
        GlNative.glUniform2iv(location, count, value);
    }

    public static void Uniform3iv(int location, int count, int* value)
    {
        GlNative.glUniform3iv(location, count, value);
    }

    public static void Uniform4iv(int location, int count, int* value)
    {
        GlNative.glUniform4iv(location, count, value);
    }

    public static void UniformMatrix2fv(int location, int count, int transpose, float* value)
    {
        GlNative.glUniformMatrix2fv(location, count, transpose, value);
    }

    public static void UniformMatrix3fv(int location, int count, int transpose, float* value)
    {
        GlNative.glUniformMatrix3fv(location, count, transpose, value);
    }

    public static void UniformMatrix4fv(int location, int count, int transpose, float* value)
    {
        GlNative.glUniformMatrix4fv(location, count, transpose, value);
    }

    public static void ValidateProgram(uint program)
    {
        GlNative.glValidateProgram(program);
    }

    public static void VertexAttrib1d(uint index, double x)
    {
        GlNative.glVertexAttrib1d(index, x);
    }

    public static void VertexAttrib1dv(uint index, double* v)
    {
        GlNative.glVertexAttrib1dv(index, v);
    }

    public static void VertexAttrib1f(uint index, float x)
    {
        GlNative.glVertexAttrib1f(index, x);
    }

    public static void VertexAttrib1fv(uint index, float* v)
    {
        GlNative.glVertexAttrib1fv(index, v);
    }

    public static void VertexAttrib1s(uint index, nint x)
    {
        GlNative.glVertexAttrib1s(index, x);
    }

    public static void VertexAttrib1sv(uint index, nint* v)
    {
        GlNative.glVertexAttrib1sv(index, v);
    }

    public static void VertexAttrib2d(uint index, double x, double y)
    {
        GlNative.glVertexAttrib2d(index, x, y);
    }

    public static void VertexAttrib2dv(uint index, double* v)
    {
        GlNative.glVertexAttrib2dv(index, v);
    }

    public static void VertexAttrib2f(uint index, float x, float y)
    {
        GlNative.glVertexAttrib2f(index, x, y);
    }

    public static void VertexAttrib2fv(uint index, float* v)
    {
        GlNative.glVertexAttrib2fv(index, v);
    }

    public static void VertexAttrib2s(uint index, nint x, nint y)
    {
        GlNative.glVertexAttrib2s(index, x, y);
    }

    public static void VertexAttrib2sv(uint index, nint* v)
    {
        GlNative.glVertexAttrib2sv(index, v);
    }

    public static void VertexAttrib3d(uint index, double x, double y, double z)
    {
        GlNative.glVertexAttrib3d(index, x, y, z);
    }

    public static void VertexAttrib3dv(uint index, double* v)
    {
        GlNative.glVertexAttrib3dv(index, v);
    }

    public static void VertexAttrib3f(uint index, float x, float y, float z)
    {
        GlNative.glVertexAttrib3f(index, x, y, z);
    }

    public static void VertexAttrib3fv(uint index, float* v)
    {
        GlNative.glVertexAttrib3fv(index, v);
    }

    public static void VertexAttrib3s(uint index, nint x, nint y, nint z)
    {
        GlNative.glVertexAttrib3s(index, x, y, z);
    }

    public static void VertexAttrib3sv(uint index, nint* v)
    {
        GlNative.glVertexAttrib3sv(index, v);
    }

    public static void VertexAttrib4Nbv(uint index, nint* v)
    {
        GlNative.glVertexAttrib4Nbv(index, v);
    }

    public static void VertexAttrib4Niv(uint index, int* v)
    {
        GlNative.glVertexAttrib4Niv(index, v);
    }

    public static void VertexAttrib4Nsv(uint index, nint* v)
    {
        GlNative.glVertexAttrib4Nsv(index, v);
    }

    public static void VertexAttrib4Nub(uint index, nint x, nint y, nint z, nint w)
    {
        GlNative.glVertexAttrib4Nub(index, x, y, z, w);
    }

    public static void VertexAttrib4Nubv(uint index, nint* v)
    {
        GlNative.glVertexAttrib4Nubv(index, v);
    }

    public static void VertexAttrib4Nuiv(uint index, uint* v)
    {
        GlNative.glVertexAttrib4Nuiv(index, v);
    }

    public static void VertexAttrib4Nusv(uint index, nint* v)
    {
        GlNative.glVertexAttrib4Nusv(index, v);
    }

    public static void VertexAttrib4bv(uint index, nint* v)
    {
        GlNative.glVertexAttrib4bv(index, v);
    }

    public static void VertexAttrib4d(uint index, double x, double y, double z, double w)
    {
        GlNative.glVertexAttrib4d(index, x, y, z, w);
    }

    public static void VertexAttrib4dv(uint index, double* v)
    {
        GlNative.glVertexAttrib4dv(index, v);
    }

    public static void VertexAttrib4f(uint index, float x, float y, float z, float w)
    {
        GlNative.glVertexAttrib4f(index, x, y, z, w);
    }

    public static void VertexAttrib4fv(uint index, float* v)
    {
        GlNative.glVertexAttrib4fv(index, v);
    }

    public static void VertexAttrib4iv(uint index, int* v)
    {
        GlNative.glVertexAttrib4iv(index, v);
    }

    public static void VertexAttrib4s(uint index, nint x, nint y, nint z, nint w)
    {
        GlNative.glVertexAttrib4s(index, x, y, z, w);
    }

    public static void VertexAttrib4sv(uint index, nint* v)
    {
        GlNative.glVertexAttrib4sv(index, v);
    }

    public static void VertexAttrib4ubv(uint index, nint* v)
    {
        GlNative.glVertexAttrib4ubv(index, v);
    }

    public static void VertexAttrib4uiv(uint index, uint* v)
    {
        GlNative.glVertexAttrib4uiv(index, v);
    }

    public static void VertexAttrib4usv(uint index, nint* v)
    {
        GlNative.glVertexAttrib4usv(index, v);
    }

    public static void VertexAttribPointer(uint index, int size, uint type, int normalized, int stride, void* pointer)
    {
        GlNative.glVertexAttribPointer(index, size, type, normalized, stride, pointer);
    }

    public static void UniformMatrix2x3fv(int location, int count, int transpose, float* value)
    {
        GlNative.glUniformMatrix2x3fv(location, count, transpose, value);
    }

    public static void UniformMatrix3x2fv(int location, int count, int transpose, float* value)
    {
        GlNative.glUniformMatrix3x2fv(location, count, transpose, value);
    }

    public static void UniformMatrix2x4fv(int location, int count, int transpose, float* value)
    {
        GlNative.glUniformMatrix2x4fv(location, count, transpose, value);
    }

    public static void UniformMatrix4x2fv(int location, int count, int transpose, float* value)
    {
        GlNative.glUniformMatrix4x2fv(location, count, transpose, value);
    }

    public static void UniformMatrix3x4fv(int location, int count, int transpose, float* value)
    {
        GlNative.glUniformMatrix3x4fv(location, count, transpose, value);
    }

    public static void UniformMatrix4x3fv(int location, int count, int transpose, float* value)
    {
        GlNative.glUniformMatrix4x3fv(location, count, transpose, value);
    }

    public static void ColorMaski(uint index, int r, int g, int b, int a)
    {
        GlNative.glColorMaski(index, r, g, b, a);
    }

    public static void GetBooleani_v(uint target, uint index, int* data)
    {
        GlNative.glGetBooleani_v(target, index, data);
    }

    public static void GetIntegeri_v(uint target, uint index, int* data)
    {
        GlNative.glGetIntegeri_v(target, index, data);
    }

    public static void Enablei(uint target, uint index)
    {
        GlNative.glEnablei(target, index);
    }

    public static void Disablei(uint target, uint index)
    {
        GlNative.glDisablei(target, index);
    }

    public static int IsEnabledi(uint target, uint index)
    {
        return GlNative.glIsEnabledi(target, index);
    }

    public static void BeginTransformFeedback(uint primitiveMode)
    {
        GlNative.glBeginTransformFeedback(primitiveMode);
    }

    public static void EndTransformFeedback()
    {
        GlNative.glEndTransformFeedback();
    }

    public static void BindBufferRange(uint target, uint index, uint buffer, nint offset, nint size)
    {
        GlNative.glBindBufferRange(target, index, buffer, offset, size);
    }

    public static void BindBufferBase(uint target, uint index, uint buffer)
    {
        GlNative.glBindBufferBase(target, index, buffer);
    }

    public static void TransformFeedbackVaryings(uint program, int count, byte** varyings, uint bufferMode)
    {
        GlNative.glTransformFeedbackVaryings(program, count, varyings, bufferMode);
    }

    public static void GetTransformFeedbackVarying(uint program, uint index, int bufSize, int* length, int* size, uint* type, byte* name)
    {
        GlNative.glGetTransformFeedbackVarying(program, index, bufSize, length, size, type, name);
    }

    public static void ClampColor(uint target, uint clamp)
    {
        GlNative.glClampColor(target, clamp);
    }

    public static void BeginConditionalRender(uint id, uint mode)
    {
        GlNative.glBeginConditionalRender(id, mode);
    }

    public static void EndConditionalRender()
    {
        GlNative.glEndConditionalRender();
    }

    public static void VertexAttribIPointer(uint index, int size, uint type, int stride, void* pointer)
    {
        GlNative.glVertexAttribIPointer(index, size, type, stride, pointer);
    }

    public static void GetVertexAttribIiv(uint index, uint pname, int* prms)
    {
        GlNative.glGetVertexAttribIiv(index, pname, prms);
    }

    public static void GetVertexAttribIuiv(uint index, uint pname, uint* prms)
    {
        GlNative.glGetVertexAttribIuiv(index, pname, prms);
    }

    public static void VertexAttribI1i(uint index, int x)
    {
        GlNative.glVertexAttribI1i(index, x);
    }

    public static void VertexAttribI2i(uint index, int x, int y)
    {
        GlNative.glVertexAttribI2i(index, x, y);
    }

    public static void VertexAttribI3i(uint index, int x, int y, int z)
    {
        GlNative.glVertexAttribI3i(index, x, y, z);
    }

    public static void VertexAttribI4i(uint index, int x, int y, int z, int w)
    {
        GlNative.glVertexAttribI4i(index, x, y, z, w);
    }

    public static void VertexAttribI1ui(uint index, uint x)
    {
        GlNative.glVertexAttribI1ui(index, x);
    }

    public static void VertexAttribI2ui(uint index, uint x, uint y)
    {
        GlNative.glVertexAttribI2ui(index, x, y);
    }

    public static void VertexAttribI3ui(uint index, uint x, uint y, uint z)
    {
        GlNative.glVertexAttribI3ui(index, x, y, z);
    }

    public static void VertexAttribI4ui(uint index, uint x, uint y, uint z, uint w)
    {
        GlNative.glVertexAttribI4ui(index, x, y, z, w);
    }

    public static void VertexAttribI1iv(uint index, int* v)
    {
        GlNative.glVertexAttribI1iv(index, v);
    }

    public static void VertexAttribI2iv(uint index, int* v)
    {
        GlNative.glVertexAttribI2iv(index, v);
    }

    public static void VertexAttribI3iv(uint index, int* v)
    {
        GlNative.glVertexAttribI3iv(index, v);
    }

    public static void VertexAttribI4iv(uint index, int* v)
    {
        GlNative.glVertexAttribI4iv(index, v);
    }

    public static void VertexAttribI1uiv(uint index, uint* v)
    {
        GlNative.glVertexAttribI1uiv(index, v);
    }

    public static void VertexAttribI2uiv(uint index, uint* v)
    {
        GlNative.glVertexAttribI2uiv(index, v);
    }

    public static void VertexAttribI3uiv(uint index, uint* v)
    {
        GlNative.glVertexAttribI3uiv(index, v);
    }

    public static void VertexAttribI4uiv(uint index, uint* v)
    {
        GlNative.glVertexAttribI4uiv(index, v);
    }

    public static void VertexAttribI4bv(uint index, nint* v)
    {
        GlNative.glVertexAttribI4bv(index, v);
    }

    public static void VertexAttribI4sv(uint index, nint* v)
    {
        GlNative.glVertexAttribI4sv(index, v);
    }

    public static void VertexAttribI4ubv(uint index, nint* v)
    {
        GlNative.glVertexAttribI4ubv(index, v);
    }

    public static void VertexAttribI4usv(uint index, nint* v)
    {
        GlNative.glVertexAttribI4usv(index, v);
    }

    public static void GetUniformuiv(uint program, int location, uint* prms)
    {
        GlNative.glGetUniformuiv(program, location, prms);
    }

    public static void BindFragDataLocation(uint program, uint color, byte* name)
    {
        GlNative.glBindFragDataLocation(program, color, name);
    }

    public static int GetFragDataLocation(uint program, byte* name)
    {
        return GlNative.glGetFragDataLocation(program, name);
    }

    public static void Uniform1ui(int location, uint v0)
    {
        GlNative.glUniform1ui(location, v0);
    }

    public static void Uniform2ui(int location, uint v0, uint v1)
    {
        GlNative.glUniform2ui(location, v0, v1);
    }

    public static void Uniform3ui(int location, uint v0, uint v1, uint v2)
    {
        GlNative.glUniform3ui(location, v0, v1, v2);
    }

    public static void Uniform4ui(int location, uint v0, uint v1, uint v2, uint v3)
    {
        GlNative.glUniform4ui(location, v0, v1, v2, v3);
    }

    public static void Uniform1uiv(int location, int count, uint* value)
    {
        GlNative.glUniform1uiv(location, count, value);
    }

    public static void Uniform2uiv(int location, int count, uint* value)
    {
        GlNative.glUniform2uiv(location, count, value);
    }

    public static void Uniform3uiv(int location, int count, uint* value)
    {
        GlNative.glUniform3uiv(location, count, value);
    }

    public static void Uniform4uiv(int location, int count, uint* value)
    {
        GlNative.glUniform4uiv(location, count, value);
    }

    public static void TexParameterIiv(uint target, uint pname, int* prms)
    {
        GlNative.glTexParameterIiv(target, pname, prms);
    }

    public static void TexParameterIuiv(uint target, uint pname, uint* prms)
    {
        GlNative.glTexParameterIuiv(target, pname, prms);
    }

    public static void GetTexParameterIiv(uint target, uint pname, int* prms)
    {
        GlNative.glGetTexParameterIiv(target, pname, prms);
    }

    public static void GetTexParameterIuiv(uint target, uint pname, uint* prms)
    {
        GlNative.glGetTexParameterIuiv(target, pname, prms);
    }

    public static void ClearBufferiv(uint buffer, int drawbuffer, int* value)
    {
        GlNative.glClearBufferiv(buffer, drawbuffer, value);
    }

    public static void ClearBufferuiv(uint buffer, int drawbuffer, uint* value)
    {
        GlNative.glClearBufferuiv(buffer, drawbuffer, value);
    }

    public static void ClearBufferfv(uint buffer, int drawbuffer, float* value)
    {
        GlNative.glClearBufferfv(buffer, drawbuffer, value);
    }

    public static void ClearBufferfi(uint buffer, int drawbuffer, float depth, int stencil)
    {
        GlNative.glClearBufferfi(buffer, drawbuffer, depth, stencil);
    }

    public static int IsRenderbuffer(uint renderbuffer)
    {
        return GlNative.glIsRenderbuffer(renderbuffer);
    }

    public static void BindRenderbuffer(uint target, uint renderbuffer)
    {
        GlNative.glBindRenderbuffer(target, renderbuffer);
    }

    public static void DeleteRenderbuffers(int n, uint* renderbuffers)
    {
        GlNative.glDeleteRenderbuffers(n, renderbuffers);
    }

    public static void GenRenderbuffers(int n, uint* renderbuffers)
    {
        GlNative.glGenRenderbuffers(n, renderbuffers);
    }

    public static void RenderbufferStorage(uint target, uint internalformat, int width, int height)
    {
        GlNative.glRenderbufferStorage(target, internalformat, width, height);
    }

    public static void GetRenderbufferParameteriv(uint target, uint pname, int* prms)
    {
        GlNative.glGetRenderbufferParameteriv(target, pname, prms);
    }

    public static int IsFramebuffer(uint framebuffer)
    {
        return GlNative.glIsFramebuffer(framebuffer);
    }

    public static void BindFramebuffer(uint target, uint framebuffer)
    {
        GlNative.glBindFramebuffer(target, framebuffer);
    }

    public static void DeleteFramebuffers(int n, uint* framebuffers)
    {
        GlNative.glDeleteFramebuffers(n, framebuffers);
    }

    public static void GenFramebuffers(int n, uint* framebuffers)
    {
        GlNative.glGenFramebuffers(n, framebuffers);
    }

    public static uint CheckFramebufferStatus(uint target)
    {
        return GlNative.glCheckFramebufferStatus(target);
    }

    public static void FramebufferTexture1D(uint target, uint attachment, uint textarget, uint texture, int level)
    {
        GlNative.glFramebufferTexture1D(target, attachment, textarget, texture, level);
    }

    public static void FramebufferTexture2D(uint target, uint attachment, uint textarget, uint texture, int level)
    {
        GlNative.glFramebufferTexture2D(target, attachment, textarget, texture, level);
    }

    public static void FramebufferTexture3D(uint target, uint attachment, uint textarget, uint texture, int level, int zoffset)
    {
        GlNative.glFramebufferTexture3D(target, attachment, textarget, texture, level, zoffset);
    }

    public static void FramebufferRenderbuffer(uint target, uint attachment, uint renderbuffertarget, uint renderbuffer)
    {
        GlNative.glFramebufferRenderbuffer(target, attachment, renderbuffertarget, renderbuffer);
    }

    public static void GetFramebufferAttachmentParameteriv(uint target, uint attachment, uint pname, int* prms)
    {
        GlNative.glGetFramebufferAttachmentParameteriv(target, attachment, pname, prms);
    }

    public static void GenerateMipmap(uint target)
    {
        GlNative.glGenerateMipmap(target);
    }

    public static void BlitFramebuffer(int srcX0, int srcY0, int srcX1, int srcY1, int dstX0, int dstY0, int dstX1, int dstY1, uint mask, uint filter)
    {
        GlNative.glBlitFramebuffer(srcX0, srcY0, srcX1, srcY1, dstX0, dstY0, dstX1, dstY1, mask, filter);
    }

    public static void RenderbufferStorageMultisample(uint target, int samples, uint internalformat, int width, int height)
    {
        GlNative.glRenderbufferStorageMultisample(target, samples, internalformat, width, height);
    }

    public static void FramebufferTextureLayer(uint target, uint attachment, uint texture, int level, int layer)
    {
        GlNative.glFramebufferTextureLayer(target, attachment, texture, level, layer);
    }

    public static void FlushMappedBufferRange(uint target, nint offset, nint length)
    {
        GlNative.glFlushMappedBufferRange(target, offset, length);
    }
    
    public static void BindVertexArray(int array)
    {
        GlNative.glBindVertexArray((uint) array);
    }

    public static void BindVertexArray(uint array)
    {
        GlNative.glBindVertexArray(array);
    }
    
    public static void DeleteVertexArray(int handle)
    {
        DeleteVertexArray((uint) handle);
    }
    
    public static void DeleteVertexArray(uint handle)
    {
        GlNative.glDeleteVertexArrays(1, &handle);
    }

    public static void DeleteVertexArrays(int n, uint* arrays)
    {
        GlNative.glDeleteVertexArrays(n, arrays);
    }

    public static int GenVertexArray()
    {
        uint id;
        GlNative.glGenVertexArrays(1, &id);
        return (int) id;
    }
    
    public static void GenVertexArrays(int n, uint* arrays)
    {
        GlNative.glGenVertexArrays(n, arrays);
    }

    public static int IsVertexArray(uint array)
    {
        return GlNative.glIsVertexArray(array);
    }

    public static void DrawArraysInstanced(uint mode, int first, int count, int instancecount)
    {
        GlNative.glDrawArraysInstanced(mode, first, count, instancecount);
    }

    public static void DrawElementsInstanced(uint mode, int count, uint type, void* indices, int instancecount)
    {
        GlNative.glDrawElementsInstanced(mode, count, type, indices, instancecount);
    }

    public static void TexBuffer(uint target, uint internalformat, uint buffer)
    {
        GlNative.glTexBuffer(target, internalformat, buffer);
    }

    public static void PrimitiveRestartIndex(uint index)
    {
        GlNative.glPrimitiveRestartIndex(index);
    }

    public static void CopyBufferSubData(uint readTarget, uint writeTarget, nint readOffset, nint writeOffset, nint size)
    {
        GlNative.glCopyBufferSubData(readTarget, writeTarget, readOffset, writeOffset, size);
    }

    public static void GetUniformIndices(uint program, int uniformCount, byte** uniformNames, uint* uniformIndices)
    {
        GlNative.glGetUniformIndices(program, uniformCount, uniformNames, uniformIndices);
    }

    public static void GetActiveUniformsiv(uint program, int uniformCount, uint* uniformIndices, uint pname, int* prms)
    {
        GlNative.glGetActiveUniformsiv(program, uniformCount, uniformIndices, pname, prms);
    }

    public static void GetActiveUniformName(uint program, uint uniformIndex, int bufSize, int* length, byte* uniformName)
    {
        GlNative.glGetActiveUniformName(program, uniformIndex, bufSize, length, uniformName);
    }

    public static uint GetUniformBlockIndex(uint program, byte* uniformBlockName)
    {
        return GlNative.glGetUniformBlockIndex(program, uniformBlockName);
    }

    public static void GetActiveUniformBlockiv(uint program, uint uniformBlockIndex, uint pname, int* prms)
    {
        GlNative.glGetActiveUniformBlockiv(program, uniformBlockIndex, pname, prms);
    }

    public static void GetActiveUniformBlockName(uint program, uint uniformBlockIndex, int bufSize, int* length, byte* uniformBlockName)
    {
        GlNative.glGetActiveUniformBlockName(program, uniformBlockIndex, bufSize, length, uniformBlockName);
    }

    public static void UniformBlockBinding(uint program, uint uniformBlockIndex, uint uniformBlockBinding)
    {
        GlNative.glUniformBlockBinding(program, uniformBlockIndex, uniformBlockBinding);
    }

    public static void DrawElementsBaseVertex(uint mode, int count, uint type, void* indices, int basevertex)
    {
        GlNative.glDrawElementsBaseVertex(mode, count, type, indices, basevertex);
    }

    public static void DrawRangeElementsBaseVertex(uint mode, uint start, uint end, int count, uint type, void* indices, int basevertex)
    {
        GlNative.glDrawRangeElementsBaseVertex(mode, start, end, count, type, indices, basevertex);
    }

    public static void DrawElementsInstancedBaseVertex(uint mode, int count, uint type, void* indices, int instancecount, int basevertex)
    {
        GlNative.glDrawElementsInstancedBaseVertex(mode, count, type, indices, instancecount, basevertex);
    }

    public static void MultiDrawElementsBaseVertex(uint mode, int* count, uint type, void** indices, int drawcount, int* basevertex)
    {
        GlNative.glMultiDrawElementsBaseVertex(mode, count, type, indices, drawcount, basevertex);
    }

    public static void ProvokingVertex(uint mode)
    {
        GlNative.glProvokingVertex(mode);
    }

    public static nint FenceSync(uint condition, uint flags)
    {
        return GlNative.glFenceSync(condition, flags);
    }

    public static int IsSync(nint sync)
    {
        return GlNative.glIsSync(sync);
    }

    public static void DeleteSync(nint sync)
    {
        GlNative.glDeleteSync(sync);
    }

    public static uint ClientWaitSync(nint sync, uint flags, nint timeout)
    {
        return GlNative.glClientWaitSync(sync, flags, timeout);
    }

    public static void WaitSync(nint sync, uint flags, nint timeout)
    {
        GlNative.glWaitSync(sync, flags, timeout);
    }

    public static void GetInteger64v(uint pname, nint* data)
    {
        GlNative.glGetInteger64v(pname, data);
    }

    public static void GetSynciv(nint sync, uint pname, int count, int* length, int* values)
    {
        GlNative.glGetSynciv(sync, pname, count, length, values);
    }

    public static void GetInteger64i_v(uint target, uint index, nint* data)
    {
        GlNative.glGetInteger64i_v(target, index, data);
    }

    public static void GetBufferParameteri64v(uint target, uint pname, nint* prms)
    {
        GlNative.glGetBufferParameteri64v(target, pname, prms);
    }

    public static void FramebufferTexture(uint target, uint attachment, uint texture, int level)
    {
        GlNative.glFramebufferTexture(target, attachment, texture, level);
    }

    public static void TexImage2DMultisample(uint target, int samples, uint internalformat, int width, int height, int fixedsamplelocations)
    {
        GlNative.glTexImage2DMultisample(target, samples, internalformat, width, height, fixedsamplelocations);
    }

    public static void TexImage3DMultisample(uint target, int samples, uint internalformat, int width, int height, int depth, int fixedsamplelocations)
    {
        GlNative.glTexImage3DMultisample(target, samples, internalformat, width, height, depth, fixedsamplelocations);
    }

    public static void GetMultisamplefv(uint pname, uint index, float* val)
    {
        GlNative.glGetMultisamplefv(pname, index, val);
    }

    public static void SampleMaski(uint maskNumber, uint mask)
    {
        GlNative.glSampleMaski(maskNumber, mask);
    }

    public static void BindFragDataLocationIndexed(uint program, uint colorNumber, uint index, byte* name)
    {
        GlNative.glBindFragDataLocationIndexed(program, colorNumber, index, name);
    }

    public static int GetFragDataIndex(uint program, byte* name)
    {
        return GlNative.glGetFragDataIndex(program, name);
    }

    public static void GenSamplers(int count, uint* samplers)
    {
        GlNative.glGenSamplers(count, samplers);
    }

    public static void DeleteSamplers(int count, uint* samplers)
    {
        GlNative.glDeleteSamplers(count, samplers);
    }

    public static int IsSampler(uint sampler)
    {
        return GlNative.glIsSampler(sampler);
    }

    public static void BindSampler(uint unit, uint sampler)
    {
        GlNative.glBindSampler(unit, sampler);
    }

    public static void SamplerParameteri(uint sampler, uint pname, int param)
    {
        GlNative.glSamplerParameteri(sampler, pname, param);
    }

    public static void SamplerParameteriv(uint sampler, uint pname, int* param)
    {
        GlNative.glSamplerParameteriv(sampler, pname, param);
    }

    public static void SamplerParameterf(uint sampler, uint pname, float param)
    {
        GlNative.glSamplerParameterf(sampler, pname, param);
    }

    public static void SamplerParameterfv(uint sampler, uint pname, float* param)
    {
        GlNative.glSamplerParameterfv(sampler, pname, param);
    }

    public static void SamplerParameterIiv(uint sampler, uint pname, int* param)
    {
        GlNative.glSamplerParameterIiv(sampler, pname, param);
    }

    public static void SamplerParameterIuiv(uint sampler, uint pname, uint* param)
    {
        GlNative.glSamplerParameterIuiv(sampler, pname, param);
    }

    public static void GetSamplerParameteriv(uint sampler, uint pname, int* prms)
    {
        GlNative.glGetSamplerParameteriv(sampler, pname, prms);
    }

    public static void GetSamplerParameterIiv(uint sampler, uint pname, int* prms)
    {
        GlNative.glGetSamplerParameterIiv(sampler, pname, prms);
    }

    public static void GetSamplerParameterfv(uint sampler, uint pname, float* prms)
    {
        GlNative.glGetSamplerParameterfv(sampler, pname, prms);
    }

    public static void GetSamplerParameterIuiv(uint sampler, uint pname, uint* prms)
    {
        GlNative.glGetSamplerParameterIuiv(sampler, pname, prms);
    }

    public static void QueryCounter(uint id, uint target)
    {
        GlNative.glQueryCounter(id, target);
    }

    public static void GetQueryObjecti64v(uint id, uint pname, nint* prms)
    {
        GlNative.glGetQueryObjecti64v(id, pname, prms);
    }

    public static void GetQueryObjectui64v(uint id, uint pname, nint* prms)
    {
        GlNative.glGetQueryObjectui64v(id, pname, prms);
    }

    public static void VertexAttribDivisor(uint index, uint divisor)
    {
        GlNative.glVertexAttribDivisor(index, divisor);
    }

    public static void VertexAttribP1ui(uint index, uint type, int normalized, uint value)
    {
        GlNative.glVertexAttribP1ui(index, type, normalized, value);
    }

    public static void VertexAttribP1uiv(uint index, uint type, int normalized, uint* value)
    {
        GlNative.glVertexAttribP1uiv(index, type, normalized, value);
    }

    public static void VertexAttribP2ui(uint index, uint type, int normalized, uint value)
    {
        GlNative.glVertexAttribP2ui(index, type, normalized, value);
    }

    public static void VertexAttribP2uiv(uint index, uint type, int normalized, uint* value)
    {
        GlNative.glVertexAttribP2uiv(index, type, normalized, value);
    }

    public static void VertexAttribP3ui(uint index, uint type, int normalized, uint value)
    {
        GlNative.glVertexAttribP3ui(index, type, normalized, value);
    }

    public static void VertexAttribP3uiv(uint index, uint type, int normalized, uint* value)
    {
        GlNative.glVertexAttribP3uiv(index, type, normalized, value);
    }

    public static void VertexAttribP4ui(uint index, uint type, int normalized, uint value)
    {
        GlNative.glVertexAttribP4ui(index, type, normalized, value);
    }

    public static void VertexAttribP4uiv(uint index, uint type, int normalized, uint* value)
    {
        GlNative.glVertexAttribP4uiv(index, type, normalized, value);
    }

    public static void MinSampleShading(float value)
    {
        GlNative.glMinSampleShading(value);
    }

    public static void BlendEquationi(uint buf, uint mode)
    {
        GlNative.glBlendEquationi(buf, mode);
    }

    public static void BlendEquationSeparatei(uint buf, uint modeRGB, uint modeAlpha)
    {
        GlNative.glBlendEquationSeparatei(buf, modeRGB, modeAlpha);
    }

    public static void BlendFunci(uint buf, uint src, uint dst)
    {
        GlNative.glBlendFunci(buf, src, dst);
    }

    public static void BlendFuncSeparatei(uint buf, uint srcRGB, uint dstRGB, uint srcAlpha, uint dstAlpha)
    {
        GlNative.glBlendFuncSeparatei(buf, srcRGB, dstRGB, srcAlpha, dstAlpha);
    }

    public static void DrawArraysIndirect(uint mode, void* indirect)
    {
        GlNative.glDrawArraysIndirect(mode, indirect);
    }

    public static void DrawElementsIndirect(uint mode, uint type, void* indirect)
    {
        GlNative.glDrawElementsIndirect(mode, type, indirect);
    }

    public static void Uniform1d(int location, double x)
    {
        GlNative.glUniform1d(location, x);
    }

    public static void Uniform2d(int location, double x, double y)
    {
        GlNative.glUniform2d(location, x, y);
    }

    public static void Uniform3d(int location, double x, double y, double z)
    {
        GlNative.glUniform3d(location, x, y, z);
    }

    public static void Uniform4d(int location, double x, double y, double z, double w)
    {
        GlNative.glUniform4d(location, x, y, z, w);
    }

    public static void Uniform1dv(int location, int count, double* value)
    {
        GlNative.glUniform1dv(location, count, value);
    }

    public static void Uniform2dv(int location, int count, double* value)
    {
        GlNative.glUniform2dv(location, count, value);
    }

    public static void Uniform3dv(int location, int count, double* value)
    {
        GlNative.glUniform3dv(location, count, value);
    }

    public static void Uniform4dv(int location, int count, double* value)
    {
        GlNative.glUniform4dv(location, count, value);
    }

    public static void UniformMatrix2dv(int location, int count, int transpose, double* value)
    {
        GlNative.glUniformMatrix2dv(location, count, transpose, value);
    }

    public static void UniformMatrix3dv(int location, int count, int transpose, double* value)
    {
        GlNative.glUniformMatrix3dv(location, count, transpose, value);
    }

    public static void UniformMatrix4dv(int location, int count, int transpose, double* value)
    {
        GlNative.glUniformMatrix4dv(location, count, transpose, value);
    }

    public static void UniformMatrix2x3dv(int location, int count, int transpose, double* value)
    {
        GlNative.glUniformMatrix2x3dv(location, count, transpose, value);
    }

    public static void UniformMatrix2x4dv(int location, int count, int transpose, double* value)
    {
        GlNative.glUniformMatrix2x4dv(location, count, transpose, value);
    }

    public static void UniformMatrix3x2dv(int location, int count, int transpose, double* value)
    {
        GlNative.glUniformMatrix3x2dv(location, count, transpose, value);
    }

    public static void UniformMatrix3x4dv(int location, int count, int transpose, double* value)
    {
        GlNative.glUniformMatrix3x4dv(location, count, transpose, value);
    }

    public static void UniformMatrix4x2dv(int location, int count, int transpose, double* value)
    {
        GlNative.glUniformMatrix4x2dv(location, count, transpose, value);
    }

    public static void UniformMatrix4x3dv(int location, int count, int transpose, double* value)
    {
        GlNative.glUniformMatrix4x3dv(location, count, transpose, value);
    }

    public static void GetUniformdv(uint program, int location, double* prms)
    {
        GlNative.glGetUniformdv(program, location, prms);
    }

    public static int GetSubroutineUniformLocation(uint program, uint shadertype, byte* name)
    {
        return GlNative.glGetSubroutineUniformLocation(program, shadertype, name);
    }

    public static uint GetSubroutineIndex(uint program, uint shadertype, byte* name)
    {
        return GlNative.glGetSubroutineIndex(program, shadertype, name);
    }

    public static void GetActiveSubroutineUniformiv(uint program, uint shadertype, uint index, uint pname, int* values)
    {
        GlNative.glGetActiveSubroutineUniformiv(program, shadertype, index, pname, values);
    }

    public static void GetActiveSubroutineUniformName(uint program, uint shadertype, uint index, int bufSize, int* length, byte* name)
    {
        GlNative.glGetActiveSubroutineUniformName(program, shadertype, index, bufSize, length, name);
    }

    public static void GetActiveSubroutineName(uint program, uint shadertype, uint index, int bufSize, int* length, byte* name)
    {
        GlNative.glGetActiveSubroutineName(program, shadertype, index, bufSize, length, name);
    }

    public static void UniformSubroutinesuiv(uint shadertype, int count, uint* indices)
    {
        GlNative.glUniformSubroutinesuiv(shadertype, count, indices);
    }

    public static void GetUniformSubroutineuiv(uint shadertype, int location, uint* prms)
    {
        GlNative.glGetUniformSubroutineuiv(shadertype, location, prms);
    }

    public static void GetProgramStageiv(uint program, uint shadertype, uint pname, int* values)
    {
        GlNative.glGetProgramStageiv(program, shadertype, pname, values);
    }

    public static void PatchParameteri(uint pname, int value)
    {
        GlNative.glPatchParameteri(pname, value);
    }

    public static void PatchParameterfv(uint pname, float* values)
    {
        GlNative.glPatchParameterfv(pname, values);
    }

    public static void BindTransformFeedback(uint target, uint id)
    {
        GlNative.glBindTransformFeedback(target, id);
    }

    public static void DeleteTransformFeedbacks(int n, uint* ids)
    {
        GlNative.glDeleteTransformFeedbacks(n, ids);
    }

    public static void GenTransformFeedbacks(int n, uint* ids)
    {
        GlNative.glGenTransformFeedbacks(n, ids);
    }

    public static int IsTransformFeedback(uint id)
    {
        return GlNative.glIsTransformFeedback(id);
    }

    public static void PauseTransformFeedback()
    {
        GlNative.glPauseTransformFeedback();
    }

    public static void ResumeTransformFeedback()
    {
        GlNative.glResumeTransformFeedback();
    }

    public static void DrawTransformFeedback(uint mode, uint id)
    {
        GlNative.glDrawTransformFeedback(mode, id);
    }

    public static void DrawTransformFeedbackStream(uint mode, uint id, uint stream)
    {
        GlNative.glDrawTransformFeedbackStream(mode, id, stream);
    }

    public static void BeginQueryIndexed(uint target, uint index, uint id)
    {
        GlNative.glBeginQueryIndexed(target, index, id);
    }

    public static void EndQueryIndexed(uint target, uint index)
    {
        GlNative.glEndQueryIndexed(target, index);
    }

    public static void GetQueryIndexediv(uint target, uint index, uint pname, int* prms)
    {
        GlNative.glGetQueryIndexediv(target, index, pname, prms);
    }

    public static void ReleaseShaderCompiler()
    {
        GlNative.glReleaseShaderCompiler();
    }

    public static void ShaderBinary(int count, uint* shaders, uint binaryFormat, void* binary, int length)
    {
        GlNative.glShaderBinary(count, shaders, binaryFormat, binary, length);
    }

    public static void GetShaderPrecisionFormat(uint shadertype, uint precisiontype, int* range, int* precision)
    {
        GlNative.glGetShaderPrecisionFormat(shadertype, precisiontype, range, precision);
    }

    public static void DepthRangef(float n, float f)
    {
        GlNative.glDepthRangef(n, f);
    }

    public static void ClearDepthf(float d)
    {
        GlNative.glClearDepthf(d);
    }

    public static void GetProgramBinary(uint program, int bufSize, int* length, uint* binaryFormat, void* binary)
    {
        GlNative.glGetProgramBinary(program, bufSize, length, binaryFormat, binary);
    }

    public static void ProgramBinary(uint program, uint binaryFormat, void* binary, int length)
    {
        GlNative.glProgramBinary(program, binaryFormat, binary, length);
    }

    public static void ProgramParameteri(uint program, uint pname, int value)
    {
        GlNative.glProgramParameteri(program, pname, value);
    }

    public static void UseProgramStages(uint pipeline, uint stages, uint program)
    {
        GlNative.glUseProgramStages(pipeline, stages, program);
    }

    public static void ActiveShaderProgram(uint pipeline, uint program)
    {
        GlNative.glActiveShaderProgram(pipeline, program);
    }

    public static uint CreateShaderProgramv(uint type, int count, byte** strings)
    {
        return GlNative.glCreateShaderProgramv(type, count, strings);
    }

    public static void BindProgramPipeline(uint pipeline)
    {
        GlNative.glBindProgramPipeline(pipeline);
    }

    public static void DeleteProgramPipelines(int n, uint* pipelines)
    {
        GlNative.glDeleteProgramPipelines(n, pipelines);
    }

    public static void GenProgramPipelines(int n, uint* pipelines)
    {
        GlNative.glGenProgramPipelines(n, pipelines);
    }

    public static int IsProgramPipeline(uint pipeline)
    {
        return GlNative.glIsProgramPipeline(pipeline);
    }

    public static void GetProgramPipelineiv(uint pipeline, uint pname, int* prms)
    {
        GlNative.glGetProgramPipelineiv(pipeline, pname, prms);
    }

    public static void ProgramUniform1i(uint program, int location, int v0)
    {
        GlNative.glProgramUniform1i(program, location, v0);
    }

    public static void ProgramUniform1iv(uint program, int location, int count, int* value)
    {
        GlNative.glProgramUniform1iv(program, location, count, value);
    }

    public static void ProgramUniform1f(uint program, int location, float v0)
    {
        GlNative.glProgramUniform1f(program, location, v0);
    }

    public static void ProgramUniform1fv(uint program, int location, int count, float* value)
    {
        GlNative.glProgramUniform1fv(program, location, count, value);
    }

    public static void ProgramUniform1d(uint program, int location, double v0)
    {
        GlNative.glProgramUniform1d(program, location, v0);
    }

    public static void ProgramUniform1dv(uint program, int location, int count, double* value)
    {
        GlNative.glProgramUniform1dv(program, location, count, value);
    }

    public static void ProgramUniform1ui(uint program, int location, uint v0)
    {
        GlNative.glProgramUniform1ui(program, location, v0);
    }

    public static void ProgramUniform1uiv(uint program, int location, int count, uint* value)
    {
        GlNative.glProgramUniform1uiv(program, location, count, value);
    }

    public static void ProgramUniform2i(uint program, int location, int v0, int v1)
    {
        GlNative.glProgramUniform2i(program, location, v0, v1);
    }

    public static void ProgramUniform2iv(uint program, int location, int count, int* value)
    {
        GlNative.glProgramUniform2iv(program, location, count, value);
    }

    public static void ProgramUniform2f(uint program, int location, float v0, float v1)
    {
        GlNative.glProgramUniform2f(program, location, v0, v1);
    }

    public static void ProgramUniform2fv(uint program, int location, int count, float* value)
    {
        GlNative.glProgramUniform2fv(program, location, count, value);
    }

    public static void ProgramUniform2d(uint program, int location, double v0, double v1)
    {
        GlNative.glProgramUniform2d(program, location, v0, v1);
    }

    public static void ProgramUniform2dv(uint program, int location, int count, double* value)
    {
        GlNative.glProgramUniform2dv(program, location, count, value);
    }

    public static void ProgramUniform2ui(uint program, int location, uint v0, uint v1)
    {
        GlNative.glProgramUniform2ui(program, location, v0, v1);
    }

    public static void ProgramUniform2uiv(uint program, int location, int count, uint* value)
    {
        GlNative.glProgramUniform2uiv(program, location, count, value);
    }

    public static void ProgramUniform3i(uint program, int location, int v0, int v1, int v2)
    {
        GlNative.glProgramUniform3i(program, location, v0, v1, v2);
    }

    public static void ProgramUniform3iv(uint program, int location, int count, int* value)
    {
        GlNative.glProgramUniform3iv(program, location, count, value);
    }

    public static void ProgramUniform3f(uint program, int location, float v0, float v1, float v2)
    {
        GlNative.glProgramUniform3f(program, location, v0, v1, v2);
    }

    public static void ProgramUniform3fv(uint program, int location, int count, float* value)
    {
        GlNative.glProgramUniform3fv(program, location, count, value);
    }

    public static void ProgramUniform3d(uint program, int location, double v0, double v1, double v2)
    {
        GlNative.glProgramUniform3d(program, location, v0, v1, v2);
    }

    public static void ProgramUniform3dv(uint program, int location, int count, double* value)
    {
        GlNative.glProgramUniform3dv(program, location, count, value);
    }

    public static void ProgramUniform3ui(uint program, int location, uint v0, uint v1, uint v2)
    {
        GlNative.glProgramUniform3ui(program, location, v0, v1, v2);
    }

    public static void ProgramUniform3uiv(uint program, int location, int count, uint* value)
    {
        GlNative.glProgramUniform3uiv(program, location, count, value);
    }

    public static void ProgramUniform4i(uint program, int location, int v0, int v1, int v2, int v3)
    {
        GlNative.glProgramUniform4i(program, location, v0, v1, v2, v3);
    }

    public static void ProgramUniform4iv(uint program, int location, int count, int* value)
    {
        GlNative.glProgramUniform4iv(program, location, count, value);
    }

    public static void ProgramUniform4f(uint program, int location, float v0, float v1, float v2, float v3)
    {
        GlNative.glProgramUniform4f(program, location, v0, v1, v2, v3);
    }

    public static void ProgramUniform4fv(uint program, int location, int count, float* value)
    {
        GlNative.glProgramUniform4fv(program, location, count, value);
    }

    public static void ProgramUniform4d(uint program, int location, double v0, double v1, double v2, double v3)
    {
        GlNative.glProgramUniform4d(program, location, v0, v1, v2, v3);
    }

    public static void ProgramUniform4dv(uint program, int location, int count, double* value)
    {
        GlNative.glProgramUniform4dv(program, location, count, value);
    }

    public static void ProgramUniform4ui(uint program, int location, uint v0, uint v1, uint v2, uint v3)
    {
        GlNative.glProgramUniform4ui(program, location, v0, v1, v2, v3);
    }

    public static void ProgramUniform4uiv(uint program, int location, int count, uint* value)
    {
        GlNative.glProgramUniform4uiv(program, location, count, value);
    }
    
    public static void ProgramUniformMatrix2fv(uint program, int location, int count, int transpose, float* value)
    {
        GlNative.glProgramUniformMatrix2fv(program, location, count, transpose, value);
    }
    
    public static void UniformMatrix3(int program, int location, bool transpose, float* value)
    {
        GlNative.glProgramUniformMatrix3fv((uint) program, location, 1, transpose ? GlNative.True : GlNative.False, value);
    }
    
    public static void ProgramUniformMatrix3fv(uint program, int location, int count, int transpose, float* value)
    {
        GlNative.glProgramUniformMatrix3fv(program, location, count, transpose, value);
    }
    
    public static void UniformMatrix4(int program, int location, bool transpose, float* value)
    {
        GlNative.glProgramUniformMatrix4fv((uint) program, location, 1, transpose ? GlNative.True : GlNative.False, value);
    }

    public static void ProgramUniformMatrix4fv(uint program, int location, int count, int transpose, float* value)
    {
        GlNative.glProgramUniformMatrix4fv(program, location, count, transpose, value);
    }

    public static void ProgramUniformMatrix2dv(uint program, int location, int count, int transpose, double* value)
    {
        GlNative.glProgramUniformMatrix2dv(program, location, count, transpose, value);
    }

    public static void ProgramUniformMatrix3dv(uint program, int location, int count, int transpose, double* value)
    {
        GlNative.glProgramUniformMatrix3dv(program, location, count, transpose, value);
    }

    public static void ProgramUniformMatrix4dv(uint program, int location, int count, int transpose, double* value)
    {
        GlNative.glProgramUniformMatrix4dv(program, location, count, transpose, value);
    }

    public static void ProgramUniformMatrix2x3fv(uint program, int location, int count, int transpose, float* value)
    {
        GlNative.glProgramUniformMatrix2x3fv(program, location, count, transpose, value);
    }

    public static void ProgramUniformMatrix3x2fv(uint program, int location, int count, int transpose, float* value)
    {
        GlNative.glProgramUniformMatrix3x2fv(program, location, count, transpose, value);
    }

    public static void ProgramUniformMatrix2x4fv(uint program, int location, int count, int transpose, float* value)
    {
        GlNative.glProgramUniformMatrix2x4fv(program, location, count, transpose, value);
    }

    public static void ProgramUniformMatrix4x2fv(uint program, int location, int count, int transpose, float* value)
    {
        GlNative.glProgramUniformMatrix4x2fv(program, location, count, transpose, value);
    }

    public static void ProgramUniformMatrix3x4fv(uint program, int location, int count, int transpose, float* value)
    {
        GlNative.glProgramUniformMatrix3x4fv(program, location, count, transpose, value);
    }

    public static void ProgramUniformMatrix4x3fv(uint program, int location, int count, int transpose, float* value)
    {
        GlNative.glProgramUniformMatrix4x3fv(program, location, count, transpose, value);
    }

    public static void ProgramUniformMatrix2x3dv(uint program, int location, int count, int transpose, double* value)
    {
        GlNative.glProgramUniformMatrix2x3dv(program, location, count, transpose, value);
    }

    public static void ProgramUniformMatrix3x2dv(uint program, int location, int count, int transpose, double* value)
    {
        GlNative.glProgramUniformMatrix3x2dv(program, location, count, transpose, value);
    }

    public static void ProgramUniformMatrix2x4dv(uint program, int location, int count, int transpose, double* value)
    {
        GlNative.glProgramUniformMatrix2x4dv(program, location, count, transpose, value);
    }

    public static void ProgramUniformMatrix4x2dv(uint program, int location, int count, int transpose, double* value)
    {
        GlNative.glProgramUniformMatrix4x2dv(program, location, count, transpose, value);
    }

    public static void ProgramUniformMatrix3x4dv(uint program, int location, int count, int transpose, double* value)
    {
        GlNative.glProgramUniformMatrix3x4dv(program, location, count, transpose, value);
    }

    public static void ProgramUniformMatrix4x3dv(uint program, int location, int count, int transpose, double* value)
    {
        GlNative.glProgramUniformMatrix4x3dv(program, location, count, transpose, value);
    }

    public static void ValidateProgramPipeline(uint pipeline)
    {
        GlNative.glValidateProgramPipeline(pipeline);
    }

    public static void GetProgramPipelineInfoLog(uint pipeline, int bufSize, int* length, byte* infoLog)
    {
        GlNative.glGetProgramPipelineInfoLog(pipeline, bufSize, length, infoLog);
    }

    public static void VertexAttribL1d(uint index, double x)
    {
        GlNative.glVertexAttribL1d(index, x);
    }

    public static void VertexAttribL2d(uint index, double x, double y)
    {
        GlNative.glVertexAttribL2d(index, x, y);
    }

    public static void VertexAttribL3d(uint index, double x, double y, double z)
    {
        GlNative.glVertexAttribL3d(index, x, y, z);
    }

    public static void VertexAttribL4d(uint index, double x, double y, double z, double w)
    {
        GlNative.glVertexAttribL4d(index, x, y, z, w);
    }

    public static void VertexAttribL1dv(uint index, double* v)
    {
        GlNative.glVertexAttribL1dv(index, v);
    }

    public static void VertexAttribL2dv(uint index, double* v)
    {
        GlNative.glVertexAttribL2dv(index, v);
    }

    public static void VertexAttribL3dv(uint index, double* v)
    {
        GlNative.glVertexAttribL3dv(index, v);
    }

    public static void VertexAttribL4dv(uint index, double* v)
    {
        GlNative.glVertexAttribL4dv(index, v);
    }

    public static void VertexAttribLPointer(uint index, int size, uint type, int stride, void* pointer)
    {
        GlNative.glVertexAttribLPointer(index, size, type, stride, pointer);
    }

    public static void GetVertexAttribLdv(uint index, uint pname, double* prms)
    {
        GlNative.glGetVertexAttribLdv(index, pname, prms);
    }

    public static void ViewportArrayv(uint first, int count, float* v)
    {
        GlNative.glViewportArrayv(first, count, v);
    }

    public static void ViewportIndexedf(uint index, float x, float y, float w, float h)
    {
        GlNative.glViewportIndexedf(index, x, y, w, h);
    }

    public static void ViewportIndexedfv(uint index, float* v)
    {
        GlNative.glViewportIndexedfv(index, v);
    }

    public static void ScissorArrayv(uint first, int count, int* v)
    {
        GlNative.glScissorArrayv(first, count, v);
    }

    public static void ScissorIndexed(uint index, int left, int bottom, int width, int height)
    {
        GlNative.glScissorIndexed(index, left, bottom, width, height);
    }

    public static void ScissorIndexedv(uint index, int* v)
    {
        GlNative.glScissorIndexedv(index, v);
    }

    public static void DepthRangeArrayv(uint first, int count, double* v)
    {
        GlNative.glDepthRangeArrayv(first, count, v);
    }

    public static void DepthRangeIndexed(uint index, double n, double f)
    {
        GlNative.glDepthRangeIndexed(index, n, f);
    }

    public static void GetFloati_v(uint target, uint index, float* data)
    {
        GlNative.glGetFloati_v(target, index, data);
    }

    public static void GetDoublei_v(uint target, uint index, double* data)
    {
        GlNative.glGetDoublei_v(target, index, data);
    }

    public static void DrawArraysInstancedBaseInstance(uint mode, int first, int count, int instancecount, uint baseinstance)
    {
        GlNative.glDrawArraysInstancedBaseInstance(mode, first, count, instancecount, baseinstance);
    }

    public static void DrawElementsInstancedBaseInstance(uint mode, int count, uint type, void* indices, int instancecount, uint baseinstance)
    {
        GlNative.glDrawElementsInstancedBaseInstance(mode, count, type, indices, instancecount, baseinstance);
    }

    public static void DrawElementsInstancedBaseVertexBaseInstance(uint mode, int count, uint type, void* indices, int instancecount, int basevertex, uint baseinstance)
    {
        GlNative.glDrawElementsInstancedBaseVertexBaseInstance(mode, count, type, indices, instancecount, basevertex, baseinstance);
    }

    public static void GetInternalformativ(uint target, uint internalformat, uint pname, int count, int* prms)
    {
        GlNative.glGetInternalformativ(target, internalformat, pname, count, prms);
    }

    public static void GetActiveAtomicCounterBufferiv(uint program, uint bufferIndex, uint pname, int* prms)
    {
        GlNative.glGetActiveAtomicCounterBufferiv(program, bufferIndex, pname, prms);
    }

    public static void BindImageTexture(uint unit, uint texture, int level, int layered, int layer, uint access, uint format)
    {
        GlNative.glBindImageTexture(unit, texture, level, layered, layer, access, format);
    }

    public static void MemoryBarrier(uint barriers)
    {
        GlNative.glMemoryBarrier(barriers);
    }

    public static void TexStorage1D(uint target, int levels, uint internalformat, int width)
    {
        GlNative.glTexStorage1D(target, levels, internalformat, width);
    }

    public static void TexStorage2D(uint target, int levels, uint internalformat, int width, int height)
    {
        GlNative.glTexStorage2D(target, levels, internalformat, width, height);
    }

    public static void TexStorage3D(uint target, int levels, uint internalformat, int width, int height, int depth)
    {
        GlNative.glTexStorage3D(target, levels, internalformat, width, height, depth);
    }

    public static void DrawTransformFeedbackInstanced(uint mode, uint id, int instancecount)
    {
        GlNative.glDrawTransformFeedbackInstanced(mode, id, instancecount);
    }

    public static void DrawTransformFeedbackStreamInstanced(uint mode, uint id, uint stream, int instancecount)
    {
        GlNative.glDrawTransformFeedbackStreamInstanced(mode, id, stream, instancecount);
    }

    public static void ClearBufferData(uint target, uint internalformat, uint format, uint type, void* data)
    {
        GlNative.glClearBufferData(target, internalformat, format, type, data);
    }

    public static void ClearBufferSubData(uint target, uint internalformat, nint offset, nint size, uint format, uint type, void* data)
    {
        GlNative.glClearBufferSubData(target, internalformat, offset, size, format, type, data);
    }

    public static void DispatchCompute(uint num_groups_x, uint num_groups_y, uint num_groups_z)
    {
        GlNative.glDispatchCompute(num_groups_x, num_groups_y, num_groups_z);
    }

    public static void DispatchComputeIndirect(nint indirect)
    {
        GlNative.glDispatchComputeIndirect(indirect);
    }

    public static void CopyImageSubData(uint srcName, uint srcTarget, int srcLevel, int srcX, int srcY, int srcZ, uint dstName, uint dstTarget, int dstLevel, int dstX, int dstY, int dstZ, int srcWidth, int srcHeight, int srcDepth)
    {
        GlNative.glCopyImageSubData(srcName, srcTarget, srcLevel, srcX, srcY, srcZ, dstName, dstTarget, dstLevel, dstX, dstY, dstZ, srcWidth, srcHeight, srcDepth);
    }

    public static void FramebufferParameteri(uint target, uint pname, int param)
    {
        GlNative.glFramebufferParameteri(target, pname, param);
    }

    public static void GetFramebufferParameteriv(uint target, uint pname, int* prms)
    {
        GlNative.glGetFramebufferParameteriv(target, pname, prms);
    }

    public static void GetInternalformati64v(uint target, uint internalformat, uint pname, int count, nint* prms)
    {
        GlNative.glGetInternalformati64v(target, internalformat, pname, count, prms);
    }

    public static void InvalidateTexSubImage(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth)
    {
        GlNative.glInvalidateTexSubImage(texture, level, xoffset, yoffset, zoffset, width, height, depth);
    }

    public static void InvalidateTexImage(uint texture, int level)
    {
        GlNative.glInvalidateTexImage(texture, level);
    }

    public static void InvalidateBufferSubData(uint buffer, nint offset, nint length)
    {
        GlNative.glInvalidateBufferSubData(buffer, offset, length);
    }

    public static void InvalidateBufferData(uint buffer)
    {
        GlNative.glInvalidateBufferData(buffer);
    }

    public static void InvalidateFramebuffer(uint target, int numAttachments, uint* attachments)
    {
        GlNative.glInvalidateFramebuffer(target, numAttachments, attachments);
    }

    public static void InvalidateSubFramebuffer(uint target, int numAttachments, uint* attachments, int x, int y, int width, int height)
    {
        GlNative.glInvalidateSubFramebuffer(target, numAttachments, attachments, x, y, width, height);
    }

    public static void MultiDrawArraysIndirect(uint mode, void* indirect, int drawcount, int stride)
    {
        GlNative.glMultiDrawArraysIndirect(mode, indirect, drawcount, stride);
    }

    public static void MultiDrawElementsIndirect(uint mode, uint type, void* indirect, int drawcount, int stride)
    {
        GlNative.glMultiDrawElementsIndirect(mode, type, indirect, drawcount, stride);
    }

    public static void GetProgramInterfaceiv(uint program, uint programInterface, uint pname, int* prms)
    {
        GlNative.glGetProgramInterfaceiv(program, programInterface, pname, prms);
    }

    public static uint GetProgramResourceIndex(uint program, uint programInterface, byte* name)
    {
        return GlNative.glGetProgramResourceIndex(program, programInterface, name);
    }

    public static void GetProgramResourceName(uint program, uint programInterface, uint index, int bufSize, int* length, byte* name)
    {
        GlNative.glGetProgramResourceName(program, programInterface, index, bufSize, length, name);
    }

    public static void GetProgramResourceiv(uint program, uint programInterface, uint index, int propCount, uint* props, int count, int* length, int* prms)
    {
        GlNative.glGetProgramResourceiv(program, programInterface, index, propCount, props, count, length, prms);
    }

    public static int GetProgramResourceLocation(uint program, uint programInterface, byte* name)
    {
        return GlNative.glGetProgramResourceLocation(program, programInterface, name);
    }

    public static int GetProgramResourceLocationIndex(uint program, uint programInterface, byte* name)
    {
        return GlNative.glGetProgramResourceLocationIndex(program, programInterface, name);
    }

    public static void ShaderStorageBlockBinding(uint program, uint storageBlockIndex, uint storageBlockBinding)
    {
        GlNative.glShaderStorageBlockBinding(program, storageBlockIndex, storageBlockBinding);
    }

    public static void TexBufferRange(uint target, uint internalformat, uint buffer, nint offset, nint size)
    {
        GlNative.glTexBufferRange(target, internalformat, buffer, offset, size);
    }

    public static void TexStorage2DMultisample(uint target, int samples, uint internalformat, int width, int height, int fixedsamplelocations)
    {
        GlNative.glTexStorage2DMultisample(target, samples, internalformat, width, height, fixedsamplelocations);
    }

    public static void TexStorage3DMultisample(uint target, int samples, uint internalformat, int width, int height, int depth, int fixedsamplelocations)
    {
        GlNative.glTexStorage3DMultisample(target, samples, internalformat, width, height, depth, fixedsamplelocations);
    }

    public static void TextureView(uint texture, uint target, uint origtexture, uint internalformat, uint minlevel, uint numlevels, uint minlayer, uint numlayers)
    {
        GlNative.glTextureView(texture, target, origtexture, internalformat, minlevel, numlevels, minlayer, numlayers);
    }

    public static void BindVertexBuffer(uint bindingindex, uint buffer, nint offset, int stride)
    {
        GlNative.glBindVertexBuffer(bindingindex, buffer, offset, stride);
    }

    public static void VertexAttribFormat(uint attribindex, int size, uint type, int normalized, uint relativeoffset)
    {
        GlNative.glVertexAttribFormat(attribindex, size, type, normalized, relativeoffset);
    }

    public static void VertexAttribIFormat(uint attribindex, int size, uint type, uint relativeoffset)
    {
        GlNative.glVertexAttribIFormat(attribindex, size, type, relativeoffset);
    }

    public static void VertexAttribLFormat(uint attribindex, int size, uint type, uint relativeoffset)
    {
        GlNative.glVertexAttribLFormat(attribindex, size, type, relativeoffset);
    }

    public static void VertexAttribBinding(uint attribindex, uint bindingindex)
    {
        GlNative.glVertexAttribBinding(attribindex, bindingindex);
    }

    public static void VertexBindingDivisor(uint bindingindex, uint divisor)
    {
        GlNative.glVertexBindingDivisor(bindingindex, divisor);
    }

    public static void DebugMessageControl(uint source, uint type, uint severity, int count, uint* ids, int enabled)
    {
        GlNative.glDebugMessageControl(source, type, severity, count, ids, enabled);
    }

    public static void DebugMessageInsert(uint source, uint type, uint id, uint severity, int length, byte* buf)
    {
        GlNative.glDebugMessageInsert(source, type, id, severity, length, buf);
    }

    public static void DebugMessageCallback(nint callback, void* userParam)
    {
        GlNative.glDebugMessageCallback(callback, userParam);
    }

    public static uint GetDebugMessageLog(uint count, int bufSize, uint* sources, uint* types, uint* ids, uint* severities, int* lengths, byte* messageLog)
    {
        return GlNative.glGetDebugMessageLog(count, bufSize, sources, types, ids, severities, lengths, messageLog);
    }

    public static void PushDebugGroup(uint source, uint id, int length, byte* message)
    {
        GlNative.glPushDebugGroup(source, id, length, message);
    }

    public static void PopDebugGroup()
    {
        GlNative.glPopDebugGroup();
    }
    
    public static void LabelVertexArray(int handle, string label)
    {
        ObjectLabel(LabelIdentifier.VertexArray, handle, label);
    }

    public static void ObjectLabel(LabelIdentifier identifier, int handle, string label)
    {
        ObjectLabel(identifier, (uint) handle, label);
    }
    
    public static void ObjectLabel(LabelIdentifier identifier, uint handle, string label)
    {
        var pointer = Marshal.StringToHGlobalAnsi(label);
        
        GlNative.glObjectLabel((uint) identifier, handle, label.Length, (byte*) pointer);
        
        if (pointer != nint.Zero)
            Marshal.FreeHGlobal(pointer);
    }
    
    public static void ObjectLabel(uint identifier, uint name, int length, byte* label)
    {
        GlNative.glObjectLabel(identifier, name, length, label);
    }

    public static void GetObjectLabel(uint identifier, uint name, int bufSize, int* length, byte* label)
    {
        GlNative.glGetObjectLabel(identifier, name, bufSize, length, label);
    }

    public static void ObjectPtrLabel(void* ptr, int length, byte* label)
    {
        GlNative.glObjectPtrLabel(ptr, length, label);
    }

    public static void GetObjectPtrLabel(void* ptr, int bufSize, int* length, byte* label)
    {
        GlNative.glGetObjectPtrLabel(ptr, bufSize, length, label);
    }

    public static void BufferStorage(uint target, nint size, void* data, uint flags)
    {
        GlNative.glBufferStorage(target, size, data, flags);
    }

    public static void ClearTexImage(uint texture, int level, uint format, uint type, void* data)
    {
        GlNative.glClearTexImage(texture, level, format, type, data);
    }

    public static void ClearTexSubImage(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, uint format, uint type, void* data)
    {
        GlNative.glClearTexSubImage(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, data);
    }

    public static void BindBuffersBase(uint target, uint first, int count, uint* buffers)
    {
        GlNative.glBindBuffersBase(target, first, count, buffers);
    }

    public static void BindBuffersRange(uint target, uint first, int count, uint* buffers, nint* offsets, nint* sizes)
    {
        GlNative.glBindBuffersRange(target, first, count, buffers, offsets, sizes);
    }

    public static void BindTextures(uint first, int count, uint* textures)
    {
        GlNative.glBindTextures(first, count, textures);
    }

    public static void BindSamplers(uint first, int count, uint* samplers)
    {
        GlNative.glBindSamplers(first, count, samplers);
    }

    public static void BindImageTextures(uint first, int count, uint* textures)
    {
        GlNative.glBindImageTextures(first, count, textures);
    }

    public static void BindVertexBuffers(uint first, int count, uint* buffers, nint* offsets, int* strides)
    {
        GlNative.glBindVertexBuffers(first, count, buffers, offsets, strides);
    }

    public static void ClipControl(uint origin, uint depth)
    {
        GlNative.glClipControl(origin, depth);
    }

    public static void CreateTransformFeedbacks(int n, uint* ids)
    {
        GlNative.glCreateTransformFeedbacks(n, ids);
    }

    public static void TransformFeedbackBufferBase(uint xfb, uint index, uint buffer)
    {
        GlNative.glTransformFeedbackBufferBase(xfb, index, buffer);
    }

    public static void TransformFeedbackBufferRange(uint xfb, uint index, uint buffer, nint offset, nint size)
    {
        GlNative.glTransformFeedbackBufferRange(xfb, index, buffer, offset, size);
    }

    public static void GetTransformFeedbackiv(uint xfb, uint pname, int* param)
    {
        GlNative.glGetTransformFeedbackiv(xfb, pname, param);
    }

    public static void GetTransformFeedbacki_v(uint xfb, uint pname, uint index, int* param)
    {
        GlNative.glGetTransformFeedbacki_v(xfb, pname, index, param);
    }

    public static void GetTransformFeedbacki64_v(uint xfb, uint pname, uint index, nint* param)
    {
        GlNative.glGetTransformFeedbacki64_v(xfb, pname, index, param);
    }

    public static void CreateBuffers(int n, uint* buffers)
    {
        GlNative.glCreateBuffers(n, buffers);
    }

    public static void NamedBufferStorage(uint buffer, nint size, void* data, uint flags)
    {
        GlNative.glNamedBufferStorage(buffer, size, data, flags);
    }

    public static void NamedBufferData(uint buffer, nint size, void* data, uint usage)
    {
        GlNative.glNamedBufferData(buffer, size, data, usage);
    }

    public static void NamedBufferSubData(uint buffer, nint offset, nint size, void* data)
    {
        GlNative.glNamedBufferSubData(buffer, offset, size, data);
    }

    public static void CopyNamedBufferSubData(uint readBuffer, uint writeBuffer, nint readOffset, nint writeOffset, nint size)
    {
        GlNative.glCopyNamedBufferSubData(readBuffer, writeBuffer, readOffset, writeOffset, size);
    }

    public static void ClearNamedBufferData(uint buffer, uint internalformat, uint format, uint type, void* data)
    {
        GlNative.glClearNamedBufferData(buffer, internalformat, format, type, data);
    }

    public static void ClearNamedBufferSubData(uint buffer, uint internalformat, nint offset, nint size, uint format, uint type, void* data)
    {
        GlNative.glClearNamedBufferSubData(buffer, internalformat, offset, size, format, type, data);
    }

    public static int UnmapNamedBuffer(uint buffer)
    {
        return GlNative.glUnmapNamedBuffer(buffer);
    }

    public static void FlushMappedNamedBufferRange(uint buffer, nint offset, nint length)
    {
        GlNative.glFlushMappedNamedBufferRange(buffer, offset, length);
    }

    public static void GetNamedBufferParameteriv(uint buffer, uint pname, int* prms)
    {
        GlNative.glGetNamedBufferParameteriv(buffer, pname, prms);
    }

    public static void GetNamedBufferParameteri64v(uint buffer, uint pname, nint* prms)
    {
        GlNative.glGetNamedBufferParameteri64v(buffer, pname, prms);
    }

    public static void GetNamedBufferPointerv(uint buffer, uint pname, void** prms)
    {
        GlNative.glGetNamedBufferPointerv(buffer, pname, prms);
    }

    public static void GetNamedBufferSubData(uint buffer, nint offset, nint size, void* data)
    {
        GlNative.glGetNamedBufferSubData(buffer, offset, size, data);
    }

    public static void CreateFramebuffers(int n, uint* framebuffers)
    {
        GlNative.glCreateFramebuffers(n, framebuffers);
    }

    public static void NamedFramebufferRenderbuffer(uint framebuffer, uint attachment, uint renderbuffertarget, uint renderbuffer)
    {
        GlNative.glNamedFramebufferRenderbuffer(framebuffer, attachment, renderbuffertarget, renderbuffer);
    }

    public static void NamedFramebufferParameteri(uint framebuffer, uint pname, int param)
    {
        GlNative.glNamedFramebufferParameteri(framebuffer, pname, param);
    }

    public static void NamedFramebufferTexture(uint framebuffer, uint attachment, uint texture, int level)
    {
        GlNative.glNamedFramebufferTexture(framebuffer, attachment, texture, level);
    }

    public static void NamedFramebufferTextureLayer(uint framebuffer, uint attachment, uint texture, int level, int layer)
    {
        GlNative.glNamedFramebufferTextureLayer(framebuffer, attachment, texture, level, layer);
    }

    public static void NamedFramebufferDrawBuffer(uint framebuffer, uint buf)
    {
        GlNative.glNamedFramebufferDrawBuffer(framebuffer, buf);
    }

    public static void NamedFramebufferDrawBuffers(uint framebuffer, int n, uint* bufs)
    {
        GlNative.glNamedFramebufferDrawBuffers(framebuffer, n, bufs);
    }

    public static void NamedFramebufferReadBuffer(uint framebuffer, uint src)
    {
        GlNative.glNamedFramebufferReadBuffer(framebuffer, src);
    }

    public static void InvalidateNamedFramebufferData(uint framebuffer, int numAttachments, uint* attachments)
    {
        GlNative.glInvalidateNamedFramebufferData(framebuffer, numAttachments, attachments);
    }

    public static void InvalidateNamedFramebufferSubData(uint framebuffer, int numAttachments, uint* attachments, int x, int y, int width, int height)
    {
        GlNative.glInvalidateNamedFramebufferSubData(framebuffer, numAttachments, attachments, x, y, width, height);
    }

    public static void ClearNamedFramebufferiv(uint framebuffer, uint buffer, int drawbuffer, int* value)
    {
        GlNative.glClearNamedFramebufferiv(framebuffer, buffer, drawbuffer, value);
    }

    public static void ClearNamedFramebufferuiv(uint framebuffer, uint buffer, int drawbuffer, uint* value)
    {
        GlNative.glClearNamedFramebufferuiv(framebuffer, buffer, drawbuffer, value);
    }

    public static void ClearNamedFramebufferfv(uint framebuffer, uint buffer, int drawbuffer, float* value)
    {
        GlNative.glClearNamedFramebufferfv(framebuffer, buffer, drawbuffer, value);
    }

    public static void ClearNamedFramebufferfi(uint framebuffer, uint buffer, int drawbuffer, float depth, int stencil)
    {
        GlNative.glClearNamedFramebufferfi(framebuffer, buffer, drawbuffer, depth, stencil);
    }

    public static void BlitNamedFramebuffer(uint readFramebuffer, uint drawFramebuffer, int srcX0, int srcY0, int srcX1, int srcY1, int dstX0, int dstY0, int dstX1, int dstY1, uint mask, uint filter)
    {
        GlNative.glBlitNamedFramebuffer(readFramebuffer, drawFramebuffer, srcX0, srcY0, srcX1, srcY1, dstX0, dstY0, dstX1, dstY1, mask, filter);
    }

    public static uint CheckNamedFramebufferStatus(uint framebuffer, uint target)
    {
        return GlNative.glCheckNamedFramebufferStatus(framebuffer, target);
    }

    public static void GetNamedFramebufferParameteriv(uint framebuffer, uint pname, int* param)
    {
        GlNative.glGetNamedFramebufferParameteriv(framebuffer, pname, param);
    }

    public static void GetNamedFramebufferAttachmentParameteriv(uint framebuffer, uint attachment, uint pname, int* prms)
    {
        GlNative.glGetNamedFramebufferAttachmentParameteriv(framebuffer, attachment, pname, prms);
    }

    public static void CreateRenderbuffers(int n, uint* renderbuffers)
    {
        GlNative.glCreateRenderbuffers(n, renderbuffers);
    }

    public static void NamedRenderbufferStorage(uint renderbuffer, uint internalformat, int width, int height)
    {
        GlNative.glNamedRenderbufferStorage(renderbuffer, internalformat, width, height);
    }

    public static void NamedRenderbufferStorageMultisample(uint renderbuffer, int samples, uint internalformat, int width, int height)
    {
        GlNative.glNamedRenderbufferStorageMultisample(renderbuffer, samples, internalformat, width, height);
    }

    public static void GetNamedRenderbufferParameteriv(uint renderbuffer, uint pname, int* prms)
    {
        GlNative.glGetNamedRenderbufferParameteriv(renderbuffer, pname, prms);
    }

    public static void CreateTextures(uint target, int n, uint* textures)
    {
        GlNative.glCreateTextures(target, n, textures);
    }

    public static void TextureBuffer(uint texture, uint internalformat, uint buffer)
    {
        GlNative.glTextureBuffer(texture, internalformat, buffer);
    }

    public static void TextureBufferRange(uint texture, uint internalformat, uint buffer, nint offset, nint size)
    {
        GlNative.glTextureBufferRange(texture, internalformat, buffer, offset, size);
    }

    public static void TextureStorage1D(uint texture, int levels, uint internalformat, int width)
    {
        GlNative.glTextureStorage1D(texture, levels, internalformat, width);
    }

    public static void TextureStorage2D(uint texture, int levels, uint internalformat, int width, int height)
    {
        GlNative.glTextureStorage2D(texture, levels, internalformat, width, height);
    }

    public static void TextureStorage3D(uint texture, int levels, uint internalformat, int width, int height, int depth)
    {
        GlNative.glTextureStorage3D(texture, levels, internalformat, width, height, depth);
    }

    public static void TextureStorage2DMultisample(uint texture, int samples, uint internalformat, int width, int height, int fixedsamplelocations)
    {
        GlNative.glTextureStorage2DMultisample(texture, samples, internalformat, width, height, fixedsamplelocations);
    }

    public static void TextureStorage3DMultisample(uint texture, int samples, uint internalformat, int width, int height, int depth, int fixedsamplelocations)
    {
        GlNative.glTextureStorage3DMultisample(texture, samples, internalformat, width, height, depth, fixedsamplelocations);
    }

    public static void TextureSubImage1D(uint texture, int level, int xoffset, int width, uint format, uint type, void* pixels)
    {
        GlNative.glTextureSubImage1D(texture, level, xoffset, width, format, type, pixels);
    }

    public static void TextureSubImage2D(uint texture, int level, int xoffset, int yoffset, int width, int height, uint format, uint type, void* pixels)
    {
        GlNative.glTextureSubImage2D(texture, level, xoffset, yoffset, width, height, format, type, pixels);
    }

    public static void TextureSubImage3D(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, uint format, uint type, void* pixels)
    {
        GlNative.glTextureSubImage3D(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, pixels);
    }

    public static void CompressedTextureSubImage1D(uint texture, int level, int xoffset, int width, uint format, int imageSize, void* data)
    {
        GlNative.glCompressedTextureSubImage1D(texture, level, xoffset, width, format, imageSize, data);
    }

    public static void CompressedTextureSubImage2D(uint texture, int level, int xoffset, int yoffset, int width, int height, uint format, int imageSize, void* data)
    {
        GlNative.glCompressedTextureSubImage2D(texture, level, xoffset, yoffset, width, height, format, imageSize, data);
    }

    public static void CompressedTextureSubImage3D(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, uint format, int imageSize, void* data)
    {
        GlNative.glCompressedTextureSubImage3D(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, data);
    }

    public static void CopyTextureSubImage1D(uint texture, int level, int xoffset, int x, int y, int width)
    {
        GlNative.glCopyTextureSubImage1D(texture, level, xoffset, x, y, width);
    }

    public static void CopyTextureSubImage2D(uint texture, int level, int xoffset, int yoffset, int x, int y, int width, int height)
    {
        GlNative.glCopyTextureSubImage2D(texture, level, xoffset, yoffset, x, y, width, height);
    }

    public static void CopyTextureSubImage3D(uint texture, int level, int xoffset, int yoffset, int zoffset, int x, int y, int width, int height)
    {
        GlNative.glCopyTextureSubImage3D(texture, level, xoffset, yoffset, zoffset, x, y, width, height);
    }

    public static void TextureParameterf(uint texture, uint pname, float param)
    {
        GlNative.glTextureParameterf(texture, pname, param);
    }

    public static void TextureParameterfv(uint texture, uint pname, float* param)
    {
        GlNative.glTextureParameterfv(texture, pname, param);
    }

    public static void TextureParameteri(uint texture, uint pname, int param)
    {
        GlNative.glTextureParameteri(texture, pname, param);
    }

    public static void TextureParameterIiv(uint texture, uint pname, int* prms)
    {
        GlNative.glTextureParameterIiv(texture, pname, prms);
    }

    public static void TextureParameterIuiv(uint texture, uint pname, uint* prms)
    {
        GlNative.glTextureParameterIuiv(texture, pname, prms);
    }

    public static void TextureParameteriv(uint texture, uint pname, int* param)
    {
        GlNative.glTextureParameteriv(texture, pname, param);
    }

    public static void GenerateTextureMipmap(uint texture)
    {
        GlNative.glGenerateTextureMipmap(texture);
    }

    public static void BindTextureUnit(uint unit, uint texture)
    {
        GlNative.glBindTextureUnit(unit, texture);
    }

    public static void GetTextureImage(uint texture, int level, uint format, uint type, int bufSize, void* pixels)
    {
        GlNative.glGetTextureImage(texture, level, format, type, bufSize, pixels);
    }

    public static void GetCompressedTextureImage(uint texture, int level, int bufSize, void* pixels)
    {
        GlNative.glGetCompressedTextureImage(texture, level, bufSize, pixels);
    }

    public static void GetTextureLevelParameterfv(uint texture, int level, uint pname, float* prms)
    {
        GlNative.glGetTextureLevelParameterfv(texture, level, pname, prms);
    }

    public static void GetTextureLevelParameteriv(uint texture, int level, uint pname, int* prms)
    {
        GlNative.glGetTextureLevelParameteriv(texture, level, pname, prms);
    }

    public static void GetTextureParameterfv(uint texture, uint pname, float* prms)
    {
        GlNative.glGetTextureParameterfv(texture, pname, prms);
    }

    public static void GetTextureParameterIiv(uint texture, uint pname, int* prms)
    {
        GlNative.glGetTextureParameterIiv(texture, pname, prms);
    }

    public static void GetTextureParameterIuiv(uint texture, uint pname, uint* prms)
    {
        GlNative.glGetTextureParameterIuiv(texture, pname, prms);
    }

    public static void GetTextureParameteriv(uint texture, uint pname, int* prms)
    {
        GlNative.glGetTextureParameteriv(texture, pname, prms);
    }

    public static void CreateVertexArrays(int n, uint* arrays)
    {
        GlNative.glCreateVertexArrays(n, arrays);
    }

    public static void DisableVertexArrayAttrib(uint vaobj, uint index)
    {
        GlNative.glDisableVertexArrayAttrib(vaobj, index);
    }

    public static void EnableVertexArrayAttrib(uint vaobj, uint index)
    {
        GlNative.glEnableVertexArrayAttrib(vaobj, index);
    }

    public static void VertexArrayElementBuffer(uint vaobj, uint buffer)
    {
        GlNative.glVertexArrayElementBuffer(vaobj, buffer);
    }

    public static void VertexArrayVertexBuffer(uint vaobj, uint bindingindex, uint buffer, nint offset, int stride)
    {
        GlNative.glVertexArrayVertexBuffer(vaobj, bindingindex, buffer, offset, stride);
    }

    public static void VertexArrayVertexBuffers(uint vaobj, uint first, int count, uint* buffers, nint* offsets, int* strides)
    {
        GlNative.glVertexArrayVertexBuffers(vaobj, first, count, buffers, offsets, strides);
    }

    public static void VertexArrayAttribBinding(uint vaobj, uint attribindex, uint bindingindex)
    {
        GlNative.glVertexArrayAttribBinding(vaobj, attribindex, bindingindex);
    }

    public static void VertexArrayAttribFormat(uint vaobj, uint attribindex, int size, uint type, int normalized, uint relativeoffset)
    {
        GlNative.glVertexArrayAttribFormat(vaobj, attribindex, size, type, normalized, relativeoffset);
    }

    public static void VertexArrayAttribIFormat(uint vaobj, uint attribindex, int size, uint type, uint relativeoffset)
    {
        GlNative.glVertexArrayAttribIFormat(vaobj, attribindex, size, type, relativeoffset);
    }

    public static void VertexArrayAttribLFormat(uint vaobj, uint attribindex, int size, uint type, uint relativeoffset)
    {
        GlNative.glVertexArrayAttribLFormat(vaobj, attribindex, size, type, relativeoffset);
    }

    public static void VertexArrayBindingDivisor(uint vaobj, uint bindingindex, uint divisor)
    {
        GlNative.glVertexArrayBindingDivisor(vaobj, bindingindex, divisor);
    }

    public static void GetVertexArrayiv(uint vaobj, uint pname, int* param)
    {
        GlNative.glGetVertexArrayiv(vaobj, pname, param);
    }

    public static void GetVertexArrayIndexediv(uint vaobj, uint index, uint pname, int* param)
    {
        GlNative.glGetVertexArrayIndexediv(vaobj, index, pname, param);
    }

    public static void GetVertexArrayIndexed64iv(uint vaobj, uint index, uint pname, nint* param)
    {
        GlNative.glGetVertexArrayIndexed64iv(vaobj, index, pname, param);
    }

    public static void CreateSamplers(int n, uint* samplers)
    {
        GlNative.glCreateSamplers(n, samplers);
    }

    public static void CreateProgramPipelines(int n, uint* pipelines)
    {
        GlNative.glCreateProgramPipelines(n, pipelines);
    }

    public static void CreateQueries(uint target, int n, uint* ids)
    {
        GlNative.glCreateQueries(target, n, ids);
    }

    public static void GetQueryBufferObjecti64v(uint id, uint buffer, uint pname, nint offset)
    {
        GlNative.glGetQueryBufferObjecti64v(id, buffer, pname, offset);
    }

    public static void GetQueryBufferObjectiv(uint id, uint buffer, uint pname, nint offset)
    {
        GlNative.glGetQueryBufferObjectiv(id, buffer, pname, offset);
    }

    public static void GetQueryBufferObjectui64v(uint id, uint buffer, uint pname, nint offset)
    {
        GlNative.glGetQueryBufferObjectui64v(id, buffer, pname, offset);
    }

    public static void GetQueryBufferObjectuiv(uint id, uint buffer, uint pname, nint offset)
    {
        GlNative.glGetQueryBufferObjectuiv(id, buffer, pname, offset);
    }

    public static void MemoryBarrierByRegion(uint barriers)
    {
        GlNative.glMemoryBarrierByRegion(barriers);
    }

    public static void GetTextureSubImage(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, uint format, uint type, int bufSize, void* pixels)
    {
        GlNative.glGetTextureSubImage(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, bufSize, pixels);
    }

    public static void GetCompressedTextureSubImage(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, int bufSize, void* pixels)
    {
        GlNative.glGetCompressedTextureSubImage(texture, level, xoffset, yoffset, zoffset, width, height, depth, bufSize, pixels);
    }

    public static uint GetGraphicsResetStatus()
    {
        return GlNative.glGetGraphicsResetStatus();
    }

    public static void GetnCompressedTexImage(uint target, int lod, int bufSize, void* pixels)
    {
        GlNative.glGetnCompressedTexImage(target, lod, bufSize, pixels);
    }

    public static void GetnTexImage(uint target, int level, uint format, uint type, int bufSize, void* pixels)
    {
        GlNative.glGetnTexImage(target, level, format, type, bufSize, pixels);
    }

    public static void GetnUniformdv(uint program, int location, int bufSize, double* prms)
    {
        GlNative.glGetnUniformdv(program, location, bufSize, prms);
    }

    public static void GetnUniformfv(uint program, int location, int bufSize, float* prms)
    {
        GlNative.glGetnUniformfv(program, location, bufSize, prms);
    }

    public static void GetnUniformiv(uint program, int location, int bufSize, int* prms)
    {
        GlNative.glGetnUniformiv(program, location, bufSize, prms);
    }

    public static void GetnUniformuiv(uint program, int location, int bufSize, uint* prms)
    {
        GlNative.glGetnUniformuiv(program, location, bufSize, prms);
    }

    public static void ReadnPixels(int x, int y, int width, int height, uint format, uint type, int bufSize, void* data)
    {
        GlNative.glReadnPixels(x, y, width, height, format, type, bufSize, data);
    }

    public static void TextureBarrier()
    {
        GlNative.glTextureBarrier();
    }

    public static void SpecializeShader(uint shader, byte* pEntryPoint, uint numSpecializationConstants, uint* pConstantIndex, uint* pConstantValue)
    {
        GlNative.glSpecializeShader(shader, pEntryPoint, numSpecializationConstants, pConstantIndex, pConstantValue);
    }

    public static void MultiDrawArraysIndirectCount(uint mode, void* indirect, nint drawcount, int maxdrawcount, int stride)
    {
        GlNative.glMultiDrawArraysIndirectCount(mode, indirect, drawcount, maxdrawcount, stride);
    }

    public static void MultiDrawElementsIndirectCount(uint mode, uint type, void* indirect, nint drawcount, int maxdrawcount, int stride)
    {
        GlNative.glMultiDrawElementsIndirectCount(mode, type, indirect, drawcount, maxdrawcount, stride);
    }

    public static void PolygonOffsetClamp(float factor, float units, float clamp)
    {
        GlNative.glPolygonOffsetClamp(factor, units, clamp);
    }

    public static void PrimitiveBoundingBoxARB(float minX, float minY, float minZ, float minW, float maxX, float maxY, float maxZ, float maxW)
    {
        GlNative.glPrimitiveBoundingBoxARB(minX, minY, minZ, minW, maxX, maxY, maxZ, maxW);
    }

    public static nint GetTextureHandleARB(uint texture)
    {
        return GlNative.glGetTextureHandleARB(texture);
    }

    public static nint GetTextureSamplerHandleARB(uint texture, uint sampler)
    {
        return GlNative.glGetTextureSamplerHandleARB(texture, sampler);
    }

    public static void MakeTextureHandleResidentARB(nint handle)
    {
        GlNative.glMakeTextureHandleResidentARB(handle);
    }

    public static void MakeTextureHandleNonResidentARB(nint handle)
    {
        GlNative.glMakeTextureHandleNonResidentARB(handle);
    }

    public static nint GetImageHandleARB(uint texture, int level, int layered, int layer, uint format)
    {
        return GlNative.glGetImageHandleARB(texture, level, layered, layer, format);
    }

    public static void MakeImageHandleResidentARB(nint handle, uint access)
    {
        GlNative.glMakeImageHandleResidentARB(handle, access);
    }

    public static void MakeImageHandleNonResidentARB(nint handle)
    {
        GlNative.glMakeImageHandleNonResidentARB(handle);
    }

    public static void UniformHandleui64ARB(int location, nint value)
    {
        GlNative.glUniformHandleui64ARB(location, value);
    }

    public static void UniformHandleui64vARB(int location, int count, nint* value)
    {
        GlNative.glUniformHandleui64vARB(location, count, value);
    }

    public static void ProgramUniformHandleui64ARB(uint program, int location, nint value)
    {
        GlNative.glProgramUniformHandleui64ARB(program, location, value);
    }

    public static void ProgramUniformHandleui64vARB(uint program, int location, int count, nint* values)
    {
        GlNative.glProgramUniformHandleui64vARB(program, location, count, values);
    }

    public static int IsTextureHandleResidentARB(nint handle)
    {
        return GlNative.glIsTextureHandleResidentARB(handle);
    }

    public static int IsImageHandleResidentARB(nint handle)
    {
        return GlNative.glIsImageHandleResidentARB(handle);
    }

    public static void VertexAttribL1ui64ARB(uint index, nint x)
    {
        GlNative.glVertexAttribL1ui64ARB(index, x);
    }

    public static void VertexAttribL1ui64vARB(uint index, nint* v)
    {
        GlNative.glVertexAttribL1ui64vARB(index, v);
    }

    public static void GetVertexAttribLui64vARB(uint index, uint pname, nint* prms)
    {
        GlNative.glGetVertexAttribLui64vARB(index, pname, prms);
    }

    public static nint CreateSyncFromCLeventARB(nint* context, nint* ev, uint flags)
    {
        return GlNative.glCreateSyncFromCLeventARB(context, ev, flags);
    }

    public static void DispatchComputeGroupSizeARB(uint num_groups_x, uint num_groups_y, uint num_groups_z, uint group_size_x, uint group_size_y, uint group_size_z)
    {
        GlNative.glDispatchComputeGroupSizeARB(num_groups_x, num_groups_y, num_groups_z, group_size_x, group_size_y, group_size_z);
    }

    public static void DebugMessageControlARB(uint source, uint type, uint severity, int count, uint* ids, int enabled)
    {
        GlNative.glDebugMessageControlARB(source, type, severity, count, ids, enabled);
    }

    public static void DebugMessageInsertARB(uint source, uint type, uint id, uint severity, int length, byte* buf)
    {
        GlNative.glDebugMessageInsertARB(source, type, id, severity, length, buf);
    }

    public static void DebugMessageCallbackARB(nint callback, void* userParam)
    {
        GlNative.glDebugMessageCallbackARB(callback, userParam);
    }

    public static uint GetDebugMessageLogARB(uint count, int bufSize, uint* sources, uint* types, uint* ids, uint* severities, int* lengths, byte* messageLog)
    {
        return GlNative.glGetDebugMessageLogARB(count, bufSize, sources, types, ids, severities, lengths, messageLog);
    }

    public static void BlendEquationiARB(uint buf, uint mode)
    {
        GlNative.glBlendEquationiARB(buf, mode);
    }

    public static void BlendEquationSeparateiARB(uint buf, uint modeRGB, uint modeAlpha)
    {
        GlNative.glBlendEquationSeparateiARB(buf, modeRGB, modeAlpha);
    }

    public static void BlendFunciARB(uint buf, uint src, uint dst)
    {
        GlNative.glBlendFunciARB(buf, src, dst);
    }

    public static void BlendFuncSeparateiARB(uint buf, uint srcRGB, uint dstRGB, uint srcAlpha, uint dstAlpha)
    {
        GlNative.glBlendFuncSeparateiARB(buf, srcRGB, dstRGB, srcAlpha, dstAlpha);
    }

    public static void DrawArraysInstancedARB(uint mode, int first, int count, int primcount)
    {
        GlNative.glDrawArraysInstancedARB(mode, first, count, primcount);
    }

    public static void DrawElementsInstancedARB(uint mode, int count, uint type, void* indices, int primcount)
    {
        GlNative.glDrawElementsInstancedARB(mode, count, type, indices, primcount);
    }

    public static void ProgramParameteriARB(uint program, uint pname, int value)
    {
        GlNative.glProgramParameteriARB(program, pname, value);
    }

    public static void FramebufferTextureARB(uint target, uint attachment, uint texture, int level)
    {
        GlNative.glFramebufferTextureARB(target, attachment, texture, level);
    }

    public static void FramebufferTextureLayerARB(uint target, uint attachment, uint texture, int level, int layer)
    {
        GlNative.glFramebufferTextureLayerARB(target, attachment, texture, level, layer);
    }

    public static void FramebufferTextureFaceARB(uint target, uint attachment, uint texture, int level, uint face)
    {
        GlNative.glFramebufferTextureFaceARB(target, attachment, texture, level, face);
    }

    public static void SpecializeShaderARB(uint shader, byte* pEntryPoint, uint numSpecializationConstants, uint* pConstantIndex, uint* pConstantValue)
    {
        GlNative.glSpecializeShaderARB(shader, pEntryPoint, numSpecializationConstants, pConstantIndex, pConstantValue);
    }

    public static void Uniform1i64ARB(int location, nint x)
    {
        GlNative.glUniform1i64ARB(location, x);
    }

    public static void Uniform2i64ARB(int location, nint x, nint y)
    {
        GlNative.glUniform2i64ARB(location, x, y);
    }

    public static void Uniform3i64ARB(int location, nint x, nint y, nint z)
    {
        GlNative.glUniform3i64ARB(location, x, y, z);
    }

    public static void Uniform4i64ARB(int location, nint x, nint y, nint z, nint w)
    {
        GlNative.glUniform4i64ARB(location, x, y, z, w);
    }

    public static void Uniform1i64vARB(int location, int count, nint* value)
    {
        GlNative.glUniform1i64vARB(location, count, value);
    }

    public static void Uniform2i64vARB(int location, int count, nint* value)
    {
        GlNative.glUniform2i64vARB(location, count, value);
    }

    public static void Uniform3i64vARB(int location, int count, nint* value)
    {
        GlNative.glUniform3i64vARB(location, count, value);
    }

    public static void Uniform4i64vARB(int location, int count, nint* value)
    {
        GlNative.glUniform4i64vARB(location, count, value);
    }

    public static void Uniform1ui64ARB(int location, nint x)
    {
        GlNative.glUniform1ui64ARB(location, x);
    }

    public static void Uniform2ui64ARB(int location, nint x, nint y)
    {
        GlNative.glUniform2ui64ARB(location, x, y);
    }

    public static void Uniform3ui64ARB(int location, nint x, nint y, nint z)
    {
        GlNative.glUniform3ui64ARB(location, x, y, z);
    }

    public static void Uniform4ui64ARB(int location, nint x, nint y, nint z, nint w)
    {
        GlNative.glUniform4ui64ARB(location, x, y, z, w);
    }

    public static void Uniform1ui64vARB(int location, int count, nint* value)
    {
        GlNative.glUniform1ui64vARB(location, count, value);
    }

    public static void Uniform2ui64vARB(int location, int count, nint* value)
    {
        GlNative.glUniform2ui64vARB(location, count, value);
    }

    public static void Uniform3ui64vARB(int location, int count, nint* value)
    {
        GlNative.glUniform3ui64vARB(location, count, value);
    }

    public static void Uniform4ui64vARB(int location, int count, nint* value)
    {
        GlNative.glUniform4ui64vARB(location, count, value);
    }

    public static void GetUniformi64vARB(uint program, int location, nint* prms)
    {
        GlNative.glGetUniformi64vARB(program, location, prms);
    }

    public static void GetUniformui64vARB(uint program, int location, nint* prms)
    {
        GlNative.glGetUniformui64vARB(program, location, prms);
    }

    public static void GetnUniformi64vARB(uint program, int location, int bufSize, nint* prms)
    {
        GlNative.glGetnUniformi64vARB(program, location, bufSize, prms);
    }

    public static void GetnUniformui64vARB(uint program, int location, int bufSize, nint* prms)
    {
        GlNative.glGetnUniformui64vARB(program, location, bufSize, prms);
    }

    public static void ProgramUniform1i64ARB(uint program, int location, nint x)
    {
        GlNative.glProgramUniform1i64ARB(program, location, x);
    }

    public static void ProgramUniform2i64ARB(uint program, int location, nint x, nint y)
    {
        GlNative.glProgramUniform2i64ARB(program, location, x, y);
    }

    public static void ProgramUniform3i64ARB(uint program, int location, nint x, nint y, nint z)
    {
        GlNative.glProgramUniform3i64ARB(program, location, x, y, z);
    }

    public static void ProgramUniform4i64ARB(uint program, int location, nint x, nint y, nint z, nint w)
    {
        GlNative.glProgramUniform4i64ARB(program, location, x, y, z, w);
    }

    public static void ProgramUniform1i64vARB(uint program, int location, int count, nint* value)
    {
        GlNative.glProgramUniform1i64vARB(program, location, count, value);
    }

    public static void ProgramUniform2i64vARB(uint program, int location, int count, nint* value)
    {
        GlNative.glProgramUniform2i64vARB(program, location, count, value);
    }

    public static void ProgramUniform3i64vARB(uint program, int location, int count, nint* value)
    {
        GlNative.glProgramUniform3i64vARB(program, location, count, value);
    }

    public static void ProgramUniform4i64vARB(uint program, int location, int count, nint* value)
    {
        GlNative.glProgramUniform4i64vARB(program, location, count, value);
    }

    public static void ProgramUniform1ui64ARB(uint program, int location, nint x)
    {
        GlNative.glProgramUniform1ui64ARB(program, location, x);
    }

    public static void ProgramUniform2ui64ARB(uint program, int location, nint x, nint y)
    {
        GlNative.glProgramUniform2ui64ARB(program, location, x, y);
    }

    public static void ProgramUniform3ui64ARB(uint program, int location, nint x, nint y, nint z)
    {
        GlNative.glProgramUniform3ui64ARB(program, location, x, y, z);
    }

    public static void ProgramUniform4ui64ARB(uint program, int location, nint x, nint y, nint z, nint w)
    {
        GlNative.glProgramUniform4ui64ARB(program, location, x, y, z, w);
    }

    public static void ProgramUniform1ui64vARB(uint program, int location, int count, nint* value)
    {
        GlNative.glProgramUniform1ui64vARB(program, location, count, value);
    }

    public static void ProgramUniform2ui64vARB(uint program, int location, int count, nint* value)
    {
        GlNative.glProgramUniform2ui64vARB(program, location, count, value);
    }

    public static void ProgramUniform3ui64vARB(uint program, int location, int count, nint* value)
    {
        GlNative.glProgramUniform3ui64vARB(program, location, count, value);
    }

    public static void ProgramUniform4ui64vARB(uint program, int location, int count, nint* value)
    {
        GlNative.glProgramUniform4ui64vARB(program, location, count, value);
    }

    public static void MultiDrawArraysIndirectCountARB(uint mode, void* indirect, nint drawcount, int maxdrawcount, int stride)
    {
        GlNative.glMultiDrawArraysIndirectCountARB(mode, indirect, drawcount, maxdrawcount, stride);
    }

    public static void MultiDrawElementsIndirectCountARB(uint mode, uint type, void* indirect, nint drawcount, int maxdrawcount, int stride)
    {
        GlNative.glMultiDrawElementsIndirectCountARB(mode, type, indirect, drawcount, maxdrawcount, stride);
    }

    public static void VertexAttribDivisorARB(uint index, uint divisor)
    {
        GlNative.glVertexAttribDivisorARB(index, divisor);
    }

    public static void MaxShaderCompilerThreadsARB(uint count)
    {
        GlNative.glMaxShaderCompilerThreadsARB(count);
    }

    public static uint GetGraphicsResetStatusARB()
    {
        return GlNative.glGetGraphicsResetStatusARB();
    }

    public static void GetnTexImageARB(uint target, int level, uint format, uint type, int bufSize, void* img)
    {
        GlNative.glGetnTexImageARB(target, level, format, type, bufSize, img);
    }

    public static void ReadnPixelsARB(int x, int y, int width, int height, uint format, uint type, int bufSize, void* data)
    {
        GlNative.glReadnPixelsARB(x, y, width, height, format, type, bufSize, data);
    }

    public static void GetnCompressedTexImageARB(uint target, int lod, int bufSize, void* img)
    {
        GlNative.glGetnCompressedTexImageARB(target, lod, bufSize, img);
    }

    public static void GetnUniformfvARB(uint program, int location, int bufSize, float* prms)
    {
        GlNative.glGetnUniformfvARB(program, location, bufSize, prms);
    }

    public static void GetnUniformivARB(uint program, int location, int bufSize, int* prms)
    {
        GlNative.glGetnUniformivARB(program, location, bufSize, prms);
    }

    public static void GetnUniformuivARB(uint program, int location, int bufSize, uint* prms)
    {
        GlNative.glGetnUniformuivARB(program, location, bufSize, prms);
    }

    public static void GetnUniformdvARB(uint program, int location, int bufSize, double* prms)
    {
        GlNative.glGetnUniformdvARB(program, location, bufSize, prms);
    }

    public static void FramebufferSampleLocationsfvARB(uint target, uint start, int count, float* v)
    {
        GlNative.glFramebufferSampleLocationsfvARB(target, start, count, v);
    }

    public static void NamedFramebufferSampleLocationsfvARB(uint framebuffer, uint start, int count, float* v)
    {
        GlNative.glNamedFramebufferSampleLocationsfvARB(framebuffer, start, count, v);
    }

    public static void EvaluateDepthValuesARB()
    {
        GlNative.glEvaluateDepthValuesARB();
    }

    public static void MinSampleShadingARB(float value)
    {
        GlNative.glMinSampleShadingARB(value);
    }

    public static void NamedStringARB(uint type, int namelen, byte* name, int stringlen, byte* str)
    {
        GlNative.glNamedStringARB(type, namelen, name, stringlen, str);
    }

    public static void DeleteNamedStringARB(int namelen, byte* name)
    {
        GlNative.glDeleteNamedStringARB(namelen, name);
    }

    public static void CompileShaderIncludeARB(uint shader, int count, byte** path, int* length)
    {
        GlNative.glCompileShaderIncludeARB(shader, count, path, length);
    }

    public static int IsNamedStringARB(int namelen, byte* name)
    {
        return GlNative.glIsNamedStringARB(namelen, name);
    }

    public static void GetNamedStringARB(int namelen, byte* name, int bufSize, int* stringlen, byte* str)
    {
        GlNative.glGetNamedStringARB(namelen, name, bufSize, stringlen, str);
    }

    public static void GetNamedStringivARB(int namelen, byte* name, uint pname, int* prms)
    {
        GlNative.glGetNamedStringivARB(namelen, name, pname, prms);
    }

    public static void BufferPageCommitmentARB(uint target, nint offset, nint size, int commit)
    {
        GlNative.glBufferPageCommitmentARB(target, offset, size, commit);
    }

    public static void NamedBufferPageCommitmentEXT(uint buffer, nint offset, nint size, int commit)
    {
        GlNative.glNamedBufferPageCommitmentEXT(buffer, offset, size, commit);
    }

    public static void NamedBufferPageCommitmentARB(uint buffer, nint offset, nint size, int commit)
    {
        GlNative.glNamedBufferPageCommitmentARB(buffer, offset, size, commit);
    }

    public static void TexPageCommitmentARB(uint target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, int commit)
    {
        GlNative.glTexPageCommitmentARB(target, level, xoffset, yoffset, zoffset, width, height, depth, commit);
    }

    public static void TexBufferARB(uint target, uint internalformat, uint buffer)
    {
        GlNative.glTexBufferARB(target, internalformat, buffer);
    }

    public static void DepthRangeArraydvNV(uint first, int count, double* v)
    {
        GlNative.glDepthRangeArraydvNV(first, count, v);
    }

    public static void DepthRangeIndexeddNV(uint index, double n, double f)
    {
        GlNative.glDepthRangeIndexeddNV(index, n, f);
    }

    public static void BlendBarrierKHR()
    {
        GlNative.glBlendBarrierKHR();
    }

    public static void MaxShaderCompilerThreadsKHR(uint count)
    {
        GlNative.glMaxShaderCompilerThreadsKHR(count);
    }

    public static void RenderbufferStorageMultisampleAdvancedAMD(uint target, int samples, int storageSamples, uint internalformat, int width, int height)
    {
        GlNative.glRenderbufferStorageMultisampleAdvancedAMD(target, samples, storageSamples, internalformat, width, height);
    }

    public static void NamedRenderbufferStorageMultisampleAdvancedAMD(uint renderbuffer, int samples, int storageSamples, uint internalformat, int width, int height)
    {
        GlNative.glNamedRenderbufferStorageMultisampleAdvancedAMD(renderbuffer, samples, storageSamples, internalformat, width, height);
    }

    public static void GetPerfMonitorGroupsAMD(int* numGroups, int groupsSize, uint* groups)
    {
        GlNative.glGetPerfMonitorGroupsAMD(numGroups, groupsSize, groups);
    }

    public static void GetPerfMonitorCountersAMD(uint group, int* numCounters, int* maxActiveCounters, int counterSize, uint* counters)
    {
        GlNative.glGetPerfMonitorCountersAMD(group, numCounters, maxActiveCounters, counterSize, counters);
    }

    public static void GetPerfMonitorGroupStringAMD(uint group, int bufSize, int* length, byte* groupString)
    {
        GlNative.glGetPerfMonitorGroupStringAMD(group, bufSize, length, groupString);
    }

    public static void GetPerfMonitorCounterStringAMD(uint group, uint counter, int bufSize, int* length, byte* counterString)
    {
        GlNative.glGetPerfMonitorCounterStringAMD(group, counter, bufSize, length, counterString);
    }

    public static void GetPerfMonitorCounterInfoAMD(uint group, uint counter, uint pname, void* data)
    {
        GlNative.glGetPerfMonitorCounterInfoAMD(group, counter, pname, data);
    }

    public static void GenPerfMonitorsAMD(int n, uint* monitors)
    {
        GlNative.glGenPerfMonitorsAMD(n, monitors);
    }

    public static void DeletePerfMonitorsAMD(int n, uint* monitors)
    {
        GlNative.glDeletePerfMonitorsAMD(n, monitors);
    }

    public static void SelectPerfMonitorCountersAMD(uint monitor, int enable, uint group, int numCounters, uint* counterList)
    {
        GlNative.glSelectPerfMonitorCountersAMD(monitor, enable, group, numCounters, counterList);
    }

    public static void BeginPerfMonitorAMD(uint monitor)
    {
        GlNative.glBeginPerfMonitorAMD(monitor);
    }

    public static void EndPerfMonitorAMD(uint monitor)
    {
        GlNative.glEndPerfMonitorAMD(monitor);
    }

    public static void GetPerfMonitorCounterDataAMD(uint monitor, uint pname, int dataSize, uint* data, int* bytesWritten)
    {
        GlNative.glGetPerfMonitorCounterDataAMD(monitor, pname, dataSize, data, bytesWritten);
    }

    public static void EGLImageTargetTexStorageEXT(uint target, nint image, nint attrib_list)
    {
        GlNative.glEGLImageTargetTexStorageEXT(target, image, attrib_list);
    }

    public static void EGLImageTargetTextureStorageEXT(uint texture, nint image, nint attrib_list)
    {
        GlNative.glEGLImageTargetTextureStorageEXT(texture, image, attrib_list);
    }

    public static void LabelObjectEXT(uint type, uint obj, int length, byte* label)
    {
        GlNative.glLabelObjectEXT(type, obj, length, label);
    }

    public static void GetObjectLabelEXT(uint type, uint obj, int bufSize, int* length, byte* label)
    {
        GlNative.glGetObjectLabelEXT(type, obj, bufSize, length, label);
    }

    public static void InsertEventMarkerEXT(int length, byte* marker)
    {
        GlNative.glInsertEventMarkerEXT(length, marker);
    }

    public static void PushGroupMarkerEXT(int length, byte* marker)
    {
        GlNative.glPushGroupMarkerEXT(length, marker);
    }

    public static void PopGroupMarkerEXT()
    {
        GlNative.glPopGroupMarkerEXT();
    }

    public static void MatrixLoadfEXT(uint mode, float* m)
    {
        GlNative.glMatrixLoadfEXT(mode, m);
    }

    public static void MatrixLoaddEXT(uint mode, double* m)
    {
        GlNative.glMatrixLoaddEXT(mode, m);
    }

    public static void MatrixMultfEXT(uint mode, float* m)
    {
        GlNative.glMatrixMultfEXT(mode, m);
    }

    public static void MatrixMultdEXT(uint mode, double* m)
    {
        GlNative.glMatrixMultdEXT(mode, m);
    }

    public static void MatrixLoadIdentityEXT(uint mode)
    {
        GlNative.glMatrixLoadIdentityEXT(mode);
    }

    public static void MatrixRotatefEXT(uint mode, float angle, float x, float y, float z)
    {
        GlNative.glMatrixRotatefEXT(mode, angle, x, y, z);
    }

    public static void MatrixRotatedEXT(uint mode, double angle, double x, double y, double z)
    {
        GlNative.glMatrixRotatedEXT(mode, angle, x, y, z);
    }

    public static void MatrixScalefEXT(uint mode, float x, float y, float z)
    {
        GlNative.glMatrixScalefEXT(mode, x, y, z);
    }

    public static void MatrixScaledEXT(uint mode, double x, double y, double z)
    {
        GlNative.glMatrixScaledEXT(mode, x, y, z);
    }

    public static void MatrixTranslatefEXT(uint mode, float x, float y, float z)
    {
        GlNative.glMatrixTranslatefEXT(mode, x, y, z);
    }

    public static void MatrixTranslatedEXT(uint mode, double x, double y, double z)
    {
        GlNative.glMatrixTranslatedEXT(mode, x, y, z);
    }

    public static void MatrixFrustumEXT(uint mode, double left, double right, double bottom, double top, double zNear, double zFar)
    {
        GlNative.glMatrixFrustumEXT(mode, left, right, bottom, top, zNear, zFar);
    }

    public static void MatrixOrthoEXT(uint mode, double left, double right, double bottom, double top, double zNear, double zFar)
    {
        GlNative.glMatrixOrthoEXT(mode, left, right, bottom, top, zNear, zFar);
    }

    public static void MatrixPopEXT(uint mode)
    {
        GlNative.glMatrixPopEXT(mode);
    }

    public static void MatrixPushEXT(uint mode)
    {
        GlNative.glMatrixPushEXT(mode);
    }

    public static void ClientAttribDefaultEXT(uint mask)
    {
        GlNative.glClientAttribDefaultEXT(mask);
    }

    public static void PushClientAttribDefaultEXT(uint mask)
    {
        GlNative.glPushClientAttribDefaultEXT(mask);
    }

    public static void TextureParameterfEXT(uint texture, uint target, uint pname, float param)
    {
        GlNative.glTextureParameterfEXT(texture, target, pname, param);
    }

    public static void TextureParameterfvEXT(uint texture, uint target, uint pname, float* prms)
    {
        GlNative.glTextureParameterfvEXT(texture, target, pname, prms);
    }

    public static void TextureParameteriEXT(uint texture, uint target, uint pname, int param)
    {
        GlNative.glTextureParameteriEXT(texture, target, pname, param);
    }

    public static void TextureParameterivEXT(uint texture, uint target, uint pname, int* prms)
    {
        GlNative.glTextureParameterivEXT(texture, target, pname, prms);
    }

    public static void TextureImage1DEXT(uint texture, uint target, int level, int internalformat, int width, int border, uint format, uint type, void* pixels)
    {
        GlNative.glTextureImage1DEXT(texture, target, level, internalformat, width, border, format, type, pixels);
    }

    public static void TextureImage2DEXT(uint texture, uint target, int level, int internalformat, int width, int height, int border, uint format, uint type, void* pixels)
    {
        GlNative.glTextureImage2DEXT(texture, target, level, internalformat, width, height, border, format, type, pixels);
    }

    public static void TextureSubImage1DEXT(uint texture, uint target, int level, int xoffset, int width, uint format, uint type, void* pixels)
    {
        GlNative.glTextureSubImage1DEXT(texture, target, level, xoffset, width, format, type, pixels);
    }

    public static void TextureSubImage2DEXT(uint texture, uint target, int level, int xoffset, int yoffset, int width, int height, uint format, uint type, void* pixels)
    {
        GlNative.glTextureSubImage2DEXT(texture, target, level, xoffset, yoffset, width, height, format, type, pixels);
    }

    public static void CopyTextureImage1DEXT(uint texture, uint target, int level, uint internalformat, int x, int y, int width, int border)
    {
        GlNative.glCopyTextureImage1DEXT(texture, target, level, internalformat, x, y, width, border);
    }

    public static void CopyTextureImage2DEXT(uint texture, uint target, int level, uint internalformat, int x, int y, int width, int height, int border)
    {
        GlNative.glCopyTextureImage2DEXT(texture, target, level, internalformat, x, y, width, height, border);
    }

    public static void CopyTextureSubImage1DEXT(uint texture, uint target, int level, int xoffset, int x, int y, int width)
    {
        GlNative.glCopyTextureSubImage1DEXT(texture, target, level, xoffset, x, y, width);
    }

    public static void CopyTextureSubImage2DEXT(uint texture, uint target, int level, int xoffset, int yoffset, int x, int y, int width, int height)
    {
        GlNative.glCopyTextureSubImage2DEXT(texture, target, level, xoffset, yoffset, x, y, width, height);
    }

    public static void GetTextureImageEXT(uint texture, uint target, int level, uint format, uint type, void* pixels)
    {
        GlNative.glGetTextureImageEXT(texture, target, level, format, type, pixels);
    }

    public static void GetTextureParameterfvEXT(uint texture, uint target, uint pname, float* prms)
    {
        GlNative.glGetTextureParameterfvEXT(texture, target, pname, prms);
    }

    public static void GetTextureParameterivEXT(uint texture, uint target, uint pname, int* prms)
    {
        GlNative.glGetTextureParameterivEXT(texture, target, pname, prms);
    }

    public static void GetTextureLevelParameterfvEXT(uint texture, uint target, int level, uint pname, float* prms)
    {
        GlNative.glGetTextureLevelParameterfvEXT(texture, target, level, pname, prms);
    }

    public static void GetTextureLevelParameterivEXT(uint texture, uint target, int level, uint pname, int* prms)
    {
        GlNative.glGetTextureLevelParameterivEXT(texture, target, level, pname, prms);
    }

    public static void TextureImage3DEXT(uint texture, uint target, int level, int internalformat, int width, int height, int depth, int border, uint format, uint type, void* pixels)
    {
        GlNative.glTextureImage3DEXT(texture, target, level, internalformat, width, height, depth, border, format, type, pixels);
    }

    public static void TextureSubImage3DEXT(uint texture, uint target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, uint format, uint type, void* pixels)
    {
        GlNative.glTextureSubImage3DEXT(texture, target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, pixels);
    }

    public static void CopyTextureSubImage3DEXT(uint texture, uint target, int level, int xoffset, int yoffset, int zoffset, int x, int y, int width, int height)
    {
        GlNative.glCopyTextureSubImage3DEXT(texture, target, level, xoffset, yoffset, zoffset, x, y, width, height);
    }

    public static void BindMultiTextureEXT(uint texunit, uint target, uint texture)
    {
        GlNative.glBindMultiTextureEXT(texunit, target, texture);
    }

    public static void MultiTexCoordPointerEXT(uint texunit, int size, uint type, int stride, void* pointer)
    {
        GlNative.glMultiTexCoordPointerEXT(texunit, size, type, stride, pointer);
    }

    public static void MultiTexEnvfEXT(uint texunit, uint target, uint pname, float param)
    {
        GlNative.glMultiTexEnvfEXT(texunit, target, pname, param);
    }

    public static void MultiTexEnvfvEXT(uint texunit, uint target, uint pname, float* prms)
    {
        GlNative.glMultiTexEnvfvEXT(texunit, target, pname, prms);
    }

    public static void MultiTexEnviEXT(uint texunit, uint target, uint pname, int param)
    {
        GlNative.glMultiTexEnviEXT(texunit, target, pname, param);
    }

    public static void MultiTexEnvivEXT(uint texunit, uint target, uint pname, int* prms)
    {
        GlNative.glMultiTexEnvivEXT(texunit, target, pname, prms);
    }

    public static void MultiTexGendEXT(uint texunit, uint coord, uint pname, double param)
    {
        GlNative.glMultiTexGendEXT(texunit, coord, pname, param);
    }

    public static void MultiTexGendvEXT(uint texunit, uint coord, uint pname, double* prms)
    {
        GlNative.glMultiTexGendvEXT(texunit, coord, pname, prms);
    }

    public static void MultiTexGenfEXT(uint texunit, uint coord, uint pname, float param)
    {
        GlNative.glMultiTexGenfEXT(texunit, coord, pname, param);
    }

    public static void MultiTexGenfvEXT(uint texunit, uint coord, uint pname, float* prms)
    {
        GlNative.glMultiTexGenfvEXT(texunit, coord, pname, prms);
    }

    public static void MultiTexGeniEXT(uint texunit, uint coord, uint pname, int param)
    {
        GlNative.glMultiTexGeniEXT(texunit, coord, pname, param);
    }

    public static void MultiTexGenivEXT(uint texunit, uint coord, uint pname, int* prms)
    {
        GlNative.glMultiTexGenivEXT(texunit, coord, pname, prms);
    }

    public static void GetMultiTexEnvfvEXT(uint texunit, uint target, uint pname, float* prms)
    {
        GlNative.glGetMultiTexEnvfvEXT(texunit, target, pname, prms);
    }

    public static void GetMultiTexEnvivEXT(uint texunit, uint target, uint pname, int* prms)
    {
        GlNative.glGetMultiTexEnvivEXT(texunit, target, pname, prms);
    }

    public static void GetMultiTexGendvEXT(uint texunit, uint coord, uint pname, double* prms)
    {
        GlNative.glGetMultiTexGendvEXT(texunit, coord, pname, prms);
    }

    public static void GetMultiTexGenfvEXT(uint texunit, uint coord, uint pname, float* prms)
    {
        GlNative.glGetMultiTexGenfvEXT(texunit, coord, pname, prms);
    }

    public static void GetMultiTexGenivEXT(uint texunit, uint coord, uint pname, int* prms)
    {
        GlNative.glGetMultiTexGenivEXT(texunit, coord, pname, prms);
    }

    public static void MultiTexParameteriEXT(uint texunit, uint target, uint pname, int param)
    {
        GlNative.glMultiTexParameteriEXT(texunit, target, pname, param);
    }

    public static void MultiTexParameterivEXT(uint texunit, uint target, uint pname, int* prms)
    {
        GlNative.glMultiTexParameterivEXT(texunit, target, pname, prms);
    }

    public static void MultiTexParameterfEXT(uint texunit, uint target, uint pname, float param)
    {
        GlNative.glMultiTexParameterfEXT(texunit, target, pname, param);
    }

    public static void MultiTexParameterfvEXT(uint texunit, uint target, uint pname, float* prms)
    {
        GlNative.glMultiTexParameterfvEXT(texunit, target, pname, prms);
    }

    public static void MultiTexImage1DEXT(uint texunit, uint target, int level, int internalformat, int width, int border, uint format, uint type, void* pixels)
    {
        GlNative.glMultiTexImage1DEXT(texunit, target, level, internalformat, width, border, format, type, pixels);
    }

    public static void MultiTexImage2DEXT(uint texunit, uint target, int level, int internalformat, int width, int height, int border, uint format, uint type, void* pixels)
    {
        GlNative.glMultiTexImage2DEXT(texunit, target, level, internalformat, width, height, border, format, type, pixels);
    }

    public static void MultiTexSubImage1DEXT(uint texunit, uint target, int level, int xoffset, int width, uint format, uint type, void* pixels)
    {
        GlNative.glMultiTexSubImage1DEXT(texunit, target, level, xoffset, width, format, type, pixels);
    }

    public static void MultiTexSubImage2DEXT(uint texunit, uint target, int level, int xoffset, int yoffset, int width, int height, uint format, uint type, void* pixels)
    {
        GlNative.glMultiTexSubImage2DEXT(texunit, target, level, xoffset, yoffset, width, height, format, type, pixels);
    }

    public static void CopyMultiTexImage1DEXT(uint texunit, uint target, int level, uint internalformat, int x, int y, int width, int border)
    {
        GlNative.glCopyMultiTexImage1DEXT(texunit, target, level, internalformat, x, y, width, border);
    }

    public static void CopyMultiTexImage2DEXT(uint texunit, uint target, int level, uint internalformat, int x, int y, int width, int height, int border)
    {
        GlNative.glCopyMultiTexImage2DEXT(texunit, target, level, internalformat, x, y, width, height, border);
    }

    public static void CopyMultiTexSubImage1DEXT(uint texunit, uint target, int level, int xoffset, int x, int y, int width)
    {
        GlNative.glCopyMultiTexSubImage1DEXT(texunit, target, level, xoffset, x, y, width);
    }

    public static void CopyMultiTexSubImage2DEXT(uint texunit, uint target, int level, int xoffset, int yoffset, int x, int y, int width, int height)
    {
        GlNative.glCopyMultiTexSubImage2DEXT(texunit, target, level, xoffset, yoffset, x, y, width, height);
    }

    public static void GetMultiTexImageEXT(uint texunit, uint target, int level, uint format, uint type, void* pixels)
    {
        GlNative.glGetMultiTexImageEXT(texunit, target, level, format, type, pixels);
    }

    public static void GetMultiTexParameterfvEXT(uint texunit, uint target, uint pname, float* prms)
    {
        GlNative.glGetMultiTexParameterfvEXT(texunit, target, pname, prms);
    }

    public static void GetMultiTexParameterivEXT(uint texunit, uint target, uint pname, int* prms)
    {
        GlNative.glGetMultiTexParameterivEXT(texunit, target, pname, prms);
    }

    public static void GetMultiTexLevelParameterfvEXT(uint texunit, uint target, int level, uint pname, float* prms)
    {
        GlNative.glGetMultiTexLevelParameterfvEXT(texunit, target, level, pname, prms);
    }

    public static void GetMultiTexLevelParameterivEXT(uint texunit, uint target, int level, uint pname, int* prms)
    {
        GlNative.glGetMultiTexLevelParameterivEXT(texunit, target, level, pname, prms);
    }

    public static void MultiTexImage3DEXT(uint texunit, uint target, int level, int internalformat, int width, int height, int depth, int border, uint format, uint type, void* pixels)
    {
        GlNative.glMultiTexImage3DEXT(texunit, target, level, internalformat, width, height, depth, border, format, type, pixels);
    }

    public static void MultiTexSubImage3DEXT(uint texunit, uint target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, uint format, uint type, void* pixels)
    {
        GlNative.glMultiTexSubImage3DEXT(texunit, target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, pixels);
    }

    public static void CopyMultiTexSubImage3DEXT(uint texunit, uint target, int level, int xoffset, int yoffset, int zoffset, int x, int y, int width, int height)
    {
        GlNative.glCopyMultiTexSubImage3DEXT(texunit, target, level, xoffset, yoffset, zoffset, x, y, width, height);
    }

    public static void EnableClientStateIndexedEXT(uint array, uint index)
    {
        GlNative.glEnableClientStateIndexedEXT(array, index);
    }

    public static void DisableClientStateIndexedEXT(uint array, uint index)
    {
        GlNative.glDisableClientStateIndexedEXT(array, index);
    }

    public static void GetFloatIndexedvEXT(uint target, uint index, float* data)
    {
        GlNative.glGetFloatIndexedvEXT(target, index, data);
    }

    public static void GetDoubleIndexedvEXT(uint target, uint index, double* data)
    {
        GlNative.glGetDoubleIndexedvEXT(target, index, data);
    }

    public static void GetPointerIndexedvEXT(uint target, uint index, void** data)
    {
        GlNative.glGetPointerIndexedvEXT(target, index, data);
    }

    public static void EnableIndexedEXT(uint target, uint index)
    {
        GlNative.glEnableIndexedEXT(target, index);
    }

    public static void DisableIndexedEXT(uint target, uint index)
    {
        GlNative.glDisableIndexedEXT(target, index);
    }

    public static int IsEnabledIndexedEXT(uint target, uint index)
    {
        return GlNative.glIsEnabledIndexedEXT(target, index);
    }

    public static void GetIntegerIndexedvEXT(uint target, uint index, int* data)
    {
        GlNative.glGetIntegerIndexedvEXT(target, index, data);
    }

    public static void GetBooleanIndexedvEXT(uint target, uint index, int* data)
    {
        GlNative.glGetBooleanIndexedvEXT(target, index, data);
    }

    public static void CompressedTextureImage3DEXT(uint texture, uint target, int level, uint internalformat, int width, int height, int depth, int border, int imageSize, void* bits)
    {
        GlNative.glCompressedTextureImage3DEXT(texture, target, level, internalformat, width, height, depth, border, imageSize, bits);
    }

    public static void CompressedTextureImage2DEXT(uint texture, uint target, int level, uint internalformat, int width, int height, int border, int imageSize, void* bits)
    {
        GlNative.glCompressedTextureImage2DEXT(texture, target, level, internalformat, width, height, border, imageSize, bits);
    }

    public static void CompressedTextureImage1DEXT(uint texture, uint target, int level, uint internalformat, int width, int border, int imageSize, void* bits)
    {
        GlNative.glCompressedTextureImage1DEXT(texture, target, level, internalformat, width, border, imageSize, bits);
    }

    public static void CompressedTextureSubImage3DEXT(uint texture, uint target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, uint format, int imageSize, void* bits)
    {
        GlNative.glCompressedTextureSubImage3DEXT(texture, target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, bits);
    }

    public static void CompressedTextureSubImage2DEXT(uint texture, uint target, int level, int xoffset, int yoffset, int width, int height, uint format, int imageSize, void* bits)
    {
        GlNative.glCompressedTextureSubImage2DEXT(texture, target, level, xoffset, yoffset, width, height, format, imageSize, bits);
    }

    public static void CompressedTextureSubImage1DEXT(uint texture, uint target, int level, int xoffset, int width, uint format, int imageSize, void* bits)
    {
        GlNative.glCompressedTextureSubImage1DEXT(texture, target, level, xoffset, width, format, imageSize, bits);
    }

    public static void GetCompressedTextureImageEXT(uint texture, uint target, int lod, void* img)
    {
        GlNative.glGetCompressedTextureImageEXT(texture, target, lod, img);
    }

    public static void CompressedMultiTexImage3DEXT(uint texunit, uint target, int level, uint internalformat, int width, int height, int depth, int border, int imageSize, void* bits)
    {
        GlNative.glCompressedMultiTexImage3DEXT(texunit, target, level, internalformat, width, height, depth, border, imageSize, bits);
    }

    public static void CompressedMultiTexImage2DEXT(uint texunit, uint target, int level, uint internalformat, int width, int height, int border, int imageSize, void* bits)
    {
        GlNative.glCompressedMultiTexImage2DEXT(texunit, target, level, internalformat, width, height, border, imageSize, bits);
    }

    public static void CompressedMultiTexImage1DEXT(uint texunit, uint target, int level, uint internalformat, int width, int border, int imageSize, void* bits)
    {
        GlNative.glCompressedMultiTexImage1DEXT(texunit, target, level, internalformat, width, border, imageSize, bits);
    }

    public static void CompressedMultiTexSubImage3DEXT(uint texunit, uint target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, uint format, int imageSize, void* bits)
    {
        GlNative.glCompressedMultiTexSubImage3DEXT(texunit, target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, bits);
    }

    public static void CompressedMultiTexSubImage2DEXT(uint texunit, uint target, int level, int xoffset, int yoffset, int width, int height, uint format, int imageSize, void* bits)
    {
        GlNative.glCompressedMultiTexSubImage2DEXT(texunit, target, level, xoffset, yoffset, width, height, format, imageSize, bits);
    }

    public static void CompressedMultiTexSubImage1DEXT(uint texunit, uint target, int level, int xoffset, int width, uint format, int imageSize, void* bits)
    {
        GlNative.glCompressedMultiTexSubImage1DEXT(texunit, target, level, xoffset, width, format, imageSize, bits);
    }

    public static void GetCompressedMultiTexImageEXT(uint texunit, uint target, int lod, void* img)
    {
        GlNative.glGetCompressedMultiTexImageEXT(texunit, target, lod, img);
    }

    public static void MatrixLoadTransposefEXT(uint mode, float* m)
    {
        GlNative.glMatrixLoadTransposefEXT(mode, m);
    }

    public static void MatrixLoadTransposedEXT(uint mode, double* m)
    {
        GlNative.glMatrixLoadTransposedEXT(mode, m);
    }

    public static void MatrixMultTransposefEXT(uint mode, float* m)
    {
        GlNative.glMatrixMultTransposefEXT(mode, m);
    }

    public static void MatrixMultTransposedEXT(uint mode, double* m)
    {
        GlNative.glMatrixMultTransposedEXT(mode, m);
    }

    public static void NamedBufferDataEXT(uint buffer, nint size, void* data, uint usage)
    {
        GlNative.glNamedBufferDataEXT(buffer, size, data, usage);
    }

    public static void NamedBufferSubDataEXT(uint buffer, nint offset, nint size, void* data)
    {
        GlNative.glNamedBufferSubDataEXT(buffer, offset, size, data);
    }

    public static int UnmapNamedBufferEXT(uint buffer)
    {
        return GlNative.glUnmapNamedBufferEXT(buffer);
    }

    public static void GetNamedBufferParameterivEXT(uint buffer, uint pname, int* prms)
    {
        GlNative.glGetNamedBufferParameterivEXT(buffer, pname, prms);
    }

    public static void GetNamedBufferPointervEXT(uint buffer, uint pname, void** prms)
    {
        GlNative.glGetNamedBufferPointervEXT(buffer, pname, prms);
    }

    public static void GetNamedBufferSubDataEXT(uint buffer, nint offset, nint size, void* data)
    {
        GlNative.glGetNamedBufferSubDataEXT(buffer, offset, size, data);
    }

    public static void ProgramUniform1fEXT(uint program, int location, float v0)
    {
        GlNative.glProgramUniform1fEXT(program, location, v0);
    }

    public static void ProgramUniform2fEXT(uint program, int location, float v0, float v1)
    {
        GlNative.glProgramUniform2fEXT(program, location, v0, v1);
    }

    public static void ProgramUniform3fEXT(uint program, int location, float v0, float v1, float v2)
    {
        GlNative.glProgramUniform3fEXT(program, location, v0, v1, v2);
    }

    public static void ProgramUniform4fEXT(uint program, int location, float v0, float v1, float v2, float v3)
    {
        GlNative.glProgramUniform4fEXT(program, location, v0, v1, v2, v3);
    }

    public static void ProgramUniform1iEXT(uint program, int location, int v0)
    {
        GlNative.glProgramUniform1iEXT(program, location, v0);
    }

    public static void ProgramUniform2iEXT(uint program, int location, int v0, int v1)
    {
        GlNative.glProgramUniform2iEXT(program, location, v0, v1);
    }

    public static void ProgramUniform3iEXT(uint program, int location, int v0, int v1, int v2)
    {
        GlNative.glProgramUniform3iEXT(program, location, v0, v1, v2);
    }

    public static void ProgramUniform4iEXT(uint program, int location, int v0, int v1, int v2, int v3)
    {
        GlNative.glProgramUniform4iEXT(program, location, v0, v1, v2, v3);
    }

    public static void ProgramUniform1fvEXT(uint program, int location, int count, float* value)
    {
        GlNative.glProgramUniform1fvEXT(program, location, count, value);
    }

    public static void ProgramUniform2fvEXT(uint program, int location, int count, float* value)
    {
        GlNative.glProgramUniform2fvEXT(program, location, count, value);
    }

    public static void ProgramUniform3fvEXT(uint program, int location, int count, float* value)
    {
        GlNative.glProgramUniform3fvEXT(program, location, count, value);
    }

    public static void ProgramUniform4fvEXT(uint program, int location, int count, float* value)
    {
        GlNative.glProgramUniform4fvEXT(program, location, count, value);
    }

    public static void ProgramUniform1ivEXT(uint program, int location, int count, int* value)
    {
        GlNative.glProgramUniform1ivEXT(program, location, count, value);
    }

    public static void ProgramUniform2ivEXT(uint program, int location, int count, int* value)
    {
        GlNative.glProgramUniform2ivEXT(program, location, count, value);
    }

    public static void ProgramUniform3ivEXT(uint program, int location, int count, int* value)
    {
        GlNative.glProgramUniform3ivEXT(program, location, count, value);
    }

    public static void ProgramUniform4ivEXT(uint program, int location, int count, int* value)
    {
        GlNative.glProgramUniform4ivEXT(program, location, count, value);
    }

    public static void ProgramUniformMatrix2fvEXT(uint program, int location, int count, int transpose, float* value)
    {
        GlNative.glProgramUniformMatrix2fvEXT(program, location, count, transpose, value);
    }

    public static void ProgramUniformMatrix3fvEXT(uint program, int location, int count, int transpose, float* value)
    {
        GlNative.glProgramUniformMatrix3fvEXT(program, location, count, transpose, value);
    }

    public static void ProgramUniformMatrix4fvEXT(uint program, int location, int count, int transpose, float* value)
    {
        GlNative.glProgramUniformMatrix4fvEXT(program, location, count, transpose, value);
    }

    public static void ProgramUniformMatrix2x3fvEXT(uint program, int location, int count, int transpose, float* value)
    {
        GlNative.glProgramUniformMatrix2x3fvEXT(program, location, count, transpose, value);
    }

    public static void ProgramUniformMatrix3x2fvEXT(uint program, int location, int count, int transpose, float* value)
    {
        GlNative.glProgramUniformMatrix3x2fvEXT(program, location, count, transpose, value);
    }

    public static void ProgramUniformMatrix2x4fvEXT(uint program, int location, int count, int transpose, float* value)
    {
        GlNative.glProgramUniformMatrix2x4fvEXT(program, location, count, transpose, value);
    }

    public static void ProgramUniformMatrix4x2fvEXT(uint program, int location, int count, int transpose, float* value)
    {
        GlNative.glProgramUniformMatrix4x2fvEXT(program, location, count, transpose, value);
    }

    public static void ProgramUniformMatrix3x4fvEXT(uint program, int location, int count, int transpose, float* value)
    {
        GlNative.glProgramUniformMatrix3x4fvEXT(program, location, count, transpose, value);
    }

    public static void ProgramUniformMatrix4x3fvEXT(uint program, int location, int count, int transpose, float* value)
    {
        GlNative.glProgramUniformMatrix4x3fvEXT(program, location, count, transpose, value);
    }

    public static void TextureBufferEXT(uint texture, uint target, uint internalformat, uint buffer)
    {
        GlNative.glTextureBufferEXT(texture, target, internalformat, buffer);
    }

    public static void MultiTexBufferEXT(uint texunit, uint target, uint internalformat, uint buffer)
    {
        GlNative.glMultiTexBufferEXT(texunit, target, internalformat, buffer);
    }

    public static void TextureParameterIivEXT(uint texture, uint target, uint pname, int* prms)
    {
        GlNative.glTextureParameterIivEXT(texture, target, pname, prms);
    }

    public static void TextureParameterIuivEXT(uint texture, uint target, uint pname, uint* prms)
    {
        GlNative.glTextureParameterIuivEXT(texture, target, pname, prms);
    }

    public static void GetTextureParameterIivEXT(uint texture, uint target, uint pname, int* prms)
    {
        GlNative.glGetTextureParameterIivEXT(texture, target, pname, prms);
    }

    public static void GetTextureParameterIuivEXT(uint texture, uint target, uint pname, uint* prms)
    {
        GlNative.glGetTextureParameterIuivEXT(texture, target, pname, prms);
    }

    public static void MultiTexParameterIivEXT(uint texunit, uint target, uint pname, int* prms)
    {
        GlNative.glMultiTexParameterIivEXT(texunit, target, pname, prms);
    }

    public static void MultiTexParameterIuivEXT(uint texunit, uint target, uint pname, uint* prms)
    {
        GlNative.glMultiTexParameterIuivEXT(texunit, target, pname, prms);
    }

    public static void GetMultiTexParameterIivEXT(uint texunit, uint target, uint pname, int* prms)
    {
        GlNative.glGetMultiTexParameterIivEXT(texunit, target, pname, prms);
    }

    public static void GetMultiTexParameterIuivEXT(uint texunit, uint target, uint pname, uint* prms)
    {
        GlNative.glGetMultiTexParameterIuivEXT(texunit, target, pname, prms);
    }

    public static void ProgramUniform1uiEXT(uint program, int location, uint v0)
    {
        GlNative.glProgramUniform1uiEXT(program, location, v0);
    }

    public static void ProgramUniform2uiEXT(uint program, int location, uint v0, uint v1)
    {
        GlNative.glProgramUniform2uiEXT(program, location, v0, v1);
    }

    public static void ProgramUniform3uiEXT(uint program, int location, uint v0, uint v1, uint v2)
    {
        GlNative.glProgramUniform3uiEXT(program, location, v0, v1, v2);
    }

    public static void ProgramUniform4uiEXT(uint program, int location, uint v0, uint v1, uint v2, uint v3)
    {
        GlNative.glProgramUniform4uiEXT(program, location, v0, v1, v2, v3);
    }

    public static void ProgramUniform1uivEXT(uint program, int location, int count, uint* value)
    {
        GlNative.glProgramUniform1uivEXT(program, location, count, value);
    }

    public static void ProgramUniform2uivEXT(uint program, int location, int count, uint* value)
    {
        GlNative.glProgramUniform2uivEXT(program, location, count, value);
    }

    public static void ProgramUniform3uivEXT(uint program, int location, int count, uint* value)
    {
        GlNative.glProgramUniform3uivEXT(program, location, count, value);
    }

    public static void ProgramUniform4uivEXT(uint program, int location, int count, uint* value)
    {
        GlNative.glProgramUniform4uivEXT(program, location, count, value);
    }

    public static void NamedProgramLocalParameters4fvEXT(uint program, uint target, uint index, int count, float* prms)
    {
        GlNative.glNamedProgramLocalParameters4fvEXT(program, target, index, count, prms);
    }

    public static void NamedProgramLocalParameterI4iEXT(uint program, uint target, uint index, int x, int y, int z, int w)
    {
        GlNative.glNamedProgramLocalParameterI4iEXT(program, target, index, x, y, z, w);
    }

    public static void NamedProgramLocalParameterI4ivEXT(uint program, uint target, uint index, int* prms)
    {
        GlNative.glNamedProgramLocalParameterI4ivEXT(program, target, index, prms);
    }

    public static void NamedProgramLocalParametersI4ivEXT(uint program, uint target, uint index, int count, int* prms)
    {
        GlNative.glNamedProgramLocalParametersI4ivEXT(program, target, index, count, prms);
    }

    public static void NamedProgramLocalParameterI4uiEXT(uint program, uint target, uint index, uint x, uint y, uint z, uint w)
    {
        GlNative.glNamedProgramLocalParameterI4uiEXT(program, target, index, x, y, z, w);
    }

    public static void NamedProgramLocalParameterI4uivEXT(uint program, uint target, uint index, uint* prms)
    {
        GlNative.glNamedProgramLocalParameterI4uivEXT(program, target, index, prms);
    }

    public static void NamedProgramLocalParametersI4uivEXT(uint program, uint target, uint index, int count, uint* prms)
    {
        GlNative.glNamedProgramLocalParametersI4uivEXT(program, target, index, count, prms);
    }

    public static void GetNamedProgramLocalParameterIivEXT(uint program, uint target, uint index, int* prms)
    {
        GlNative.glGetNamedProgramLocalParameterIivEXT(program, target, index, prms);
    }

    public static void GetNamedProgramLocalParameterIuivEXT(uint program, uint target, uint index, uint* prms)
    {
        GlNative.glGetNamedProgramLocalParameterIuivEXT(program, target, index, prms);
    }

    public static void EnableClientStateiEXT(uint array, uint index)
    {
        GlNative.glEnableClientStateiEXT(array, index);
    }

    public static void DisableClientStateiEXT(uint array, uint index)
    {
        GlNative.glDisableClientStateiEXT(array, index);
    }

    public static void GetFloati_vEXT(uint pname, uint index, float* prms)
    {
        GlNative.glGetFloati_vEXT(pname, index, prms);
    }

    public static void GetDoublei_vEXT(uint pname, uint index, double* prms)
    {
        GlNative.glGetDoublei_vEXT(pname, index, prms);
    }

    public static void GetPointeri_vEXT(uint pname, uint index, void** prms)
    {
        GlNative.glGetPointeri_vEXT(pname, index, prms);
    }

    public static void NamedProgramStringEXT(uint program, uint target, uint format, int len, void* str)
    {
        GlNative.glNamedProgramStringEXT(program, target, format, len, str);
    }

    public static void NamedProgramLocalParameter4dEXT(uint program, uint target, uint index, double x, double y, double z, double w)
    {
        GlNative.glNamedProgramLocalParameter4dEXT(program, target, index, x, y, z, w);
    }

    public static void NamedProgramLocalParameter4dvEXT(uint program, uint target, uint index, double* prms)
    {
        GlNative.glNamedProgramLocalParameter4dvEXT(program, target, index, prms);
    }

    public static void NamedProgramLocalParameter4fEXT(uint program, uint target, uint index, float x, float y, float z, float w)
    {
        GlNative.glNamedProgramLocalParameter4fEXT(program, target, index, x, y, z, w);
    }

    public static void NamedProgramLocalParameter4fvEXT(uint program, uint target, uint index, float* prms)
    {
        GlNative.glNamedProgramLocalParameter4fvEXT(program, target, index, prms);
    }

    public static void GetNamedProgramLocalParameterdvEXT(uint program, uint target, uint index, double* prms)
    {
        GlNative.glGetNamedProgramLocalParameterdvEXT(program, target, index, prms);
    }

    public static void GetNamedProgramLocalParameterfvEXT(uint program, uint target, uint index, float* prms)
    {
        GlNative.glGetNamedProgramLocalParameterfvEXT(program, target, index, prms);
    }

    public static void GetNamedProgramivEXT(uint program, uint target, uint pname, int* prms)
    {
        GlNative.glGetNamedProgramivEXT(program, target, pname, prms);
    }

    public static void GetNamedProgramStringEXT(uint program, uint target, uint pname, void* str)
    {
        GlNative.glGetNamedProgramStringEXT(program, target, pname, str);
    }

    public static void NamedRenderbufferStorageEXT(uint renderbuffer, uint internalformat, int width, int height)
    {
        GlNative.glNamedRenderbufferStorageEXT(renderbuffer, internalformat, width, height);
    }

    public static void GetNamedRenderbufferParameterivEXT(uint renderbuffer, uint pname, int* prms)
    {
        GlNative.glGetNamedRenderbufferParameterivEXT(renderbuffer, pname, prms);
    }

    public static void NamedRenderbufferStorageMultisampleEXT(uint renderbuffer, int samples, uint internalformat, int width, int height)
    {
        GlNative.glNamedRenderbufferStorageMultisampleEXT(renderbuffer, samples, internalformat, width, height);
    }

    public static void NamedRenderbufferStorageMultisampleCoverageEXT(uint renderbuffer, int coverageSamples, int colorSamples, uint internalformat, int width, int height)
    {
        GlNative.glNamedRenderbufferStorageMultisampleCoverageEXT(renderbuffer, coverageSamples, colorSamples, internalformat, width, height);
    }

    public static uint CheckNamedFramebufferStatusEXT(uint framebuffer, uint target)
    {
        return GlNative.glCheckNamedFramebufferStatusEXT(framebuffer, target);
    }

    public static void NamedFramebufferTexture1DEXT(uint framebuffer, uint attachment, uint textarget, uint texture, int level)
    {
        GlNative.glNamedFramebufferTexture1DEXT(framebuffer, attachment, textarget, texture, level);
    }

    public static void NamedFramebufferTexture2DEXT(uint framebuffer, uint attachment, uint textarget, uint texture, int level)
    {
        GlNative.glNamedFramebufferTexture2DEXT(framebuffer, attachment, textarget, texture, level);
    }

    public static void NamedFramebufferTexture3DEXT(uint framebuffer, uint attachment, uint textarget, uint texture, int level, int zoffset)
    {
        GlNative.glNamedFramebufferTexture3DEXT(framebuffer, attachment, textarget, texture, level, zoffset);
    }

    public static void NamedFramebufferRenderbufferEXT(uint framebuffer, uint attachment, uint renderbuffertarget, uint renderbuffer)
    {
        GlNative.glNamedFramebufferRenderbufferEXT(framebuffer, attachment, renderbuffertarget, renderbuffer);
    }

    public static void GetNamedFramebufferAttachmentParameterivEXT(uint framebuffer, uint attachment, uint pname, int* prms)
    {
        GlNative.glGetNamedFramebufferAttachmentParameterivEXT(framebuffer, attachment, pname, prms);
    }

    public static void GenerateTextureMipmapEXT(uint texture, uint target)
    {
        GlNative.glGenerateTextureMipmapEXT(texture, target);
    }

    public static void GenerateMultiTexMipmapEXT(uint texunit, uint target)
    {
        GlNative.glGenerateMultiTexMipmapEXT(texunit, target);
    }

    public static void FramebufferDrawBufferEXT(uint framebuffer, uint mode)
    {
        GlNative.glFramebufferDrawBufferEXT(framebuffer, mode);
    }

    public static void FramebufferDrawBuffersEXT(uint framebuffer, int n, uint* bufs)
    {
        GlNative.glFramebufferDrawBuffersEXT(framebuffer, n, bufs);
    }

    public static void FramebufferReadBufferEXT(uint framebuffer, uint mode)
    {
        GlNative.glFramebufferReadBufferEXT(framebuffer, mode);
    }

    public static void GetFramebufferParameterivEXT(uint framebuffer, uint pname, int* prms)
    {
        GlNative.glGetFramebufferParameterivEXT(framebuffer, pname, prms);
    }

    public static void NamedCopyBufferSubDataEXT(uint readBuffer, uint writeBuffer, nint readOffset, nint writeOffset, nint size)
    {
        GlNative.glNamedCopyBufferSubDataEXT(readBuffer, writeBuffer, readOffset, writeOffset, size);
    }

    public static void NamedFramebufferTextureEXT(uint framebuffer, uint attachment, uint texture, int level)
    {
        GlNative.glNamedFramebufferTextureEXT(framebuffer, attachment, texture, level);
    }

    public static void NamedFramebufferTextureLayerEXT(uint framebuffer, uint attachment, uint texture, int level, int layer)
    {
        GlNative.glNamedFramebufferTextureLayerEXT(framebuffer, attachment, texture, level, layer);
    }

    public static void NamedFramebufferTextureFaceEXT(uint framebuffer, uint attachment, uint texture, int level, uint face)
    {
        GlNative.glNamedFramebufferTextureFaceEXT(framebuffer, attachment, texture, level, face);
    }

    public static void TextureRenderbufferEXT(uint texture, uint target, uint renderbuffer)
    {
        GlNative.glTextureRenderbufferEXT(texture, target, renderbuffer);
    }

    public static void MultiTexRenderbufferEXT(uint texunit, uint target, uint renderbuffer)
    {
        GlNative.glMultiTexRenderbufferEXT(texunit, target, renderbuffer);
    }

    public static void VertexArrayVertexOffsetEXT(uint vaobj, uint buffer, int size, uint type, int stride, nint offset)
    {
        GlNative.glVertexArrayVertexOffsetEXT(vaobj, buffer, size, type, stride, offset);
    }

    public static void VertexArrayColorOffsetEXT(uint vaobj, uint buffer, int size, uint type, int stride, nint offset)
    {
        GlNative.glVertexArrayColorOffsetEXT(vaobj, buffer, size, type, stride, offset);
    }

    public static void VertexArrayEdgeFlagOffsetEXT(uint vaobj, uint buffer, int stride, nint offset)
    {
        GlNative.glVertexArrayEdgeFlagOffsetEXT(vaobj, buffer, stride, offset);
    }

    public static void VertexArrayIndexOffsetEXT(uint vaobj, uint buffer, uint type, int stride, nint offset)
    {
        GlNative.glVertexArrayIndexOffsetEXT(vaobj, buffer, type, stride, offset);
    }

    public static void VertexArrayNormalOffsetEXT(uint vaobj, uint buffer, uint type, int stride, nint offset)
    {
        GlNative.glVertexArrayNormalOffsetEXT(vaobj, buffer, type, stride, offset);
    }

    public static void VertexArrayTexCoordOffsetEXT(uint vaobj, uint buffer, int size, uint type, int stride, nint offset)
    {
        GlNative.glVertexArrayTexCoordOffsetEXT(vaobj, buffer, size, type, stride, offset);
    }

    public static void VertexArrayMultiTexCoordOffsetEXT(uint vaobj, uint buffer, uint texunit, int size, uint type, int stride, nint offset)
    {
        GlNative.glVertexArrayMultiTexCoordOffsetEXT(vaobj, buffer, texunit, size, type, stride, offset);
    }

    public static void VertexArrayFogCoordOffsetEXT(uint vaobj, uint buffer, uint type, int stride, nint offset)
    {
        GlNative.glVertexArrayFogCoordOffsetEXT(vaobj, buffer, type, stride, offset);
    }

    public static void VertexArraySecondaryColorOffsetEXT(uint vaobj, uint buffer, int size, uint type, int stride, nint offset)
    {
        GlNative.glVertexArraySecondaryColorOffsetEXT(vaobj, buffer, size, type, stride, offset);
    }

    public static void VertexArrayVertexAttribOffsetEXT(uint vaobj, uint buffer, uint index, int size, uint type, int normalized, int stride, nint offset)
    {
        GlNative.glVertexArrayVertexAttribOffsetEXT(vaobj, buffer, index, size, type, normalized, stride, offset);
    }

    public static void VertexArrayVertexAttribIOffsetEXT(uint vaobj, uint buffer, uint index, int size, uint type, int stride, nint offset)
    {
        GlNative.glVertexArrayVertexAttribIOffsetEXT(vaobj, buffer, index, size, type, stride, offset);
    }

    public static void EnableVertexArrayEXT(uint vaobj, uint array)
    {
        GlNative.glEnableVertexArrayEXT(vaobj, array);
    }

    public static void DisableVertexArrayEXT(uint vaobj, uint array)
    {
        GlNative.glDisableVertexArrayEXT(vaobj, array);
    }

    public static void EnableVertexArrayAttribEXT(uint vaobj, uint index)
    {
        GlNative.glEnableVertexArrayAttribEXT(vaobj, index);
    }

    public static void DisableVertexArrayAttribEXT(uint vaobj, uint index)
    {
        GlNative.glDisableVertexArrayAttribEXT(vaobj, index);
    }

    public static void GetVertexArrayIntegervEXT(uint vaobj, uint pname, int* param)
    {
        GlNative.glGetVertexArrayIntegervEXT(vaobj, pname, param);
    }

    public static void GetVertexArrayPointervEXT(uint vaobj, uint pname, void** param)
    {
        GlNative.glGetVertexArrayPointervEXT(vaobj, pname, param);
    }

    public static void GetVertexArrayIntegeri_vEXT(uint vaobj, uint index, uint pname, int* param)
    {
        GlNative.glGetVertexArrayIntegeri_vEXT(vaobj, index, pname, param);
    }

    public static void GetVertexArrayPointeri_vEXT(uint vaobj, uint index, uint pname, void** param)
    {
        GlNative.glGetVertexArrayPointeri_vEXT(vaobj, index, pname, param);
    }

    public static void FlushMappedNamedBufferRangeEXT(uint buffer, nint offset, nint length)
    {
        GlNative.glFlushMappedNamedBufferRangeEXT(buffer, offset, length);
    }

    public static void NamedBufferStorageEXT(uint buffer, nint size, void* data, uint flags)
    {
        GlNative.glNamedBufferStorageEXT(buffer, size, data, flags);
    }

    public static void ClearNamedBufferDataEXT(uint buffer, uint internalformat, uint format, uint type, void* data)
    {
        GlNative.glClearNamedBufferDataEXT(buffer, internalformat, format, type, data);
    }

    public static void ClearNamedBufferSubDataEXT(uint buffer, uint internalformat, nint offset, nint size, uint format, uint type, void* data)
    {
        GlNative.glClearNamedBufferSubDataEXT(buffer, internalformat, offset, size, format, type, data);
    }

    public static void NamedFramebufferParameteriEXT(uint framebuffer, uint pname, int param)
    {
        GlNative.glNamedFramebufferParameteriEXT(framebuffer, pname, param);
    }

    public static void GetNamedFramebufferParameterivEXT(uint framebuffer, uint pname, int* prms)
    {
        GlNative.glGetNamedFramebufferParameterivEXT(framebuffer, pname, prms);
    }

    public static void ProgramUniform1dEXT(uint program, int location, double x)
    {
        GlNative.glProgramUniform1dEXT(program, location, x);
    }

    public static void ProgramUniform2dEXT(uint program, int location, double x, double y)
    {
        GlNative.glProgramUniform2dEXT(program, location, x, y);
    }

    public static void ProgramUniform3dEXT(uint program, int location, double x, double y, double z)
    {
        GlNative.glProgramUniform3dEXT(program, location, x, y, z);
    }

    public static void ProgramUniform4dEXT(uint program, int location, double x, double y, double z, double w)
    {
        GlNative.glProgramUniform4dEXT(program, location, x, y, z, w);
    }

    public static void ProgramUniform1dvEXT(uint program, int location, int count, double* value)
    {
        GlNative.glProgramUniform1dvEXT(program, location, count, value);
    }

    public static void ProgramUniform2dvEXT(uint program, int location, int count, double* value)
    {
        GlNative.glProgramUniform2dvEXT(program, location, count, value);
    }

    public static void ProgramUniform3dvEXT(uint program, int location, int count, double* value)
    {
        GlNative.glProgramUniform3dvEXT(program, location, count, value);
    }

    public static void ProgramUniform4dvEXT(uint program, int location, int count, double* value)
    {
        GlNative.glProgramUniform4dvEXT(program, location, count, value);
    }

    public static void ProgramUniformMatrix2dvEXT(uint program, int location, int count, int transpose, double* value)
    {
        GlNative.glProgramUniformMatrix2dvEXT(program, location, count, transpose, value);
    }

    public static void ProgramUniformMatrix3dvEXT(uint program, int location, int count, int transpose, double* value)
    {
        GlNative.glProgramUniformMatrix3dvEXT(program, location, count, transpose, value);
    }

    public static void ProgramUniformMatrix4dvEXT(uint program, int location, int count, int transpose, double* value)
    {
        GlNative.glProgramUniformMatrix4dvEXT(program, location, count, transpose, value);
    }

    public static void ProgramUniformMatrix2x3dvEXT(uint program, int location, int count, int transpose, double* value)
    {
        GlNative.glProgramUniformMatrix2x3dvEXT(program, location, count, transpose, value);
    }

    public static void ProgramUniformMatrix2x4dvEXT(uint program, int location, int count, int transpose, double* value)
    {
        GlNative.glProgramUniformMatrix2x4dvEXT(program, location, count, transpose, value);
    }

    public static void ProgramUniformMatrix3x2dvEXT(uint program, int location, int count, int transpose, double* value)
    {
        GlNative.glProgramUniformMatrix3x2dvEXT(program, location, count, transpose, value);
    }

    public static void ProgramUniformMatrix3x4dvEXT(uint program, int location, int count, int transpose, double* value)
    {
        GlNative.glProgramUniformMatrix3x4dvEXT(program, location, count, transpose, value);
    }

    public static void ProgramUniformMatrix4x2dvEXT(uint program, int location, int count, int transpose, double* value)
    {
        GlNative.glProgramUniformMatrix4x2dvEXT(program, location, count, transpose, value);
    }

    public static void ProgramUniformMatrix4x3dvEXT(uint program, int location, int count, int transpose, double* value)
    {
        GlNative.glProgramUniformMatrix4x3dvEXT(program, location, count, transpose, value);
    }

    public static void TextureBufferRangeEXT(uint texture, uint target, uint internalformat, uint buffer, nint offset, nint size)
    {
        GlNative.glTextureBufferRangeEXT(texture, target, internalformat, buffer, offset, size);
    }

    public static void TextureStorage1DEXT(uint texture, uint target, int levels, uint internalformat, int width)
    {
        GlNative.glTextureStorage1DEXT(texture, target, levels, internalformat, width);
    }

    public static void TextureStorage2DEXT(uint texture, uint target, int levels, uint internalformat, int width, int height)
    {
        GlNative.glTextureStorage2DEXT(texture, target, levels, internalformat, width, height);
    }

    public static void TextureStorage3DEXT(uint texture, uint target, int levels, uint internalformat, int width, int height, int depth)
    {
        GlNative.glTextureStorage3DEXT(texture, target, levels, internalformat, width, height, depth);
    }

    public static void TextureStorage2DMultisampleEXT(uint texture, uint target, int samples, uint internalformat, int width, int height, int fixedsamplelocations)
    {
        GlNative.glTextureStorage2DMultisampleEXT(texture, target, samples, internalformat, width, height, fixedsamplelocations);
    }

    public static void TextureStorage3DMultisampleEXT(uint texture, uint target, int samples, uint internalformat, int width, int height, int depth, int fixedsamplelocations)
    {
        GlNative.glTextureStorage3DMultisampleEXT(texture, target, samples, internalformat, width, height, depth, fixedsamplelocations);
    }

    public static void VertexArrayBindVertexBufferEXT(uint vaobj, uint bindingindex, uint buffer, nint offset, int stride)
    {
        GlNative.glVertexArrayBindVertexBufferEXT(vaobj, bindingindex, buffer, offset, stride);
    }

    public static void VertexArrayVertexAttribFormatEXT(uint vaobj, uint attribindex, int size, uint type, int normalized, uint relativeoffset)
    {
        GlNative.glVertexArrayVertexAttribFormatEXT(vaobj, attribindex, size, type, normalized, relativeoffset);
    }

    public static void VertexArrayVertexAttribIFormatEXT(uint vaobj, uint attribindex, int size, uint type, uint relativeoffset)
    {
        GlNative.glVertexArrayVertexAttribIFormatEXT(vaobj, attribindex, size, type, relativeoffset);
    }

    public static void VertexArrayVertexAttribLFormatEXT(uint vaobj, uint attribindex, int size, uint type, uint relativeoffset)
    {
        GlNative.glVertexArrayVertexAttribLFormatEXT(vaobj, attribindex, size, type, relativeoffset);
    }

    public static void VertexArrayVertexAttribBindingEXT(uint vaobj, uint attribindex, uint bindingindex)
    {
        GlNative.glVertexArrayVertexAttribBindingEXT(vaobj, attribindex, bindingindex);
    }

    public static void VertexArrayVertexBindingDivisorEXT(uint vaobj, uint bindingindex, uint divisor)
    {
        GlNative.glVertexArrayVertexBindingDivisorEXT(vaobj, bindingindex, divisor);
    }

    public static void VertexArrayVertexAttribLOffsetEXT(uint vaobj, uint buffer, uint index, int size, uint type, int stride, nint offset)
    {
        GlNative.glVertexArrayVertexAttribLOffsetEXT(vaobj, buffer, index, size, type, stride, offset);
    }

    public static void TexturePageCommitmentEXT(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, int commit)
    {
        GlNative.glTexturePageCommitmentEXT(texture, level, xoffset, yoffset, zoffset, width, height, depth, commit);
    }

    public static void VertexArrayVertexAttribDivisorEXT(uint vaobj, uint index, uint divisor)
    {
        GlNative.glVertexArrayVertexAttribDivisorEXT(vaobj, index, divisor);
    }

    public static void DrawArraysInstancedEXT(uint mode, int start, int count, int primcount)
    {
        GlNative.glDrawArraysInstancedEXT(mode, start, count, primcount);
    }

    public static void DrawElementsInstancedEXT(uint mode, int count, uint type, void* indices, int primcount)
    {
        GlNative.glDrawElementsInstancedEXT(mode, count, type, indices, primcount);
    }

    public static void PolygonOffsetClampEXT(float factor, float units, float clamp)
    {
        GlNative.glPolygonOffsetClampEXT(factor, units, clamp);
    }

    public static void RasterSamplesEXT(uint samples, int fixedsamplelocations)
    {
        GlNative.glRasterSamplesEXT(samples, fixedsamplelocations);
    }

    public static void UseShaderProgramEXT(uint type, uint program)
    {
        GlNative.glUseShaderProgramEXT(type, program);
    }

    public static void ActiveProgramEXT(uint program)
    {
        GlNative.glActiveProgramEXT(program);
    }

    public static uint CreateShaderProgramEXT(uint type, byte* str)
    {
        return GlNative.glCreateShaderProgramEXT(type, str);
    }

    public static void FramebufferFetchBarrierEXT()
    {
        GlNative.glFramebufferFetchBarrierEXT();
    }

    public static void TexStorage1DEXT(uint target, int levels, uint internalformat, int width)
    {
        GlNative.glTexStorage1DEXT(target, levels, internalformat, width);
    }

    public static void TexStorage2DEXT(uint target, int levels, uint internalformat, int width, int height)
    {
        GlNative.glTexStorage2DEXT(target, levels, internalformat, width, height);
    }

    public static void TexStorage3DEXT(uint target, int levels, uint internalformat, int width, int height, int depth)
    {
        GlNative.glTexStorage3DEXT(target, levels, internalformat, width, height, depth);
    }

    public static void WindowRectanglesEXT(uint mode, int count, int* box)
    {
        GlNative.glWindowRectanglesEXT(mode, count, box);
    }

    public static void ApplyFramebufferAttachmentCMAAINTEL()
    {
        GlNative.glApplyFramebufferAttachmentCMAAINTEL();
    }

    public static void BeginPerfQueryINTEL(uint queryHandle)
    {
        GlNative.glBeginPerfQueryINTEL(queryHandle);
    }

    public static void CreatePerfQueryINTEL(uint queryId, uint* queryHandle)
    {
        GlNative.glCreatePerfQueryINTEL(queryId, queryHandle);
    }

    public static void DeletePerfQueryINTEL(uint queryHandle)
    {
        GlNative.glDeletePerfQueryINTEL(queryHandle);
    }

    public static void EndPerfQueryINTEL(uint queryHandle)
    {
        GlNative.glEndPerfQueryINTEL(queryHandle);
    }

    public static void GetFirstPerfQueryIdINTEL(uint* queryId)
    {
        GlNative.glGetFirstPerfQueryIdINTEL(queryId);
    }

    public static void GetNextPerfQueryIdINTEL(uint queryId, uint* nextQueryId)
    {
        GlNative.glGetNextPerfQueryIdINTEL(queryId, nextQueryId);
    }

    public static void GetPerfCounterInfoINTEL(uint queryId, uint counterId, uint counterNameLength, byte* counterName, uint counterDescLength, byte* counterDesc, uint* counterOffset, uint* counterDataSize, uint* counterTypeEnum, uint* counterDataTypeEnum, nint* rawCounterMaxValue)
    {
        GlNative.glGetPerfCounterInfoINTEL(queryId, counterId, counterNameLength, counterName, counterDescLength, counterDesc, counterOffset, counterDataSize, counterTypeEnum, counterDataTypeEnum, rawCounterMaxValue);
    }

    public static void GetPerfQueryDataINTEL(uint queryHandle, uint flags, int dataSize, void* data, uint* bytesWritten)
    {
        GlNative.glGetPerfQueryDataINTEL(queryHandle, flags, dataSize, data, bytesWritten);
    }

    public static void GetPerfQueryIdByNameINTEL(byte* queryName, uint* queryId)
    {
        GlNative.glGetPerfQueryIdByNameINTEL(queryName, queryId);
    }

    public static void GetPerfQueryInfoINTEL(uint queryId, uint queryNameLength, byte* queryName, uint* dataSize, uint* noCounters, uint* noInstances, uint* capsMask)
    {
        GlNative.glGetPerfQueryInfoINTEL(queryId, queryNameLength, queryName, dataSize, noCounters, noInstances, capsMask);
    }

    public static void FramebufferParameteriMESA(uint target, uint pname, int param)
    {
        GlNative.glFramebufferParameteriMESA(target, pname, param);
    }

    public static void GetFramebufferParameterivMESA(uint target, uint pname, int* prms)
    {
        GlNative.glGetFramebufferParameterivMESA(target, pname, prms);
    }

    public static void MultiDrawArraysIndirectBindlessNV(uint mode, void* indirect, int drawCount, int stride, int vertexBufferCount)
    {
        GlNative.glMultiDrawArraysIndirectBindlessNV(mode, indirect, drawCount, stride, vertexBufferCount);
    }

    public static void MultiDrawElementsIndirectBindlessNV(uint mode, uint type, void* indirect, int drawCount, int stride, int vertexBufferCount)
    {
        GlNative.glMultiDrawElementsIndirectBindlessNV(mode, type, indirect, drawCount, stride, vertexBufferCount);
    }

    public static void MultiDrawArraysIndirectBindlessCountNV(uint mode, void* indirect, int drawCount, int maxDrawCount, int stride, int vertexBufferCount)
    {
        GlNative.glMultiDrawArraysIndirectBindlessCountNV(mode, indirect, drawCount, maxDrawCount, stride, vertexBufferCount);
    }

    public static void MultiDrawElementsIndirectBindlessCountNV(uint mode, uint type, void* indirect, int drawCount, int maxDrawCount, int stride, int vertexBufferCount)
    {
        GlNative.glMultiDrawElementsIndirectBindlessCountNV(mode, type, indirect, drawCount, maxDrawCount, stride, vertexBufferCount);
    }

    public static nint GetTextureHandleNV(uint texture)
    {
        return GlNative.glGetTextureHandleNV(texture);
    }

    public static nint GetTextureSamplerHandleNV(uint texture, uint sampler)
    {
        return GlNative.glGetTextureSamplerHandleNV(texture, sampler);
    }

    public static void MakeTextureHandleResidentNV(nint handle)
    {
        GlNative.glMakeTextureHandleResidentNV(handle);
    }

    public static void MakeTextureHandleNonResidentNV(nint handle)
    {
        GlNative.glMakeTextureHandleNonResidentNV(handle);
    }

    public static nint GetImageHandleNV(uint texture, int level, int layered, int layer, uint format)
    {
        return GlNative.glGetImageHandleNV(texture, level, layered, layer, format);
    }

    public static void MakeImageHandleResidentNV(nint handle, uint access)
    {
        GlNative.glMakeImageHandleResidentNV(handle, access);
    }

    public static void MakeImageHandleNonResidentNV(nint handle)
    {
        GlNative.glMakeImageHandleNonResidentNV(handle);
    }

    public static void UniformHandleui64NV(int location, nint value)
    {
        GlNative.glUniformHandleui64NV(location, value);
    }

    public static void UniformHandleui64vNV(int location, int count, nint* value)
    {
        GlNative.glUniformHandleui64vNV(location, count, value);
    }

    public static void ProgramUniformHandleui64NV(uint program, int location, nint value)
    {
        GlNative.glProgramUniformHandleui64NV(program, location, value);
    }

    public static void ProgramUniformHandleui64vNV(uint program, int location, int count, nint* values)
    {
        GlNative.glProgramUniformHandleui64vNV(program, location, count, values);
    }

    public static int IsTextureHandleResidentNV(nint handle)
    {
        return GlNative.glIsTextureHandleResidentNV(handle);
    }

    public static int IsImageHandleResidentNV(nint handle)
    {
        return GlNative.glIsImageHandleResidentNV(handle);
    }

    public static void BlendParameteriNV(uint pname, int value)
    {
        GlNative.glBlendParameteriNV(pname, value);
    }

    public static void BlendBarrierNV()
    {
        GlNative.glBlendBarrierNV();
    }

    public static void ViewportPositionWScaleNV(uint index, float xcoeff, float ycoeff)
    {
        GlNative.glViewportPositionWScaleNV(index, xcoeff, ycoeff);
    }

    public static void CreateStatesNV(int n, uint* states)
    {
        GlNative.glCreateStatesNV(n, states);
    }

    public static void DeleteStatesNV(int n, uint* states)
    {
        GlNative.glDeleteStatesNV(n, states);
    }

    public static int IsStateNV(uint state)
    {
        return GlNative.glIsStateNV(state);
    }

    public static void StateCaptureNV(uint state, uint mode)
    {
        GlNative.glStateCaptureNV(state, mode);
    }

    public static uint GetCommandHeaderNV(uint tokenID, uint size)
    {
        return GlNative.glGetCommandHeaderNV(tokenID, size);
    }

    public static nint GetStageIndexNV(uint shadertype)
    {
        return GlNative.glGetStageIndexNV(shadertype);
    }

    public static void DrawCommandsNV(uint primitiveMode, uint buffer, nint* indirects, int* sizes, uint count)
    {
        GlNative.glDrawCommandsNV(primitiveMode, buffer, indirects, sizes, count);
    }

    public static void DrawCommandsAddressNV(uint primitiveMode, nint* indirects, int* sizes, uint count)
    {
        GlNative.glDrawCommandsAddressNV(primitiveMode, indirects, sizes, count);
    }

    public static void DrawCommandsStatesNV(uint buffer, nint* indirects, int* sizes, uint* states, uint* fbos, uint count)
    {
        GlNative.glDrawCommandsStatesNV(buffer, indirects, sizes, states, fbos, count);
    }

    public static void DrawCommandsStatesAddressNV(nint* indirects, int* sizes, uint* states, uint* fbos, uint count)
    {
        GlNative.glDrawCommandsStatesAddressNV(indirects, sizes, states, fbos, count);
    }

    public static void CreateCommandListsNV(int n, uint* lists)
    {
        GlNative.glCreateCommandListsNV(n, lists);
    }

    public static void DeleteCommandListsNV(int n, uint* lists)
    {
        GlNative.glDeleteCommandListsNV(n, lists);
    }

    public static int IsCommandListNV(uint list)
    {
        return GlNative.glIsCommandListNV(list);
    }

    public static void ListDrawCommandsStatesClientNV(uint list, uint segment, void** indirects, int* sizes, uint* states, uint* fbos, uint count)
    {
        GlNative.glListDrawCommandsStatesClientNV(list, segment, indirects, sizes, states, fbos, count);
    }

    public static void CommandListSegmentsNV(uint list, uint segments)
    {
        GlNative.glCommandListSegmentsNV(list, segments);
    }

    public static void CompileCommandListNV(uint list)
    {
        GlNative.glCompileCommandListNV(list);
    }

    public static void CallCommandListNV(uint list)
    {
        GlNative.glCallCommandListNV(list);
    }

    public static void BeginConditionalRenderNV(uint id, uint mode)
    {
        GlNative.glBeginConditionalRenderNV(id, mode);
    }

    public static void EndConditionalRenderNV()
    {
        GlNative.glEndConditionalRenderNV();
    }

    public static void SubpixelPrecisionBiasNV(uint xbits, uint ybits)
    {
        GlNative.glSubpixelPrecisionBiasNV(xbits, ybits);
    }

    public static void ConservativeRasterParameterfNV(uint pname, float value)
    {
        GlNative.glConservativeRasterParameterfNV(pname, value);
    }

    public static void ConservativeRasterParameteriNV(uint pname, int param)
    {
        GlNative.glConservativeRasterParameteriNV(pname, param);
    }

    public static void DepthRangedNV(double zNear, double zFar)
    {
        GlNative.glDepthRangedNV(zNear, zFar);
    }

    public static void ClearDepthdNV(double depth)
    {
        GlNative.glClearDepthdNV(depth);
    }

    public static void DepthBoundsdNV(double zmin, double zmax)
    {
        GlNative.glDepthBoundsdNV(zmin, zmax);
    }

    public static void DrawVkImageNV(nint vkImage, uint sampler, float x0, float y0, float x1, float y1, float z, float s0, float t0, float s1, float t1)
    {
        GlNative.glDrawVkImageNV(vkImage, sampler, x0, y0, x1, y1, z, s0, t0, s1, t1);
    }

    public static nint GetVkProcAddrNV(byte* name)
    {
        return GlNative.glGetVkProcAddrNV(name);
    }

    public static void WaitVkSemaphoreNV(nint vkSemaphore)
    {
        GlNative.glWaitVkSemaphoreNV(vkSemaphore);
    }

    public static void SignalVkSemaphoreNV(nint vkSemaphore)
    {
        GlNative.glSignalVkSemaphoreNV(vkSemaphore);
    }

    public static void SignalVkFenceNV(nint vkFence)
    {
        GlNative.glSignalVkFenceNV(vkFence);
    }

    public static void FragmentCoverageColorNV(uint color)
    {
        GlNative.glFragmentCoverageColorNV(color);
    }

    public static void CoverageModulationTableNV(int n, float* v)
    {
        GlNative.glCoverageModulationTableNV(n, v);
    }

    public static void GetCoverageModulationTableNV(int bufSize, float* v)
    {
        GlNative.glGetCoverageModulationTableNV(bufSize, v);
    }

    public static void CoverageModulationNV(uint components)
    {
        GlNative.glCoverageModulationNV(components);
    }

    public static void RenderbufferStorageMultisampleCoverageNV(uint target, int coverageSamples, int colorSamples, uint internalformat, int width, int height)
    {
        GlNative.glRenderbufferStorageMultisampleCoverageNV(target, coverageSamples, colorSamples, internalformat, width, height);
    }

    public static void Uniform1i64NV(int location, nint x)
    {
        GlNative.glUniform1i64NV(location, x);
    }

    public static void Uniform2i64NV(int location, nint x, nint y)
    {
        GlNative.glUniform2i64NV(location, x, y);
    }

    public static void Uniform3i64NV(int location, nint x, nint y, nint z)
    {
        GlNative.glUniform3i64NV(location, x, y, z);
    }

    public static void Uniform4i64NV(int location, nint x, nint y, nint z, nint w)
    {
        GlNative.glUniform4i64NV(location, x, y, z, w);
    }

    public static void Uniform1i64vNV(int location, int count, nint* value)
    {
        GlNative.glUniform1i64vNV(location, count, value);
    }

    public static void Uniform2i64vNV(int location, int count, nint* value)
    {
        GlNative.glUniform2i64vNV(location, count, value);
    }

    public static void Uniform3i64vNV(int location, int count, nint* value)
    {
        GlNative.glUniform3i64vNV(location, count, value);
    }

    public static void Uniform4i64vNV(int location, int count, nint* value)
    {
        GlNative.glUniform4i64vNV(location, count, value);
    }

    public static void Uniform1ui64NV(int location, nint x)
    {
        GlNative.glUniform1ui64NV(location, x);
    }

    public static void Uniform2ui64NV(int location, nint x, nint y)
    {
        GlNative.glUniform2ui64NV(location, x, y);
    }

    public static void Uniform3ui64NV(int location, nint x, nint y, nint z)
    {
        GlNative.glUniform3ui64NV(location, x, y, z);
    }

    public static void Uniform4ui64NV(int location, nint x, nint y, nint z, nint w)
    {
        GlNative.glUniform4ui64NV(location, x, y, z, w);
    }

    public static void Uniform1ui64vNV(int location, int count, nint* value)
    {
        GlNative.glUniform1ui64vNV(location, count, value);
    }

    public static void Uniform2ui64vNV(int location, int count, nint* value)
    {
        GlNative.glUniform2ui64vNV(location, count, value);
    }

    public static void Uniform3ui64vNV(int location, int count, nint* value)
    {
        GlNative.glUniform3ui64vNV(location, count, value);
    }

    public static void Uniform4ui64vNV(int location, int count, nint* value)
    {
        GlNative.glUniform4ui64vNV(location, count, value);
    }

    public static void GetUniformi64vNV(uint program, int location, nint* prms)
    {
        GlNative.glGetUniformi64vNV(program, location, prms);
    }

    public static void ProgramUniform1i64NV(uint program, int location, nint x)
    {
        GlNative.glProgramUniform1i64NV(program, location, x);
    }

    public static void ProgramUniform2i64NV(uint program, int location, nint x, nint y)
    {
        GlNative.glProgramUniform2i64NV(program, location, x, y);
    }

    public static void ProgramUniform3i64NV(uint program, int location, nint x, nint y, nint z)
    {
        GlNative.glProgramUniform3i64NV(program, location, x, y, z);
    }

    public static void ProgramUniform4i64NV(uint program, int location, nint x, nint y, nint z, nint w)
    {
        GlNative.glProgramUniform4i64NV(program, location, x, y, z, w);
    }

    public static void ProgramUniform1i64vNV(uint program, int location, int count, nint* value)
    {
        GlNative.glProgramUniform1i64vNV(program, location, count, value);
    }

    public static void ProgramUniform2i64vNV(uint program, int location, int count, nint* value)
    {
        GlNative.glProgramUniform2i64vNV(program, location, count, value);
    }

    public static void ProgramUniform3i64vNV(uint program, int location, int count, nint* value)
    {
        GlNative.glProgramUniform3i64vNV(program, location, count, value);
    }

    public static void ProgramUniform4i64vNV(uint program, int location, int count, nint* value)
    {
        GlNative.glProgramUniform4i64vNV(program, location, count, value);
    }

    public static void ProgramUniform1ui64NV(uint program, int location, nint x)
    {
        GlNative.glProgramUniform1ui64NV(program, location, x);
    }

    public static void ProgramUniform2ui64NV(uint program, int location, nint x, nint y)
    {
        GlNative.glProgramUniform2ui64NV(program, location, x, y);
    }

    public static void ProgramUniform3ui64NV(uint program, int location, nint x, nint y, nint z)
    {
        GlNative.glProgramUniform3ui64NV(program, location, x, y, z);
    }

    public static void ProgramUniform4ui64NV(uint program, int location, nint x, nint y, nint z, nint w)
    {
        GlNative.glProgramUniform4ui64NV(program, location, x, y, z, w);
    }

    public static void ProgramUniform1ui64vNV(uint program, int location, int count, nint* value)
    {
        GlNative.glProgramUniform1ui64vNV(program, location, count, value);
    }

    public static void ProgramUniform2ui64vNV(uint program, int location, int count, nint* value)
    {
        GlNative.glProgramUniform2ui64vNV(program, location, count, value);
    }

    public static void ProgramUniform3ui64vNV(uint program, int location, int count, nint* value)
    {
        GlNative.glProgramUniform3ui64vNV(program, location, count, value);
    }

    public static void ProgramUniform4ui64vNV(uint program, int location, int count, nint* value)
    {
        GlNative.glProgramUniform4ui64vNV(program, location, count, value);
    }

    public static void GetInternalformatSampleivNV(uint target, uint internalformat, int samples, uint pname, int count, int* prms)
    {
        GlNative.glGetInternalformatSampleivNV(target, internalformat, samples, pname, count, prms);
    }

    public static void GetMemoryObjectDetachedResourcesuivNV(uint memory, uint pname, int first, int count, uint* prms)
    {
        GlNative.glGetMemoryObjectDetachedResourcesuivNV(memory, pname, first, count, prms);
    }

    public static void ResetMemoryObjectParameterNV(uint memory, uint pname)
    {
        GlNative.glResetMemoryObjectParameterNV(memory, pname);
    }

    public static void TexAttachMemoryNV(uint target, uint memory, nint offset)
    {
        GlNative.glTexAttachMemoryNV(target, memory, offset);
    }

    public static void BufferAttachMemoryNV(uint target, uint memory, nint offset)
    {
        GlNative.glBufferAttachMemoryNV(target, memory, offset);
    }

    public static void TextureAttachMemoryNV(uint texture, uint memory, nint offset)
    {
        GlNative.glTextureAttachMemoryNV(texture, memory, offset);
    }

    public static void NamedBufferAttachMemoryNV(uint buffer, uint memory, nint offset)
    {
        GlNative.glNamedBufferAttachMemoryNV(buffer, memory, offset);
    }

    public static void BufferPageCommitmentMemNV(uint target, nint offset, nint size, uint memory, nint memOffset, int commit)
    {
        GlNative.glBufferPageCommitmentMemNV(target, offset, size, memory, memOffset, commit);
    }

    public static void TexPageCommitmentMemNV(uint target, int layer, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, uint memory, nint offset, int commit)
    {
        GlNative.glTexPageCommitmentMemNV(target, layer, level, xoffset, yoffset, zoffset, width, height, depth, memory, offset, commit);
    }

    public static void NamedBufferPageCommitmentMemNV(uint buffer, nint offset, nint size, uint memory, nint memOffset, int commit)
    {
        GlNative.glNamedBufferPageCommitmentMemNV(buffer, offset, size, memory, memOffset, commit);
    }

    public static void TexturePageCommitmentMemNV(uint texture, int layer, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, uint memory, nint offset, int commit)
    {
        GlNative.glTexturePageCommitmentMemNV(texture, layer, level, xoffset, yoffset, zoffset, width, height, depth, memory, offset, commit);
    }

    public static void DrawMeshTasksNV(uint first, uint count)
    {
        GlNative.glDrawMeshTasksNV(first, count);
    }

    public static void DrawMeshTasksIndirectNV(nint indirect)
    {
        GlNative.glDrawMeshTasksIndirectNV(indirect);
    }

    public static void MultiDrawMeshTasksIndirectNV(nint indirect, int drawcount, int stride)
    {
        GlNative.glMultiDrawMeshTasksIndirectNV(indirect, drawcount, stride);
    }

    public static void MultiDrawMeshTasksIndirectCountNV(nint indirect, nint drawcount, int maxdrawcount, int stride)
    {
        GlNative.glMultiDrawMeshTasksIndirectCountNV(indirect, drawcount, maxdrawcount, stride);
    }

    public static uint GenPathsNV(int range)
    {
        return GlNative.glGenPathsNV(range);
    }

    public static void DeletePathsNV(uint path, int range)
    {
        GlNative.glDeletePathsNV(path, range);
    }

    public static int IsPathNV(uint path)
    {
        return GlNative.glIsPathNV(path);
    }

    public static void PathCommandsNV(uint path, int numCommands, nint* commands, int numCoords, uint coordType, void* coords)
    {
        GlNative.glPathCommandsNV(path, numCommands, commands, numCoords, coordType, coords);
    }

    public static void PathCoordsNV(uint path, int numCoords, uint coordType, void* coords)
    {
        GlNative.glPathCoordsNV(path, numCoords, coordType, coords);
    }

    public static void PathSubCommandsNV(uint path, int commandStart, int commandsToDelete, int numCommands, nint* commands, int numCoords, uint coordType, void* coords)
    {
        GlNative.glPathSubCommandsNV(path, commandStart, commandsToDelete, numCommands, commands, numCoords, coordType, coords);
    }

    public static void PathSubCoordsNV(uint path, int coordStart, int numCoords, uint coordType, void* coords)
    {
        GlNative.glPathSubCoordsNV(path, coordStart, numCoords, coordType, coords);
    }

    public static void PathStringNV(uint path, uint format, int length, void* pathString)
    {
        GlNative.glPathStringNV(path, format, length, pathString);
    }

    public static void PathGlyphsNV(uint firstPathName, uint fontTarget, void* fontName, uint fontStyle, int numGlyphs, uint type, void* charcodes, uint handleMissingGlyphs, uint pathParameterTemplate, float emScale)
    {
        GlNative.glPathGlyphsNV(firstPathName, fontTarget, fontName, fontStyle, numGlyphs, type, charcodes, handleMissingGlyphs, pathParameterTemplate, emScale);
    }

    public static void PathGlyphRangeNV(uint firstPathName, uint fontTarget, void* fontName, uint fontStyle, uint firstGlyph, int numGlyphs, uint handleMissingGlyphs, uint pathParameterTemplate, float emScale)
    {
        GlNative.glPathGlyphRangeNV(firstPathName, fontTarget, fontName, fontStyle, firstGlyph, numGlyphs, handleMissingGlyphs, pathParameterTemplate, emScale);
    }

    public static void WeightPathsNV(uint resultPath, int numPaths, uint* paths, float* weights)
    {
        GlNative.glWeightPathsNV(resultPath, numPaths, paths, weights);
    }

    public static void CopyPathNV(uint resultPath, uint srcPath)
    {
        GlNative.glCopyPathNV(resultPath, srcPath);
    }

    public static void InterpolatePathsNV(uint resultPath, uint pathA, uint pathB, float weight)
    {
        GlNative.glInterpolatePathsNV(resultPath, pathA, pathB, weight);
    }

    public static void TransformPathNV(uint resultPath, uint srcPath, uint transformType, float* transformValues)
    {
        GlNative.glTransformPathNV(resultPath, srcPath, transformType, transformValues);
    }

    public static void PathParameterivNV(uint path, uint pname, int* value)
    {
        GlNative.glPathParameterivNV(path, pname, value);
    }

    public static void PathParameteriNV(uint path, uint pname, int value)
    {
        GlNative.glPathParameteriNV(path, pname, value);
    }

    public static void PathParameterfvNV(uint path, uint pname, float* value)
    {
        GlNative.glPathParameterfvNV(path, pname, value);
    }

    public static void PathParameterfNV(uint path, uint pname, float value)
    {
        GlNative.glPathParameterfNV(path, pname, value);
    }

    public static void PathDashArrayNV(uint path, int dashCount, float* dashArray)
    {
        GlNative.glPathDashArrayNV(path, dashCount, dashArray);
    }

    public static void PathStencilFuncNV(uint func, int refer, uint mask)
    {
        GlNative.glPathStencilFuncNV(func, refer, mask);
    }

    public static void PathStencilDepthOffsetNV(float factor, float units)
    {
        GlNative.glPathStencilDepthOffsetNV(factor, units);
    }

    public static void StencilFillPathNV(uint path, uint fillMode, uint mask)
    {
        GlNative.glStencilFillPathNV(path, fillMode, mask);
    }

    public static void StencilStrokePathNV(uint path, int reference, uint mask)
    {
        GlNative.glStencilStrokePathNV(path, reference, mask);
    }

    public static void StencilFillPathInstancedNV(int numPaths, uint pathNameType, void* paths, uint pathBase, uint fillMode, uint mask, uint transformType, float* transformValues)
    {
        GlNative.glStencilFillPathInstancedNV(numPaths, pathNameType, paths, pathBase, fillMode, mask, transformType, transformValues);
    }

    public static void StencilStrokePathInstancedNV(int numPaths, uint pathNameType, void* paths, uint pathBase, int reference, uint mask, uint transformType, float* transformValues)
    {
        GlNative.glStencilStrokePathInstancedNV(numPaths, pathNameType, paths, pathBase, reference, mask, transformType, transformValues);
    }

    public static void PathCoverDepthFuncNV(uint func)
    {
        GlNative.glPathCoverDepthFuncNV(func);
    }

    public static void CoverFillPathNV(uint path, uint coverMode)
    {
        GlNative.glCoverFillPathNV(path, coverMode);
    }

    public static void CoverStrokePathNV(uint path, uint coverMode)
    {
        GlNative.glCoverStrokePathNV(path, coverMode);
    }

    public static void CoverFillPathInstancedNV(int numPaths, uint pathNameType, void* paths, uint pathBase, uint coverMode, uint transformType, float* transformValues)
    {
        GlNative.glCoverFillPathInstancedNV(numPaths, pathNameType, paths, pathBase, coverMode, transformType, transformValues);
    }

    public static void CoverStrokePathInstancedNV(int numPaths, uint pathNameType, void* paths, uint pathBase, uint coverMode, uint transformType, float* transformValues)
    {
        GlNative.glCoverStrokePathInstancedNV(numPaths, pathNameType, paths, pathBase, coverMode, transformType, transformValues);
    }

    public static void GetPathParameterivNV(uint path, uint pname, int* value)
    {
        GlNative.glGetPathParameterivNV(path, pname, value);
    }

    public static void GetPathParameterfvNV(uint path, uint pname, float* value)
    {
        GlNative.glGetPathParameterfvNV(path, pname, value);
    }

    public static void GetPathCommandsNV(uint path, nint* commands)
    {
        GlNative.glGetPathCommandsNV(path, commands);
    }

    public static void GetPathCoordsNV(uint path, float* coords)
    {
        GlNative.glGetPathCoordsNV(path, coords);
    }

    public static void GetPathDashArrayNV(uint path, float* dashArray)
    {
        GlNative.glGetPathDashArrayNV(path, dashArray);
    }

    public static void GetPathMetricsNV(uint metricQueryMask, int numPaths, uint pathNameType, void* paths, uint pathBase, int stride, float* metrics)
    {
        GlNative.glGetPathMetricsNV(metricQueryMask, numPaths, pathNameType, paths, pathBase, stride, metrics);
    }

    public static void GetPathMetricRangeNV(uint metricQueryMask, uint firstPathName, int numPaths, int stride, float* metrics)
    {
        GlNative.glGetPathMetricRangeNV(metricQueryMask, firstPathName, numPaths, stride, metrics);
    }

    public static void GetPathSpacingNV(uint pathListMode, int numPaths, uint pathNameType, void* paths, uint pathBase, float advanceScale, float kerningScale, uint transformType, float* returnedSpacing)
    {
        GlNative.glGetPathSpacingNV(pathListMode, numPaths, pathNameType, paths, pathBase, advanceScale, kerningScale, transformType, returnedSpacing);
    }

    public static int IsPointInFillPathNV(uint path, uint mask, float x, float y)
    {
        return GlNative.glIsPointInFillPathNV(path, mask, x, y);
    }

    public static int IsPointInStrokePathNV(uint path, float x, float y)
    {
        return GlNative.glIsPointInStrokePathNV(path, x, y);
    }

    public static float GetPathLengthNV(uint path, int startSegment, int numSegments)
    {
        return GlNative.glGetPathLengthNV(path, startSegment, numSegments);
    }

    public static int PointAlongPathNV(uint path, int startSegment, int numSegments, float distance, float* x, float* y, float* tangentX, float* tangentY)
    {
        return GlNative.glPointAlongPathNV(path, startSegment, numSegments, distance, x, y, tangentX, tangentY);
    }

    public static void MatrixLoad3x2fNV(uint matrixMode, float* m)
    {
        GlNative.glMatrixLoad3x2fNV(matrixMode, m);
    }

    public static void MatrixLoad3x3fNV(uint matrixMode, float* m)
    {
        GlNative.glMatrixLoad3x3fNV(matrixMode, m);
    }

    public static void MatrixLoadTranspose3x3fNV(uint matrixMode, float* m)
    {
        GlNative.glMatrixLoadTranspose3x3fNV(matrixMode, m);
    }

    public static void MatrixMult3x2fNV(uint matrixMode, float* m)
    {
        GlNative.glMatrixMult3x2fNV(matrixMode, m);
    }

    public static void MatrixMult3x3fNV(uint matrixMode, float* m)
    {
        GlNative.glMatrixMult3x3fNV(matrixMode, m);
    }

    public static void MatrixMultTranspose3x3fNV(uint matrixMode, float* m)
    {
        GlNative.glMatrixMultTranspose3x3fNV(matrixMode, m);
    }

    public static void StencilThenCoverFillPathNV(uint path, uint fillMode, uint mask, uint coverMode)
    {
        GlNative.glStencilThenCoverFillPathNV(path, fillMode, mask, coverMode);
    }

    public static void StencilThenCoverStrokePathNV(uint path, int reference, uint mask, uint coverMode)
    {
        GlNative.glStencilThenCoverStrokePathNV(path, reference, mask, coverMode);
    }

    public static void StencilThenCoverFillPathInstancedNV(int numPaths, uint pathNameType, void* paths, uint pathBase, uint fillMode, uint mask, uint coverMode, uint transformType, float* transformValues)
    {
        GlNative.glStencilThenCoverFillPathInstancedNV(numPaths, pathNameType, paths, pathBase, fillMode, mask, coverMode, transformType, transformValues);
    }

    public static void StencilThenCoverStrokePathInstancedNV(int numPaths, uint pathNameType, void* paths, uint pathBase, int reference, uint mask, uint coverMode, uint transformType, float* transformValues)
    {
        GlNative.glStencilThenCoverStrokePathInstancedNV(numPaths, pathNameType, paths, pathBase, reference, mask, coverMode, transformType, transformValues);
    }

    public static uint PathGlyphIndexRangeNV(uint fontTarget, void* fontName, uint fontStyle, uint pathParameterTemplate, float emScale, uint* baseAndCount)
    {
        return GlNative.glPathGlyphIndexRangeNV(fontTarget, fontName, fontStyle, pathParameterTemplate, emScale, baseAndCount);
    }

    public static uint PathGlyphIndexArrayNV(uint firstPathName, uint fontTarget, void* fontName, uint fontStyle, uint firstGlyphIndex, int numGlyphs, uint pathParameterTemplate, float emScale)
    {
        return GlNative.glPathGlyphIndexArrayNV(firstPathName, fontTarget, fontName, fontStyle, firstGlyphIndex, numGlyphs, pathParameterTemplate, emScale);
    }

    public static uint PathMemoryGlyphIndexArrayNV(uint firstPathName, uint fontTarget, nint fontSize, void* fontData, int faceIndex, uint firstGlyphIndex, int numGlyphs, uint pathParameterTemplate, float emScale)
    {
        return GlNative.glPathMemoryGlyphIndexArrayNV(firstPathName, fontTarget, fontSize, fontData, faceIndex, firstGlyphIndex, numGlyphs, pathParameterTemplate, emScale);
    }

    public static void ProgramPathFragmentInputGenNV(uint program, int location, uint genMode, int components, float* coeffs)
    {
        GlNative.glProgramPathFragmentInputGenNV(program, location, genMode, components, coeffs);
    }

    public static void GetProgramResourcefvNV(uint program, uint programInterface, uint index, int propCount, uint* props, int count, int* length, float* prms)
    {
        GlNative.glGetProgramResourcefvNV(program, programInterface, index, propCount, props, count, length, prms);
    }

    public static void FramebufferSampleLocationsfvNV(uint target, uint start, int count, float* v)
    {
        GlNative.glFramebufferSampleLocationsfvNV(target, start, count, v);
    }

    public static void NamedFramebufferSampleLocationsfvNV(uint framebuffer, uint start, int count, float* v)
    {
        GlNative.glNamedFramebufferSampleLocationsfvNV(framebuffer, start, count, v);
    }

    public static void ResolveDepthValuesNV()
    {
        GlNative.glResolveDepthValuesNV();
    }

    public static void ScissorExclusiveNV(int x, int y, int width, int height)
    {
        GlNative.glScissorExclusiveNV(x, y, width, height);
    }

    public static void ScissorExclusiveArrayvNV(uint first, int count, int* v)
    {
        GlNative.glScissorExclusiveArrayvNV(first, count, v);
    }

    public static void MakeBufferResidentNV(uint target, uint access)
    {
        GlNative.glMakeBufferResidentNV(target, access);
    }

    public static void MakeBufferNonResidentNV(uint target)
    {
        GlNative.glMakeBufferNonResidentNV(target);
    }

    public static int IsBufferResidentNV(uint target)
    {
        return GlNative.glIsBufferResidentNV(target);
    }

    public static void MakeNamedBufferResidentNV(uint buffer, uint access)
    {
        GlNative.glMakeNamedBufferResidentNV(buffer, access);
    }

    public static void MakeNamedBufferNonResidentNV(uint buffer)
    {
        GlNative.glMakeNamedBufferNonResidentNV(buffer);
    }

    public static int IsNamedBufferResidentNV(uint buffer)
    {
        return GlNative.glIsNamedBufferResidentNV(buffer);
    }

    public static void GetBufferParameterui64vNV(uint target, uint pname, nint* prms)
    {
        GlNative.glGetBufferParameterui64vNV(target, pname, prms);
    }

    public static void GetNamedBufferParameterui64vNV(uint buffer, uint pname, nint* prms)
    {
        GlNative.glGetNamedBufferParameterui64vNV(buffer, pname, prms);
    }

    public static void GetIntegerui64vNV(uint value, nint* result)
    {
        GlNative.glGetIntegerui64vNV(value, result);
    }

    public static void Uniformui64NV(int location, nint value)
    {
        GlNative.glUniformui64NV(location, value);
    }

    public static void Uniformui64vNV(int location, int count, nint* value)
    {
        GlNative.glUniformui64vNV(location, count, value);
    }

    public static void GetUniformui64vNV(uint program, int location, nint* prms)
    {
        GlNative.glGetUniformui64vNV(program, location, prms);
    }

    public static void ProgramUniformui64NV(uint program, int location, nint value)
    {
        GlNative.glProgramUniformui64NV(program, location, value);
    }

    public static void ProgramUniformui64vNV(uint program, int location, int count, nint* value)
    {
        GlNative.glProgramUniformui64vNV(program, location, count, value);
    }

    public static void BindShadingRateImageNV(uint texture)
    {
        GlNative.glBindShadingRateImageNV(texture);
    }

    public static void GetShadingRateImagePaletteNV(uint viewport, uint entry, uint* rate)
    {
        GlNative.glGetShadingRateImagePaletteNV(viewport, entry, rate);
    }

    public static void GetShadingRateSampleLocationivNV(uint rate, uint samples, uint index, int* location)
    {
        GlNative.glGetShadingRateSampleLocationivNV(rate, samples, index, location);
    }

    public static void ShadingRateImageBarrierNV(int synchronize)
    {
        GlNative.glShadingRateImageBarrierNV(synchronize);
    }

    public static void ShadingRateImagePaletteNV(uint viewport, uint first, int count, uint* rates)
    {
        GlNative.glShadingRateImagePaletteNV(viewport, first, count, rates);
    }

    public static void ShadingRateSampleOrderNV(uint order)
    {
        GlNative.glShadingRateSampleOrderNV(order);
    }

    public static void ShadingRateSampleOrderCustomNV(uint rate, uint samples, int* locations)
    {
        GlNative.glShadingRateSampleOrderCustomNV(rate, samples, locations);
    }

    public static void TextureBarrierNV()
    {
        GlNative.glTextureBarrierNV();
    }

    public static void VertexAttribL1i64NV(uint index, nint x)
    {
        GlNative.glVertexAttribL1i64NV(index, x);
    }

    public static void VertexAttribL2i64NV(uint index, nint x, nint y)
    {
        GlNative.glVertexAttribL2i64NV(index, x, y);
    }

    public static void VertexAttribL3i64NV(uint index, nint x, nint y, nint z)
    {
        GlNative.glVertexAttribL3i64NV(index, x, y, z);
    }

    public static void VertexAttribL4i64NV(uint index, nint x, nint y, nint z, nint w)
    {
        GlNative.glVertexAttribL4i64NV(index, x, y, z, w);
    }

    public static void VertexAttribL1i64vNV(uint index, nint* v)
    {
        GlNative.glVertexAttribL1i64vNV(index, v);
    }

    public static void VertexAttribL2i64vNV(uint index, nint* v)
    {
        GlNative.glVertexAttribL2i64vNV(index, v);
    }

    public static void VertexAttribL3i64vNV(uint index, nint* v)
    {
        GlNative.glVertexAttribL3i64vNV(index, v);
    }

    public static void VertexAttribL4i64vNV(uint index, nint* v)
    {
        GlNative.glVertexAttribL4i64vNV(index, v);
    }

    public static void VertexAttribL1ui64NV(uint index, nint x)
    {
        GlNative.glVertexAttribL1ui64NV(index, x);
    }

    public static void VertexAttribL2ui64NV(uint index, nint x, nint y)
    {
        GlNative.glVertexAttribL2ui64NV(index, x, y);
    }

    public static void VertexAttribL3ui64NV(uint index, nint x, nint y, nint z)
    {
        GlNative.glVertexAttribL3ui64NV(index, x, y, z);
    }

    public static void VertexAttribL4ui64NV(uint index, nint x, nint y, nint z, nint w)
    {
        GlNative.glVertexAttribL4ui64NV(index, x, y, z, w);
    }

    public static void VertexAttribL1ui64vNV(uint index, nint* v)
    {
        GlNative.glVertexAttribL1ui64vNV(index, v);
    }

    public static void VertexAttribL2ui64vNV(uint index, nint* v)
    {
        GlNative.glVertexAttribL2ui64vNV(index, v);
    }

    public static void VertexAttribL3ui64vNV(uint index, nint* v)
    {
        GlNative.glVertexAttribL3ui64vNV(index, v);
    }

    public static void VertexAttribL4ui64vNV(uint index, nint* v)
    {
        GlNative.glVertexAttribL4ui64vNV(index, v);
    }

    public static void GetVertexAttribLi64vNV(uint index, uint pname, nint* prms)
    {
        GlNative.glGetVertexAttribLi64vNV(index, pname, prms);
    }

    public static void GetVertexAttribLui64vNV(uint index, uint pname, nint* prms)
    {
        GlNative.glGetVertexAttribLui64vNV(index, pname, prms);
    }

    public static void VertexAttribLFormatNV(uint index, int size, uint type, int stride)
    {
        GlNative.glVertexAttribLFormatNV(index, size, type, stride);
    }

    public static void BufferAddressRangeNV(uint pname, uint index, nint address, nint length)
    {
        GlNative.glBufferAddressRangeNV(pname, index, address, length);
    }

    public static void VertexFormatNV(int size, uint type, int stride)
    {
        GlNative.glVertexFormatNV(size, type, stride);
    }

    public static void NormalFormatNV(uint type, int stride)
    {
        GlNative.glNormalFormatNV(type, stride);
    }

    public static void ColorFormatNV(int size, uint type, int stride)
    {
        GlNative.glColorFormatNV(size, type, stride);
    }

    public static void IndexFormatNV(uint type, int stride)
    {
        GlNative.glIndexFormatNV(type, stride);
    }

    public static void TexCoordFormatNV(int size, uint type, int stride)
    {
        GlNative.glTexCoordFormatNV(size, type, stride);
    }

    public static void EdgeFlagFormatNV(int stride)
    {
        GlNative.glEdgeFlagFormatNV(stride);
    }

    public static void SecondaryColorFormatNV(int size, uint type, int stride)
    {
        GlNative.glSecondaryColorFormatNV(size, type, stride);
    }

    public static void FogCoordFormatNV(uint type, int stride)
    {
        GlNative.glFogCoordFormatNV(type, stride);
    }

    public static void VertexAttribFormatNV(uint index, int size, uint type, int normalized, int stride)
    {
        GlNative.glVertexAttribFormatNV(index, size, type, normalized, stride);
    }

    public static void VertexAttribIFormatNV(uint index, int size, uint type, int stride)
    {
        GlNative.glVertexAttribIFormatNV(index, size, type, stride);
    }

    public static void GetIntegerui64i_vNV(uint value, uint index, nint* result)
    {
        GlNative.glGetIntegerui64i_vNV(value, index, result);
    }

    public static void ViewportSwizzleNV(uint index, uint swizzlex, uint swizzley, uint swizzlez, uint swizzlew)
    {
        GlNative.glViewportSwizzleNV(index, swizzlex, swizzley, swizzlez, swizzlew);
    }

    public static void FramebufferTextureMultiviewOVR(uint target, uint attachment, uint texture, int level, int baseViewIndex, int numViews)
    {
        GlNative.glFramebufferTextureMultiviewOVR(target, attachment, texture, level, baseViewIndex, numViews);
    }

    public static void NamedFramebufferTextureMultiviewOVR(uint framebuffer, uint attachment, uint texture, int level, int baseViewIndex, int numViews)
    {
        GlNative.glNamedFramebufferTextureMultiviewOVR(framebuffer, attachment, texture, level, baseViewIndex, numViews);
    }
}