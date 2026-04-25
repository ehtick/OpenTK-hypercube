using System.Text;
using Hypercube.Core.Graphics.Utilities.Extensions;
using Silk.NET.GLFW;
using Silk.NET.OpenGL;

// Silk redefine for reduce type/namespace collisions
using SilkWindowHandle = Silk.NET.GLFW.WindowHandle;

namespace Hypercube.Core.Windowing.Api.Realisations.Glfw;

public sealed unsafe partial class GlfwWindowingApi
{
    private string DiagnosticGenerateWindowReport(SilkWindowHandle* window)
    {
        var builder = new StringBuilder();
        DiagnosticWriteWindowReport(window, builder);
        return builder.ToString();
    }
    
    private void DiagnosticWriteWindowReport(SilkWindowHandle* window, StringBuilder builder)
    {
        if (window is null)
        {
            builder.AppendLine("--- General ---");
            builder.AppendLine($"Pointer: 0x{nint.Zero:x8} (nullptr)");
            return;
        }

        var context = _glfw.GetCurrentContext();
        var glContext = context is not null && GetProcAddress("glGetString") != nint.Zero;
        
        builder.AppendLine("--- General ---");
        builder.AppendLine($"Pointer: 0x{(nint) window:x8}");
        
        builder.AppendLine("--- Attributes ---");
        builder.AppendLine($"Focused: {_glfw.GetWindowAttrib(window, WindowAttributeGetter.Focused)}");
        builder.AppendLine($"Visible: {_glfw.GetWindowAttrib(window, WindowAttributeGetter.Visible)}");
        builder.AppendLine($"Resizable: {_glfw.GetWindowAttrib(window, WindowAttributeGetter.Resizable)}");
        builder.AppendLine($"Maximized: {_glfw.GetWindowAttrib(window, WindowAttributeGetter.Maximized)}");
        builder.AppendLine($"Decorated: {_glfw.GetWindowAttrib(window, WindowAttributeGetter.Decorated)}");
        builder.AppendLine($"AutoIconify: {_glfw.GetWindowAttrib(window, WindowAttributeGetter.AutoIconify)}");
        builder.AppendLine($"Floating: {_glfw.GetWindowAttrib(window, WindowAttributeGetter.Floating)}");
        builder.AppendLine($"FocusOnShow: {_glfw.GetWindowAttrib(window, WindowAttributeGetter.FocusOnShow)}");
        builder.AppendLine($"Hovered: {_glfw.GetWindowAttrib(window, WindowAttributeGetter.Hovered)}");
        builder.AppendLine($"Iconified: {_glfw.GetWindowAttrib(window, WindowAttributeGetter.Iconified)}");
        builder.AppendLine($"TransparentFramebuffer: {_glfw.GetWindowAttrib(window, WindowAttributeGetter.TransparentFramebuffer)}");
        
        builder.AppendLine("--- Context ---");
        builder.AppendLine($"Current: 0x{(nint) context:x8}");
        builder.AppendLine($"OpenGL type: {glContext}");
        
        if (glContext)
        {
            var gl = GL.GetApi(GetProcAddress);
            
            builder.AppendLine("--- Open GL ---");
            builder.AppendLine($"Vendor: {gl.GetStringExt(StringName.Vendor)}");
            builder.AppendLine($"Renderer: {gl.GetStringExt(StringName.Renderer)}");
            builder.AppendLine($"Version: {gl.GetStringExt(StringName.Version)}");
            builder.AppendLine($"Shading Language: {gl.GetStringExt(StringName.ShadingLanguageVersion)}");
            builder.AppendLine($"Extensions: {gl.GetStringExt(StringName.Extensions)}");
        }
        
        builder.AppendLine("--- Data ---");
        _glfw.GetWindowSize(window, out var width, out var height);
        builder.AppendLine($"Window Size: {width}x{height}");

        _glfw.GetWindowPos(window, out var positionX, out var positionY);
        builder.Append($"Window Position: {positionX},{positionY}");
    }
}